// ===========================================================================================================
// <copyright file="TravelineDownloadForm.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the traveline download Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    using CheckPublicTransportRelations.Properties;

    using WinSCP;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the traveline download.</summary>
    ///
    /// ### <inheritdoc/>
    // ===========================================================================================================
    public partial class TravelineDownloadForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the
        ///          <see cref="T:CheckPublicTransportRelations.TravelineDownloadForm" /> class.</summary>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public TravelineDownloadForm()
        {
            this.InitializeComponent();
            this.downloadBackgroundWorker.WorkerReportsProgress = true;
            this.downloadBackgroundWorker.WorkerSupportsCancellation = true;
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
            if (!this.downloadBackgroundWorker.WorkerSupportsCancellation)
            {
                return;
            }

            this.Enabled = false;
            this.downloadBackgroundWorker.CancelAsync();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by DownloadBackgroundWorker for do work events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Do work event information.</param>
        // ===========================================================================================================
        private void DownloadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            try
            {
                var sessionOptions = new SessionOptions
                                         {
                                             Protocol = Protocol.Ftp,
                                             HostName = Settings.Default.TravelineSite,
                                             UserName = Settings.Default.TravelineUsername,
                                             Password = Settings.Default.TravelinePassword
                                         };

                using (var session = new Session())
                {
                    session.Open(sessionOptions);

                    var transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };

                    ComparisonDifferenceCollection result = session.CompareDirectories(
                        SynchronizationMode.Local,
                        Path.Combine(Settings.Default.LocalPath, "tdnsdata"),
                        ".",
                        true,
                        false,
                        SynchronizationCriteria.Time,
                        transferOptions);

                    int filesCount = result.Count;
                    var counter = 0;
                    var allDownloaded = true;
                    foreach (ComparisonDifference change in result)
                    {
                        if (worker != null && worker.CancellationPending)
                        {
                            e.Cancel = true;
                            allDownloaded = false;
                            break;
                        }

                        counter += 1;

                        if (change.Action == SynchronizationAction.DownloadNew
                            // ReSharper disable once StringLiteralTypo
                            && change.Remote.FileName == "./TNDSV2.5")
                        {
                            worker?.ReportProgress(100 * counter / filesCount);
                            continue;
                        }

                        change.Resolve(session);
                        worker?.ReportProgress(100 * counter / filesCount);
                    }

                    if (!allDownloaded || counter == 0)
                    {
                        return;
                    }

                    Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: {0}", ex);
            }
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by downloadBackgroundWorker for progress changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Progress changed event information.</param>
        // ===========================================================================================================
        private void DownloadBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.downloadProgressBar.Value = e.ProgressPercentage;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by DownloadBackgroundWorker for run worker completed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Run worker completed event information.</param>
        // ===========================================================================================================
        private void DownloadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by Traveline Download Form for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        private void TravelineDownloadForm_Load(object sender, EventArgs e)
        {
            if (this.downloadBackgroundWorker.IsBusy != true)
            {
                this.downloadBackgroundWorker.RunWorkerAsync();
            }
        }
    }
}