using System;
using System.Text;
using System.Windows.Forms;
using UCNLDrivers;

namespace uTrackDiver
{
    public partial class SettingsEditor : Form
    {
        #region Properties

        bool isUseAUXGNSS
        {
            get => isUseAUXGNSSChb.Checked;
            set => isUseAUXGNSSChb.Checked = value;
        }

        BaudRate AUXGNSSBaudrate
        {
            get => (BaudRate)Enum.Parse(typeof(BaudRate), auxGNSSBaudrateCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(auxGNSSBaudrateCbx, value.ToString());
        }

        bool isBase1AsAUXGNSS
        {
            get => isBase1AsAUXGNSSChb.Checked;
            set => isBase1AsAUXGNSSChb.Checked= value;
        }


        bool isAutoSalinity
        {
            get => isAutoSalinityChb.Checked;
            set => isAutoSalinityChb.Checked = value;
        }

        double salinity
        {
            get => Convert.ToDouble(salinityEdit.Value);
            set => UIHelpers.SetNumericEditValue(salinityEdit, value);
        }

        bool isAutoSoundspeed
        {
            get => isAutoSpeedOfSoundChb.Checked;
            set => isAutoSpeedOfSoundChb.Checked = value;
        }

        double soundSpeed
        {
            get => Convert.ToDouble(speedOfSoundEdit.Value);
            set => UIHelpers.SetNumericEditValue(speedOfSoundEdit, value);
        }

        double waterTemperature
        {
            get => Convert.ToDouble(waterTemperatureEdit.Value);
            set => UIHelpers.SetNumericEditValue(waterTemperatureEdit, value);
        }


        int radialErrorThreshold
        {
            get => Convert.ToInt32(rerThresholdEdit.Value);
            set => UIHelpers.SetNumericEditValue(rerThresholdEdit, value);
        }

        int trackPointsToShow
        {
            get => Convert.ToInt32(trackPointNumberEdit.Value);
            set => UIHelpers.SetNumericEditValue(trackPointNumberEdit, value);
        }

        string[] tileServers
        {
            get
            {
                return tileServersTxb.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            set
            {
                tileServersTxb.Clear();
                StringBuilder sb = new StringBuilder();
                foreach (var item in value)
                    sb.AppendLine(item);

                tileServersTxb.Text = sb.ToString();
            }
        }

        int tileSize
        {
            get => int.Parse(tileSizeCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(tileSizeCbx, value.ToString());
        }


        public SettingsContainer Value
        {
            get
            {
                SettingsContainer result = new SettingsContainer();

                result.IsUseAUXGNSS = isUseAUXGNSS;
                result.AUXGNSSPort_Baudrate = AUXGNSSBaudrate;
                result.IsBase1AsAUXGNSS = isBase1AsAUXGNSS;
                result.IsAutoSalinity = isAutoSalinity;
                result.Salinity_PSU = salinity;
                result.IsAutosoundSpeed = isAutoSoundspeed;
                result.SoundSpeed_mps = soundSpeed;
                result.WaterTemperature_C = waterTemperature;
                result.RERRThreshold_m = radialErrorThreshold;
                result.TrackPointsToShow = trackPointsToShow;
                result.TileServers = tileServers;
                result.TileSize = tileSize;

                return result;
            }
            set
            {
                isUseAUXGNSS = value.IsUseAUXGNSS;
                AUXGNSSBaudrate = value.AUXGNSSPort_Baudrate;
                isBase1AsAUXGNSS = value.IsBase1AsAUXGNSS;
                isAutoSalinity = value.IsAutoSalinity;
                salinity = value.Salinity_PSU;
                isAutoSoundspeed = value.IsAutosoundSpeed;
                soundSpeed = value.SoundSpeed_mps;
                waterTemperature = value.WaterTemperature_C;
                radialErrorThreshold = Convert.ToInt32(value.RERRThreshold_m);
                trackPointsToShow = value.TrackPointsToShow;
                tileServers = value.TileServers;
                tileSize = value.TileSize;
            }
        }

        #endregion

        #region Constructor

        public SettingsEditor()
        {
            InitializeComponent();

            tileSize = 256;
            var baudrates = Enum.GetNames(typeof(BaudRate));
            auxGNSSBaudrateCbx.Items.Clear();
            auxGNSSBaudrateCbx.Items.AddRange(baudrates);
            AUXGNSSBaudrate = BaudRate.baudRate9600;
        }

        #endregion

        #region Methods

        private void CheckValidity()
        {
            okBtn.Enabled = (isUseAUXGNSS && !isBase1AsAUXGNSS) ||
                            (!isUseAUXGNSS && isBase1AsAUXGNSS) ||
                            (!isUseAUXGNSS && !isBase1AsAUXGNSS);
        }

        #endregion

        #region Handlers

        private void isUseAUXGNSSChb_CheckedChanged(object sender, EventArgs e)
        {
            auxGNSSGroup.Enabled = isUseAUXGNSSChb.Checked;

            if (isUseAUXGNSS)
                isBase1AsAUXGNSS = false;

            CheckValidity();
        }

        private void isBase1AsAUXGNSSChb_CheckedChanged(object sender, EventArgs e)
        {
            if (isBase1AsAUXGNSS)
                isUseAUXGNSS = false;

            CheckValidity();
        }

        private void isAutoSalinityChb_CheckedChanged(object sender, EventArgs e)
        {
            salinityGroup.Enabled = !isAutoSalinityChb.Checked;
        }

        private void isAutoSpeedOfSoundChb_CheckedChanged(object sender, EventArgs e)
        {
            speedOfSoundGroup.Enabled = !isAutoSpeedOfSoundChb.Checked;
            waterTemperatureGroup.Enabled = isAutoSpeedOfSoundChb.Checked;
        }

        private void setDefaultsBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset to default settings?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)                
                Value = new SettingsContainer();
        }

        #endregion        
    }
}
