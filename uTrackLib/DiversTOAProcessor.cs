using System;
using System.Collections.Generic;
using UCNLDrivers;
using UCNLNav;
using UCNLPhysics;

namespace uTrackLib
{
    public class RemoteDescriptor
    {
        #region Properties

        public int ID;
        public AgingValue<double> Latitude;
        public AgingValue<double> Longitude;
        public AgingValue<double> RadialError;
        public AgingValue<double> Distance;
        public AgingValue<double> ForwardAzimuth;
        public AgingValue<double> ReverseAzimuth;
        public AgingValue<bool> IsRERRExceed;
        public AgingValue<DOPState> DOP;
        public AgingValue<TBAQuality> TBA;

        #endregion

        #region Constructor

        public RemoteDescriptor(int id)
        {
            ID = id;
            Latitude = new AgingValue<double>(10, 600, RWLT.LatLonFormatter);
            Longitude = new AgingValue<double>(10, 600, RWLT.LatLonFormatter);
            RadialError = new AgingValue<double>(10, 600, RWLT.DptDstFormatter);
            Distance = new AgingValue<double>(10, 600, RWLT.DptDstFormatter);
            ForwardAzimuth = new AgingValue<double>(10, 600, RWLT.CourseFormatter);
            ReverseAzimuth = new AgingValue<double>(10, 600, RWLT.CourseFormatter);
            DOP = new AgingValue<DOPState>(10, 600, x => x.ToString());
            TBA = new AgingValue<TBAQuality>(10, 600, x => x.ToString().Replace('_', ' '));
            IsRERRExceed = new AgingValue<bool>(10, 600, x => x.ToString());
        }

        #endregion

        #region Methods

        public Dictionary<string, string> GetDescription()
        {
            return GetDescription(true, true, true, true, true, true);
        }

        public Dictionary<string, string> GetDescription(bool isDst, bool isAzm, bool isRaz, bool isLatLon, bool isRer, bool isDopTba)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (Distance.IsInitialized && isDst)
                result.Add("DST", Distance.ToString());
            if (ForwardAzimuth.IsInitialized && isAzm)
                result.Add("AZM", ForwardAzimuth.ToString());
            if (ReverseAzimuth.IsInitialized && isRaz)
                result.Add("RAZ", ReverseAzimuth.ToString());

            if (isLatLon)
            {
                if (Latitude.IsInitialized)
                    result.Add("LAT", Latitude.ToString());
                if (Longitude.IsInitialized)
                    result.Add("LON", Longitude.ToString());
            }

            if (RadialError.IsInitialized && isRer)
                result.Add("RER", RadialError.ToString());

            if (IsRERRExceed.IsInitialized && IsRERRExceed.Value)
                result.Add("RERE", IsRERRExceed.Value.ToString());

            if (isDopTba)
            {
                if (DOP.IsInitialized)
                    result.Add("DOP", DOP.ToString());
                if (TBA.IsInitialized)
                    result.Add("TBA", TBA.ToString());
            }

            return result;
        }

        #endregion
    }

    public class DiversTOAProcessor : ITOAProcessor
    {
        #region Properties

        Dictionary<int, RWLT_BProc> bProcs;
        Dictionary<int, PCore2D<GeoPoint3DT>> estimators;
        Dictionary<int, RemoteDescriptor> remotes;
                
        double soundSpeed = PHX.PHX_FWTR_SOUND_SPEED_MPS;
        public double SoundSpeed_mps
        {
            get { return soundSpeed; }
            set
            {
                if ((value >= PHX.PHX_FWTR_SOUND_SPEED_MPS_MIN) && (value <= PHX.PHX_FWTR_SOUND_SPEED_MPS_MAX))
                {
                    soundSpeed = value;
                    foreach (var item in estimators)
                    {
                        item.Value.SoundSpeed = soundSpeed;
                    }
                }
                else
                    throw new ArgumentOutOfRangeException("value",
                        string.Format("must be in the a range from {0} to {1} m/s",
                        PHX.PHX_FWTR_SOUND_SPEED_MPS_MIN,
                        PHX.PHX_FWTR_SOUND_SPEED_MPS_MAX));
            }

        }

        double gravityAcc = PHX.PHX_GRAVITY_ACC_MPS2;
        public double GravityAcceleration
        {
            get { return gravityAcc; }
            set
            {
                if ((value >= PHX.PHX_GRAVITY_ACC_MPS2_MIN) && (value <= PHX.PHX_GRAVITY_ACC_MPS2_MAX))
                    gravityAcc = value;
                else
                    throw new ArgumentOutOfRangeException("value",
                        string.Format("must be in the a range from {0} to {1} m/s²",
                        PHX.PHX_GRAVITY_ACC_MPS2_MIN,
                        PHX.PHX_GRAVITY_ACC_MPS2_MAX));
            }
        }

        public string Moniker { get; set; }

        public double RadialErrorThreshold { get; private set; }
        public double SimplexSize { get; private set; }

        #endregion

        #region Constructor

        public DiversTOAProcessor(double rErrThreshold, double smplxSize)
        {
            if (rErrThreshold <= 0)
                throw new ArgumentOutOfRangeException("rErrThreshold should be greater than zero");

            RadialErrorThreshold = rErrThreshold;

            if (smplxSize <= 0)
                throw new ArgumentOutOfRangeException("smplxSize should be greater than zero");

            Moniker = "Diver";

            SimplexSize = smplxSize;

            bProcs = new Dictionary<int, RWLT_BProc>();
            estimators = new Dictionary<int, PCore2D<GeoPoint3DT>>();
            remotes = new Dictionary<int, RemoteDescriptor>();
        }

        #endregion

        #region Methods        

        public Dictionary<string, Dictionary<string, string>> GetRemotesDescription()
        {
            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();

            foreach (var remote in remotes)
                result.Add(string.Format("Diver #{0}", remote.Key.ToString()), remote.Value.GetDescription());

            return result;
        }

        public Dictionary<string, Dictionary<string, string>> GetRemotesDescription(bool isDst, bool isAzm, bool isRaz, bool isLatLon, bool isRer, bool isDopTba)
        {
            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();

            foreach (var remote in remotes)
                result.Add(string.Format("Diver #{0}", remote.Key.ToString()), 
                    remote.Value.GetDescription(isDst, isAzm, isRaz, isLatLon, isRer, isDopTba));

            return result;
        }

        #endregion

        #region ITOAProcessor

        public void TOAProcess(BaseIDs baseID, double baseLat_deg, double baseLon_deg, double baseDpt_m, double baseBat_V, double baseMSR_dB, int pcode, double TOAs)
        {
            if (pcode < 0)
                return;

            if (!remotes.ContainsKey(pcode))
                remotes.Add(pcode, new RemoteDescriptor(pcode));

            if (!bProcs.ContainsKey(pcode))
                bProcs.Add(pcode, new RWLT_BProc(4, RWLT.PNG_INTERVAL_S));            

            var bases = bProcs[pcode].ProcessBase(baseID, baseLat_deg, baseLon_deg, baseDpt_m, TOAs);
            if ((bases != null) && (bases.Length >= 3))
            {
                if (!estimators.ContainsKey(pcode))
                {
                    estimators.Add(pcode, new PCore2D<GeoPoint3DT>(RadialErrorThreshold, SimplexSize, Algorithms.WGS84Ellipsoid, 2));

                    estimators[pcode].SoundSpeed = soundSpeed;
                    estimators[pcode].TargetDepth = baseDpt_m;

                    estimators[pcode].BaseQualityUpdatedHandler += (o, e) =>
                    {
                        remotes[pcode].TBA.Value = e.TBAState;
                        remotes[pcode].DOP.Value = e.DopState;
                        RemotesUpdatedHandler.Rise(this, new EventArgs());
                    };

                    estimators[pcode].RadialErrorExeedsThrehsoldEventHandler += (o, e) =>
                    {
                        remotes[pcode].IsRERRExceed.Value = true;
                        RemotesUpdatedHandler.Rise(this, new EventArgs());
                    };
                    estimators[pcode].TargetLocationUpdatedHandler += (o, e) =>
                    {
                        remotes[pcode].IsRERRExceed.Value = false;
                        remotes[pcode].Latitude.Value = e.Location.Latitude;
                        remotes[pcode].Longitude.Value = e.Location.Longitude;
                        remotes[pcode].RadialError.Value = e.Location.RadialError;

                        LocationUpdatedHandler.Rise(this,
                            new LocationUpdatedEventArgs(string.Format("{0} #{1}", Moniker, pcode),
                            e.Location.Latitude,
                            e.Location.Longitude,
                            e.Location.RadialError));

                        RemotesUpdatedHandler.Rise(this, new EventArgs());
                    };
                }

                estimators[pcode].ProcessBasePoints(bases, DateTime.Now);
            }
        }

        public void UpdateRelativePosition(double slat_deg, double slon_deg)
        {
            double slat_rad = Algorithms.Deg2Rad(slat_deg);
            double slon_rad = Algorithms.Deg2Rad(slon_deg);

            foreach (var remote in remotes)
            {
                if (remote.Value.Latitude.IsInitialized &&
                    remote.Value.Longitude.IsInitialized)
                {
                    double rlat_rad = Algorithms.Deg2Rad(remote.Value.Latitude.Value);
                    double rlon_rad = Algorithms.Deg2Rad(remote.Value.Longitude.Value);

                    int its = 0;
                    double dst_m = 0;
                    double fwd_az = 0;
                    double rev_az = 0;

                    if (!Algorithms.VincentyInverse(slat_rad, slon_rad, rlat_rad, rlon_rad,
                            Algorithms.WGS84Ellipsoid, Algorithms.VNC_DEF_EPSILON, Algorithms.VNC_DEF_IT_LIMIT,
                            out dst_m, out fwd_az, out rev_az, out its))
                    {
                        dst_m = Algorithms.HaversineInverse(slat_rad, slon_rad, rlat_rad, rlon_rad, Algorithms.WGS84Ellipsoid.MajorSemiAxis_m);
                        fwd_az = Algorithms.HaversineInitialBearing(slat_rad, slon_rad, rlat_rad, rlon_rad);
                        rev_az = Algorithms.HaversineInitialBearing(rlat_rad, rlon_rad, slat_rad, slon_rad);
                    }

                    rev_az = Algorithms.Wrap2PI(rev_az + Math.PI);
                    fwd_az = Algorithms.Rad2Deg(fwd_az);
                    rev_az = Algorithms.Rad2Deg(rev_az);
                    remote.Value.Distance.Value = dst_m;
                    remote.Value.ForwardAzimuth.Value = fwd_az;
                    remote.Value.ReverseAzimuth.Value = rev_az;
                }
            }

            RemotesUpdatedHandler.Rise(this, new EventArgs());
        }

        #endregion

        #region Events

        public EventHandler<LocationUpdatedEventArgs> LocationUpdatedHandler;
        public EventHandler RemotesUpdatedHandler;

        #endregion
    }
}
