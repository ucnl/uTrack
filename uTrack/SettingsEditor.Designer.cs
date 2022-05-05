namespace uTrack
{
    partial class SettingsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.setDefaultsBtn = new System.Windows.Forms.Button();
            this.isUseAUXGNSSChb = new System.Windows.Forms.CheckBox();
            this.auxGNSSGroup = new System.Windows.Forms.GroupBox();
            this.auxGNSSBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.isBase1AsAUXGNSSChb = new System.Windows.Forms.CheckBox();
            this.isAutoSalinityChb = new System.Windows.Forms.CheckBox();
            this.salinityGroup = new System.Windows.Forms.GroupBox();
            this.salinityEdit = new System.Windows.Forms.NumericUpDown();
            this.speedOfSoundGroup = new System.Windows.Forms.GroupBox();
            this.speedOfSoundEdit = new System.Windows.Forms.NumericUpDown();
            this.isAutoSpeedOfSoundChb = new System.Windows.Forms.CheckBox();
            this.trackGroup = new System.Windows.Forms.GroupBox();
            this.trackPointNumberEdit = new System.Windows.Forms.NumericUpDown();
            this.rerGroup = new System.Windows.Forms.GroupBox();
            this.rerThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.tilesServersGroup = new System.Windows.Forms.GroupBox();
            this.tileServersTxb = new System.Windows.Forms.RichTextBox();
            this.tileSizeGroup = new System.Windows.Forms.GroupBox();
            this.tileSizeCbx = new System.Windows.Forms.ComboBox();
            this.auxGNSSGroup.SuspendLayout();
            this.salinityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).BeginInit();
            this.speedOfSoundGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSoundEdit)).BeginInit();
            this.trackGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackPointNumberEdit)).BeginInit();
            this.rerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rerThresholdEdit)).BeginInit();
            this.tilesServersGroup.SuspendLayout();
            this.tileSizeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.Location = new System.Drawing.Point(380, 492);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(157, 49);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(560, 492);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(157, 49);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // setDefaultsBtn
            // 
            this.setDefaultsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setDefaultsBtn.Location = new System.Drawing.Point(12, 492);
            this.setDefaultsBtn.Name = "setDefaultsBtn";
            this.setDefaultsBtn.Size = new System.Drawing.Size(157, 49);
            this.setDefaultsBtn.TabIndex = 2;
            this.setDefaultsBtn.Text = "SET DEFAULTS";
            this.setDefaultsBtn.UseVisualStyleBackColor = true;
            this.setDefaultsBtn.Click += new System.EventHandler(this.setDefaultsBtn_Click);
            // 
            // isUseAUXGNSSChb
            // 
            this.isUseAUXGNSSChb.AutoSize = true;
            this.isUseAUXGNSSChb.Location = new System.Drawing.Point(12, 12);
            this.isUseAUXGNSSChb.Name = "isUseAUXGNSSChb";
            this.isUseAUXGNSSChb.Size = new System.Drawing.Size(146, 27);
            this.isUseAUXGNSSChb.TabIndex = 3;
            this.isUseAUXGNSSChb.Text = "Use AUX GNSS";
            this.isUseAUXGNSSChb.UseVisualStyleBackColor = true;
            this.isUseAUXGNSSChb.CheckedChanged += new System.EventHandler(this.isUseAUXGNSSChb_CheckedChanged);
            // 
            // auxGNSSGroup
            // 
            this.auxGNSSGroup.Controls.Add(this.auxGNSSBaudrateCbx);
            this.auxGNSSGroup.Enabled = false;
            this.auxGNSSGroup.Location = new System.Drawing.Point(12, 45);
            this.auxGNSSGroup.Name = "auxGNSSGroup";
            this.auxGNSSGroup.Size = new System.Drawing.Size(240, 73);
            this.auxGNSSGroup.TabIndex = 4;
            this.auxGNSSGroup.TabStop = false;
            this.auxGNSSGroup.Text = "AUX GNSS Port baudrate";
            // 
            // auxGNSSBaudrateCbx
            // 
            this.auxGNSSBaudrateCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.auxGNSSBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.auxGNSSBaudrateCbx.FormattingEnabled = true;
            this.auxGNSSBaudrateCbx.Location = new System.Drawing.Point(6, 36);
            this.auxGNSSBaudrateCbx.Name = "auxGNSSBaudrateCbx";
            this.auxGNSSBaudrateCbx.Size = new System.Drawing.Size(224, 31);
            this.auxGNSSBaudrateCbx.TabIndex = 0;
            // 
            // isBase1AsAUXGNSSChb
            // 
            this.isBase1AsAUXGNSSChb.AutoSize = true;
            this.isBase1AsAUXGNSSChb.Location = new System.Drawing.Point(12, 136);
            this.isBase1AsAUXGNSSChb.Name = "isBase1AsAUXGNSSChb";
            this.isBase1AsAUXGNSSChb.Size = new System.Drawing.Size(245, 27);
            this.isBase1AsAUXGNSSChb.TabIndex = 5;
            this.isBase1AsAUXGNSSChb.Text = "Base 1 as AUX GNSS Source";
            this.isBase1AsAUXGNSSChb.UseVisualStyleBackColor = true;
            this.isBase1AsAUXGNSSChb.CheckedChanged += new System.EventHandler(this.isBase1AsAUXGNSSChb_CheckedChanged);
            // 
            // isAutoSalinityChb
            // 
            this.isAutoSalinityChb.AutoSize = true;
            this.isAutoSalinityChb.Checked = true;
            this.isAutoSalinityChb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutoSalinityChb.Location = new System.Drawing.Point(270, 12);
            this.isAutoSalinityChb.Name = "isAutoSalinityChb";
            this.isAutoSalinityChb.Size = new System.Drawing.Size(126, 27);
            this.isAutoSalinityChb.TabIndex = 6;
            this.isAutoSalinityChb.Text = "Auto salinity";
            this.isAutoSalinityChb.UseVisualStyleBackColor = true;
            this.isAutoSalinityChb.CheckedChanged += new System.EventHandler(this.isAutoSalinityChb_CheckedChanged);
            // 
            // salinityGroup
            // 
            this.salinityGroup.Controls.Add(this.salinityEdit);
            this.salinityGroup.Enabled = false;
            this.salinityGroup.Location = new System.Drawing.Point(270, 45);
            this.salinityGroup.Name = "salinityGroup";
            this.salinityGroup.Size = new System.Drawing.Size(230, 73);
            this.salinityGroup.TabIndex = 5;
            this.salinityGroup.TabStop = false;
            this.salinityGroup.Text = "Salinity, PSU";
            this.salinityGroup.UseCompatibleTextRendering = true;
            // 
            // salinityEdit
            // 
            this.salinityEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.salinityEdit.DecimalPlaces = 1;
            this.salinityEdit.Location = new System.Drawing.Point(6, 37);
            this.salinityEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.salinityEdit.Name = "salinityEdit";
            this.salinityEdit.Size = new System.Drawing.Size(218, 30);
            this.salinityEdit.TabIndex = 0;
            // 
            // speedOfSoundGroup
            // 
            this.speedOfSoundGroup.Controls.Add(this.speedOfSoundEdit);
            this.speedOfSoundGroup.Enabled = false;
            this.speedOfSoundGroup.Location = new System.Drawing.Point(270, 169);
            this.speedOfSoundGroup.Name = "speedOfSoundGroup";
            this.speedOfSoundGroup.Size = new System.Drawing.Size(230, 73);
            this.speedOfSoundGroup.TabIndex = 7;
            this.speedOfSoundGroup.TabStop = false;
            this.speedOfSoundGroup.Text = "Speed of sound, m/s";
            this.speedOfSoundGroup.UseCompatibleTextRendering = true;
            // 
            // speedOfSoundEdit
            // 
            this.speedOfSoundEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedOfSoundEdit.DecimalPlaces = 1;
            this.speedOfSoundEdit.Location = new System.Drawing.Point(6, 37);
            this.speedOfSoundEdit.Maximum = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            this.speedOfSoundEdit.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.speedOfSoundEdit.Name = "speedOfSoundEdit";
            this.speedOfSoundEdit.Size = new System.Drawing.Size(218, 30);
            this.speedOfSoundEdit.TabIndex = 0;
            this.speedOfSoundEdit.Value = new decimal(new int[] {
            1450,
            0,
            0,
            0});
            // 
            // isAutoSpeedOfSoundChb
            // 
            this.isAutoSpeedOfSoundChb.AutoSize = true;
            this.isAutoSpeedOfSoundChb.Location = new System.Drawing.Point(270, 136);
            this.isAutoSpeedOfSoundChb.Name = "isAutoSpeedOfSoundChb";
            this.isAutoSpeedOfSoundChb.Size = new System.Drawing.Size(191, 27);
            this.isAutoSpeedOfSoundChb.TabIndex = 8;
            this.isAutoSpeedOfSoundChb.Text = "Auto speed of sound";
            this.isAutoSpeedOfSoundChb.UseVisualStyleBackColor = true;
            this.isAutoSpeedOfSoundChb.CheckedChanged += new System.EventHandler(this.isAutoSpeedOfSoundChb_CheckedChanged);
            // 
            // trackGroup
            // 
            this.trackGroup.Controls.Add(this.trackPointNumberEdit);
            this.trackGroup.Location = new System.Drawing.Point(510, 250);
            this.trackGroup.Name = "trackGroup";
            this.trackGroup.Size = new System.Drawing.Size(207, 73);
            this.trackGroup.TabIndex = 6;
            this.trackGroup.TabStop = false;
            this.trackGroup.Text = "Track points to show";
            this.trackGroup.UseCompatibleTextRendering = true;
            // 
            // trackPointNumberEdit
            // 
            this.trackPointNumberEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackPointNumberEdit.Location = new System.Drawing.Point(6, 37);
            this.trackPointNumberEdit.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.trackPointNumberEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackPointNumberEdit.Name = "trackPointNumberEdit";
            this.trackPointNumberEdit.Size = new System.Drawing.Size(195, 30);
            this.trackPointNumberEdit.TabIndex = 0;
            this.trackPointNumberEdit.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // rerGroup
            // 
            this.rerGroup.Controls.Add(this.rerThresholdEdit);
            this.rerGroup.Location = new System.Drawing.Point(270, 250);
            this.rerGroup.Name = "rerGroup";
            this.rerGroup.Size = new System.Drawing.Size(230, 73);
            this.rerGroup.TabIndex = 7;
            this.rerGroup.TabStop = false;
            this.rerGroup.Text = "Radial error threshold, m";
            this.rerGroup.UseCompatibleTextRendering = true;
            // 
            // rerThresholdEdit
            // 
            this.rerThresholdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rerThresholdEdit.Location = new System.Drawing.Point(6, 37);
            this.rerThresholdEdit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.rerThresholdEdit.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.rerThresholdEdit.Name = "rerThresholdEdit";
            this.rerThresholdEdit.Size = new System.Drawing.Size(218, 30);
            this.rerThresholdEdit.TabIndex = 0;
            this.rerThresholdEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tilesServersGroup
            // 
            this.tilesServersGroup.Controls.Add(this.tileServersTxb);
            this.tilesServersGroup.Location = new System.Drawing.Point(12, 346);
            this.tilesServersGroup.Name = "tilesServersGroup";
            this.tilesServersGroup.Size = new System.Drawing.Size(307, 117);
            this.tilesServersGroup.TabIndex = 8;
            this.tilesServersGroup.TabStop = false;
            this.tilesServersGroup.Text = "Tile servers";
            this.tilesServersGroup.UseCompatibleTextRendering = true;
            // 
            // tileServersTxb
            // 
            this.tileServersTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileServersTxb.Location = new System.Drawing.Point(6, 29);
            this.tileServersTxb.Name = "tileServersTxb";
            this.tileServersTxb.Size = new System.Drawing.Size(295, 82);
            this.tileServersTxb.TabIndex = 0;
            this.tileServersTxb.Text = "https://a.tile.openstreetmap.org\nhttps://b.tile.openstreetmap.org\nhttps://c.tile." +
    "openstreetmap.org";
            // 
            // tileSizeGroup
            // 
            this.tileSizeGroup.Controls.Add(this.tileSizeCbx);
            this.tileSizeGroup.Location = new System.Drawing.Point(325, 346);
            this.tileSizeGroup.Name = "tileSizeGroup";
            this.tileSizeGroup.Size = new System.Drawing.Size(175, 70);
            this.tileSizeGroup.TabIndex = 9;
            this.tileSizeGroup.TabStop = false;
            this.tileSizeGroup.Text = "Tile size";
            this.tileSizeGroup.UseCompatibleTextRendering = true;
            // 
            // tileSizeCbx
            // 
            this.tileSizeCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileSizeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tileSizeCbx.FormattingEnabled = true;
            this.tileSizeCbx.Items.AddRange(new object[] {
            "128",
            "256",
            "512"});
            this.tileSizeCbx.Location = new System.Drawing.Point(6, 33);
            this.tileSizeCbx.Name = "tileSizeCbx";
            this.tileSizeCbx.Size = new System.Drawing.Size(163, 31);
            this.tileSizeCbx.TabIndex = 1;
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 553);
            this.Controls.Add(this.tileSizeGroup);
            this.Controls.Add(this.tilesServersGroup);
            this.Controls.Add(this.rerGroup);
            this.Controls.Add(this.trackGroup);
            this.Controls.Add(this.speedOfSoundGroup);
            this.Controls.Add(this.isAutoSpeedOfSoundChb);
            this.Controls.Add(this.salinityGroup);
            this.Controls.Add(this.isAutoSalinityChb);
            this.Controls.Add(this.isBase1AsAUXGNSSChb);
            this.Controls.Add(this.auxGNSSGroup);
            this.Controls.Add(this.isUseAUXGNSSChb);
            this.Controls.Add(this.setDefaultsBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsEditor";
            this.ShowIcon = false;
            this.Text = "SettingsEditor";
            this.auxGNSSGroup.ResumeLayout(false);
            this.salinityGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).EndInit();
            this.speedOfSoundGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSoundEdit)).EndInit();
            this.trackGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackPointNumberEdit)).EndInit();
            this.rerGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rerThresholdEdit)).EndInit();
            this.tilesServersGroup.ResumeLayout(false);
            this.tileSizeGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button setDefaultsBtn;
        private System.Windows.Forms.CheckBox isUseAUXGNSSChb;
        private System.Windows.Forms.GroupBox auxGNSSGroup;
        private System.Windows.Forms.ComboBox auxGNSSBaudrateCbx;
        private System.Windows.Forms.CheckBox isBase1AsAUXGNSSChb;
        private System.Windows.Forms.CheckBox isAutoSalinityChb;
        private System.Windows.Forms.GroupBox salinityGroup;
        private System.Windows.Forms.GroupBox speedOfSoundGroup;
        private System.Windows.Forms.NumericUpDown speedOfSoundEdit;
        private System.Windows.Forms.CheckBox isAutoSpeedOfSoundChb;
        private System.Windows.Forms.GroupBox trackGroup;
        private System.Windows.Forms.NumericUpDown trackPointNumberEdit;
        private System.Windows.Forms.GroupBox rerGroup;
        private System.Windows.Forms.NumericUpDown rerThresholdEdit;
        private System.Windows.Forms.GroupBox tilesServersGroup;
        private System.Windows.Forms.RichTextBox tileServersTxb;
        private System.Windows.Forms.GroupBox tileSizeGroup;
        private System.Windows.Forms.NumericUpDown salinityEdit;
        private System.Windows.Forms.ComboBox tileSizeCbx;
    }
}