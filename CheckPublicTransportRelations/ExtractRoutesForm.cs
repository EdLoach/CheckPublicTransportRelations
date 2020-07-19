// ===========================================================================================================
// <copyright file="ExtractRoutesForm.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the extract routes Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;

    using CheckPublicTransportRelations.Properties;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the extract routes.</summary>
    ///
    /// ### <inheritdoc/>
    // ===========================================================================================================
    public partial class ExtractRoutesForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the
        ///          <see cref="T:CheckPublicTransportRelations.ExtractRoutesForm" /> class.</summary>
        ///
        /// <param name="busStops">The bus stops.</param>
        /// <param name="locations">The locations</param>
        /// <param name="selectedLocation">The selected location</param>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public ExtractRoutesForm(List<BusStop> busStops, Locations locations, Location selectedLocation)
        {
            this.InitializeComponent();
            this.OverpassBusStops = busStops;
            this.extractRoutesBackgroundWorker.WorkerReportsProgress = true;
            this.extractRoutesBackgroundWorker.WorkerSupportsCancellation = true;
            this.Locations = locations;
            this.SelectedLocation = selectedLocation;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the selected location.</summary>
        ///
        /// <value>The selected location.</value>
        // ===========================================================================================================
        private Location SelectedLocation { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the locations.</summary>
        ///
        /// <value>The locations.</value>
        // ===========================================================================================================
        private Locations Locations { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the overpass bus stops.</summary>
        ///
        /// <value>The overpass bus stops.</value>
        // ===========================================================================================================
        private List<BusStop> OverpassBusStops { get; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the stops.</summary>
        ///
        /// <param name="file">        The file.</param>
        /// <param name="unzippedFile">The unzipped file.</param>
        ///
        /// <returns>The stops.</returns>
        // ===========================================================================================================
        private static IEnumerable<string> GetStops(FileSystemInfo file = null, string unzippedFile = null)
        {
            var returnValue = new HashSet<string>();
            if (file == null && unzippedFile == null)
            {
                return returnValue;
            }

            try
            {
                XDocument document = file != null ? XDocument.Load(file.FullName) : XDocument.Parse(unzippedFile);

                XElement stops = null;
                if (document.Root != null)
                {
                    for (var i = 0; i < document.Root.Elements().Count(); i++)
                    {
                        stops = document.Root.Elements().ElementAt(i);
                        if (stops.ToString().StartsWith("<StopPoints"))
                        {
                            break;
                        }

                        stops = null;
                    }
                }

                if (stops != null && stops.ToString().StartsWith("<StopPoints"))
                {
                    foreach (XElement stop in stops.Elements())
                    {
                        returnValue.Add(stop.Elements().ElementAt(0).Value);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return returnValue;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by CancelButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (!this.extractRoutesBackgroundWorker.WorkerSupportsCancellation)
            {
                return;
            }

            this.Enabled = false;
            this.extractRoutesBackgroundWorker.CancelAsync();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by extractRoutesBackgroundWorker for do work events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Do work event information.</param>
        // ===========================================================================================================
        private void ExtractRoutesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            string subFolder = DateTime.Today.ToString("yyyyMMdd");
            string copyPath = Path.Combine(Properties.Settings.Default.LocalPath, MainForm.ValidPathString(this.SelectedLocation.Description), subFolder);
            Directory.CreateDirectory(copyPath);
            var directoryInfo = new DirectoryInfo(copyPath);
            FileInfo[] files = directoryInfo.GetFiles("*.xml");
            foreach (FileInfo file in files)
            {
                File.Delete(file.FullName);
            }

            var openStreetMapStops = new HashSet<string>();
            foreach (BusStop stop in this.OverpassBusStops)
            {
                if (!openStreetMapStops.Contains(stop.AtcoCode))
                {
                    openStreetMapStops.Add(stop.AtcoCode);
                }
            }

            // get files in local path
            directoryInfo = new DirectoryInfo(Path.Combine(Settings.Default.LocalPath, "tdnsdata"));
            files = directoryInfo.GetFiles("*.zip");
            this.fileProgressBar.Minimum = 0;
            int filesCount = files.Length;
            var counter = 0;
            foreach (FileInfo file in files)
            {
                if (worker != null && worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                counter += 1;

                using (ZipArchive archive = ZipFile.OpenRead(file.FullName))
                {
                    int archiveEntryCount = archive.Entries.Count;
                    var archiveCounter = 0;
                    worker?.ReportProgress(
                        100 * counter / filesCount,
                        new Tuple<int, int>(archiveCounter, archiveEntryCount));
                    var extractedFiles = new Dictionary<string, Tuple<int, string>>();
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (worker != null && worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        archiveCounter += 1;
                        worker?.ReportProgress(
                            100 * counter / filesCount,
                            new Tuple<int, int>(archiveCounter, archiveEntryCount));

                        if (!entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        using (Stream stream = entry.Open())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                string unzippedFile = reader.ReadToEnd();
                                IEnumerable<string> routeStops = GetStops(null, unzippedFile);
                                var sharedStops = new HashSet<string>(openStreetMapStops);
                                sharedStops.IntersectWith(routeStops);
                                if (sharedStops.Count > 0)
                                {
                                    string nameEnds = entry.Name.Substring(entry.Name.LastIndexOf("-", StringComparison.Ordinal) + 1);
                                    nameEnds = nameEnds.Substring(0, nameEnds.Length - 4);
                                    string nameStarts = entry.Name.Substring(0, entry.Name.LastIndexOf("-", StringComparison.Ordinal));
                                    int nameEndsValue;
                                    int.TryParse(nameEnds, out nameEndsValue);
                                    if ((entry.Name.StartsWith("suf", StringComparison.OrdinalIgnoreCase) || entry.Name.StartsWith("bed", StringComparison.OrdinalIgnoreCase))
                                        && extractedFiles.ContainsKey(nameStarts))
                                    {
                                        if (extractedFiles[nameStarts].Item1 < nameEndsValue)
                                        {
                                            File.Delete(Path.Combine(copyPath, extractedFiles[nameStarts].Item2));
                                            extractedFiles.Remove(nameStarts);
                                            entry.ExtractToFile(Path.Combine(copyPath, entry.Name));
                                            extractedFiles.Add(nameStarts, new Tuple<int, string>(nameEndsValue, entry.Name));
                                        }
                                    }
                                    else
                                    {
                                        entry.ExtractToFile(Path.Combine(copyPath, entry.Name));
                                        extractedFiles.Add(nameStarts, new Tuple<int, string>(nameEndsValue, entry.Name));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (worker == null || worker.CancellationPending)
            {
                return;
            }

            this.SelectedLocation.LastServiceExtract = DateTime.Today;
            this.Locations.Save();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ExtractRoutesBackgroundWorker for progress changed
        ///          events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Progress changed event information.</param>
        // ===========================================================================================================
        private void ExtractRoutesBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.fileProgressBar.Value = e.ProgressPercentage;
            this.archiveProgressBar.Minimum = 0;
            var archiveProgress = (Tuple<int, int>)e.UserState;
            this.archiveProgressBar.Maximum = archiveProgress.Item2;
            this.archiveProgressBar.Value = archiveProgress.Item1;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ExtractRoutesBackgroundWorker for run worker completed
        ///          events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Run worker completed event information.</param>
        // ===========================================================================================================
        private void ExtractRoutesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ExtractRoutesForm for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ExtractRoutesForm_Load(object sender, EventArgs e)
        {
            if (this.extractRoutesBackgroundWorker.IsBusy != true)
            {
                this.extractRoutesBackgroundWorker.RunWorkerAsync();
            }
        }
    }
}