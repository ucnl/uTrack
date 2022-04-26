using System;
using UCNLDrivers;
using UCNLNav;
using UCNLPhysics;

namespace uTrackLib
{
    public class WPManager
    {
        #region Properties

        public bool IsAutoSalinity { get; set; }

        public bool IsAutoSoundSpeed { get; set; }

        public bool IsAutoGravity { get; set; }


        double _soundSpeed = PHX.PHX_FWTR_SOUND_SPEED_MPS;

        double _salinity = PHX.PHX_FWTR_SALINITY_PSU;

        double salinity
        {
            get => _salinity;
            set
            {
                if (Math.Abs(_salinity - value) > 0.1)
                {
                    _salinity = value;
                    SalinityChanged.Rise(this, new EventArgs());
                    if (IsAutoSoundSpeed)
                        UpdateSoundSpeed();
                }
            }
        }

        double soundSpeed
        {
            get => _soundSpeed;
            set
            {
                if (Math.Abs(_soundSpeed - value) > 0.1)
                {
                    _soundSpeed = value;
                    SoundSpeedChanged.Rise(this, new EventArgs());
                }
            }
        }

        double temperature = 0;

        double pressure = PHX.PHX_ATM_PRESSURE_MBAR;

        double atmospheric_pressure = PHX.PHX_ATM_PRESSURE_MBAR;

        public double Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                if (IsAutoSoundSpeed)
                    UpdateSoundSpeed();
            }
        }

        public double Pressure
        {
            get => pressure;
            set
            {
                pressure = value;
                if (IsAutoSoundSpeed)
                    UpdateSoundSpeed();
            }

        }

        public double AtmosphericPressure
        {
            get => atmospheric_pressure;
            set
            {
                atmospheric_pressure = value;
                if (IsAutoSoundSpeed)
                {
                    /// TODO Recalc
                }
            }
        }

        public double SoundSpeed
        {
            get => _soundSpeed;
            set
            {
                if ((value >= PHX.PHX_FWTR_SOUND_SPEED_MPS_MIN) &&
                    (value <= PHX.PHX_FWTR_SOUND_SPEED_MPS_MAX))
                {
                    soundSpeed = value;
                    IsAutoSoundSpeed = false;
                }
                else
                    throw new ArgumentOutOfRangeException(
                        string.Format("Value must be in a range {0}..{1}",
                        PHX.PHX_FWTR_SOUND_SPEED_MPS_MIN,
                        PHX.PHX_FWTR_SOUND_SPEED_MPS_MAX));
            }
        }

        public double Salinity
        {
            get => _salinity;
            set
            {
                if ((value >= PHX.PHX_SALINITY_PSU_MIN) && (value <= PHX.PHX_SALINITY_PSU_MAX))
                {
                    IsAutoSalinity = false;
                    salinity = value;
                }
                else
                    throw new ArgumentOutOfRangeException(
                        string.Format("Value must be in a range {0}..{1} PSU",
                        PHX.PHX_SALINITY_PSU_MIN,
                        PHX.PHX_SALINITY_PSU_MAX));
            }
        }


        double _gravityAcceleration = PHX.PHX_GRAVITY_ACC_MPS2;

        double gravityAcceleration
        {
            get => _gravityAcceleration;
            set
            {
                if (Math.Abs(_gravityAcceleration - value) > 0.0001)
                {
                    _gravityAcceleration = value;
                    GravityAccelerationChanged.Rise(this, new EventArgs());
                }
            }
        }

        public double GravityAcceleration
        {
            get => _gravityAcceleration;
            set
            {
                if ((value >= PHX.PHX_GRAVITY_ACC_MPS2_MIN) && (value <= PHX.PHX_GRAVITY_ACC_MPS2_MAX))
                {
                    gravityAcceleration = value;
                    IsAutoGravity = false;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }


        double _latitude = 48;
        public double Latitude_Deg
        {
            get => _latitude;
            private set
            {
                if ((value >= -90) && (value <= 90))
                {
                    _latitude = value;
                    if (IsAutoGravity)
                        gravityAcceleration = PHX.Gravity_constant_wgs84_calc(_latitude);
                }
                else
                    throw new ArgumentOutOfRangeException("Value must be in range from -90 to 90");
            }
        }

        double _longitude = 44;
        public double Longitude_Deg
        {
            get => _longitude;
            private set
            {
                if ((value >= -180) && (value <= 180))
                    _longitude = value;
                else
                    throw new ArgumentOutOfRangeException("Value must be in range from -180 to 180");
            }
        }


        double salinityLatPoint = 48;
        double salinityLonPoint = 44;
        public double SalinityLatPoint { get => salinityLatPoint; }
        public double SalinityLonPoint { get => salinityLonPoint; }

        #endregion

        #region Constructor


        #endregion

        #region Methods

        private void UpdateSoundSpeed()
        {
            soundSpeed = PHX.Speed_of_sound_UNESCO_calc(temperature, pressure, salinity);
        }

        public void UpdateLocation(double lat_deg, double lon_deg)
        {
            Latitude_Deg = lat_deg;
            Longitude_Deg = lon_deg;

            double range = 0;
            double fwd_az = 0;
            double rev_az = 0;
            int its = 0;
            Algorithms.VincentyInverse(
                Algorithms.Deg2Rad(lat_deg), Algorithms.Deg2Rad(lon_deg),
                Algorithms.Deg2Rad(salinityLatPoint), Algorithms.Deg2Rad(salinityLonPoint),
                Algorithms.WGS84Ellipsoid,
                Algorithms.VNC_DEF_EPSILON,
                Algorithms.VNC_DEF_IT_LIMIT,
                out range,
                out fwd_az,
                out rev_az,
                out its);

            if (range > 1000)
            {
                if (IsAutoSalinity)
                {
                    UCNLSalinity.WWSalinityProvider sProvider = new UCNLSalinity.WWSalinityProvider("WWSalinity.xml");
                    salinity = sProvider.GetNearestSalinity(_latitude, _longitude, out salinityLatPoint, out salinityLonPoint);
                }
            }

        }

        #endregion

        #region Events

        public EventHandler SoundSpeedChanged;
        public EventHandler SalinityChanged;
        public EventHandler GravityAccelerationChanged;

        #endregion
    }
}
