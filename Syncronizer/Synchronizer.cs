using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;

namespace iSyncA
{
    public enum Option : int 
    {
        IgnoreFileSizeDiffer = 1<<0, // 忽略檔案不同大小的檔案
        IgnoreExtraFiles     = 1<<1  // 不刪除多餘的檔案
    }

    public class Synchronizer
    {
        public PlaylistData[] Playlist { get; private set; }
        public Logger Logger { get; private set; }

        private string iTunesLibPath;    // iTunes音樂資料庫路徑
        private string localMusicFolder; // 實體音樂檔案存放的資料夾
        private string sdFolder;         // SD卡存放音樂的根目錄
        private Dictionary<string, FileInfo> iTunesMusicIndex; // iTunes資料庫 <Track ID, 實體檔案>
        private Dictionary<string, FileInfo> index_Local;      // iTunes資料庫 <去除根目錄後的路徑, 實體檔案>
        private Dictionary<string, FileInfo> index_SD;         // SD卡資料夾索引 <去除根目錄後的路徑, 實體檔案>
        private List<SyncDir> syncList; // 要同步的檔案清單
        private List<SyncDir> delList;  // 要刪除的檔案清單
        private bool traverseFailed; // 建立資料夾索引時使用 (避免出錯後還繼續跑)


        public Synchronizer(string iTunesLibPath, string localMusicFolder, string sdFolder)
        {
            // 設定參數與初始化資料
            this.iTunesLibPath = iTunesLibPath;
            this.localMusicFolder = localMusicFolder;
            this.sdFolder = sdFolder;

            this.iTunesMusicIndex = new Dictionary<string, FileInfo>();
            this.index_Local = new Dictionary<string, FileInfo>();
            this.index_SD = new Dictionary<string, FileInfo>();

            this.traverseFailed = false;

            SyncFile.Count = 0;
        }


        #region 比對檔案 
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 按下"開始比對"按鈕
        public SyncDir[] Compare(BackgroundWorker worker)
        {
            worker.ReportProgress(0, "初始化 ...");
            this.Logger = new Logger();
            // 新增執行緒
            Thread thread_LoadDatabase = new Thread(() => LoadDatabase(this.iTunesLibPath));
            Thread thread_Traverse = new Thread(() => Traverse(new DirectoryInfo(this.sdFolder)));
            // 開始建立資料索引
            thread_LoadDatabase.Start();
            thread_Traverse.Start();
            worker.ReportProgress(33, "建立資料索引中 ...");
            while (thread_LoadDatabase.IsAlive || thread_Traverse.IsAlive);
            // 開始比對檔案並回傳結果
            worker.ReportProgress(66, "進行比對 ...");
            return BuildSyncList(worker);
        }

        // 比較iTunes資料庫和SD卡資料夾索引的差別
        private SyncDir[] BuildSyncList(BackgroundWorker worker)
        {
            const double BASE_PROGRESS = 66;
            double total = this.index_Local.Count + this.index_SD.Count; // 分母
            double currentProgress = 0.0; // 分子

            // 建立需要同步的清單
            Dictionary<string, SyncDir> tempSyncList = new Dictionary<string, SyncDir>();
            foreach (KeyValuePair<string, FileInfo> entry in this.index_Local) {
                string path = entry.Key;
                FileInfo file = entry.Value;
                DirectoryInfo dir = file.Directory;
                if (this.index_SD.ContainsKey(path)) { // SD卡內有該檔案
                    if (this.index_SD[path].Length == file.Length)
                        continue;
                    else { // 兩個檔案的大小不一樣
                        if (!tempSyncList.ContainsKey(dir.FullName))
                            tempSyncList.Add(dir.FullName, new SyncDir(dir));
                        tempSyncList[dir.FullName].FileList.Add(new SyncFile(file, SyncDataType.FileSizeDiffer, path));
                    }
                } else { // 檔案不存在於sd卡
                    if (!tempSyncList.ContainsKey(dir.FullName))
                        tempSyncList.Add(dir.FullName, new SyncDir(dir));
                    tempSyncList[dir.FullName].FileList.Add(new SyncFile(file, SyncDataType.NotExist, path));
                }
                worker.ReportProgress((int)(BASE_PROGRESS + (100.0-BASE_PROGRESS)*(++currentProgress / total)), "進行比對中 ...");
            }
            this.syncList = tempSyncList.Values.ToList();

            // 建立需要被刪除的檔案清單
            Dictionary<string, SyncDir> tempDelList = new Dictionary<string, SyncDir>();
            foreach (KeyValuePair<string, FileInfo> entry in this.index_SD) {
                if (entry.Value.Extension.Equals(".m3u"))
                    continue;
                if (!this.index_Local.ContainsKey(entry.Key)) {
                    DirectoryInfo dir = entry.Value.Directory;
                    if (!tempDelList.ContainsKey(dir.FullName))
                        tempDelList.Add(dir.FullName, new SyncDir(dir));
                    tempDelList[dir.FullName].FileList.Add(new SyncFile(entry.Value, SyncDataType.Extra, null));
                }
                worker.ReportProgress((int)(BASE_PROGRESS + (100.0-BASE_PROGRESS)*(++currentProgress / total)), "進行比對中 ...");
            }
            this.delList = tempDelList.Values.ToList();

            List<SyncDir> result = new List<SyncDir>();
            result.AddRange(syncList);
            result.AddRange(delList);
            return result.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 建立資料索引
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region 讀取iTunes Music Library.xml
        private void LoadDatabase(string path)
        {
            try {
                StreamReader reader = new StreamReader(path);
                while (reader.Peek() > 0) {
                    string line = reader.ReadLine().Trim();
                    // 開始讀取所有Tracks資料，直到碰到此層的</dict>
                    if (line.Equals("<key>Tracks</key>")) {
                        while (!(line = reader.ReadLine().Trim()).Equals("</dict>")) {
                            // 逐一讀取每筆Track資料，直到碰到此層的</dict>
                            if (Regex.IsMatch(line, @"<key>\d+</key>")) {
                                StringBuilder track = new StringBuilder();
                                while (!(line = reader.ReadLine().Trim()).Equals("</dict>"))
                                    track.Append(line);
                                Match match = Regex.Match(track.ToString(), @".*<key>Track ID</key><integer>(\d+)</integer>.*<key>Location</key><string>(.*)</string>.*");
                                if (!match.Success) continue; // 有可能iTunes資料庫不完整 (例如缺少Location資料)
                                FileInfo file = new FileInfo(Uri.UnescapeDataString(match.Groups[2].Value.Replace("file://localhost/", "").Replace("&#38;", "&")));
                                this.iTunesMusicIndex.Add(match.Groups[1].Value, file);
                                this.index_Local.Add(file.FullName.Substring((this.localMusicFolder=="") ? file.FullName.IndexOf(@"\") : this.localMusicFolder.Length), file);
                            }
                        }
                    // 開始讀取所有Playlist資料
                    // TODO: 未處理同名播放清單(不支援) & 空播放清單的狀況(不會同步) & KEY不存在(會直接拋出例外)
                    } else if (line.Equals("<key>Playlists</key>")) {
                        Dictionary<string, PlaylistData> tempPlaylist = new Dictionary<string, PlaylistData>();
                        while (reader.Peek() > 0) {
                            line = reader.ReadLine().Trim();
                            // 逐一讀取每筆Playlist資料，直到碰到每筆Playlist的</dict>
                            if (line.Contains("<key>Name</key><string>")) {
                                Match match = Regex.Match(line, @".*<key>Name</key><string>(.*)</string>.*");
                                string name = match.Groups[1].Value;
                                while (!(line = reader.ReadLine().Trim()).Equals("</dict>")) {
                                    // 忽略iTunes內建的資料庫
                                    if (line.Contains("<key>Master</key><true/>") || line.Contains("<key>Distinguished Kind</key>")) {
                                        while (!(line = reader.ReadLine().Trim()).Equals("</dict>")) {
                                            if (line.Equals("<array>"))
                                                while (!(line = reader.ReadLine().Trim()).Equals("</array>"));
                                        }
                                        break; // 讀取下一筆Playlist資料
                                    }
                                    // 讀取使用者自訂的播放清單
                                    if (line.Equals("<array>")) {
                                        while (!(line = reader.ReadLine().Trim()).Equals("</array>")) { // 可能會讀到"<dict>"或是"</array>"
                                            // 讀取Track ID
                                            match = Regex.Match(reader.ReadLine(), @".*<key>Track ID</key><integer>(\d+)</integer>.*");
                                            if (!tempPlaylist.ContainsKey(name))
                                                tempPlaylist.Add(name, new PlaylistData(name));
                                            tempPlaylist[name].FileList.Add(this.iTunesMusicIndex[match.Groups[1].Value]);
                                            reader.ReadLine(); // 去除"</dict>"
                                        }
                                    }
                                }
                            }
                        }
                        this.Playlist = tempPlaylist.Values.ToArray();
                    }
                }
                reader.Close();
            } catch (Exception ex) {
                this.Logger.Log(new ExceptionData(ex, "讀取iTunes音樂資料庫時出現錯誤。"));
            }
        }
        #endregion


        // 遞迴的搜尋dir下的所有檔案，並建立索引
        private void Traverse(DirectoryInfo dir)
        {
            if (this.traverseFailed)
                return;
            try { 
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                    Traverse(subDir);
                foreach (FileInfo file in dir.GetFiles())
                    this.index_SD.Add(file.FullName.Substring(this.sdFolder.Length), file);
            } catch (Exception ex) {
                this.Logger.Log(new ExceptionData(ex, "建立SD卡資料索引時出現錯誤。請確定你有適當的權限檢視該資料夾內的所有檔案。"));
                this.traverseFailed = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 同步檔案 (按下"開始同步"按鈕)
        public void Sync(int option, string androidRoot, BackgroundWorker worker)
        {
            double total = SyncFile.Count;
            double progress = 0.0;
            this.Logger = new Logger();
            
            // 把本地端檔案複製到SD卡上
            foreach (SyncDir syncDir in this.syncList) {
                foreach (SyncFile syncFile in syncDir.FileList) {
                    try { 
                        // 選擇性忽略不同大小的檔案
                        if (((option&(int)Option.IgnoreFileSizeDiffer)==((int)Option.IgnoreFileSizeDiffer)) && 
                             (syncFile.SyncType==(int)SyncDataType.FileSizeDiffer)) {
                            continue;
                        }
                        FileInfo file = syncFile.File;
                        if (!file.Exists)
                            this.Logger.Log(new ExceptionData(new Exception(), String.Format("檔案不存在: {0}", file.FullName)));
                        else {
                            string targetPath = this.sdFolder + syncFile.SyncPath;
                            Directory.CreateDirectory(targetPath);
                            File.Copy(file.FullName, targetPath+file.Name, true);
                        }
                    } catch (Exception ex) {
                        this.Logger.Log(new ExceptionData(ex, String.Format("同步檔案時出現錯誤。檔案名稱: {0}", syncFile.File.FullName)));
                    }
                    worker.ReportProgress((int)((++progress/total)*100.0), new String[] {"同步檔案到SD卡中 ...", syncFile.File.Name});
                }
            }

            // 把SD卡上多餘的檔案刪除
            if ((option&(int)Option.IgnoreExtraFiles) != ((int)Option.IgnoreExtraFiles)) {
                try { 
                    foreach (SyncDir syncDir in this.delList) {
                        // 刪除檔案
                        foreach (SyncFile syncFile in syncDir.FileList) { 
                            File.Delete(syncFile.File.FullName);
                            worker.ReportProgress((int)((++progress/total)*100.0), new String[] {"刪除SD卡多餘的檔案中 ...", syncFile.File.Name});
                        }
                        // 刪除空的資料夾
                        if (!syncDir.Directory.EnumerateFileSystemInfos().Any())
                            Directory.Delete(syncDir.Directory.FullName, true); 
                    }
                } catch (Exception ex) {
                    this.Logger.Log(new ExceptionData(ex, "刪除SD卡檔案時出現錯誤"));
                }
            }
            
            // 建立播放清單
            string path = this.sdFolder + @"\.playlist\";
            try { 
                Directory.CreateDirectory(path);
                foreach (PlaylistData data in this.Playlist) {
                    StreamWriter writer = new StreamWriter(String.Format("{0}{1}.m3u", path, data.Name));
                    foreach (FileInfo file in data.FileList) {
                        string musicPath = androidRoot + file.FullName.Substring((this.localMusicFolder=="") ? file.FullName.IndexOf(@"\") : this.localMusicFolder.Length).Replace(@"\", "/");
                        writer.Write(musicPath);
                        writer.WriteLine();
                    }
                    writer.Close();
                }
            } catch (Exception ex) {
                this.Logger.Log(new ExceptionData(ex, String.Format("建立播放清單時出現錯誤。路徑: {0}", path))); 
            }
        }
        #endregion


    }
}
