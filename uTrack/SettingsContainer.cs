using UCNLDrivers;

namespace uTrack
{
    public class SettingsContainer : SimpleSettingsContainer
    {
        #region Properties

        public bool IsUseAUXGNSS;
        public BaudRate AUXGNSSPort_Baudrate;
        public bool IsBase1AsAUXGNSS;
        public bool IsAutoSalinity;
        public double Salinity_PSU;
        public bool IsAutosoundSpeed;
        public double SoundSpeed_mps;

        public int TrackPointsToShow;
        public double RERRThreshold_m;

        public string[] TileServers;
        public int TileSize;

        #endregion

        #region Methods

        public override void SetDefaults()
        {
            IsUseAUXGNSS = false;
            AUXGNSSPort_Baudrate = BaudRate.baudRate9600;
            IsBase1AsAUXGNSS = true;
            IsAutoSalinity = true;
            Salinity_PSU = 0.0;
            IsAutosoundSpeed = true;
            SoundSpeed_mps = UCNLPhysics.PHX.PHX_FWTR_SOUND_SPEED_MPS;

            TrackPointsToShow = 32;
            RERRThreshold_m = 10;

            TileServers = new string[]
            {
                "https://a.tile.openstreetmap.org",
                "https://b.tile.openstreetmap.org",
                "https://c.tile.openstreetmap.org"
            };

            TileSize = 256;
        }

        #endregion
    }
}
