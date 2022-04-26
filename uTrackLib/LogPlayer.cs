using System;
using System.Globalization;
using System.IO;
using System.Threading;
using UCNLDrivers;

namespace uTrackLib
{
    public class StringEventArgs : EventArgs
    {
        public string Line { get; private set; }

        public StringEventArgs(string line)
        {
            Line = line;
        }
    }

    public class LogPlayer
    {
        #region Properties

        public bool IsRunning { get; private set; }

        public string LogFileName { get; private set; }

        readonly char[] tSplitter = new char[] { ':' };

        #endregion

        #region Methods

        public void Playback(string fileName)
        {
            if (!IsRunning)
            {
                LogFileName = fileName;
                _ = ThreadPool.QueueUserWorkItem(PlaybackThread, fileName);
                IsRunning = true;
            }
        }
        public void RequestToStop()
        {
            if (IsRunning)
                IsRunning = false;
        }

        private bool ParseTime(string s, out TimeSpan ts)
        {
            bool result = false;
            ts = TimeSpan.MinValue;
            var splits = s.Split(tSplitter, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length == 3)
            {
                int hr = int.Parse(splits[0]);
                int mn = int.Parse(splits[1]);
                double sec = double.Parse(splits[2], CultureInfo.InvariantCulture);
                int sc = Convert.ToInt32(sec);
                int ms = Convert.ToInt32(1000 * (sec - sc));

                ts = new TimeSpan(0, hr, mn, sc, ms);
                result = true;
            }

            return result;
        }

        private void PlaybackThread(object sinfo)
        {
            string fileName = sinfo as string;
            TimeSpan prevLineTS = TimeSpan.MinValue;
            TimeSpan ts = TimeSpan.MinValue;
            bool tsInitialized = false;

            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = string.Empty;
                    while (((s = sr.ReadLine()) != null) && IsRunning)
                    {
                        int idx = s.IndexOf(' ');
                        if (idx >= 0)
                        {
                            string rs = s.Substring(idx + 1);
                            string ls = s.Substring(0, idx);

                            if (ParseTime(ls, out ts))
                            {
                                if (!tsInitialized)
                                {
                                    prevLineTS = ts;
                                    tsInitialized = true;
                                }

                                var interval = Convert.ToInt32(ts.Subtract(prevLineTS).TotalMilliseconds);

                                if (interval > 10)
                                    Thread.Sleep(interval);

                                prevLineTS = ts;
                                NewLogLineHandler.Rise(this, new StringEventArgs(rs));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }

            IsRunning = false;
            LogPlaybackFinishedHandler.Rise(this, new EventArgs());
        }

        #endregion

        #region Events

        public EventHandler<StringEventArgs> NewLogLineHandler;
        public EventHandler LogPlaybackFinishedHandler;
        public EventHandler<LogEventArgs> LogEventHandler;

        #endregion
    }
}
