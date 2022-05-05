using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLUI;
using UCNLUI.Dialogs;
using uOSM;
using uTrackLib;

namespace uTrack
{
    public partial class MainForm : Form
    {
        #region Properties

        bool isRestart = false;

        string logPath;
        string logFileName;
        string settingsFileName;
        string uiSettingsFileName;
        string snapshotsPath;
        string tileDBPath;

        TSLogProvider logger;
        SimpleSettingsProviderXML<SettingsContainer> sProvider;
        SimpleSettingsProvider<UISettingsContainer> usProvider;

        LogPlayer lPlayer;

        RWLT_Listener rwltListener;
        PingerTOAProcessor toaProcessor;
        TrackManager trackManager;
        WPManager wpManager;

        uOSMTileProvider tProvider;

        MiscInfoManager miManager;


        #region misc. UI thing

        bool basesVisible
        {
            get => basesVisibleBtn.Checked;
            set
            {
                basesVisibleBtn.Checked = value;

                if (value)
                    uMapPlot.SetTracksVisibility(true);
                else
                    uMapPlot.SetTracksVisibility(new List<string>() { "BASE 1", "BASE 2", "BASE 3", "BASE 4" }, false);

                uMapPlot.Invalidate();
            }
        }

        bool legendVisible
        {
            get => legendVisibleBtn.Checked;
            set
            {
                legendVisibleBtn.Checked = value;
                uMapPlot.LegendVisible = value;
                uMapPlot.Invalidate();
            }
        }

        bool logVisible
        {
            get => logVisibleBtn.Checked;
            set
            {
                logVisibleBtn.Checked = value;
                uMapPlot.HistoryVisible = value;
                uMapPlot.Invalidate();
            }
        }

        bool notesVisible
        {
            get => notesVisibleBtn.Checked;
            set
            {
                notesVisibleBtn.Checked = value;
                uMapPlot.RightUpperTextVisible = value;
                uMapPlot.Invalidate();
            }
        }

        bool miscInfoVisible
        {
            get => miscInfoVisibleBtn.Checked;
            set
            {
                miscInfoVisibleBtn.Checked = value;
                uMapPlot.LeftUpperTextVisible = value;
                uMapPlot.Invalidate();
            }
        }


        bool isLocVisible
        {
            get => isLocBtn.Checked;
            set
            {
                isLocBtn.Checked = value;
                usProvider.Data.RemLOCVisible = value;
                InvokeSetMiscInfo();
            }
        }

        bool isDptVisible
        {
            get => isDptBtn.Checked;
            set
            {
                isDptBtn.Checked = value;
                usProvider.Data.RemDPTVisible = value;
                InvokeSetMiscInfo();
            }
        }

        bool isBatVisible
        {
            get => isBatBtn.Checked;
            set
            {
                isBatBtn.Checked = value;
                usProvider.Data.RemBATVisible = value;
                InvokeSetMiscInfo();
            }
        }

        bool isTbaDopVisible
        {
            get => isTbaDopBtn.Checked;
            set
            {
                isTbaDopBtn.Checked = value;
                usProvider.Data.RemTBADOPVisible = value;
                InvokeSetMiscInfo();
            }
        }

        bool isDstVisible
        {
            get => isDstBtn.Checked;
            set
            {
                isDstBtn.Checked = value;
                usProvider.Data.RemDSTVisible = value;
                InvokeSetMiscInfo();
            }
        }

        bool isAzmVisible
        {
            get => isAzmBtn.Checked;
            set
            {
                isAzmBtn.Checked = value;
                usProvider.Data.RemAZMVisible = value;
                InvokeSetMiscInfo();
            }
        }

        bool isCrsVisible
        {
            get => isCrsBtn.Checked;
            set
            {
                isCrsBtn.Checked = value;
                usProvider.Data.RemCRSVisible = value;
                InvokeSetMiscInfo();
            }
        }

        bool isRazVisible
        {
            get => isRazBtn.Checked;
            set
            {
                isRazBtn.Checked = value;
                usProvider.Data.RemRAZVisible = value;
                InvokeSetMiscInfo();
            }
        }
        
        UIAutomation uiAutomation;

        #endregion


        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            
            #region Early init

            string vString = string.Format("🐠 {0} v{1}", Application.ProductName, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.Text = vString;

            #endregion

            #region paths & filenames

            DateTime startTime = DateTime.Now;
            settingsFileName = Path.ChangeExtension(Application.ExecutablePath, "settings");
            uiSettingsFileName = Path.ChangeExtension(Application.ExecutablePath, "uisettings");
            logPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
            logFileName = StrUtils.GetTimeDirTreeFileName(startTime, Application.ExecutablePath, "LOG", "log", true);
            snapshotsPath = StrUtils.GetTimeDirTree(startTime, Application.ExecutablePath, "SNAPSHOTS", false);
            tileDBPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Cache\\Tiles\\");

            #endregion

            #region logger

            logger = new TSLogProvider(logFileName);
            logger.WriteStart();
            logger.Write(vString);
            logger.TextAddedEvent += (o, e) => InvokeAppendHistoryLine(e.Text);

            #endregion

            #region settings

            sProvider = new SimpleSettingsProviderXML<SettingsContainer>();
            sProvider.isSwallowExceptions = false;

            logger.Write(string.Format("Loading settings from {0}", settingsFileName));

            try
            {
                sProvider.Load(settingsFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            logger.Write("Current application settings:");
            logger.Write(sProvider.Data.ToString());

            #endregion

            #region uMapPlot

            uMapPlot.TextBackgroundColor = Color.FromArgb(120, Color.White);

            uMapPlot.InitTrack("BASE 1", 4, PaletteHelper.GetColor(), 2, 4, false, Color.Transparent, 1, 1);
            uMapPlot.InitTrack("BASE 2", 4, PaletteHelper.GetColor(), 2, 4, false, Color.Transparent, 1, 1);
            uMapPlot.InitTrack("BASE 3", 4, PaletteHelper.GetColor(), 2, 4, false, Color.Transparent, 1, 1);
            uMapPlot.InitTrack("BASE 4", 4, PaletteHelper.GetColor(), 2, 4, false, Color.Transparent, 1, 1);

            #endregion

            #region trackManager

            trackManager = new TrackManager();
            trackManager.IsEmptyChanged += (o, e) => UIHelpers.InvokeSetEnabledState(mainToolStrip, utilsTracksBtn, !trackManager.IsEmpty);

            #endregion

            #region miManager

            miManager = new MiscInfoManager();
            miManager.UpdatedEventHandler += (o, e) => InvokeSetMiscInfo();

            #endregion

            #region rwltListener & toaProcessor

            toaProcessor = new PingerTOAProcessor(sProvider.Data.RERRThreshold_m, 3, 8, 4, 25);
            toaProcessor.PingerLocationUpdatedHandler += (o, e) =>
            {
                trackManager.AddPoint(toaProcessor.Moniker, e.Location.Latitude, e.Location.Longitude, e.Location.Depth, e.TimeStamp);
                InvokeAddPoint(toaProcessor.Moniker, e.Location.Latitude, e.Location.Longitude, e.Course, true);                
            };

            toaProcessor.TemperatureUpdatedHandler += (o, e) => wpManager.Temperature = e.Temperature_C;

            toaProcessor.RemoteUpdated += (o, e) => InvokeSetMiscInfo();

            Color auxGNSSColor = PaletteHelper.GetColor();

            if (sProvider.Data.IsUseAUXGNSS)
            {
                rwltListener = new RWLT_Listener(toaProcessor, sProvider.Data.AUXGNSSPort_Baudrate);
                uMapPlot.InitTrack("AUX GNSS", sProvider.Data.TrackPointsToShow, auxGNSSColor, 1, 4, true, auxGNSSColor, 1, 200);
            }
            else if (sProvider.Data.IsBase1AsAUXGNSS)
            {
                rwltListener = new RWLT_Listener(toaProcessor, sProvider.Data.IsBase1AsAUXGNSS);
                uMapPlot.InitTrack("AUX GNSS", sProvider.Data.TrackPointsToShow, auxGNSSColor, 1, 4, true, auxGNSSColor, 1, 200);

                InvokeUpdatePortStatusLbl(mainStatusStrip, auxGNSSPortStatusLbl, rwltListener.IsActive, rwltListener.RWLTPortDetected, "BASE 1 as AUX GNSS");
                auxGNSSPortStatusLbl.Visible = true;
            }
            else
                rwltListener = new RWLT_Listener(toaProcessor);

            rwltListener.AUXGNSSPortDetectedChangedHandler += (o, e) =>
            {
                InvokeUpdatePortStatusLbl(mainStatusStrip, auxGNSSPortStatusLbl, rwltListener.IsActive, rwltListener.AUXGNSSPortDetected, rwltListener.AUXGNSSPortStatus);
            };

            rwltListener.AUXGNSSPortIsActiveChangedHandler += (o, e) =>
            {
                InvokeUpdatePortStatusLbl(mainStatusStrip, auxGNSSPortStatusLbl, rwltListener.IsActive, rwltListener.AUXGNSSPortDetected, rwltListener.AUXGNSSPortStatus);
            };

            rwltListener.RWLTPortDetectedChangedHandler += (o, e) =>
            {
                InvokeUpdatePortStatusLbl(mainStatusStrip, rwltPortStatusLbl, rwltListener.IsActive, rwltListener.RWLTPortDetected, rwltListener.RWLTPortStatus);

                if (rwltListener.IsStBaseAsAUXGNSS)
                    InvokeUpdatePortStatusLbl(mainStatusStrip, auxGNSSPortStatusLbl, rwltListener.IsActive, rwltListener.RWLTPortDetected, "BASE 1 as AUX GNSS");
            };

            rwltListener.RWLTPortIsActiveChangedHandler += (o, e) =>
            {
                UIHelpers.InvokeSetCheckedState(mainToolStrip, linkBtn, rwltListener.IsActive);
                UIHelpers.InvokeSetEnabledState(mainToolStrip, settingsBtn, !rwltListener.IsActive);
                UIHelpers.InvokeSetEnabledState(mainToolStrip, logPlaybackBtn, !rwltListener.IsActive);
                InvokeUpdatePortStatusLbl(mainStatusStrip, rwltPortStatusLbl, rwltListener.IsActive, rwltListener.RWLTPortDetected, rwltListener.RWLTPortStatus);

                if (rwltListener.IsStBaseAsAUXGNSS)
                    InvokeUpdatePortStatusLbl(mainStatusStrip, auxGNSSPortStatusLbl, rwltListener.IsActive, rwltListener.RWLTPortDetected, "BASE 1 as AUX GNSS");

                logger.Write(string.Format("rwltListener.IsActive={0}", rwltListener.IsActive));
            };

            rwltListener.CourseSpeedUpdatedHandler += (o, e) =>
            {
                miManager.SetValue("CRS", e.Course_deg);
                miManager.SetValue("SPD", e.Speed_mps * 3.6);
            };

            rwltListener.LocationUpdatedHandler += (o, e) =>
            {
                if (e.ID == "AUX GNSS")
                {
                    miManager.SetValue("LAT", e.Latitude_deg);
                    miManager.SetValue("LON", e.Longitude_deg);
                }

                trackManager.AddPoint(e.ID, e.Latitude_deg, e.Longitude_deg, 0.0, e.TimeStamp);
                InvokeAddPoint(e.ID, e.Latitude_deg, e.Longitude_deg, true);
            };

            rwltListener.BaseStateUpdatedHandler += (o, e) =>
            {
                if (e.BaseID != BaseIDs.BASE_INVALID)
                {
                    var key = e.BaseID.ToString().Remove(1, 4); // "BASE_1" -> "B1" TODO: refactor

                    if (!double.IsNaN(e.BatVoltage))
                        miManager.SetValue(key + "V", e.BatVoltage);

                    if (!double.IsNaN(e.MSR_dB))
                        miManager.SetValue(key + "M", e.MSR_dB);
                }
            };

            rwltListener.LogEventHandler += (o, e) => logger.Write(string.Format("{0}: {1}", e.EventType, e.LogString));

            #endregion

            #region uiAutomation

            uiAutomation = new UIAutomation();

            uiAutomation.InitBoolProperty<MainForm>(this, nameof(basesVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(legendVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(logVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(notesVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(miscInfoVisible));

            uiAutomation.InitBoolProperty<MainForm>(this, nameof(isLocVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(isDptVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(isBatVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(isTbaDopVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(isDstVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(isAzmVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(isCrsVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(isRazVisible));

            #endregion

            #region lPlayer

            lPlayer = new LogPlayer();
            lPlayer.NewLogLineHandler += (o, e) =>
            {
                /// TODO: Refactor!

                if (e.Line.StartsWith("INFO"))
                {
                    int idx = e.Line.IndexOf(' ');
                    if (idx >= 0)
                    {
                        rwltListener.Emulate(e.Line.Substring(idx).Trim());
                    }
                }
                else if (e.Line.StartsWith("NOTE"))
                {
                    var match = Regex.Match(e.Line, "\"[^\" ][^\"]*\"");
                    if (match.Success)
                    {
                        InvokeSetNoteText(match.ToString().Trim('"'));
                    }
                }
                else if (e.Line.StartsWith(UIAutomation.LogID))
                {
                    int idx = e.Line.IndexOf(' ');
                    if (idx >= 0)
                    {
                        InvokePerformUIAction(e.Line.Substring(idx).Trim());
                    }
                }
            };
            lPlayer.LogPlaybackFinishedHandler += (o, e) =>
            {
                rwltListener.Stop();

                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        settingsBtn.Enabled = true;
                        linkBtn.Enabled = true;
                        logPlaybackBtn.Text = "▶ Playback...";
                        MessageBox.Show(string.Format("Log file \"{0}\" playback is finished", lPlayer.LogFileName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                }
                else
                {
                    settingsBtn.Enabled = true;
                    linkBtn.Enabled = true;
                    logPlaybackBtn.Text = "▶ Playback...";
                    MessageBox.Show(string.Format("Log file \"{0}\" playback is finished", lPlayer.LogFileName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            #endregion

            #region tProvider

            Size tSize = new Size(sProvider.Data.TileSize, sProvider.Data.TileSize);
            tProvider = new uOSMTileProvider(256, 19, tSize, tileDBPath, sProvider.Data.TileServers);
            uMapPlot.ConnectTileProvider(tProvider);

            #endregion

            #region wpManager

            wpManager = new WPManager();
            wpManager.IsAutoGravity = true;
            wpManager.Salinity = sProvider.Data.Salinity_PSU;
            wpManager.SoundSpeed = sProvider.Data.SoundSpeed_mps;            

            miManager.SetValue("STY", wpManager.Salinity);
            miManager.SetValue("SOS", wpManager.SoundSpeed);
            miManager.SetValue("WTM", wpManager.Temperature);

            wpManager.IsAutoSalinity = sProvider.Data.IsAutoSalinity;
            wpManager.IsAutoSoundSpeed = sProvider.Data.IsAutosoundSpeed;

            wpManager.SalinityChanged += (o, e) =>
            {
                miManager.SetValue("STY", wpManager.Salinity);

                logger.Write(string.Format("STY updated: {0:F01} PSU ({1:F01}, {2:F01})",
                    wpManager.Salinity, wpManager.SalinityLatPoint, wpManager.SalinityLonPoint));
            };
            wpManager.SoundSpeedChanged += (o, e) =>
            {
                miManager.SetValue("SOS", wpManager.SoundSpeed);
                toaProcessor.SoundSpeed_mps = wpManager.SoundSpeed;
                logger.Write(string.Format("SOS updated: {0:F01} m/s", wpManager.SoundSpeed));
            };

            #endregion            

            #region UI settings

            usProvider = new SimpleSettingsProviderXML<UISettingsContainer>();
            usProvider.isSwallowExceptions = true;
            usProvider.Load(uiSettingsFileName);

            basesVisible = usProvider.Data.BasesVisible;
            legendVisible = usProvider.Data.LegendVisible;
            logVisible = usProvider.Data.LogVisible;
            notesVisible = usProvider.Data.NotesVisible;
            miscInfoVisible = usProvider.Data.MiscInfoVisible;

            isLocVisible = usProvider.Data.RemLOCVisible;
            isDptVisible = usProvider.Data.RemDPTVisible;
            isBatVisible = usProvider.Data.RemBATVisible;
            isTbaDopVisible = usProvider.Data.RemTBADOPVisible;
            isDstVisible = usProvider.Data.RemDSTVisible;
            isAzmVisible = usProvider.Data.RemAZMVisible;
            isCrsVisible = usProvider.Data.RemCRSVisible;
            isRazVisible = usProvider.Data.RemRAZVisible;

            if ((usProvider.Data.WSize.Width >= this.MinimumSize.Width) &&
                (usProvider.Data.WSize.Height >= this.MinimumSize.Height))
                this.Size = usProvider.Data.WSize;

            this.Location = usProvider.Data.WLocation;
            this.WindowState = usProvider.Data.WState;

            #endregion
        }

        #endregion

        #region Methods        
       
        private void InvokePerformUIAction(string uiActionName)
        {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { uiAutomation.PerformUIAction(uiActionName); });
            else
                uiAutomation.PerformUIAction(uiActionName);
        }        

        private void AddPoint(string trackID, double lat, double lon, bool isInvalidate)
        {
            if (!uMapPlot.IsTrackPresent(trackID))
                uMapPlot.InitTrack(trackID, sProvider.Data.TrackPointsToShow, PaletteHelper.GetColor(), 1, 4, true, Color.Transparent, 1, 1);

            uMapPlot.AddPoint(trackID, lat, lon);

            if (isInvalidate)
                uMapPlot.Invalidate();
        }

        private void AddPoint(string trackID, double lat, double lon, double crs, bool isInvalidate)
        {
            if (!uMapPlot.IsTrackPresent(trackID))
                uMapPlot.InitTrack(trackID, sProvider.Data.TrackPointsToShow, PaletteHelper.GetColor(), 1, 4, true, Color.Transparent, 1, 1);

            uMapPlot.AddPoint(trackID, lat, lon, crs);

            if (isInvalidate)
                uMapPlot.Invalidate();
        }

        private string BuildMiscInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("AUX\r\n{0}\r\n\r\n", miManager.ToString());

            var remDescription = toaProcessor.GetRemotesDescription();
            if (remDescription.Count > 0)
            {
                sb.AppendLine("Remote");

                foreach (var item in remDescription)
                {
                    sb.AppendFormat("{0}: {1}\r\n", item.Key, item.Value);
                }
            }

            return sb.ToString();                
        }

        private string SaveFullScreenshot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(snapshotsPath))
                    Directory.CreateDirectory(snapshotsPath);

                var fName = string.Format("{0}.{1}", StrUtils.GetHMSString(), ImageFormat.Png);
                var path = Path.Combine(snapshotsPath, fName);
                target.Save(path, ImageFormat.Png);

                return string.Format("Screenshot saved: {0}", fName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #region Invokers

        private void InvokeUpdatePortStatusLbl(StatusStrip strip, ToolStripStatusLabel lbl, bool active, bool detected, string text)
        {
            Color backColor = Color.FromKnownColor(KnownColor.Control);
            Color foreColor = Color.FromKnownColor(KnownColor.ControlText);

            if (active)
            {
                foreColor = Color.Yellow;
                if (!detected)
                {
                    backColor = Color.Red;
                }
                else
                {
                    backColor = Color.Green;
                }
            }

            UIHelpers.InvokeSetText(strip, lbl, text, foreColor, backColor);
        }

        private void InvokeAppendHistoryLine(string line)
        {
            if (uMapPlot.InvokeRequired)
                uMapPlot.Invoke((MethodInvoker)delegate
                {
                    uMapPlot.AppendHistory(line);
                    uMapPlot.Invalidate();
                });
            else
            {
                uMapPlot.AppendHistory(line);
                uMapPlot.Invalidate();
            }
        }

        private void InvokeAddPoint(string trackID, double lat, double lon, bool isInvalidate)
        {
            if (uMapPlot.InvokeRequired)
                uMapPlot.Invoke((MethodInvoker)delegate { AddPoint(trackID, lat, lon, isInvalidate); });
            else
                AddPoint(trackID, lat, lon, isInvalidate);
        }

        private void InvokeAddPoint(string trackID, double lat, double lon, double crs, bool isInvalidate)
        {
            if (uMapPlot.InvokeRequired)
                uMapPlot.Invoke((MethodInvoker)delegate { AddPoint(trackID, lat, lon, crs, isInvalidate); });
            else
                AddPoint(trackID, lat, lon, crs, isInvalidate);
        }

        private void InvokeSetMiscInfo()
        {
            if (uMapPlot.InvokeRequired)
                uMapPlot.Invoke((MethodInvoker)delegate
                {
                    uMapPlot.LeftUpperText = BuildMiscInfo();
                    uMapPlot.Invalidate();
                });
            else
            {
                uMapPlot.LeftUpperText = BuildMiscInfo();
                uMapPlot.Invalidate();
            }
        }

        private void InvokeSetNoteText(string text)
        {
            if (uMapPlot.InvokeRequired)
                uMapPlot.Invoke((MethodInvoker)delegate
                {
                    uMapPlot.RightUpperTextSet(text);
                    uMapPlot.Invalidate();
                });
            else
            {
                uMapPlot.RightUpperTextSet(text);
                uMapPlot.Invalidate();
            }
        }

        #endregion

        private void ProcessException(Exception ex, bool isMsgBox)
        {
            logger.Write(ex);

            if (isMsgBox)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Handlers

        #region UI

        #region mainToolStrip

        private void linkBtn_Click(object sender, EventArgs e)
        {
            if (rwltListener.IsActive)
                rwltListener.Stop();
            else
                rwltListener.Start();
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            using (SettingsEditor sEditor = new SettingsEditor())
            {
                sEditor.Text = string.Format("🐠 {0} - [Settings]", Application.ProductName);
                sEditor.Value = sProvider.Data;

                if (sEditor.ShowDialog() == DialogResult.OK)
                {
                    sProvider.Data = sEditor.Value;

                    bool saved = false;

                    try
                    {
                        sProvider.Save(settingsFileName);
                        saved = true;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }

                    if (saved && MessageBox.Show("Settings has been updated. Restart application to apply?",
                        "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        isRestart = true;
                        Application.Restart();
                    }

                }
            }
        }

        #region LOG

        private void logPlaybackBtn_Click(object sender, EventArgs e)
        {
            if (lPlayer.IsRunning)
            {
                if (MessageBox.Show("Log playback is currently active, do you want to stop abort it?",
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    lPlayer.RequestToStop();
            }
            else
            {
                using (OpenFileDialog oDialog = new OpenFileDialog())
                {
                    oDialog.Title = "Select a log file to playback...";
                    oDialog.DefaultExt = "log";
                    oDialog.Filter = "Log files (*.log)|*.log";

                    if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lPlayer.Playback(oDialog.FileName);

                        logPlaybackBtn.Text = "⏹ Stop playback";
                        settingsBtn.Enabled = false;
                        linkBtn.Enabled = false;
                    }
                }
            }
        }

        private void logViewCurrentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(logFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        private void logRemoveEmptyEntriesBtn_Click(object sender, EventArgs e)
        {
            string logRootPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
            var dirs = Directory.GetDirectories(logRootPath);
            int fNum = 0;
            foreach (var item in dirs)
            {
                var fNames = Directory.GetFiles(item);

                foreach (var fName in fNames)
                {
                    FileInfo fInfo = new FileInfo(fName);
                    if (fInfo.Length <= 2048)
                    {
                        try
                        {
                            File.Delete(fName);
                            fNum++;
                        }
                        catch (Exception ex)
                        {
                            ProcessException(ex, true);
                        }
                    }
                }

                fNames = Directory.GetFiles(item);
                if (fNames.Length == 0)
                {
                    try
                    {
                        Directory.Delete(item);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }

            MessageBox.Show(string.Format("{0} File(s) was/were deleted.", fNum),
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void logClearAllBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all log entries? (This action cannot be undone!)",
                                "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                string logRootPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
                var dirs = Directory.GetDirectories(logRootPath);
                int dirNum = 0;
                foreach (var item in dirs)
                {
                    try
                    {
                        Directory.Delete(item, true);
                        dirNum++;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }

                MessageBox.Show(string.Format("{0} Entries was/were deleted.", dirNum),
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        #endregion

        #region UTILS

        #region TRACKS

        private void trackExportBtn_Click(object sender, EventArgs e)
        {
            bool saved = false;
            using (SaveFileDialog sDialog = new SaveFileDialog())
            {
                sDialog.Title = "🐠 Export tracks to...";
                sDialog.Filter = "KML (*.kml)|*.kml|CSV (*.csv)|*.csv";
                sDialog.FileName = StrUtils.GetHMSString();

                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // KML
                        if (sDialog.FilterIndex == 1)
                        {
                            trackManager.ExportToKML(sDialog.FileName);
                            saved = true;
                        }
                        // CSV
                        else if (sDialog.FilterIndex == 2)
                        {
                            trackManager.ExportToCSV(sDialog.FileName);
                            saved = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }

            if (saved &&
                (MessageBox.Show("Tracks are saved, clear all tracks data?",
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes))
                trackManager.Clear();
        }

        private void trackClearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to clear all tracks obtained during the current session?",
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                trackManager.Clear();
            }
        }

        #endregion

        #endregion

        private void addNoteTxb_TextChanged(object sender, EventArgs e)
        {
            addNoteBtn.Enabled = !string.IsNullOrWhiteSpace(addNoteTxb.Text);
        }

        private void addNoteTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                addNoteBtn_Click(null, null);
        }

        private void addNoteBtn_Click(object sender, EventArgs e)
        {
            logger.Write(string.Format("NOTE: \"{0}\"", addNoteTxb.Text));
            uMapPlot.RightUpperTextSet(addNoteTxb.Text);
            addNoteTxb.Clear();
        }

        private void infoBtn_Click(object sender, System.EventArgs e)
        {
            using (AboutBox aDialog = new AboutBox())
            {
                aDialog.ApplyAssembly(Assembly.GetExecutingAssembly());

#if IS_DIVENET
                aDialog.Weblink = "www.divenetgps.com";                
#else
                aDialog.Weblink = "www.unavlab.com";
#endif

                aDialog.ShowDialog();
            }
        }

        #endregion

        #region plotToolStrip

        private void basesVisibleBtn_Click(object sender, EventArgs e)
        {
            basesVisible = !basesVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(basesVisible)));
        }

        private void logVisibleBtn_Click(object sender, EventArgs e)
        {
            logVisible = !logVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(logVisible)));
        }

        private void legendVisibleBtn_Click(object sender, EventArgs e)
        {
            legendVisible = !legendVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(legendVisible)));
        }

        private void notesVisibleBtn_Click(object sender, EventArgs e)
        {
            notesVisible = !notesVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(notesVisible)));
        }

        private void miscInfoVisibleBtn_Click(object sender, EventArgs e)
        {
            miscInfoVisible = !miscInfoVisible;

            isLocBtn.Enabled = miscInfoVisible;
            isDptBtn.Enabled = miscInfoVisible;
            isBatBtn.Enabled = miscInfoVisible;
            isTbaDopBtn.Enabled = miscInfoVisible;
            isDstBtn.Enabled = miscInfoVisible;
            isAzmBtn.Enabled = miscInfoVisible;
            isCrsBtn.Enabled = miscInfoVisible;
            isRazBtn.Enabled = miscInfoVisible;

            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(miscInfoVisible)));
        }

        private void isLocBtn_Click(object sender, EventArgs e)
        {
            isLocVisible = !isLocVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(isLocVisible)));
        }

        private void isDptBtn_Click(object sender, EventArgs e)
        {
            isDptVisible = !isDptVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(isDptVisible)));
        }

        private void isBatBtn_Click(object sender, EventArgs e)
        {
            isBatVisible = !isBatVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(isBatVisible)));
        }

        private void isTbaDopBtn_Click(object sender, EventArgs e)
        {
            isTbaDopVisible = !isTbaDopVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(isTbaDopVisible)));
        }

        private void isDstBtn_Click(object sender, EventArgs e)
        {
            isDstVisible = !isDstVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(isDstVisible)));
        }

        private void isAzmBtn_Click(object sender, EventArgs e)
        {
            isAzmVisible = !isAzmVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(isAzmVisible)));
        }

        private void isCrsBtn_Click(object sender, EventArgs e)
        {
            isCrsVisible = !isCrsVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(isCrsVisible)));
        }

        private void isRazBtn_Click(object sender, EventArgs e)
        {
            isRazVisible = !isRazVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(isRazVisible)));
        }

        private void printScreenBtn_Click(object sender, EventArgs e)
        {
            logLabel.Text = SaveFullScreenshot();
        }

        private void resetViewBtn_Click(object sender, EventArgs e)
        {
            uMapPlot.ClearTracks();
            uMapPlot.Invalidate();
        }

        #endregion

        #region mainForm

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rwltListener.Stop();
            rwltListener.Dispose();

            logger.FinishLog();
            logger.Flush();

            #region UISettings

            usProvider.Data.WState = this.WindowState;

            usProvider.Data.WSize = this.Size;
            usProvider.Data.WLocation = this.Location;

            usProvider.Data.BasesVisible = basesVisible;
            usProvider.Data.LogVisible = logVisible;
            usProvider.Data.LegendVisible = legendVisible;
            usProvider.Data.NotesVisible = notesVisible;
            usProvider.Data.MiscInfoVisible = miscInfoVisible;

            usProvider.Save(uiSettingsFileName);

            #endregion
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !isRestart &&
                (MessageBox.Show(string.Format("Close {0}?", Application.ProductName),
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((ModifierKeys == Keys.Control) && ((e.KeyChar & (char)Keys.S) != 0))
            {
                printScreenBtn_Click(printScreenBtn, null);
                e.Handled = true;
            }
            else
            {
                if (!addNoteTxb.Focused)
                    addNoteTxb.Focus();
            }
        }

        #endregion

        #endregion

        #endregion        
    }
}
