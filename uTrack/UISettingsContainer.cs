using System.Drawing;
using System.Windows.Forms;
using UCNLDrivers;

namespace uTrack
{
    public class UISettingsContainer : SimpleSettingsContainer
    {
        #region Properties

        public FormWindowState WState;
        public Size WSize;
        public Point WLocation;

        public bool BasesVisible;
        public bool LogVisible;
        public bool LegendVisible;
        public bool NotesVisible;
        public bool MiscInfoVisible;

        public bool RemLOCVisible;
        public bool RemDPTVisible;
        public bool RemBATVisible;
        public bool RemTBADOPVisible;
        public bool RemDSTVisible;
        public bool RemAZMVisible;
        public bool RemCRSVisible;
        public bool RemRAZVisible;

        #endregion

        #region SimpleSettingsContainer

        public override void SetDefaults()
        {
            WState = FormWindowState.Normal;

            BasesVisible = true;
            LogVisible = true;
            LegendVisible = true;
            NotesVisible = true;
            MiscInfoVisible = true;

            RemLOCVisible = true;
            RemDPTVisible = true;
            RemBATVisible = true;
            RemTBADOPVisible = true;
            RemDSTVisible = true;
            RemAZMVisible = true;
            RemCRSVisible = true;
            RemRAZVisible = true;
        }

        #endregion
    }
}
