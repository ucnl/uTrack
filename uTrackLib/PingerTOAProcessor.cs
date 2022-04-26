using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNLDrivers;
using UCNLNav;
using UCNLPhysics;

namespace uTrackLib
{
    public class PingerTOAProcessor : ITOAProcessor
    {
        #region Properties

        RWLT_BProc bProc;
        PCore2D<GeoPoint3DT> pCore;

        public readonly AgingValue<double> PTemperature_C;
        public readonly AgingValue<double> PBatteryVoltage_V;
        public readonly AgingValue<double> PDepth_m;
        public readonly AgingValue<PingerCodeIDs> PAlarm;

        double soundSpeed = PHX.PHX_FWTR_SOUND_SPEED_MPS;
        public double SoundSpeed_mps
        {
            get { return soundSpeed; }
            set
            {
                if ((value >= PHX.PHX_FWTR_SOUND_SPEED_MPS_MIN) && (value <= PHX.PHX_FWTR_SOUND_SPEED_MPS_MAX))
                    soundSpeed = value;
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

        #endregion

        #region Constructor

        public PingerTOAProcessor(double rErrThreshold, double smplxSize, int crsEstimatorFIFOsize)
        {
            bProc = new RWLT_BProc(4, RWLT.PNG_INTERVAL_S); // Refactor constants

            pCore = new PCore2D<GeoPoint3DT>(rErrThreshold, smplxSize, Algorithms.WGS84Ellipsoid, crsEstimatorFIFOsize);
            pCore.BaseQualityUpdatedHandler += (o, e) => BaseQualityUpdatedHandler.Rise(o, e);
            pCore.RadialErrorExeedsThrehsoldEventHandler += (o, e) => RadialErrorThresholdExeededHandler.Rise(o, e);
            pCore.TargetLocationUpdatedExHandler += (o, e) => PingerLocationUpdatedHandler.Rise(o, e);

            PTemperature_C = new AgingValue<double>(3, 30, RWLT.TempFormatter);
            PBatteryVoltage_V = new AgingValue<double>(3, 60, RWLT.SVoltageFormatter);
            PDepth_m = new AgingValue<double>(3, 30, RWLT.DptDstFormatter);
            PAlarm = new AgingValue<PingerCodeIDs>(3, 600, x => x.ToString());
    }

        #endregion

        #region Methods

        public Dictionary<string, string> GetRemotesDescription()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();


            
            return result;
        }


        private void TryLocate(IEnumerable<GeoPoint3DT> basePoints)
        {
            double baseMeanDepth = 0.0;
            int bCount = 0;
            foreach (var item in basePoints)
            {
                baseMeanDepth += item.Depth;
                bCount++;
            }

            if (bCount >= 3)
            {
                baseMeanDepth /= bCount;

                if (!double.IsNaN(pCore.TargetDepth))
                    pCore.ProcessBasePoints(basePoints, DateTime.Now);
                else
                    pCore.ProcessBasePoints(basePoints, baseMeanDepth, DateTime.Now);
            }
        }

        private void PCodeProcess(int pcode)
        {
            double pData = 0.0;
            var pDataID = RWLT.C_DecodeData(pcode, out pData);

            if (pDataID == PingerDataIDs.DID_TMP)
            {
                PTemperature_C.Value = pData;
                TemperatureUpdatedHandler.Rise(this, new EventArgs());
            }
            else if (pDataID == PingerDataIDs.DID_PRS)
            {
                double dpt = PHX.Depth_by_pressure_calc(pData, 0, PHX.PHX_FWTR_DENSITY_KGM3, gravityAcc);
                PDepth_m.Value = dpt;
                pCore.TargetDepth = dpt;
            }
            else if (pDataID == PingerDataIDs.DID_BAT)
            {
                PBatteryVoltage_V.Value = pData;
            }
            else if (pDataID == PingerDataIDs.DID_CODE)
            {
                PAlarm.Value = (PingerCodeIDs)Enum.ToObject(typeof(PingerCodeIDs), Convert.ToInt32(pData));
            }
        }

        #endregion

        #region ITOAProcessor

        public void TOAProcess(BaseIDs baseID, double baseLat_deg, double baseLon_deg, double baseDpt_m, double baseBat_V, double baseMSR_dB, int pcode, double TOAs)
        {
            PCodeProcess(pcode);            

            var result = bProc.ProcessBase(baseID, baseLat_deg, baseLon_deg, baseDpt_m, TOAs);
            if (result != null)
                TryLocate(result);
        }

        public void UpdateRelativePosition(double slat_deg, double slon_deg)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Events

        public EventHandler TemperatureUpdatedHandler;
        public EventHandler<BaseQualityUpdatedEventArgs> BaseQualityUpdatedHandler;
        public EventHandler RadialErrorThresholdExeededHandler;
        public EventHandler<TargetLocationUpdatedExEventArgs> PingerLocationUpdatedHandler;

        #endregion
    }
}
