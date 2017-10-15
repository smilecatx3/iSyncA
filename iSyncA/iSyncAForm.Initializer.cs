using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace iSyncA
{
    partial class iSyncAForm
    {
        private static Assembly resourceDll = Assembly.LoadFrom("Resource.dll");
        private static ResourceManager resource = new ResourceManager("Resource.Settings", resourceDll);
        private static Logger logger = new Logger();
        private const string registryPath = @"Software\MaouSoft\iSyncA\Settings";

        private Dictionary<Label, string> listLabelMap = new Dictionary<Label, string>(); // <Label, 預設字串>
        private Dictionary<Label, TextBox> pathLabelIndex = new Dictionary<Label, TextBox>(); // <Label, 路徑文字框>
        private Dictionary<Component, string> RegistryNameMap = new Dictionary<Component, string>(); // <元件, 註冊碼名稱> 要加入Registry的內容主要由此控制

        private bool initializing; // 程式是否位於初始化階段


        public iSyncAForm()
        {
            this.initializing = true;

            InitializeComponent();
            InitializeFields();

            FormBorderStyle = FormBorderStyle.FixedSingle; // Form不能調整大小
            ActiveControl = label_iTunesLibrary; // 隱藏游標
            
            LoadRegistry();
            SetiTunesLibPath();

            this.initializing = false;
        }


        // 初始化Filed變數資料
        private void InitializeFields()
        {
            this.listLabelMap.Add(label_DirList, label_DirList.Text);
            this.listLabelMap.Add(label_FileList, label_FileList.Text);
            this.listLabelMap.Add(label_Playlist, label_Playlist.Text);
            this.listLabelMap.Add(label_PlaylistFiles, label_PlaylistFiles.Text);

            this.pathLabelIndex.Add(label_iTunesLibrary, textBox_iTunesLibrary);
            this.pathLabelIndex.Add(label_LocalMusicFolder, textBox_LocalMusicFolder);
            this.pathLabelIndex.Add(label_SdFolder, textBox_SdFolder);

            this.RegistryNameMap.Add(textBox_iTunesLibrary, "iTunesLibrary");
            this.RegistryNameMap.Add(textBox_LocalMusicFolder, "LocalMusicFolder");
            this.RegistryNameMap.Add(textBox_SdFolder, "SdFolder");
            this.RegistryNameMap.Add(textBox_AndroidMusicRoot, "AndroidMusicRoot");
            this.RegistryNameMap.Add(menuItem_AutoSaveSettings, "AutoSaveSettings");
            this.RegistryNameMap.Add(menuItem_AlertOnExit, "AlertOnExit");
            this.RegistryNameMap.Add(menuItem_IgnoreFileSizeDiffer, "IgnoreFileSizeDiffer");
            this.RegistryNameMap.Add(menuItem_IgnoreExtraFiles, "IgnoreExtraFiles");
        }


        // 讀取Registry初始化程式
        private void LoadRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(iSyncAForm.registryPath);
            if (key == null) return;

            // 初始化所有與路徑有關的TextBox
            foreach (Control control in panel_Paths.Controls) {
                if ((control is TextBox) && this.RegistryNameMap.ContainsKey(control)) {
                    object value = key.GetValue(this.RegistryNameMap[control]);
                    (control as TextBox).Text = (value!=null) ? value.ToString() : "";
                }
            }

            // 初始化偏好設定
            foreach (ToolStripMenuItem item in menuStrip1.Items) {
                foreach (ToolStripMenuItem dropdownItems in item.DropDownItems) {
                    if (this.RegistryNameMap.ContainsKey(dropdownItems)) {
                        object value = key.GetValue(this.RegistryNameMap[dropdownItems]);
                        try { dropdownItems.Checked = bool.Parse(value.ToString()); } catch { }
                    }
                }
            }

            key.Close();
        }


        // 偵測iTunes資料庫路徑
        private void SetiTunesLibPath()
        {
            if (textBox_iTunesLibrary.TextLength > 0)
                return;
            string myMusicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string[] lines = Regex.Split(resource.GetObject("iTunes資料庫路徑").ToString().Replace("\r", ""), "\n");
            foreach (string line in lines) {
                FileInfo iTunesLib = new FileInfo(myMusicFolder + line);
                if (iTunesLib.Exists) {
                    textBox_iTunesLibrary.Text = iTunesLib.FullName;
                    openFileDialog_iTunesLib.InitialDirectory = iTunesLib.Directory.FullName;
                    return;
                }
            }
        }


    }
}
