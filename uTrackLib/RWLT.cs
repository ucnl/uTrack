using System;
using System.Collections.Generic;
using System.Globalization;

namespace uTrackLib
{
    public enum ICs
    {
        IC_D2H_ACK,
        IC_H2D_SETTINGS_WRITE,
        IC_D2H_LBLA,
        IC_H2D_DINFO_GET,
        IC_D2H_DINFO,
        IC_D2H_UNKNOWN,
        IC_INVALID
    }

    public enum BaseIDs
    {
        BASE_1 = 0,
        BASE_2 = 1,
        BASE_3 = 2,
        BASE_4 = 3,
        BASE_INVALID
    }

    public enum PingerDataIDs
    {
        DID_PRS = 0,
        DID_TMP = 1,
        DID_BAT = 2,
        DID_CODE = 3,
        DID_INVALID
    }

    public enum PingerCodeIDs
    {
        RE_RESERVED_16 = 1000,
        RE_RESERVED_15 = 1001,
        RE_RESERVED_14 = 1002,
        RE_RESERVED_13 = 1003,
        RE_RESERVED_12 = 1004,
        RE_RESERVED_11 = 1005,
        RE_RESERVED_10 = 1006,
        RE_RESERVED_9 = 1007,
        RE_RESERVED_8 = 1008,
        RE_RESERVED_7 = 1009,

        RE_RESERVED_6 = 1010,
        RE_RESERVED_5 = 1011,
        RE_RESERVED_4 = 1012,
        RE_RESERVED_3 = 1013,
        RE_RESERVED_2 = 1014,
        RE_RESERVED_1 = 1015,

        RE_PTS_FAILURE = 1016,
        RE_NOT_AVAILABLE = 1017,
        RE_PRS_OVRF = 1018,
        RE_BAT_LOW = 1019,
        RE_TMP_LOW = 1020,
        RE_TMP_HIGH = 1021,
        RE_INVALID_CODE
    }


    public static class RWLT
    {
        public readonly static int BASES_NUMBER = 4;
        public readonly static double DEFAULT_BASE_DPT_M = 1.5;

        readonly static double CR_MIN_TMP_C = -4.0;
        readonly static double CR_MAX_TMP_C = 46.0;
        readonly static double CR_TMP_RANGE_C = CR_MAX_TMP_C - CR_MIN_TMP_C;

        readonly static double CR_MIN_PRS_MBAR = 0.0;
        readonly static double CR_MAX_PRS_MBAR = 30000.0;
        readonly static double CR_PRS_RANGE_MBAR = CR_MAX_PRS_MBAR - CR_MIN_PRS_MBAR;

        readonly static double CR_MIN_BAT_VOLTAGE = 4.0;
        readonly static double CR_MAX_BAT_VOLTAGE = 16.0;
        readonly static double CR_BAT_RANGE_V = CR_MAX_BAT_VOLTAGE - CR_MIN_BAT_VOLTAGE;

        readonly static double CR_PRS_OFFSET = 0;
        readonly static double CR_PRS_CRANGE = 900;

        readonly static double CR_TMP_OFFSET = 901;
        readonly static double CR_TMP_CRANGE = 50;

        readonly static double CR_BAT_OFFSET = 952;
        readonly static double CR_BAT_CRANGE = 40;

        readonly static double CR_CODE_RANGE_END = CR_BAT_OFFSET + CR_BAT_CRANGE;

        readonly static double CR_PRS_SCALE = CR_PRS_RANGE_MBAR / (double)CR_PRS_CRANGE;
        readonly static double CR_TMP_SCALE = CR_TMP_RANGE_C / (double)CR_TMP_CRANGE;
        readonly static double CR_BAT_SCALE = CR_BAT_RANGE_V / (double)CR_BAT_CRANGE;

        public static readonly double PNG_INTERVAL_S = 2.0;

        public static readonly Func<double, string> LatLonFormatter = new Func<double, string>((v) => string.Format(CultureInfo.InvariantCulture, "{0:F06}°", v));
        public static readonly Func<double, string> SVoltageFormatter = new Func<double, string>((v) => string.Format(CultureInfo.InvariantCulture, "{0:F01} V", v));
        public static readonly Func<double, string> MSRFormatter = new Func<double, string>((v) => string.Format(CultureInfo.InvariantCulture, "{0:F01} dB", v));
        public static readonly Func<double, string> RERRFormatter = new Func<double, string>((v) => string.Format(CultureInfo.InvariantCulture, "{0:F03} m", v));
        public static readonly Func<double, string> CourseFormatter = new Func<double, string>((v) => string.Format(CultureInfo.InvariantCulture, "{0:F01}°", v));
        public static readonly Func<double, string> SpeedFormatter = new Func<double, string>((v) => string.Format(CultureInfo.InvariantCulture, "{0:F01} km/h ({1:F01} m/s)", v, v / 3.6));
        public static readonly Func<double, string> DptDstFormatter = new Func<double, string>((v) => string.Format(CultureInfo.InvariantCulture, "{0:F02} m", v));
        public static readonly Func<double, string> TempFormatter = new Func<double, string>((v) => string.Format(CultureInfo.InvariantCulture, "{0:F01} °C", v));           
           

        static Dictionary<string, ICs> ICsIdxArray = new Dictionary<string, ICs>()
        {
            { "0", ICs.IC_D2H_ACK },
            { "1", ICs.IC_H2D_SETTINGS_WRITE },
            { "A", ICs.IC_D2H_LBLA },
            { "?", ICs.IC_H2D_DINFO_GET },
            { "!", ICs.IC_D2H_DINFO },
            { "-", ICs.IC_D2H_UNKNOWN },
        };

        public static ICs ICsByMessageID(string msgID)
        {
            if (ICsIdxArray.ContainsKey(msgID))
                return ICsIdxArray[msgID];
            else
                return ICs.IC_INVALID;
        }

        public static PingerDataIDs C_DecodeData(int val, out double pValue)
        {
            /*
            Pressure as an integer value 0..900 (0 .. 30000 mBar)
            Temperature as an integer value 901..951 (-4..46 °C)
            Supply voltage as an integer value 952..993 (4..16 V)

            Pressure resolution 30000/901 = 33 mBar (~ 0.32 m)
            Temperature resolution 50/50  = 1°
            Supply voltage resolution 20/40 = 0.5 V
            */
            pValue = val;

            PingerDataIDs result = PingerDataIDs.DID_INVALID;

            if (val < 0)
            {
                result = PingerDataIDs.DID_INVALID;
            }
            else if (val < CR_TMP_OFFSET)
            {
                pValue = (val - CR_PRS_OFFSET) * CR_PRS_SCALE + CR_MIN_PRS_MBAR;
                result = PingerDataIDs.DID_PRS;
            }
            else if (val < CR_BAT_OFFSET)
            {
                pValue = (val - CR_TMP_OFFSET) * CR_TMP_SCALE + CR_MIN_TMP_C;
                result = PingerDataIDs.DID_TMP;
            }
            else if (val < CR_BAT_OFFSET + CR_BAT_CRANGE)
            {
                pValue = (val - CR_BAT_OFFSET) * CR_BAT_SCALE + CR_MIN_BAT_VOLTAGE;
                result = PingerDataIDs.DID_BAT;
            }
            else if (val > CR_CODE_RANGE_END)
            {
                pValue = val;
                result = PingerDataIDs.DID_CODE;
            }

            return result;
        }
    }
}