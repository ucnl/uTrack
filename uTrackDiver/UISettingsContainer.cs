using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using UCNLDrivers;

namespace uTrackDiver
{
    [Serializable]
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
        public bool TreeDSTVisible;
        public bool TreeAZMVisible;
        public bool TreeRAZVisible;
        public bool TreeLOCVisible;
        public bool TreeRERVisible;
        public bool TreeDOPVisible;

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

            TreeDSTVisible = true;
            TreeAZMVisible = true;
            TreeRAZVisible = false;
            TreeLOCVisible = false;

            TreeRERVisible = false;
            TreeDOPVisible = false;
    }

        #endregion
    }
}
