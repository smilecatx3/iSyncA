using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace iSyncA
{
    partial class iSyncAForm : Form
    {
        private Synchronizer sync;
        private SyncDir[] listBoxItems_SyncDir;

        private string androidMusicFolder = "/storage/sdcard1";
        private int caretIndex = 0; // textBox_AndroidMusicRoot的游標位置
        private bool isCompared = false;

        //TODO: 加上說明 (本地資料夾只支援iTunes把所有音樂放在同一層目錄)
        //TODO: 支援同步非音樂檔
        //TODO: 支援選擇性同步

        #region 設定路徑
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 選擇iTunes資料庫檔案
        private void textBox_iTunesLibrary_Click(object sender, EventArgs e)
        {
            this.ActiveControl = label_iTunesLibrary; // 隱藏游標
            if (openFileDialog_iTunesLib.ShowDialog() == DialogResult.OK) {
                textBox_iTunesLibrary.Text = openFileDialog_iTunesLib.FileName;

            }
        }

        // 設定存放音樂實體檔案的根目錄
        private void textBox_localMusicFolder_Click(object sender, EventArgs e)
        {
            this.ActiveControl = label_iTunesLibrary; // 隱藏游標
            if (folderBrowserDialog_LocalMusicFolder.ShowDialog() == DialogResult.OK)
                textBox_LocalMusicFolder.Text = folderBrowserDialog_LocalMusicFolder.SelectedPath;
        }

        // 設定SD卡存放音樂的根目錄
        private void textBox_sdFolder_Click(object sender, EventArgs e)
        {
            this.ActiveControl = label_iTunesLibrary; // 隱藏游標
            if (folderBrowserDialog_SdFolder.ShowDialog() == DialogResult.OK)
                textBox_SdFolder.Text = folderBrowserDialog_SdFolder.SelectedPath;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 清除路徑
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void label_iTunesLibrary_DoubleClick(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string msg = String.Format("確定要清除{0}的路徑嗎?", label.Text);
            if (MessageBox.Show(msg, "清除路徑", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                this.pathLabelIndex[label].Clear();
        }

        private void label_LocalMusicFolder_DoubleClick(object sender, EventArgs e)
        {
            label_iTunesLibrary_DoubleClick(sender, e);
        }

        private void label_SdFolder_DoubleClick(object sender, EventArgs e)
        {
            label_iTunesLibrary_DoubleClick(sender, e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 路徑有更改時的事件
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PathChanged()
        {
            button_compare.Enabled = textBox_AndroidMusicRoot.Enabled = (textBox_iTunesLibrary.TextLength * textBox_SdFolder.TextLength > 0);
            this.isCompared = button_sync.Enabled = false;
            statusLabel_message.Text = "";
            progressBar1.Value = 0;
        }

        private void textBox_iTunesLibrary_TextChanged(object sender, EventArgs e)
        {
            PathChanged();
            openFileDialog_iTunesLib.FileName = textBox_iTunesLibrary.Text;

            if (!this.initializing && textBox_iTunesLibrary.TextLength>0) {
                DirectoryInfo dir = new DirectoryInfo(textBox_iTunesLibrary.Text).Parent.Parent;
                if (dir!=null && dir.Exists)
                    textBox_LocalMusicFolder.Text = dir.FullName;
            }
        }

        private void textBox_LocalMusicFolder_TextChanged(object sender, EventArgs e)
        {
            PathChanged();
            folderBrowserDialog_LocalMusicFolder.SelectedPath = textBox_LocalMusicFolder.Text;
        }

        private void textBox_SdFolder_TextChanged(object sender, EventArgs e)
        {
            PathChanged();
            string sdFolder = textBox_SdFolder.Text;
            string androidMusicRoot = textBox_AndroidMusicRoot.Text;
            if (sdFolder.Length * androidMusicRoot.Length > 0) {
                string dirName = sdFolder.Substring(sdFolder.IndexOf(@"\")).Replace(@"\", "/");
                if (this.caretIndex > 0)
                    textBox_AndroidMusicRoot.Text = androidMusicRoot.Remove(this.caretIndex) + dirName;
                else if (androidMusicRoot.Equals("/storage/sdcard1")) // 程式發布時的初始設定
                    textBox_AndroidMusicRoot.Text = androidMusicRoot + dirName;
                this.caretIndex = textBox_AndroidMusicRoot.Text.LastIndexOf(dirName);
                this.androidMusicFolder = textBox_AndroidMusicRoot.Text; // 紀錄目前的Text
            }
            folderBrowserDialog_SdFolder.SelectedPath = textBox_SdFolder.Text;
        }

        private void textBox_AndroidMusicRoot_Leave(object sender, EventArgs e)
        {
            try {
                string text = textBox_AndroidMusicRoot.Text;
                string dirName = textBox_SdFolder.Text.Substring(textBox_SdFolder.Text.IndexOf(@"\")).Replace(@"\", "/");
                if (!text.EndsWith(dirName) || text[0]!='/')
                    throw new Exception();
                string path = Path.GetFullPath(text); // 避免使用者輸入不合法字元 (會拋出例外)
                textBox_AndroidMusicRoot.Text = path.Substring(path.IndexOf(@"\")).Replace(@"\", "/");
            } catch {
                textBox_AndroidMusicRoot.Text = this.androidMusicFolder; // 復原上一次的變更
            } finally {
                this.caretIndex += textBox_AndroidMusicRoot.TextLength - this.androidMusicFolder.Length;
                this.androidMusicFolder = textBox_AndroidMusicRoot.Text; // 紀錄目前的Text
            }
        }

        private void textBox_AndroidMusicRoot_TextChanged(object sender, EventArgs e)
        {
            button_sync.Enabled = this.isCompared;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 進行比對
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_compare_Click(object sender, EventArgs e)
        {
            button_compare.Enabled = button_sync.Enabled = false;
            tabControl1.SelectTab(tabPage_Synclist);
            // 清除所有資料
            listBox_dir.Items.Clear();
            listBox_file.Items.Clear();
            listBox_playlist.Items.Clear();
            listBox_musiclist.Items.Clear();
            textBox_fullPath.Clear();
            textBox_playlistFullPath.Clear();
            label_DirList.Text = listLabelMap[label_DirList];
            label_FileList.Text = listLabelMap[label_FileList];
            label_Playlist.Text = listLabelMap[label_Playlist];
            label_PlaylistFiles.Text = listLabelMap[label_PlaylistFiles];
            // 初始化Syncronizer
            this.sync = new Synchronizer(textBox_iTunesLibrary.Text, textBox_LocalMusicFolder.Text, textBox_SdFolder.Text);
            backgroundWorker_Compare.RunWorkerAsync();
        }

        private void backgroundWorker_Compare_DoWork(object sender, DoWorkEventArgs e)
        {
            this.listBoxItems_SyncDir = sync.Compare(sender as BackgroundWorker);
        }

        private void backgroundWorker_Compare_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusLabel_message.Text = e.UserState.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_Compare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try { 
                if (sync.Logger.isDirty) {
                    textBox_Log.AppendText(sync.Logger.ToString());
                    MessageBox.Show("比對時出現錯誤，詳細訊息請切換至記錄頁面。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectTab(tabPage_Log);
                    statusLabel_message.Text = "";
                    progressBar1.Value = 0;
                } else {
                    button_sync.Enabled = this.isCompared = true;
                    statusLabel_message.Text = String.Format("檔案比對完成，可以開始進行同步 (總共有 {0} 個檔案需要同步)", SyncFile.Count);
                    progressBar1.Value = 100;
                    listBox_dir.Items.AddRange(listBoxItems_SyncDir);
                    listBox_playlist.Items.AddRange(sync.Playlist);
                    label_DirList.Text = String.Format("資料夾清單 ({0})", listBox_dir.Items.Count);
                    label_Playlist.Text = String.Format("播放清單 ({0})", listBox_playlist.Items.Count);
                }
                button_compare.Enabled = true;
            } catch (Exception ex) {
                iSyncAForm.logger.Log(new ExceptionData(ex, "比對完成時出現錯誤"));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 開始同步
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_sync_Click(object sender, EventArgs e)
        {
            button_compare.Enabled = button_sync.Enabled = this.isCompared = false;
            backgroundWorker_Sync.RunWorkerAsync();
        }

        private void backgroundWorker_Sync_DoWork(object sender, DoWorkEventArgs e)
        {
            int option = 0;
            if (menuItem_IgnoreFileSizeDiffer.Checked) option |= (int)Option.IgnoreFileSizeDiffer;
            if (menuItem_IgnoreExtraFiles.Checked) option |= (int)Option.IgnoreExtraFiles;
            sync.Sync(option, textBox_AndroidMusicRoot.Text, sender as BackgroundWorker);
        }

        private void backgroundWorker_Sync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusLabel_message.Text = String.Format("{0} ({1}%)   {2}", (e.UserState as String[])[0], e.ProgressPercentage, (e.UserState as String[])[1]);
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_Sync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sync.Logger.isDirty) {
                textBox_Log.AppendText(sync.Logger.ToString());
                MessageBox.Show("同步時出現錯誤，詳細訊息請切換至記錄頁面。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectTab(tabPage_Log);
                statusLabel_message.Text = "";
                progressBar1.Value = 0;
            } else {
                statusLabel_message.Text = "檔案同步完成";
                progressBar1.Value = 100;
            }
            button_compare.Enabled = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 清單改變時的事件
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 資料夾清單改變時的事件
        private void listBox_dir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_dir.SelectedIndex < 0) return;
            SyncDir dir = listBoxItems_SyncDir[listBox_dir.SelectedIndex];
            listBox_file.Items.Clear();
            listBox_file.Items.AddRange(dir.FileList.ToArray());
            textBox_fullPath.Text = dir.Directory.FullName;
            label_DirList.Text = String.Format("{0} ({1}/{2})", listLabelMap[label_DirList], listBox_dir.SelectedIndex+1, listBox_dir.Items.Count);
            label_FileList.Text = String.Format("{0} ({1})", listLabelMap[label_FileList], listBox_file.Items.Count);
        }

        // 檔案清單改變時的事件
        private void listBox_file_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_file.SelectedIndex < 0) return;
            SyncDir dir = listBoxItems_SyncDir[listBox_dir.SelectedIndex];
            SyncFile file = dir.FileList[listBox_file.SelectedIndex];
            textBox_fullPath.Text = file.File.FullName;
            label_FileList.Text = String.Format("{0} ({1}/{2})", listLabelMap[label_FileList], listBox_file.SelectedIndex+1, listBox_file.Items.Count);
        }

        // 播放清單改變時的事件
        private void listBox_playlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_playlist.SelectedIndex < 0) return;
            textBox_playlistFullPath.Clear();
            listBox_musiclist.Items.Clear();
            listBox_musiclist.Items.AddRange(sync.Playlist[listBox_playlist.SelectedIndex].GetFileListNames());
            label_Playlist.Text = String.Format("{0} ({1}/{2})", listLabelMap[label_Playlist], listBox_playlist.SelectedIndex+1, listBox_playlist.Items.Count);
            label_PlaylistFiles.Text = String.Format("{0} ({1})", listLabelMap[label_PlaylistFiles], listBox_musiclist.Items.Count);
        }

        // 播放清單檔案列表改變時的事件
        private void listBox_musiclist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_musiclist.SelectedIndex < 0) return;
            textBox_playlistFullPath.Text = sync.Playlist[listBox_playlist.SelectedIndex].FileList[listBox_musiclist.SelectedIndex].FullName;
            label_PlaylistFiles.Text = String.Format("{0} ({1}/{2})", listLabelMap[label_PlaylistFiles], listBox_musiclist.SelectedIndex+1, listBox_musiclist.Items.Count);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 雙擊清單事件
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listBox_dir_DoubleClick(object sender, EventArgs e)
        {
            if (listBox_dir.SelectedIndex >= 0)
                Process.Start("explorer.exe", textBox_fullPath.Text);
        }

        private void listBox_file_DoubleClick(object sender, EventArgs e)
        {
            if (listBox_file.SelectedIndex >= 0)
                Process.Start("explorer.exe", "/select, " + textBox_fullPath.Text);
        }

        private void listBox_musiclist_DoubleClick(object sender, EventArgs e)
        {
            if (listBox_musiclist.SelectedIndex >= 0)
                Process.Start("explorer.exe", "/select, " + textBox_playlistFullPath.Text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 指定textBox的游標
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox_AndroidMusicRoot_Click(object sender, EventArgs e)
        {
            if (textBox_AndroidMusicRoot.TextLength > 0)
                textBox_AndroidMusicRoot.Select(this.caretIndex, 0);
        }

        private void textBox_AndroidMusicRoot_Enter(object sender, EventArgs e)
        {
            textBox_AndroidMusicRoot_Click(sender, e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 設定值儲存/匯出
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void toolStripMenuItem_ExportSettings_Click(object sender, EventArgs e)
        {
            if (Registry.CurrentUser.OpenSubKey(iSyncAForm.registryPath) == null)
                toolStripMenuItem_SaveSettings_Click(sender, e);
            if (saveFileDialog_Settings.FileName.Length == 0)
                saveFileDialog_Settings.FileName = String.Format("{0}_iSyncA設定檔", DateTime.Now.ToString("yyyyMMdd"));
            if (saveFileDialog_Settings.ShowDialog() == DialogResult.OK) {
                string fileName = saveFileDialog_Settings.FileName;
                fileName = fileName.EndsWith(".reg") ? fileName : fileName+".reg";
                Process.Start("regedit.exe", String.Format(@"/e {0} HKEY_CURRENT_USER\{1}", fileName, registryPath.Substring(0, registryPath.LastIndexOf(@"\"))));
                MessageBox.Show("匯出成功", "匯出設定值", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem_SaveSettings_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(iSyncAForm.registryPath);

            // 儲存路徑設定值
            foreach (Control control in panel_Paths.Controls) {
                if ((control is TextBox) && this.RegistryNameMap.ContainsKey(control))
                    key.SetValue(this.RegistryNameMap[control], (control as TextBox).Text);
            }

            // 儲存偏好設定
            foreach (ToolStripMenuItem item in menuStrip1.Items) {
                foreach (ToolStripMenuItem dropdownItems in item.DropDownItems) {
                    if (this.RegistryNameMap.ContainsKey(dropdownItems)) {
                        key.SetValue(this.RegistryNameMap[dropdownItems], dropdownItems.Checked);
                    }
                }
            }

            key.Close();

            if (sender is ToolStripMenuItem)
                MessageBox.Show("儲存成功", "儲存設定值", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        #region 其他事件
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 將游標顯示設定到文字底端
        private void textBox_fullPath_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.SelectionStart = textBox.TextLength;
            textBox.ScrollToCaret();
        }

        private void iSyncAForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (menuItem_AlertOnExit.Checked)
                e.Cancel = (MessageBox.Show("確定要離開嗎?", "關閉程式", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK);
            if (!e.Cancel) {
                if (menuItem_AutoSaveSettings.Checked)
                    toolStripMenuItem_SaveSettings_Click(sender, e);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

       
    }
}
