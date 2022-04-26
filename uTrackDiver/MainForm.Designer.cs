namespace uTrackDiver
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.rwltPortStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.auxGNSSPortStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.linkBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.logBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.logViewCurrentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logPlaybackBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.logRemoveEmptyEntriesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.logClearAllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.utilsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.utilsTracksBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.trackExportBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.trackClearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addNoteTxb = new System.Windows.Forms.ToolStripTextBox();
            this.addNoteBtn = new System.Windows.Forms.ToolStripButton();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.bottomTreeToolStrip = new System.Windows.Forms.ToolStrip();
            this.tree_isDstBtn = new System.Windows.Forms.ToolStripButton();
            this.tree_isAzmBtn = new System.Windows.Forms.ToolStripButton();
            this.tree_isRazBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tree_isLatLonBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tree_isRerBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tree_isDopTbaBtn = new System.Windows.Forms.ToolStripButton();
            this.diversTreeView = new System.Windows.Forms.TreeView();
            this.rightToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.expandTreeBtn = new System.Windows.Forms.ToolStripButton();
            this.collapseTreeBtn = new System.Windows.Forms.ToolStripButton();
            this.sortTreeBtn = new System.Windows.Forms.ToolStripButton();
            this.plotToolStrip = new System.Windows.Forms.ToolStrip();
            this.basesVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.logVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.legendVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.notesVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.miscInfoVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.resetViewBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.plotPanel = new System.Windows.Forms.Panel();
            this.uMapPlot = new UCNLUI.Controls.uOSMGeoPlot();
            this.mainStatusStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.bottomTreeToolStrip.SuspendLayout();
            this.rightToolStrip.SuspendLayout();
            this.plotToolStrip.SuspendLayout();
            this.plotPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rwltPortStatusLbl,
            this.toolStripStatusLabel1,
            this.auxGNSSPortStatusLbl});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 519);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1006, 34);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "mainStatusStrip";
            // 
            // rwltPortStatusLbl
            // 
            this.rwltPortStatusLbl.Name = "rwltPortStatusLbl";
            this.rwltPortStatusLbl.Size = new System.Drawing.Size(34, 28);
            this.rwltPortStatusLbl.Text = ". . .";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 28);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // auxGNSSPortStatusLbl
            // 
            this.auxGNSSPortStatusLbl.Name = "auxGNSSPortStatusLbl";
            this.auxGNSSPortStatusLbl.Size = new System.Drawing.Size(34, 28);
            this.auxGNSSPortStatusLbl.Text = ". . .";
            this.auxGNSSPortStatusLbl.Visible = false;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkBtn,
            this.toolStripSeparator1,
            this.settingsBtn,
            this.toolStripSeparator2,
            this.logBtn,
            this.toolStripSeparator3,
            this.utilsBtn,
            this.toolStripSeparator4,
            this.addNoteTxb,
            this.addNoteBtn,
            this.infoBtn});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(1006, 38);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "mainToolStrip";
            // 
            // linkBtn
            // 
            this.linkBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.linkBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkBtn.Image = ((System.Drawing.Image)(resources.GetObject("linkBtn.Image")));
            this.linkBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.linkBtn.Name = "linkBtn";
            this.linkBtn.Size = new System.Drawing.Size(106, 35);
            this.linkBtn.Text = "🔌 LINK";
            this.linkBtn.Click += new System.EventHandler(this.linkBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(162, 35);
            this.settingsBtn.Text = "⚙ SETTINGS";
            this.settingsBtn.ToolTipText = "SETTINGS";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // logBtn
            // 
            this.logBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewCurrentBtn,
            this.logPlaybackBtn,
            this.toolStripSeparator10,
            this.logRemoveEmptyEntriesBtn,
            this.toolStripSeparator12,
            this.logClearAllBtn});
            this.logBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logBtn.Image = ((System.Drawing.Image)(resources.GetObject("logBtn.Image")));
            this.logBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(117, 35);
            this.logBtn.Text = " 📖 LOG";
            // 
            // logViewCurrentBtn
            // 
            this.logViewCurrentBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.logViewCurrentBtn.Name = "logViewCurrentBtn";
            this.logViewCurrentBtn.Size = new System.Drawing.Size(367, 36);
            this.logViewCurrentBtn.Text = "👀 View current";
            this.logViewCurrentBtn.Click += new System.EventHandler(this.logViewCurrentBtn_Click);
            // 
            // logPlaybackBtn
            // 
            this.logPlaybackBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.logPlaybackBtn.Name = "logPlaybackBtn";
            this.logPlaybackBtn.Size = new System.Drawing.Size(367, 36);
            this.logPlaybackBtn.Text = "▶ Playback...";
            this.logPlaybackBtn.Click += new System.EventHandler(this.logPlaybackBtn_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(364, 6);
            // 
            // logRemoveEmptyEntriesBtn
            // 
            this.logRemoveEmptyEntriesBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.logRemoveEmptyEntriesBtn.Name = "logRemoveEmptyEntriesBtn";
            this.logRemoveEmptyEntriesBtn.Size = new System.Drawing.Size(367, 36);
            this.logRemoveEmptyEntriesBtn.Text = "🧹 Remove empty entries";
            this.logRemoveEmptyEntriesBtn.Click += new System.EventHandler(this.logRemoveEmptyEntriesBtn_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(364, 6);
            // 
            // logClearAllBtn
            // 
            this.logClearAllBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.logClearAllBtn.Name = "logClearAllBtn";
            this.logClearAllBtn.Size = new System.Drawing.Size(367, 36);
            this.logClearAllBtn.Text = "🗑 Clear all";
            this.logClearAllBtn.Click += new System.EventHandler(this.logClearAllBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // utilsBtn
            // 
            this.utilsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.utilsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilsTracksBtn});
            this.utilsBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.utilsBtn.Image = ((System.Drawing.Image)(resources.GetObject("utilsBtn.Image")));
            this.utilsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.utilsBtn.Name = "utilsBtn";
            this.utilsBtn.Size = new System.Drawing.Size(129, 35);
            this.utilsBtn.Text = "🛠 UTILS";
            // 
            // utilsTracksBtn
            // 
            this.utilsTracksBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackExportBtn,
            this.toolStripSeparator11,
            this.trackClearBtn});
            this.utilsTracksBtn.Enabled = false;
            this.utilsTracksBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.utilsTracksBtn.Name = "utilsTracksBtn";
            this.utilsTracksBtn.Size = new System.Drawing.Size(220, 36);
            this.utilsTracksBtn.Text = "🗺 TRACKS";
            // 
            // trackExportBtn
            // 
            this.trackExportBtn.Name = "trackExportBtn";
            this.trackExportBtn.Size = new System.Drawing.Size(219, 36);
            this.trackExportBtn.Text = "💾 Export...";
            this.trackExportBtn.Click += new System.EventHandler(this.trackExportBtn_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(216, 6);
            // 
            // trackClearBtn
            // 
            this.trackClearBtn.Name = "trackClearBtn";
            this.trackClearBtn.Size = new System.Drawing.Size(219, 36);
            this.trackClearBtn.Text = "🗑 Clear";
            this.trackClearBtn.Click += new System.EventHandler(this.trackClearBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // addNoteTxb
            // 
            this.addNoteTxb.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNoteTxb.MaxLength = 1024;
            this.addNoteTxb.Name = "addNoteTxb";
            this.addNoteTxb.Size = new System.Drawing.Size(170, 38);
            this.addNoteTxb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addNoteTxb_KeyDown);
            this.addNoteTxb.TextChanged += new System.EventHandler(this.addNoteTxb_TextChanged);
            // 
            // addNoteBtn
            // 
            this.addNoteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addNoteBtn.Enabled = false;
            this.addNoteBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNoteBtn.Image = ((System.Drawing.Image)(resources.GetObject("addNoteBtn.Image")));
            this.addNoteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNoteBtn.Name = "addNoteBtn";
            this.addNoteBtn.Size = new System.Drawing.Size(172, 35);
            this.addNoteBtn.Text = "📝 ADD NOTE";
            this.addNoteBtn.Click += new System.EventHandler(this.addNoteBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(111, 35);
            this.infoBtn.Text = "ℹ INFO";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightPanel.Controls.Add(this.bottomTreeToolStrip);
            this.rightPanel.Controls.Add(this.diversTreeView);
            this.rightPanel.Controls.Add(this.rightToolStrip);
            this.rightPanel.Location = new System.Drawing.Point(649, 41);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(345, 472);
            this.rightPanel.TabIndex = 3;
            // 
            // bottomTreeToolStrip
            // 
            this.bottomTreeToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomTreeToolStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bottomTreeToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bottomTreeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tree_isDstBtn,
            this.tree_isAzmBtn,
            this.tree_isRazBtn,
            this.toolStripSeparator14,
            this.tree_isLatLonBtn,
            this.toolStripSeparator15,
            this.tree_isRerBtn,
            this.toolStripSeparator16,
            this.tree_isDopTbaBtn});
            this.bottomTreeToolStrip.Location = new System.Drawing.Point(0, 442);
            this.bottomTreeToolStrip.Name = "bottomTreeToolStrip";
            this.bottomTreeToolStrip.Size = new System.Drawing.Size(345, 30);
            this.bottomTreeToolStrip.TabIndex = 2;
            this.bottomTreeToolStrip.Text = "toolStrip1";
            // 
            // tree_isDstBtn
            // 
            this.tree_isDstBtn.Checked = true;
            this.tree_isDstBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tree_isDstBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tree_isDstBtn.Image = ((System.Drawing.Image)(resources.GetObject("tree_isDstBtn.Image")));
            this.tree_isDstBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree_isDstBtn.Name = "tree_isDstBtn";
            this.tree_isDstBtn.Size = new System.Drawing.Size(44, 27);
            this.tree_isDstBtn.Text = "DST";
            this.tree_isDstBtn.ToolTipText = "Show/Hide DISTANCE to divers";
            this.tree_isDstBtn.Click += new System.EventHandler(this.tree_isDstBtn_Click);
            // 
            // tree_isAzmBtn
            // 
            this.tree_isAzmBtn.Checked = true;
            this.tree_isAzmBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tree_isAzmBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tree_isAzmBtn.Image = ((System.Drawing.Image)(resources.GetObject("tree_isAzmBtn.Image")));
            this.tree_isAzmBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree_isAzmBtn.Name = "tree_isAzmBtn";
            this.tree_isAzmBtn.Size = new System.Drawing.Size(50, 27);
            this.tree_isAzmBtn.Text = "AZM";
            this.tree_isAzmBtn.ToolTipText = "Show/Hide AZIMUTH to divers";
            this.tree_isAzmBtn.Click += new System.EventHandler(this.tree_isAzmBtn_Click);
            // 
            // tree_isRazBtn
            // 
            this.tree_isRazBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tree_isRazBtn.Image = ((System.Drawing.Image)(resources.GetObject("tree_isRazBtn.Image")));
            this.tree_isRazBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree_isRazBtn.Name = "tree_isRazBtn";
            this.tree_isRazBtn.Size = new System.Drawing.Size(45, 27);
            this.tree_isRazBtn.Text = "RAZ";
            this.tree_isRazBtn.ToolTipText = "Show/Hide REVERSE AZIMUTH to divers";
            this.tree_isRazBtn.Click += new System.EventHandler(this.tree_isRazBtn_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 30);
            // 
            // tree_isLatLonBtn
            // 
            this.tree_isLatLonBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tree_isLatLonBtn.Image = ((System.Drawing.Image)(resources.GetObject("tree_isLatLonBtn.Image")));
            this.tree_isLatLonBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree_isLatLonBtn.Name = "tree_isLatLonBtn";
            this.tree_isLatLonBtn.Size = new System.Drawing.Size(45, 27);
            this.tree_isLatLonBtn.Text = "LOC";
            this.tree_isLatLonBtn.ToolTipText = "Show/Hide divers LOCATION";
            this.tree_isLatLonBtn.Click += new System.EventHandler(this.tree_isLatLonBtn_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 30);
            // 
            // tree_isRerBtn
            // 
            this.tree_isRerBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tree_isRerBtn.Image = ((System.Drawing.Image)(resources.GetObject("tree_isRerBtn.Image")));
            this.tree_isRerBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree_isRerBtn.Name = "tree_isRerBtn";
            this.tree_isRerBtn.Size = new System.Drawing.Size(43, 27);
            this.tree_isRerBtn.Text = "RER";
            this.tree_isRerBtn.ToolTipText = "Show/Hide RADIAL ERROR of calculated positions";
            this.tree_isRerBtn.Click += new System.EventHandler(this.tree_isRerBtn_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 30);
            // 
            // tree_isDopTbaBtn
            // 
            this.tree_isDopTbaBtn.Checked = true;
            this.tree_isDopTbaBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tree_isDopTbaBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tree_isDopTbaBtn.Image = ((System.Drawing.Image)(resources.GetObject("tree_isDopTbaBtn.Image")));
            this.tree_isDopTbaBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tree_isDopTbaBtn.Name = "tree_isDopTbaBtn";
            this.tree_isDopTbaBtn.Size = new System.Drawing.Size(49, 27);
            this.tree_isDopTbaBtn.Text = "DOP";
            this.tree_isDopTbaBtn.ToolTipText = "Show/Hide DILUTION OF PRECISION and TARGET-TO-BASE ARRANGEMENT quality";
            this.tree_isDopTbaBtn.Click += new System.EventHandler(this.tree_isDopTbaBtn_Click);
            // 
            // diversTreeView
            // 
            this.diversTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diversTreeView.BackColor = System.Drawing.Color.LightCyan;
            this.diversTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diversTreeView.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diversTreeView.Location = new System.Drawing.Point(3, 38);
            this.diversTreeView.Name = "diversTreeView";
            this.diversTreeView.Size = new System.Drawing.Size(339, 396);
            this.diversTreeView.TabIndex = 1;
            // 
            // rightToolStrip
            // 
            this.rightToolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rightToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.expandTreeBtn,
            this.collapseTreeBtn,
            this.sortTreeBtn});
            this.rightToolStrip.Location = new System.Drawing.Point(0, 0);
            this.rightToolStrip.Name = "rightToolStrip";
            this.rightToolStrip.Size = new System.Drawing.Size(345, 35);
            this.rightToolStrip.TabIndex = 0;
            this.rightToolStrip.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(112, 32);
            this.toolStripLabel1.Text = "🤿 DIVERS:";
            // 
            // expandTreeBtn
            // 
            this.expandTreeBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.expandTreeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.expandTreeBtn.Image = ((System.Drawing.Image)(resources.GetObject("expandTreeBtn.Image")));
            this.expandTreeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.expandTreeBtn.Name = "expandTreeBtn";
            this.expandTreeBtn.Size = new System.Drawing.Size(33, 32);
            this.expandTreeBtn.Text = "▲";
            this.expandTreeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.expandTreeBtn.ToolTipText = "Exapnd tree";
            this.expandTreeBtn.Click += new System.EventHandler(this.expandTreeBtn_Click);
            // 
            // collapseTreeBtn
            // 
            this.collapseTreeBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.collapseTreeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.collapseTreeBtn.Image = ((System.Drawing.Image)(resources.GetObject("collapseTreeBtn.Image")));
            this.collapseTreeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collapseTreeBtn.Name = "collapseTreeBtn";
            this.collapseTreeBtn.Size = new System.Drawing.Size(33, 32);
            this.collapseTreeBtn.Text = "▼";
            this.collapseTreeBtn.ToolTipText = "Collapse tree";
            this.collapseTreeBtn.Click += new System.EventHandler(this.collapseTreeBtn_Click);
            // 
            // sortTreeBtn
            // 
            this.sortTreeBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sortTreeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sortTreeBtn.Image = ((System.Drawing.Image)(resources.GetObject("sortTreeBtn.Image")));
            this.sortTreeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortTreeBtn.Name = "sortTreeBtn";
            this.sortTreeBtn.Size = new System.Drawing.Size(43, 32);
            this.sortTreeBtn.Text = "🎢";
            this.sortTreeBtn.ToolTipText = "Sort tree";
            this.sortTreeBtn.Click += new System.EventHandler(this.sortTreeBtn_Click);
            // 
            // plotToolStrip
            // 
            this.plotToolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.plotToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basesVisibleBtn,
            this.toolStripSeparator5,
            this.logVisibleBtn,
            this.toolStripSeparator6,
            this.legendVisibleBtn,
            this.toolStripSeparator7,
            this.notesVisibleBtn,
            this.toolStripSeparator9,
            this.miscInfoVisibleBtn,
            this.toolStripSeparator8,
            this.resetViewBtn,
            this.toolStripSeparator13});
            this.plotToolStrip.Location = new System.Drawing.Point(0, 0);
            this.plotToolStrip.Name = "plotToolStrip";
            this.plotToolStrip.Size = new System.Drawing.Size(631, 35);
            this.plotToolStrip.TabIndex = 0;
            this.plotToolStrip.Text = "toolStrip1";
            // 
            // basesVisibleBtn
            // 
            this.basesVisibleBtn.Checked = true;
            this.basesVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.basesVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.basesVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("basesVisibleBtn.Image")));
            this.basesVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.basesVisibleBtn.Name = "basesVisibleBtn";
            this.basesVisibleBtn.Size = new System.Drawing.Size(36, 32);
            this.basesVisibleBtn.Text = "⛯";
            this.basesVisibleBtn.ToolTipText = "Show/Hide bases on the map";
            this.basesVisibleBtn.Click += new System.EventHandler(this.basesVisibleBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
            // 
            // logVisibleBtn
            // 
            this.logVisibleBtn.Checked = true;
            this.logVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("logVisibleBtn.Image")));
            this.logVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logVisibleBtn.Name = "logVisibleBtn";
            this.logVisibleBtn.Size = new System.Drawing.Size(43, 32);
            this.logVisibleBtn.Text = "📜";
            this.logVisibleBtn.ToolTipText = "Show/Hide log in the left-bottom corner";
            this.logVisibleBtn.Click += new System.EventHandler(this.logVisibleBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 35);
            // 
            // legendVisibleBtn
            // 
            this.legendVisibleBtn.Checked = true;
            this.legendVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.legendVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.legendVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("legendVisibleBtn.Image")));
            this.legendVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.legendVisibleBtn.Name = "legendVisibleBtn";
            this.legendVisibleBtn.Size = new System.Drawing.Size(29, 32);
            this.legendVisibleBtn.Text = "⋮";
            this.legendVisibleBtn.ToolTipText = "Show/Hide tracks legend";
            this.legendVisibleBtn.Click += new System.EventHandler(this.legendVisibleBtn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 35);
            // 
            // notesVisibleBtn
            // 
            this.notesVisibleBtn.Checked = true;
            this.notesVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notesVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.notesVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("notesVisibleBtn.Image")));
            this.notesVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.notesVisibleBtn.Name = "notesVisibleBtn";
            this.notesVisibleBtn.Size = new System.Drawing.Size(42, 32);
            this.notesVisibleBtn.Text = "📑";
            this.notesVisibleBtn.ToolTipText = "Show/Hide manual notes";
            this.notesVisibleBtn.Click += new System.EventHandler(this.notesVisibleBtn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 35);
            // 
            // miscInfoVisibleBtn
            // 
            this.miscInfoVisibleBtn.Checked = true;
            this.miscInfoVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miscInfoVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miscInfoVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("miscInfoVisibleBtn.Image")));
            this.miscInfoVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miscInfoVisibleBtn.Name = "miscInfoVisibleBtn";
            this.miscInfoVisibleBtn.Size = new System.Drawing.Size(41, 32);
            this.miscInfoVisibleBtn.Text = "👽";
            this.miscInfoVisibleBtn.ToolTipText = "Show/Hide extra information in the left-top corner (Own location, speed, course, " +
    "water temperature, salinity, speed of sound)";
            this.miscInfoVisibleBtn.Click += new System.EventHandler(this.miscInfoVisibleBtn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 35);
            // 
            // resetViewBtn
            // 
            this.resetViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("resetViewBtn.Image")));
            this.resetViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetViewBtn.Name = "resetViewBtn";
            this.resetViewBtn.Size = new System.Drawing.Size(150, 32);
            this.resetViewBtn.Text = "♻ RESET VIEW";
            this.resetViewBtn.ToolTipText = "Clear visible tracks";
            this.resetViewBtn.Click += new System.EventHandler(this.resetViewBtn_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 35);
            // 
            // plotPanel
            // 
            this.plotPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotPanel.Controls.Add(this.uMapPlot);
            this.plotPanel.Controls.Add(this.plotToolStrip);
            this.plotPanel.Location = new System.Drawing.Point(12, 41);
            this.plotPanel.Name = "plotPanel";
            this.plotPanel.Size = new System.Drawing.Size(631, 475);
            this.plotPanel.TabIndex = 2;
            // 
            // uMapPlot
            // 
            this.uMapPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uMapPlot.BackColor = System.Drawing.Color.Honeydew;
            this.uMapPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uMapPlot.HistoryLinesNumber = 4;
            this.uMapPlot.HistoryTextColor = System.Drawing.Color.SeaGreen;
            this.uMapPlot.HistoryTextFont = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.HistoryVisible = true;
            this.uMapPlot.LeftUpperText = null;
            this.uMapPlot.LeftUpperTextColor = System.Drawing.Color.Black;
            this.uMapPlot.LeftUpperTextFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.LeftUpperTextVisible = true;
            this.uMapPlot.LegendFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.LegendVisible = true;
            this.uMapPlot.Location = new System.Drawing.Point(3, 38);
            this.uMapPlot.MaxHistoryLineLength = 127;
            this.uMapPlot.MeasurementLineColor = System.Drawing.Color.Black;
            this.uMapPlot.MeasurementTextBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uMapPlot.MeasurementTextColor = System.Drawing.Color.Black;
            this.uMapPlot.MeasurementTextFont = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.Name = "uMapPlot";
            this.uMapPlot.Padding = new System.Windows.Forms.Padding(11, 14, 11, 14);
            this.uMapPlot.RightUpperTextBackgoundColor = System.Drawing.Color.Transparent;
            this.uMapPlot.RightUpperTextColor = System.Drawing.Color.DarkSlateGray;
            this.uMapPlot.RightUpperTextFont = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.RightUpperTextVisible = true;
            this.uMapPlot.ScaleLineColor = System.Drawing.Color.Black;
            this.uMapPlot.ScaleLineFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.Size = new System.Drawing.Size(625, 434);
            this.uMapPlot.TabIndex = 1;
            this.uMapPlot.TextBackgroundColor = System.Drawing.Color.White;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 553);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.plotPanel);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "🤿 uTrackDiver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.bottomTreeToolStrip.ResumeLayout(false);
            this.bottomTreeToolStrip.PerformLayout();
            this.rightToolStrip.ResumeLayout(false);
            this.rightToolStrip.PerformLayout();
            this.plotToolStrip.ResumeLayout(false);
            this.plotToolStrip.PerformLayout();
            this.plotPanel.ResumeLayout(false);
            this.plotPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton linkBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton logBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton utilsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox addNoteTxb;
        private System.Windows.Forms.ToolStripButton addNoteBtn;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.ToolStrip rightToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TreeView diversTreeView;
        private System.Windows.Forms.ToolStripButton expandTreeBtn;
        private System.Windows.Forms.ToolStripButton collapseTreeBtn;
        private System.Windows.Forms.ToolStripMenuItem logViewCurrentBtn;
        private System.Windows.Forms.ToolStripMenuItem logPlaybackBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem logRemoveEmptyEntriesBtn;
        private System.Windows.Forms.ToolStripMenuItem logClearAllBtn;
        private System.Windows.Forms.ToolStripMenuItem utilsTracksBtn;
        private System.Windows.Forms.ToolStripMenuItem trackExportBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem trackClearBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStrip plotToolStrip;
        private System.Windows.Forms.ToolStripButton basesVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton logVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton legendVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton notesVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton miscInfoVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton resetViewBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.Panel plotPanel;
        private UCNLUI.Controls.uOSMGeoPlot uMapPlot;
        private System.Windows.Forms.ToolStripStatusLabel rwltPortStatusLbl;
        private System.Windows.Forms.ToolStripStatusLabel auxGNSSPortStatusLbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton sortTreeBtn;
        private System.Windows.Forms.ToolStrip bottomTreeToolStrip;
        private System.Windows.Forms.ToolStripButton tree_isDstBtn;
        private System.Windows.Forms.ToolStripButton tree_isAzmBtn;
        private System.Windows.Forms.ToolStripButton tree_isRazBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton tree_isLatLonBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton tree_isRerBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton tree_isDopTbaBtn;
    }
}

