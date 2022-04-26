using System;
using UCNLDrivers;
using UCNLNMEA;

namespace uTrackLib
{
    #region Custom EventArgs

    public class LBLAEventArgs : EventArgs
    {
        #region Properties

        public BaseIDs BaseID { get; private set; }

        public double Lat_deg { get; private set; }

        public double Lon_deg { get; private set; }

        public double Depth { get; private set; }

        public double BatV { get; private set; }

        public int PCode { get; private set; }

        public double TOAs { get; private set; }

        public double MSR_dB { get; private set; }

        public bool IsBaseLocation
        {
            get
            {
                return (BaseID != BaseIDs.BASE_INVALID) &&
                       !double.IsNaN(Lat_deg) && !double.IsNaN(Lon_deg) &&
                       !double.IsNaN(Depth);
            }
        }

        public bool IsTOA
        {
            get { return !double.IsNaN(TOAs); }
        }

        #endregion

        #region Constructor

        public LBLAEventArgs(BaseIDs baseID, double lat_deg, double lon_deg, double dpt, double batV, int pcode, double toas, double msrdb)
        {
            BaseID = baseID;
            Lat_deg = lat_deg;
            Lon_deg = lon_deg;
            Depth = dpt;
            BatV = batV;
            PCode = pcode;
            TOAs = toas;
            MSR_dB = msrdb;
        }

        #endregion
    }

    #endregion

    public class uRWLTPort : uSerialPort
    {
        #region Properties

        static bool nmeaSingleton = false;

        #endregion

        #region Constructor

        public uRWLTPort(BaudRate _baudrate)
            : base(_baudrate)
        {
            base.PortDescription = "RWLT";
            base.IsLogIncoming = true;
            base.IsTryAlways = true;

            base.supress_try_send = true;

            #region NMEA

            if (!nmeaSingleton)
            {
                NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.RWL);
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.RWL, "A", "x,x.x,x.x,x.x,x.x,x,x.x,x.x");
                nmeaSingleton = true;
            }

            #endregion
        }

        #endregion

        #region Methods
        private static double O2D(object o)
        {
            return (o == null) ? double.NaN : (double)o;
        }

        private static double O2D(object o, double defaultValue)
        {
            return (o == null) ? defaultValue : (double)o;
        }

        private static int O2I(object o)
        {
            return (o == null) ? -1 : (int)o;
        }

        private void OnLBLA(object[] parameters)
        {
            // $PRWLA,bID,baseLat,baseLon,[baseDpt],baseBat,pingerData,TOAsecond,MSR_dB
            BaseIDs baseID = (parameters[0] == null) ? BaseIDs.BASE_INVALID : (BaseIDs)(int)parameters[0];

            double baseLat = O2D(parameters[1]);
            double baseLon = O2D(parameters[2]);
            double baseDepth = O2D(parameters[3], RWLT.DEFAULT_BASE_DPT_M);
            double baseBat = O2D(parameters[4]);
            int pCode = O2I(parameters[5]);

            double TOAs = O2D(parameters[6]);
            double MSR = O2D(parameters[7]);

            LBLAReceivedHandler.Rise(this, new LBLAEventArgs(baseID, baseLat, baseLon, baseDepth, baseBat, pCode, TOAs, MSR));
        }

        #region uSerialPort
        public override void InitQuerySend()
        {
            // do nothing
        }

        public override void OnClosed()
        {
            //throw new NotImplementedException();
        }

        public override void ProcessIncoming(NMEASentence sentence)
        {
            if (sentence is NMEAProprietarySentence)
            {
                NMEAProprietarySentence pSentence = (sentence as NMEAProprietarySentence);
                if ((pSentence.Manufacturer == ManufacturerCodes.RWL) &&
                    (pSentence.SentenceIDString == "A"))
                {
                    if (!detected)
                        detected = true;

                    ResetTimer();

                    OnLBLA(pSentence.parameters);
                }
            }
        }

        #endregion

        #endregion

        #region Events

        public EventHandler<LBLAEventArgs> LBLAReceivedHandler;

        #endregion
    }
}
