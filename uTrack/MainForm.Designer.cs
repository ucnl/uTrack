namespace uTrack
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
            this.plotToolStrip = new System.Windows.Forms.ToolStrip();
            this.basesVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.logVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.legendVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.notesVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.miscInfoVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.resetViewBtn = new System.Windows.Forms.ToolStripButton();
            this.isLocBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.isDptBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.isBatBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.isTbaDopBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.isDstBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.isAzmBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.isCrsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.isRazBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.printScreenBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.rwltPortStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.auxGNSSPortStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.logLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uMapPlot = new UCNLUI.Controls.uOSMGeoPlot();
            this.mainToolStrip.SuspendLayout();
            this.plotToolStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
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
            this.toolStripLabel1,
            this.toolStripSeparator13,
            this.miscInfoVisibleBtn,
            this.toolStripSeparator8,
            this.resetViewBtn,
            this.isLocBtn,
            this.toolStripSeparator15,
            this.isDptBtn,
            this.toolStripSeparator16,
            this.isBatBtn,
            this.toolStripSeparator17,
            this.isTbaDopBtn,
            this.toolStripSeparator18,
            this.isDstBtn,
            this.toolStripSeparator19,
            this.isAzmBtn,
            this.toolStripSeparator20,
            this.isCrsBtn,
            this.toolStripSeparator21,
            this.isRazBtn,
            this.toolStripSeparator14,
            this.toolStripLabel2,
            this.toolStripSeparator22,
            this.printScreenBtn,
            this.toolStripSeparator23});
            this.plotToolStrip.Location = new System.Drawing.Point(0, 38);
            this.plotToolStrip.Name = "plotToolStrip";
            this.plotToolStrip.Size = new System.Drawing.Size(1006, 35);
            this.plotToolStrip.TabIndex = 1;
            this.plotToolStrip.Text = "toolStrip2";
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
            this.logVisibleBtn.ToolTipText = "Show/Hide log ";
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
            this.legendVisibleBtn.ToolTipText = "Show/Hide legend";
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
            this.notesVisibleBtn.ToolTipText = "Show/Hide notes";
            this.notesVisibleBtn.Click += new System.EventHandler(this.notesVisibleBtn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(17, 32);
            this.toolStripLabel1.Text = " ";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 35);
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
            this.miscInfoVisibleBtn.ToolTipText = "Show/Hide extra information";
            this.miscInfoVisibleBtn.Click += new System.EventHandler(this.miscInfoVisibleBtn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 35);
            // 
            // resetViewBtn
            // 
            this.resetViewBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.resetViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("resetViewBtn.Image")));
            this.resetViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetViewBtn.Name = "resetViewBtn";
            this.resetViewBtn.Size = new System.Drawing.Size(150, 32);
            this.resetViewBtn.Text = "♻ RESET VIEW";
            this.resetViewBtn.ToolTipText = "Clear visible tracks";
            this.resetViewBtn.Click += new System.EventHandler(this.resetViewBtn_Click);
            // 
            // isLocBtn
            // 
            this.isLocBtn.Checked = true;
            this.isLocBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isLocBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isLocBtn.Image = ((System.Drawing.Image)(resources.GetObject("isLocBtn.Image")));
            this.isLocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isLocBtn.Name = "isLocBtn";
            this.isLocBtn.Size = new System.Drawing.Size(51, 32);
            this.isLocBtn.Text = "LOC";
            this.isLocBtn.ToolTipText = "Show/hide pinger coordinates and radial error";
            this.isLocBtn.Click += new System.EventHandler(this.isLocBtn_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 35);
            // 
            // isDptBtn
            // 
            this.isDptBtn.Checked = true;
            this.isDptBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isDptBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isDptBtn.Image = ((System.Drawing.Image)(resources.GetObject("isDptBtn.Image")));
            this.isDptBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isDptBtn.Name = "isDptBtn";
            this.isDptBtn.Size = new System.Drawing.Size(51, 32);
            this.isDptBtn.Text = "DPT";
            this.isDptBtn.ToolTipText = "Show/hide depth of the pinger";
            this.isDptBtn.Click += new System.EventHandler(this.isDptBtn_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 35);
            // 
            // isBatBtn
            // 
            this.isBatBtn.Checked = true;
            this.isBatBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isBatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isBatBtn.Image = ((System.Drawing.Image)(resources.GetObject("isBatBtn.Image")));
            this.isBatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isBatBtn.Name = "isBatBtn";
            this.isBatBtn.Size = new System.Drawing.Size(49, 32);
            this.isBatBtn.Text = "BAT";
            this.isBatBtn.ToolTipText = "Show/hide pinger\'s battery voltage";
            this.isBatBtn.Click += new System.EventHandler(this.isBatBtn_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 35);
            // 
            // isTbaDopBtn
            // 
            this.isTbaDopBtn.Checked = true;
            this.isTbaDopBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isTbaDopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isTbaDopBtn.Image = ((System.Drawing.Image)(resources.GetObject("isTbaDopBtn.Image")));
            this.isTbaDopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isTbaDopBtn.Name = "isTbaDopBtn";
            this.isTbaDopBtn.Size = new System.Drawing.Size(98, 32);
            this.isTbaDopBtn.Text = "TBA/DOP";
            this.isTbaDopBtn.ToolTipText = "Show/hide pinger-to-base arrangement quality and horizontal dilution of precision" +
    "";
            this.isTbaDopBtn.Click += new System.EventHandler(this.isTbaDopBtn_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 35);
            // 
            // isDstBtn
            // 
            this.isDstBtn.Checked = true;
            this.isDstBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isDstBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isDstBtn.Image = ((System.Drawing.Image)(resources.GetObject("isDstBtn.Image")));
            this.isDstBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isDstBtn.Name = "isDstBtn";
            this.isDstBtn.Size = new System.Drawing.Size(51, 32);
            this.isDstBtn.Text = "DST";
            this.isDstBtn.ToolTipText = "Show/hide distance to the pinger";
            this.isDstBtn.Click += new System.EventHandler(this.isDstBtn_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 35);
            // 
            // isAzmBtn
            // 
            this.isAzmBtn.Checked = true;
            this.isAzmBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAzmBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isAzmBtn.Image = ((System.Drawing.Image)(resources.GetObject("isAzmBtn.Image")));
            this.isAzmBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isAzmBtn.Name = "isAzmBtn";
            this.isAzmBtn.Size = new System.Drawing.Size(59, 32);
            this.isAzmBtn.Text = "AZM";
            this.isAzmBtn.ToolTipText = "Show/hide the azimuth to the pinger";
            this.isAzmBtn.Click += new System.EventHandler(this.isAzmBtn_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 35);
            // 
            // isCrsBtn
            // 
            this.isCrsBtn.Checked = true;
            this.isCrsBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isCrsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isCrsBtn.Image = ((System.Drawing.Image)(resources.GetObject("isCrsBtn.Image")));
            this.isCrsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isCrsBtn.Name = "isCrsBtn";
            this.isCrsBtn.Size = new System.Drawing.Size(51, 32);
            this.isCrsBtn.Text = "CRS";
            this.isCrsBtn.ToolTipText = "Show/hide the course of the pinger";
            this.isCrsBtn.Click += new System.EventHandler(this.isCrsBtn_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 35);
            // 
            // isRazBtn
            // 
            this.isRazBtn.Checked = true;
            this.isRazBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isRazBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isRazBtn.Image = ((System.Drawing.Image)(resources.GetObject("isRazBtn.Image")));
            this.isRazBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isRazBtn.Name = "isRazBtn";
            this.isRazBtn.Size = new System.Drawing.Size(53, 32);
            this.isRazBtn.Text = "RAZ";
            this.isRazBtn.ToolTipText = "Show/hide homing azimuth for the pinger";
            this.isRazBtn.Click += new System.EventHandler(this.isRazBtn_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(17, 32);
            this.toolStripLabel2.Text = " ";
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 35);
            // 
            // printScreenBtn
            // 
            this.printScreenBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.printScreenBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printScreenBtn.Image = ((System.Drawing.Image)(resources.GetObject("printScreenBtn.Image")));
            this.printScreenBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printScreenBtn.Name = "printScreenBtn";
            this.printScreenBtn.Size = new System.Drawing.Size(36, 32);
            this.printScreenBtn.Text = "⎙";
            this.printScreenBtn.ToolTipText = "Save screenshot - Ctrl + S";
            this.printScreenBtn.Click += new System.EventHandler(this.printScreenBtn_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(6, 35);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rwltPortStatusLbl,
            this.toolStripStatusLabel1,
            this.auxGNSSPortStatusLbl,
            this.logLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 527);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1006, 26);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // rwltPortStatusLbl
            // 
            this.rwltPortStatusLbl.Name = "rwltPortStatusLbl";
            this.rwltPortStatusLbl.Size = new System.Drawing.Size(26, 20);
            this.rwltPortStatusLbl.Text = ". . .";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // auxGNSSPortStatusLbl
            // 
            this.auxGNSSPortStatusLbl.Name = "auxGNSSPortStatusLbl";
            this.auxGNSSPortStatusLbl.Size = new System.Drawing.Size(26, 20);
            this.auxGNSSPortStatusLbl.Text = ". . .";
            this.auxGNSSPortStatusLbl.Visible = false;
            // 
            // logLabel
            // 
            this.logLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(952, 20);
            this.logLabel.Spring = true;
            this.logLabel.Text = "...";
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
            this.uMapPlot.LegendFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.LegendVisible = true;
            this.uMapPlot.Location = new System.Drawing.Point(12, 77);
            this.uMapPlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uMapPlot.MaxHistoryLineLength = 127;
            this.uMapPlot.MeasurementLineColor = System.Drawing.Color.Black;
            this.uMapPlot.MeasurementTextBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uMapPlot.MeasurementTextColor = System.Drawing.Color.Black;
            this.uMapPlot.MeasurementTextFont = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.Name = "uMapPlot";
            this.uMapPlot.Padding = new System.Windows.Forms.Padding(12, 20, 12, 20);
            this.uMapPlot.RightUpperTextBackgoundColor = System.Drawing.Color.Transparent;
            this.uMapPlot.RightUpperTextColor = System.Drawing.Color.DarkSlateGray;
            this.uMapPlot.RightUpperTextFont = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.RightUpperTextVisible = true;
            this.uMapPlot.ScaleLineColor = System.Drawing.Color.Black;
            this.uMapPlot.ScaleLineFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uMapPlot.Size = new System.Drawing.Size(982, 450);
            this.uMapPlot.TabIndex = 3;
            this.uMapPlot.TextBackgroundColor = System.Drawing.Color.White;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 553);
            this.Controls.Add(this.uMapPlot);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.plotToolStrip);
            this.Controls.Add(this.mainToolStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "🐠 uTrack";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.plotToolStrip.ResumeLayout(false);
            this.plotToolStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStrip plotToolStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripButton linkBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton logBtn;
        private System.Windows.Forms.ToolStripMenuItem logViewCurrentBtn;
        private System.Windows.Forms.ToolStripMenuItem logPlaybackBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem logRemoveEmptyEntriesBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem logClearAllBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton utilsBtn;
        private System.Windows.Forms.ToolStripMenuItem utilsTracksBtn;
        private System.Windows.Forms.ToolStripMenuItem trackExportBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem trackClearBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox addNoteTxb;
        private System.Windows.Forms.ToolStripButton addNoteBtn;
        private System.Windows.Forms.ToolStripButton infoBtn;
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
        private UCNLUI.Controls.uOSMGeoPlot uMapPlot;
        private System.Windows.Forms.ToolStripStatusLabel rwltPortStatusLbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel auxGNSSPortStatusLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton isBatBtn;
        private System.Windows.Forms.ToolStripButton isLocBtn;
        private System.Windows.Forms.ToolStripButton isDptBtn;
        private System.Windows.Forms.ToolStripButton isTbaDopBtn;
        private System.Windows.Forms.ToolStripButton isAzmBtn;
        private System.Windows.Forms.ToolStripButton isDstBtn;
        private System.Windows.Forms.ToolStripButton isCrsBtn;
        private System.Windows.Forms.ToolStripButton isRazBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripButton printScreenBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripStatusLabel logLabel;
    }
}

