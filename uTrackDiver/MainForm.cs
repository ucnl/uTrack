using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLUI.Dialogs;
using uOSM;
using uTrackLib;

namespace uTrackDiver
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
        DiversTOAProcessor toaProcessor;
        TrackManager trackManager;
        WPManager wpManager;

        uOSMTileProvider tProvider;

        MiscInfoManager miManager;

        #region misc. UI things

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

        #endregion

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            #region Early init

            string vString = string.Format("🤿 {0} v{1}", Application.ProductName, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.Text = vString;

            #endregion

            #region misc. info

            miManager = new MiscInfoManager();
            miManager.UpdatedEventHandler += (o, e) => InvokeSetMiscInfo(miManager.ToString());

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

            #region rwltListener & toaProcessor

            trackManager = new TrackManager();
            trackManager.IsEmptyChanged += (o, e) => UIHelpers.InvokeSetEnabledState(mainToolStrip, utilsTracksBtn, !trackManager.IsEmpty);

            toaProcessor = new DiversTOAProcessor(sProvider.Data.RERRThreshold_m, 3);
            toaProcessor.LocationUpdatedHandler += (o, e) =>
            {
                trackManager.AddPoint(e.ID, e.Latitude_deg, e.Longitude_deg, 0.0, e.TimeStamp);
                InvokeAddPoint(e.ID, e.Latitude_deg, e.Longitude_deg, true);
            };
            toaProcessor.RemotesUpdatedHandler += (o, e) =>
            {
                InvokeSynchRemotes(toaProcessor.GetRemotesDescription(
                    usProvider.Data.TreeDSTVisible,
                    usProvider.Data.TreeAZMVisible,
                    usProvider.Data.TreeRAZVisible,
                    usProvider.Data.TreeLOCVisible,
                    usProvider.Data.TreeRERVisible,
                    usProvider.Data.TreeDOPVisible));
            };

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

            #region lPlayer

            lPlayer = new LogPlayer();
            lPlayer.NewLogLineHandler += (o, e) =>
            {
                if (e.Line.StartsWith("INFO"))
                {
                    int idx = e.Line.IndexOf(' ');
                    if (idx >= 0)
                    {
                        rwltListener.Emulate(e.Line.Substring(idx));
                    }
                }
                else if (e.Line.StartsWith("NOTE"))
                {
                    var match = Regex.Match(e.Line, "\"[^\" ][^\"]*\"");
                    if (match.Success)
                    {
                        // InvokeSetNoteLine(match.ToString().Trim('"'));
                        throw new NotImplementedException();
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
            wpManager.Temperature = sProvider.Data.WaterTemperature_C;

            miManager.SetValue("STY", wpManager.Salinity);
            miManager.SetValue("SOS", wpManager.SoundSpeed);
            miManager.SetValue("WTM", wpManager.Temperature);

            wpManager.IsAutoSalinity = sProvider.Data.IsAutoSalinity;
            wpManager.IsAutoSoundSpeed = sProvider.Data.IsAutosoundSpeed;

            wpManager.SalinityChanged += (o, e) =>
            {
                miManager.SetValue("STY", wpManager.Salinity);

                logger.Write(string.Format("Salinity value updated: {0:F01} PSU ({1:F01}, {2:F01})",
                    wpManager.Salinity, wpManager.SalinityLatPoint, wpManager.SalinityLonPoint));
            };
            wpManager.SoundSpeedChanged += (o, e) =>
            {
                miManager.SetValue("SOS", wpManager.SoundSpeed);
                toaProcessor.SoundSpeed_mps = wpManager.SoundSpeed;
                logger.Write(string.Format("Sound speed value updated: {0:F01} m/s", wpManager.SoundSpeed));                
            };            

            #endregion

            #region UI settings

            usProvider = new SimpleSettingsProviderXML<UISettingsContainer>();
            usProvider.isSwallowExceptions = true;
            usProvider.Load(uiSettingsFileName);

            tree_isDstBtn.Checked = usProvider.Data.TreeDSTVisible;
            tree_isAzmBtn.Checked = usProvider.Data.TreeAZMVisible;
            tree_isRazBtn.Checked = usProvider.Data.TreeRAZVisible;
            tree_isLatLonBtn.Checked = usProvider.Data.TreeLOCVisible;
            tree_isRerBtn.Checked = usProvider.Data.TreeRERVisible;
            tree_isDopTbaBtn.Checked = usProvider.Data.TreeDOPVisible;

            basesVisible = usProvider.Data.BasesVisible;
            legendVisible = usProvider.Data.LegendVisible;
            logVisible = usProvider.Data.LogVisible;
            notesVisible = usProvider.Data.NotesVisible;
            miscInfoVisible = usProvider.Data.MiscInfoVisible;

            if ((usProvider.Data.WSize.Width >= this.MinimumSize.Width) &&
                (usProvider.Data.WSize.Height >= this.MinimumSize.Height))
                this.Size = usProvider.Data.WSize;
            
            this.Location = usProvider.Data.WLocation;
            this.WindowState = usProvider.Data.WState;

            #endregion            
        }

        #endregion

        #region Methods

        private void SynchRemotes(Dictionary<string, Dictionary<string, string>> rDescriptors)
        {
            bool isNeedExpandOnFirst = (diversTreeView.Nodes.Count == 0) ||
                ((diversTreeView.Nodes.Count > 0) &&
                (diversTreeView.Nodes[0].Nodes.Count == 0));

            foreach (var remote in rDescriptors)
            {
                string rKey = remote.Key;
                TreeNode bNode;

                if (!diversTreeView.Nodes.ContainsKey(rKey))
                    bNode = diversTreeView.Nodes.Add(rKey, string.Format("🤿 {0}", rKey));
                else
                    bNode = diversTreeView.Nodes[rKey];

                for (int i = bNode.Nodes.Count - 1; i >= 0; i--)
                {
                    if (!remote.Value.ContainsKey(bNode.Nodes[i].Name))
                        bNode.Nodes.RemoveByKey(bNode.Nodes[i].Name);
                }

                foreach (var rItem in remote.Value)
                {
                    if (!bNode.Nodes.ContainsKey(rItem.Key))
                        bNode.Nodes.Add(rItem.Key, string.Format("{0}: {1}", rItem.Key, rItem.Value));
                    else
                        bNode.Nodes[rItem.Key].Text = string.Format("{0}: {1}", rItem.Key, rItem.Value);
                }
            }

            if (isNeedExpandOnFirst)
                diversTreeView.ExpandAll();

            diversTreeView.Invalidate();
        }

        private void AddPoint(string trackID, double lat, double lon, bool isInvalidate)
        {
            if (!uMapPlot.IsTrackPresent(trackID))
                uMapPlot.InitTrack(trackID, sProvider.Data.TrackPointsToShow, PaletteHelper.GetColor(), 1, 4, true, Color.Transparent, 1, 1);

            uMapPlot.AddPoint(trackID, lat, lon);

            if (isInvalidate)
                uMapPlot.Invalidate();
        }

        #region Invokers

        private void InvokeSynchRemotes(Dictionary<string, Dictionary<string, string>> rDescriptors)
        {
            if (diversTreeView.InvokeRequired)
                diversTreeView.Invoke((MethodInvoker)delegate { SynchRemotes(rDescriptors); });
            else
                SynchRemotes(rDescriptors);
        }

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

        private void InvokeSetMiscInfo(string text)
        {
            if (uMapPlot.InvokeRequired)
                uMapPlot.Invoke((MethodInvoker)delegate
                {
                    uMapPlot.LeftUpperText = text;
                    uMapPlot.Invalidate();
                });
            else
            {
                uMapPlot.LeftUpperText = text;
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

        private void UpdateRemotesTree()
        {
            SynchRemotes(toaProcessor.GetRemotesDescription(
                    usProvider.Data.TreeDSTVisible,
                    usProvider.Data.TreeAZMVisible,
                    usProvider.Data.TreeRAZVisible,
                    usProvider.Data.TreeLOCVisible,
                    usProvider.Data.TreeRERVisible,
                    usProvider.Data.TreeDOPVisible));
        }

        #endregion

        #region Handlers

        #region UI

        #region mainToolStrip items

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
                sEditor.Text = string.Format("🤿 {0} - [Settings]", Application.ProductName);
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

        #region TRACK

        private void trackExportBtn_Click(object sender, EventArgs e)
        {
            bool saved = false;
            using (SaveFileDialog sDialog = new SaveFileDialog())
            {
                sDialog.Title = "🤿 Export tracks to...";
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
        private void addNoteTxb_TextChanged(object sender, EventArgs e)
        {
            addNoteBtn.Enabled = !string.IsNullOrWhiteSpace(addNoteTxb.Text);
        }

        private void infoBtn_Click(object sender, EventArgs e)
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

        #region plotToolStrip items               

        private void basesVisibleBtn_Click(object sender, EventArgs e)
        {
            basesVisible = !basesVisible;
        }

        private void logVisibleBtn_Click(object sender, EventArgs e)
        {
            logVisible = !logVisible;
        }

        private void legendVisibleBtn_Click(object sender, EventArgs e)
        {
            legendVisible = !legendVisible;
        }

        private void notesVisibleBtn_Click(object sender, EventArgs e)
        {
            notesVisible = !notesVisible;
        }

        private void miscInfoVisibleBtn_Click(object sender, EventArgs e)
        {
            miscInfoVisible = !miscInfoVisible;
        }

        private void resetViewBtn_Click(object sender, EventArgs e)
        {
            uMapPlot.ClearTracks();
            uMapPlot.Invalidate();
        }

        #endregion

        #region rightToolStrip

        private void sortTreeBtn_Click(object sender, EventArgs e)
        {
            diversTreeView.Sort();
        }

        private void collapseTreeBtn_Click(object sender, EventArgs e)
        {
            diversTreeView.CollapseAll();
        }

        private void expandTreeBtn_Click(object sender, EventArgs e)
        {
            diversTreeView.ExpandAll();
        }

        #endregion

        #region  bottomTreeToolStrip

        private void tree_isDstBtn_Click(object sender, EventArgs e)
        {
            usProvider.Data.TreeDSTVisible = !usProvider.Data.TreeDSTVisible;
            tree_isDstBtn.Checked = usProvider.Data.TreeDSTVisible;
            UpdateRemotesTree();
        }

        private void tree_isAzmBtn_Click(object sender, EventArgs e)
        {
            usProvider.Data.TreeAZMVisible = !usProvider.Data.TreeAZMVisible;
            tree_isAzmBtn.Checked = usProvider.Data.TreeAZMVisible;
            UpdateRemotesTree();
        }

        private void tree_isRazBtn_Click(object sender, EventArgs e)
        {
            usProvider.Data.TreeRAZVisible = !usProvider.Data.TreeRAZVisible;
            tree_isRazBtn.Checked = usProvider.Data.TreeRAZVisible;
            UpdateRemotesTree();
        }

        private void tree_isLatLonBtn_Click(object sender, EventArgs e)
        {
            usProvider.Data.TreeLOCVisible = !usProvider.Data.TreeLOCVisible;
            tree_isLatLonBtn.Checked = usProvider.Data.TreeLOCVisible;
            UpdateRemotesTree();
        }

        private void tree_isRerBtn_Click(object sender, EventArgs e)
        {
            usProvider.Data.TreeRERVisible = !usProvider.Data.TreeRERVisible;
            tree_isRerBtn.Checked = usProvider.Data.TreeRERVisible;
            UpdateRemotesTree();
        }

        private void tree_isDopTbaBtn_Click(object sender, EventArgs e)
        {
            usProvider.Data.TreeDOPVisible = !usProvider.Data.TreeDOPVisible;
            tree_isDopTbaBtn.Checked = usProvider.Data.TreeDOPVisible;
            UpdateRemotesTree();
        }

        #endregion

        #region MainForm

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
            if (!addNoteTxb.Focused)
                addNoteTxb.Focus();
        }

        #endregion

        #endregion

        #endregion
    }
}
