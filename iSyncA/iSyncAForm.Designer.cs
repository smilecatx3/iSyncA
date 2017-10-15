namespace iSyncA
{
    partial class iSyncAForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iSyncAForm));
            this.選項ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_AutoSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_AlertOnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_IgnoreFileSizeDiffer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_IgnoreExtraFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ExportSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_iTunesLibrary = new System.Windows.Forms.TextBox();
            this.textBox_LocalMusicFolder = new System.Windows.Forms.TextBox();
            this.panel_Paths = new System.Windows.Forms.Panel();
            this.textBox_AndroidMusicRoot = new System.Windows.Forms.TextBox();
            this.button_sync = new System.Windows.Forms.Button();
            this.textBox_SdFolder = new System.Windows.Forms.TextBox();
            this.button_compare = new System.Windows.Forms.Button();
            this.label_SdFolder = new System.Windows.Forms.Label();
            this.label_LocalMusicFolder = new System.Windows.Forms.Label();
            this.label_iTunesLibrary = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_FileList = new System.Windows.Forms.Label();
            this.listBox_dir = new System.Windows.Forms.ListBox();
            this.listBox_file = new System.Windows.Forms.ListBox();
            this.label_DirList = new System.Windows.Forms.Label();
            this.textBox_fullPath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Synclist = new System.Windows.Forms.TabPage();
            this.tabPage_Playlist = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_playlistFullPath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_PlaylistFiles = new System.Windows.Forms.Label();
            this.listBox_playlist = new System.Windows.Forms.ListBox();
            this.listBox_musiclist = new System.Windows.Forms.ListBox();
            this.label_Playlist = new System.Windows.Forms.Label();
            this.tabPage_Log = new System.Windows.Forms.TabPage();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog_SdFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog_iTunesLib = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel_message = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker_Compare = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog_LocalMusicFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker_Sync = new System.ComponentModel.BackgroundWorker();
            this.label10 = new System.Windows.Forms.Label();
            this.saveFileDialog_Settings = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel_Paths.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Synclist.SuspendLayout();
            this.tabPage_Playlist.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage_Log.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 選項ToolStripMenuItem
            // 
            this.選項ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_AutoSaveSettings,
            this.menuItem_AlertOnExit,
            this.menuItem_IgnoreFileSizeDiffer,
            this.menuItem_IgnoreExtraFiles});
            this.選項ToolStripMenuItem.Name = "選項ToolStripMenuItem";
            this.選項ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.選項ToolStripMenuItem.Text = "選項";
            // 
            // menuItem_AutoSaveSettings
            // 
            this.menuItem_AutoSaveSettings.Checked = true;
            this.menuItem_AutoSaveSettings.CheckOnClick = true;
            this.menuItem_AutoSaveSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItem_AutoSaveSettings.Name = "menuItem_AutoSaveSettings";
            this.menuItem_AutoSaveSettings.Size = new System.Drawing.Size(206, 22);
            this.menuItem_AutoSaveSettings.Text = "結束時自動儲存設定值";
            // 
            // menuItem_AlertOnExit
            // 
            this.menuItem_AlertOnExit.Checked = true;
            this.menuItem_AlertOnExit.CheckOnClick = true;
            this.menuItem_AlertOnExit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItem_AlertOnExit.Name = "menuItem_AlertOnExit";
            this.menuItem_AlertOnExit.Size = new System.Drawing.Size(206, 22);
            this.menuItem_AlertOnExit.Text = "關閉程式時提示";
            // 
            // menuItem_IgnoreFileSizeDiffer
            // 
            this.menuItem_IgnoreFileSizeDiffer.CheckOnClick = true;
            this.menuItem_IgnoreFileSizeDiffer.Name = "menuItem_IgnoreFileSizeDiffer";
            this.menuItem_IgnoreFileSizeDiffer.Size = new System.Drawing.Size(206, 22);
            this.menuItem_IgnoreFileSizeDiffer.Text = "忽略檔案大小不同的檔案";
            // 
            // menuItem_IgnoreExtraFiles
            // 
            this.menuItem_IgnoreExtraFiles.CheckOnClick = true;
            this.menuItem_IgnoreExtraFiles.Name = "menuItem_IgnoreExtraFiles";
            this.menuItem_IgnoreExtraFiles.Size = new System.Drawing.Size(206, 22);
            this.menuItem_IgnoreExtraFiles.Text = "不移除多出來的檔案";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.選項ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SaveSettings,
            this.toolStripMenuItem_ExportSettings});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // toolStripMenuItem_SaveSettings
            // 
            this.toolStripMenuItem_SaveSettings.Name = "toolStripMenuItem_SaveSettings";
            this.toolStripMenuItem_SaveSettings.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_SaveSettings.Text = "儲存目前設定值";
            this.toolStripMenuItem_SaveSettings.Click += new System.EventHandler(this.toolStripMenuItem_SaveSettings_Click);
            // 
            // toolStripMenuItem_ExportSettings
            // 
            this.toolStripMenuItem_ExportSettings.Name = "toolStripMenuItem_ExportSettings";
            this.toolStripMenuItem_ExportSettings.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_ExportSettings.Text = "匯出設定值";
            this.toolStripMenuItem_ExportSettings.Click += new System.EventHandler(this.toolStripMenuItem_ExportSettings_Click);
            // 
            // textBox_iTunesLibrary
            // 
            this.textBox_iTunesLibrary.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_iTunesLibrary.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_iTunesLibrary.Location = new System.Drawing.Point(134, 3);
            this.textBox_iTunesLibrary.Name = "textBox_iTunesLibrary";
            this.textBox_iTunesLibrary.ReadOnly = true;
            this.textBox_iTunesLibrary.Size = new System.Drawing.Size(428, 25);
            this.textBox_iTunesLibrary.TabIndex = 1;
            this.textBox_iTunesLibrary.Click += new System.EventHandler(this.textBox_iTunesLibrary_Click);
            this.textBox_iTunesLibrary.TextChanged += new System.EventHandler(this.textBox_iTunesLibrary_TextChanged);
            // 
            // textBox_LocalMusicFolder
            // 
            this.textBox_LocalMusicFolder.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_LocalMusicFolder.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_LocalMusicFolder.Location = new System.Drawing.Point(134, 29);
            this.textBox_LocalMusicFolder.Name = "textBox_LocalMusicFolder";
            this.textBox_LocalMusicFolder.ReadOnly = true;
            this.textBox_LocalMusicFolder.Size = new System.Drawing.Size(428, 25);
            this.textBox_LocalMusicFolder.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBox_LocalMusicFolder, "不一定要指定這個資料夾，但指定這個可以讓你SD卡內的資料夾結構比較好看。");
            this.textBox_LocalMusicFolder.Click += new System.EventHandler(this.textBox_localMusicFolder_Click);
            this.textBox_LocalMusicFolder.TextChanged += new System.EventHandler(this.textBox_LocalMusicFolder_TextChanged);
            // 
            // panel_Paths
            // 
            this.panel_Paths.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Paths.Controls.Add(this.textBox_AndroidMusicRoot);
            this.panel_Paths.Controls.Add(this.button_sync);
            this.panel_Paths.Controls.Add(this.textBox_SdFolder);
            this.panel_Paths.Controls.Add(this.button_compare);
            this.panel_Paths.Controls.Add(this.label_SdFolder);
            this.panel_Paths.Controls.Add(this.label_LocalMusicFolder);
            this.panel_Paths.Controls.Add(this.textBox_LocalMusicFolder);
            this.panel_Paths.Controls.Add(this.label_iTunesLibrary);
            this.panel_Paths.Controls.Add(this.textBox_iTunesLibrary);
            this.panel_Paths.Location = new System.Drawing.Point(4, 27);
            this.panel_Paths.Name = "panel_Paths";
            this.panel_Paths.Size = new System.Drawing.Size(680, 88);
            this.panel_Paths.TabIndex = 3;
            // 
            // textBox_AndroidMusicRoot
            // 
            this.textBox_AndroidMusicRoot.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_AndroidMusicRoot.Enabled = false;
            this.textBox_AndroidMusicRoot.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AndroidMusicRoot.Location = new System.Drawing.Point(345, 56);
            this.textBox_AndroidMusicRoot.Name = "textBox_AndroidMusicRoot";
            this.textBox_AndroidMusicRoot.Size = new System.Drawing.Size(217, 25);
            this.textBox_AndroidMusicRoot.TabIndex = 7;
            this.textBox_AndroidMusicRoot.Text = "/storage/sdcard1";
            this.textBox_AndroidMusicRoot.Click += new System.EventHandler(this.textBox_AndroidMusicRoot_Click);
            this.textBox_AndroidMusicRoot.TextChanged += new System.EventHandler(this.textBox_AndroidMusicRoot_TextChanged);
            this.textBox_AndroidMusicRoot.Enter += new System.EventHandler(this.textBox_AndroidMusicRoot_Enter);
            this.textBox_AndroidMusicRoot.Leave += new System.EventHandler(this.textBox_AndroidMusicRoot_Leave);
            // 
            // button_sync
            // 
            this.button_sync.Enabled = false;
            this.button_sync.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_sync.Location = new System.Drawing.Point(577, 43);
            this.button_sync.Name = "button_sync";
            this.button_sync.Size = new System.Drawing.Size(97, 34);
            this.button_sync.TabIndex = 5;
            this.button_sync.Text = "開始同步";
            this.button_sync.UseVisualStyleBackColor = true;
            this.button_sync.Click += new System.EventHandler(this.button_sync_Click);
            // 
            // textBox_SdFolder
            // 
            this.textBox_SdFolder.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_SdFolder.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SdFolder.Location = new System.Drawing.Point(134, 56);
            this.textBox_SdFolder.Name = "textBox_SdFolder";
            this.textBox_SdFolder.ReadOnly = true;
            this.textBox_SdFolder.Size = new System.Drawing.Size(202, 25);
            this.textBox_SdFolder.TabIndex = 6;
            this.textBox_SdFolder.Click += new System.EventHandler(this.textBox_sdFolder_Click);
            this.textBox_SdFolder.TextChanged += new System.EventHandler(this.textBox_SdFolder_TextChanged);
            // 
            // button_compare
            // 
            this.button_compare.Enabled = false;
            this.button_compare.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_compare.Location = new System.Drawing.Point(577, 3);
            this.button_compare.Name = "button_compare";
            this.button_compare.Size = new System.Drawing.Size(97, 34);
            this.button_compare.TabIndex = 0;
            this.button_compare.Text = "比對檔案";
            this.button_compare.UseVisualStyleBackColor = true;
            this.button_compare.Click += new System.EventHandler(this.button_compare_Click);
            // 
            // label_SdFolder
            // 
            this.label_SdFolder.AutoSize = true;
            this.label_SdFolder.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_SdFolder.Location = new System.Drawing.Point(25, 59);
            this.label_SdFolder.Name = "label_SdFolder";
            this.label_SdFolder.Size = new System.Drawing.Size(103, 17);
            this.label_SdFolder.TabIndex = 5;
            this.label_SdFolder.Text = "SD卡音樂資料夾";
            this.label_SdFolder.DoubleClick += new System.EventHandler(this.label_SdFolder_DoubleClick);
            // 
            // label_LocalMusicFolder
            // 
            this.label_LocalMusicFolder.AutoSize = true;
            this.label_LocalMusicFolder.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_LocalMusicFolder.Location = new System.Drawing.Point(3, 33);
            this.label_LocalMusicFolder.Name = "label_LocalMusicFolder";
            this.label_LocalMusicFolder.Size = new System.Drawing.Size(125, 17);
            this.label_LocalMusicFolder.TabIndex = 4;
            this.label_LocalMusicFolder.Text = "本地音樂檔案資料夾";
            this.toolTip1.SetToolTip(this.label_LocalMusicFolder, "不一定要指定這個資料夾，但指定這個可以讓你SD卡內的資料夾結構比較好看。");
            this.label_LocalMusicFolder.DoubleClick += new System.EventHandler(this.label_LocalMusicFolder_DoubleClick);
            // 
            // label_iTunesLibrary
            // 
            this.label_iTunesLibrary.AutoSize = true;
            this.label_iTunesLibrary.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_iTunesLibrary.Location = new System.Drawing.Point(16, 7);
            this.label_iTunesLibrary.Name = "label_iTunesLibrary";
            this.label_iTunesLibrary.Size = new System.Drawing.Size(112, 17);
            this.label_iTunesLibrary.TabIndex = 2;
            this.label_iTunesLibrary.Text = "iTunes音樂資料庫";
            this.label_iTunesLibrary.DoubleClick += new System.EventHandler(this.label_iTunesLibrary_DoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.tableLayoutPanel1.Controls.Add(this.label_FileList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox_dir, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBox_file, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_DirList, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 347F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 372);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label_FileList
            // 
            this.label_FileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FileList.AutoSize = true;
            this.label_FileList.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_FileList.Location = new System.Drawing.Point(337, 0);
            this.label_FileList.Name = "label_FileList";
            this.label_FileList.Size = new System.Drawing.Size(329, 25);
            this.label_FileList.TabIndex = 3;
            this.label_FileList.Text = "檔案清單";
            this.label_FileList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_dir
            // 
            this.listBox_dir.BackColor = System.Drawing.SystemColors.Info;
            this.listBox_dir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_dir.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_dir.FormattingEnabled = true;
            this.listBox_dir.HorizontalScrollbar = true;
            this.listBox_dir.ItemHeight = 19;
            this.listBox_dir.Location = new System.Drawing.Point(3, 28);
            this.listBox_dir.Name = "listBox_dir";
            this.listBox_dir.Size = new System.Drawing.Size(328, 341);
            this.listBox_dir.TabIndex = 0;
            this.listBox_dir.SelectedIndexChanged += new System.EventHandler(this.listBox_dir_SelectedIndexChanged);
            this.listBox_dir.DoubleClick += new System.EventHandler(this.listBox_dir_DoubleClick);
            // 
            // listBox_file
            // 
            this.listBox_file.BackColor = System.Drawing.SystemColors.Info;
            this.listBox_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_file.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_file.FormattingEnabled = true;
            this.listBox_file.HorizontalScrollbar = true;
            this.listBox_file.ItemHeight = 19;
            this.listBox_file.Location = new System.Drawing.Point(337, 28);
            this.listBox_file.Name = "listBox_file";
            this.listBox_file.Size = new System.Drawing.Size(329, 341);
            this.listBox_file.TabIndex = 1;
            this.listBox_file.SelectedIndexChanged += new System.EventHandler(this.listBox_file_SelectedIndexChanged);
            this.listBox_file.DoubleClick += new System.EventHandler(this.listBox_file_DoubleClick);
            // 
            // label_DirList
            // 
            this.label_DirList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DirList.AutoSize = true;
            this.label_DirList.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_DirList.Location = new System.Drawing.Point(3, 0);
            this.label_DirList.Name = "label_DirList";
            this.label_DirList.Size = new System.Drawing.Size(328, 25);
            this.label_DirList.TabIndex = 2;
            this.label_DirList.Text = "資料夾清單";
            this.label_DirList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_fullPath
            // 
            this.textBox_fullPath.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_fullPath.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fullPath.Location = new System.Drawing.Point(95, 2);
            this.textBox_fullPath.Name = "textBox_fullPath";
            this.textBox_fullPath.ReadOnly = true;
            this.textBox_fullPath.Size = new System.Drawing.Size(571, 25);
            this.textBox_fullPath.TabIndex = 5;
            this.textBox_fullPath.TextChanged += new System.EventHandler(this.textBox_fullPath_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox_fullPath);
            this.panel2.Location = new System.Drawing.Point(1, 372);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(669, 28);
            this.panel2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "檔案完整路徑";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Synclist);
            this.tabControl1.Controls.Add(this.tabPage_Playlist);
            this.tabControl1.Controls.Add(this.tabPage_Log);
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(4, 121);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 435);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage_Synclist
            // 
            this.tabPage_Synclist.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_Synclist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage_Synclist.Controls.Add(this.panel2);
            this.tabPage_Synclist.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_Synclist.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage_Synclist.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Synclist.Name = "tabPage_Synclist";
            this.tabPage_Synclist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Synclist.Size = new System.Drawing.Size(672, 405);
            this.tabPage_Synclist.TabIndex = 0;
            this.tabPage_Synclist.Text = "音樂";
            // 
            // tabPage_Playlist
            // 
            this.tabPage_Playlist.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_Playlist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage_Playlist.Controls.Add(this.panel3);
            this.tabPage_Playlist.Controls.Add(this.tableLayoutPanel2);
            this.tabPage_Playlist.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage_Playlist.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Playlist.Name = "tabPage_Playlist";
            this.tabPage_Playlist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Playlist.Size = new System.Drawing.Size(672, 405);
            this.tabPage_Playlist.TabIndex = 1;
            this.tabPage_Playlist.Text = "播放清單";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.textBox_playlistFullPath);
            this.panel3.Location = new System.Drawing.Point(1, 372);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(669, 28);
            this.panel3.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(3, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "檔案完整路徑";
            // 
            // textBox_playlistFullPath
            // 
            this.textBox_playlistFullPath.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_playlistFullPath.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_playlistFullPath.Location = new System.Drawing.Point(95, 2);
            this.textBox_playlistFullPath.Name = "textBox_playlistFullPath";
            this.textBox_playlistFullPath.ReadOnly = true;
            this.textBox_playlistFullPath.Size = new System.Drawing.Size(571, 25);
            this.textBox_playlistFullPath.TabIndex = 5;
            this.textBox_playlistFullPath.TextChanged += new System.EventHandler(this.textBox_fullPath_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.tableLayoutPanel2.Controls.Add(this.label_PlaylistFiles, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBox_playlist, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.listBox_musiclist, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label_Playlist, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 347F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(669, 372);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label_PlaylistFiles
            // 
            this.label_PlaylistFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PlaylistFiles.AutoSize = true;
            this.label_PlaylistFiles.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_PlaylistFiles.Location = new System.Drawing.Point(337, 0);
            this.label_PlaylistFiles.Name = "label_PlaylistFiles";
            this.label_PlaylistFiles.Size = new System.Drawing.Size(329, 25);
            this.label_PlaylistFiles.TabIndex = 3;
            this.label_PlaylistFiles.Text = "音樂列表";
            this.label_PlaylistFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_playlist
            // 
            this.listBox_playlist.BackColor = System.Drawing.SystemColors.Info;
            this.listBox_playlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_playlist.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_playlist.FormattingEnabled = true;
            this.listBox_playlist.HorizontalScrollbar = true;
            this.listBox_playlist.ItemHeight = 19;
            this.listBox_playlist.Location = new System.Drawing.Point(3, 28);
            this.listBox_playlist.Name = "listBox_playlist";
            this.listBox_playlist.Size = new System.Drawing.Size(328, 341);
            this.listBox_playlist.TabIndex = 0;
            this.listBox_playlist.SelectedIndexChanged += new System.EventHandler(this.listBox_playlist_SelectedIndexChanged);
            // 
            // listBox_musiclist
            // 
            this.listBox_musiclist.BackColor = System.Drawing.SystemColors.Info;
            this.listBox_musiclist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_musiclist.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_musiclist.FormattingEnabled = true;
            this.listBox_musiclist.HorizontalScrollbar = true;
            this.listBox_musiclist.ItemHeight = 19;
            this.listBox_musiclist.Location = new System.Drawing.Point(337, 28);
            this.listBox_musiclist.Name = "listBox_musiclist";
            this.listBox_musiclist.Size = new System.Drawing.Size(329, 341);
            this.listBox_musiclist.TabIndex = 1;
            this.listBox_musiclist.SelectedIndexChanged += new System.EventHandler(this.listBox_musiclist_SelectedIndexChanged);
            this.listBox_musiclist.DoubleClick += new System.EventHandler(this.listBox_musiclist_DoubleClick);
            // 
            // label_Playlist
            // 
            this.label_Playlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Playlist.AutoSize = true;
            this.label_Playlist.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Playlist.Location = new System.Drawing.Point(3, 0);
            this.label_Playlist.Name = "label_Playlist";
            this.label_Playlist.Size = new System.Drawing.Size(328, 25);
            this.label_Playlist.TabIndex = 2;
            this.label_Playlist.Text = "播放清單";
            this.label_Playlist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage_Log
            // 
            this.tabPage_Log.Controls.Add(this.textBox_Log);
            this.tabPage_Log.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Log.Name = "tabPage_Log";
            this.tabPage_Log.Size = new System.Drawing.Size(672, 405);
            this.tabPage_Log.TabIndex = 2;
            this.tabPage_Log.Text = "記錄";
            // 
            // textBox_Log
            // 
            this.textBox_Log.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Log.Location = new System.Drawing.Point(0, 0);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ReadOnly = true;
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Log.Size = new System.Drawing.Size(672, 405);
            this.textBox_Log.TabIndex = 0;
            this.textBox_Log.WordWrap = false;
            // 
            // openFileDialog_iTunesLib
            // 
            this.openFileDialog_iTunesLib.FileName = "iTunes Library.xml";
            this.openFileDialog_iTunesLib.Filter = "iTunes Library|*.xml";
            this.openFileDialog_iTunesLib.Title = "選擇iTunes音樂資料庫 (iTunes Library.xml)";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "指定本地音樂檔案資料夾路徑";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.statusLabel_message});
            this.statusStrip1.Location = new System.Drawing.Point(0, 559);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // statusLabel_message
            // 
            this.statusLabel_message.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.statusLabel_message.Name = "statusLabel_message";
            this.statusLabel_message.Size = new System.Drawing.Size(0, 17);
            // 
            // backgroundWorker_Compare
            // 
            this.backgroundWorker_Compare.WorkerReportsProgress = true;
            this.backgroundWorker_Compare.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Compare_DoWork);
            this.backgroundWorker_Compare.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_Compare_ProgressChanged);
            this.backgroundWorker_Compare.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Compare_RunWorkerCompleted);
            // 
            // backgroundWorker_Sync
            // 
            this.backgroundWorker_Sync.WorkerReportsProgress = true;
            this.backgroundWorker_Sync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Sync_DoWork);
            this.backgroundWorker_Sync.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_Sync_ProgressChanged);
            this.backgroundWorker_Sync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Sync_RunWorkerCompleted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(606, 562);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "ψ Xavier Lin";
            // 
            // saveFileDialog_Settings
            // 
            this.saveFileDialog_Settings.Filter = "登錄檔 | *reg";
            this.saveFileDialog_Settings.Title = "匯出設定值";
            // 
            // iSyncAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 581);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel_Paths);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "iSyncAForm";
            this.Text = "iSyncA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.iSyncAForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_Paths.ResumeLayout(false);
            this.panel_Paths.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Synclist.ResumeLayout(false);
            this.tabPage_Playlist.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage_Log.ResumeLayout(false);
            this.tabPage_Log.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 選項ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_IgnoreFileSizeDiffer;
        private System.Windows.Forms.ToolStripMenuItem menuItem_IgnoreExtraFiles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox_iTunesLibrary;
        private System.Windows.Forms.TextBox textBox_LocalMusicFolder;
        private System.Windows.Forms.Panel panel_Paths;
        private System.Windows.Forms.Label label_iTunesLibrary;
        private System.Windows.Forms.Label label_LocalMusicFolder;
        private System.Windows.Forms.TextBox textBox_SdFolder;
        private System.Windows.Forms.Label label_SdFolder;
        private System.Windows.Forms.Button button_sync;
        private System.Windows.Forms.Button button_compare;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBox_file;
        private System.Windows.Forms.ListBox listBox_dir;
        private System.Windows.Forms.TextBox textBox_fullPath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_FileList;
        private System.Windows.Forms.Label label_DirList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Synclist;
        private System.Windows.Forms.TabPage tabPage_Playlist;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_SdFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog_iTunesLib;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Compare;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_LocalMusicFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Sync;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_PlaylistFiles;
        private System.Windows.Forms.ListBox listBox_playlist;
        private System.Windows.Forms.ListBox listBox_musiclist;
        private System.Windows.Forms.Label label_Playlist;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_playlistFullPath;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_message;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox_AndroidMusicRoot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ExportSettings;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Settings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SaveSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItem_AutoSaveSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItem_AlertOnExit;
        private System.Windows.Forms.TabPage tabPage_Log;
        private System.Windows.Forms.TextBox textBox_Log;

    }
}

