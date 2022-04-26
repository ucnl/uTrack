using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UCNLDrivers;
using UCNLNav;
using uTrackLib;

namespace uTrackDiver
{
    public class MiscInfoManager
    {
        #region Properties

        Dictionary<string, AgingValue<double>> list;

        #endregion

        #region Constructor

        public MiscInfoManager()
        {
            list = new Dictionary<string, AgingValue<double>>();

            list.Add("CRS", new AgingValue<double>(3, 30, RWLT.CourseFormatter));
            list.Add("SPD", new AgingValue<double>(3, 30, RWLT.SpeedFormatter));
            list.Add("LAT", new AgingValue<double>(3, 30, RWLT.LatLonFormatter));
            list.Add("LON", new AgingValue<double>(3, 30, RWLT.LatLonFormatter));
            list.Add("STY", new AgingValue<double>(3, 9999, x => string.Format(CultureInfo.InvariantCulture, "{0:F01} PSU", x)));
            list.Add("WTM", new AgingValue<double>(3, 9999, RWLT.TempFormatter));
            list.Add("SOS", new AgingValue<double>(3, 9999, x => string.Format(CultureInfo.InvariantCulture, "{0:F01} m/s", x)));

            list.Add("B1V", new AgingValue<double>(3, 300, RWLT.SVoltageFormatter));
            list.Add("B2V", new AgingValue<double>(3, 300, RWLT.SVoltageFormatter));
            list.Add("B3V", new AgingValue<double>(3, 300, RWLT.SVoltageFormatter));
            list.Add("B4V", new AgingValue<double>(3, 300, RWLT.SVoltageFormatter));

            list.Add("B1M", new AgingValue<double>(3, 30, RWLT.MSRFormatter));
            list.Add("B2M", new AgingValue<double>(3, 30, RWLT.MSRFormatter));
            list.Add("B3M", new AgingValue<double>(3, 30, RWLT.MSRFormatter));
            list.Add("B4M", new AgingValue<double>(3, 30, RWLT.MSRFormatter));
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                if (item.Value.IsInitialized)
                    sb.AppendFormat("{0}: {1}\r\n", item.Key, item.Value.ToString());
            }

            return sb.ToString();
        }

        public void SetValue(string key, double value)
        {
            list[key].Value = value;
            UpdatedEventHandler.Rise(this, new EventArgs());
        }

        #endregion

        #region Events

        public EventHandler UpdatedEventHandler;

        #endregion
    }
}
