using System;
using UCNLDrivers;
using UCNLNMEA;

namespace uTrackLib
{
    #region Custom EventArgs

    public class LocationUpdatedEventArgs : EventArgs
    {
        #region Properties

        public string ID { get; private set; }

        public double Latitude_deg { get; private set; }

        public double Longitude_deg { get; private set; }

        public double RadialError_m { get; private set; }

        public double Depth_m {  get; private set; }        

        public DateTime TimeStamp { get; private set; }

        #endregion

        #region Constructor

        public LocationUpdatedEventArgs(string id, double lat_deg, double lon_deg) 
            : this(id, lat_deg, lon_deg, double.NaN, double.NaN, DateTime.Now)
        {

        }

        public LocationUpdatedEventArgs(string id, double lat_deg, double lon_deg, double r_err_m) 
            : this(id, lat_deg, lon_deg, r_err_m, double.NaN, DateTime.Now)
        {

        }

        public LocationUpdatedEventArgs(string id, double lat_deg, double lon_deg, double r_err_m, double dpt_m) 
            : this(id, lat_deg, lon_deg, r_err_m, dpt_m, DateTime.Now)
        {

        }

        public LocationUpdatedEventArgs(string id, double lat_deg, double lon_deg, double r_err_m, double dpt_m, DateTime timeStamp)
        {
            ID = id;
            Latitude_deg = lat_deg;
            Longitude_deg = lon_deg;
            RadialError_m = r_err_m;
            Depth_m = dpt_m;
            TimeStamp = timeStamp;
        }

        #endregion
    }

    public class CourseSpeedUpdatedEventArgs : EventArgs
    {
        #region Properties

        public double Course_deg { get; private set; }
        public double Speed_mps { get; private set; }

        #endregion

        #region Constructor

        public CourseSpeedUpdatedEventArgs(double crs_deg, double spd_mps)
        {
            Course_deg = crs_deg;
            Speed_mps = spd_mps;
        }

        #endregion
    }

    public class BaseStateUpdatedEventArgs : EventArgs
    {
        #region Properties

        public BaseIDs BaseID { get; private set; }
        public double BatVoltage { get; private set; }
        public double MSR_dB { get; private set; }

        #endregion

        #region Constructor

        public BaseStateUpdatedEventArgs(BaseIDs bID, double batV, double msr_dB)
        {
            BaseID = bID;
            BatVoltage = batV;
            MSR_dB = msr_dB;
        }

        #endregion
    }

    #endregion

    public class RWLT_Listener : IDisposable
    {
        #region Properties

        bool disposed = false;

        uRWLTPort rwltPort;
        uGNSSSerialPort auxGNSSPort;

        public bool IsUseAUXGNSS { get; private set; }
        public bool IsStBaseAsAUXGNSS { get; private set; }

        public bool IsActive { get => rwltPort.IsActive; }
        public bool RWLTPortDetected { get => rwltPort.Detected; }
        public string RWLTPortName { get => rwltPort.PortName; }
        public string RWLTPortStatus { get => rwltPort.ToString(); }

        public bool AUXGNSSPortDetected { get => (auxGNSSPort != null) && (auxGNSSPort.Detected); }
        public string AUXGNSSPortName { get => auxGNSSPort == null ? string.Empty : auxGNSSPort.PortName; }
        public string AUXGNSSPortStatus { get => auxGNSSPort == null ? string.Empty : auxGNSSPort.ToString(); }

        ITOAProcessor TOAProcessor;

        readonly string[] llSeparators = new string[] { ">>", " " };

        #endregion

        #region Constructor

        public RWLT_Listener(ITOAProcessor toaProcessor) : this(toaProcessor, false)
        {
            IsUseAUXGNSS = false;            
        }        

        public RWLT_Listener(ITOAProcessor toaProcessor, BaudRate auxGNSSPortBaudrate) : this(toaProcessor, false)
        {
            IsUseAUXGNSS = true;
            AUXGNSSInit(auxGNSSPortBaudrate, toaProcessor);
        }

        public RWLT_Listener(ITOAProcessor toaProcessor, bool isStBaseAsAUXGNSS)
        {
            if (toaProcessor == null)
                throw new ArgumentNullException("toaProcessor");

            TOAProcessor = toaProcessor;

            IsStBaseAsAUXGNSS = isStBaseAsAUXGNSS;
            rwltPort = new uRWLTPort(BaudRate.baudRate9600);

            rwltPort.DetectedChanged += (o, e) =>
            {
                RWLTPortDetectedChangedHandler.Rise(o, e);

                if (rwltPort.Detected && IsUseAUXGNSS)
                    auxGNSSPort.Start();
            };

            rwltPort.IsActiveChanged += (o, e) => RWLTPortIsActiveChangedHandler.Rise(o, e);

            rwltPort.LBLAReceivedHandler += (o, e) =>
            {
                BaseStateUpdatedHandler.Rise(this, new BaseStateUpdatedEventArgs(e.BaseID, e.BatV, e.MSR_dB));

                if (e.IsBaseLocation)
                {
                    if ((e.BaseID == BaseIDs.BASE_1) && IsStBaseAsAUXGNSS)
                    {
                        toaProcessor.UpdateRelativePosition(e.Lat_deg, e.Lon_deg);
                        LocationUpdatedHandler.Rise(this,
                            new LocationUpdatedEventArgs("AUX GNSS", e.Lat_deg, e.Lon_deg, 0.0, 0, DateTime.Now));
                    }

                    LocationUpdatedHandler.Rise(this,
                        new LocationUpdatedEventArgs(e.BaseID.ToString().Replace('_', ' '), e.Lat_deg, e.Lon_deg, 0.0, 0, DateTime.Now));

                    TOAProcessor.TOAProcess(e.BaseID, e.Lat_deg, e.Lon_deg, e.Depth, e.BatV, e.MSR_dB, e.PCode, e.TOAs);
                }
            };
            
            rwltPort.LogEventHandler += (o, e) => LogEventHandler.Rise(o, e);
        }

        #endregion

        #region Methods

        #region Private

        private void AUXGNSSInit(BaudRate baudrate, ITOAProcessor toaProcessor)
        {
            auxGNSSPort = new uGNSSSerialPort(baudrate);
            auxGNSSPort.DetectedChanged += (o, e) => AUXGNSSPortDetectedChangedHandler.Rise(o, e);
            auxGNSSPort.IsActiveChanged += (o, e) => AUXGNSSPortIsActiveChangedHandler.Rise(o, e);
            
            auxGNSSPort.LocationUpdated += (o, e) =>
            {
                toaProcessor.UpdateRelativePosition(auxGNSSPort.Latitude, auxGNSSPort.Longitude);

                LocationUpdatedHandler.Rise(this,
                    new LocationUpdatedEventArgs("AUX GNSS", auxGNSSPort.Latitude, auxGNSSPort.Longitude, 0.0, 0.0, auxGNSSPort.GNSSTime));
            };
            auxGNSSPort.LogEventHandler += (o, e) => LogEventHandler.Rise(o, e);
        }

        #endregion

        public void Start()
        {
            if (IsUseAUXGNSS && auxGNSSPort.IsActive)
                auxGNSSPort.Stop();

            if (!rwltPort.IsActive)
                rwltPort.Start();
        }

        public void Stop()
        {
            if (rwltPort.IsActive)
                rwltPort.Stop();

            if (IsUseAUXGNSS && auxGNSSPort.IsActive)
                auxGNSSPort.Stop();
        }

        public void Emulate(string eString)
        {
            string str = eString.Trim() + NMEAParser.SentenceEndDelimiter;

            var splits = str.Split(llSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length == 3)
            {
                if (splits[1] == "(AUX)")
                {
                    if (auxGNSSPort == null)                    
                        AUXGNSSInit(BaudRate.baudRate9600, TOAProcessor);                    

                    auxGNSSPort.EmulateInput(splits[2]);
                }
                else if (splits[1] == "(RWLT)")
                {
                    rwltPort.EmulateInput(splits[2]);
                }
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (rwltPort.IsActive)
                        rwltPort.Stop();

                    rwltPort.Dispose();

                    if (auxGNSSPort != null)
                    {
                        if (auxGNSSPort.IsActive)
                            auxGNSSPort.Stop();

                        auxGNSSPort.Dispose();
                    }
                }

                disposed = true;
            }
        }

        #endregion

        #region Events

        public EventHandler<LogEventArgs> LogEventHandler;
        public EventHandler<LocationUpdatedEventArgs> LocationUpdatedHandler;
        public EventHandler<CourseSpeedUpdatedEventArgs> CourseSpeedUpdatedHandler;
        public EventHandler<BaseStateUpdatedEventArgs> BaseStateUpdatedHandler;

        public EventHandler RWLTPortDetectedChangedHandler;
        public EventHandler RWLTPortIsActiveChangedHandler;
        public EventHandler AUXGNSSPortDetectedChangedHandler;
        public EventHandler AUXGNSSPortIsActiveChangedHandler;

        #endregion
    }
}
