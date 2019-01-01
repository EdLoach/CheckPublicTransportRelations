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
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

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
        /// <createdBy>Ed (EdLoach) - 29 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Downloads the given file.</summary>
        ///
        /// <param name="file">The file.</param>
        ///
        /// <returns>True if it succeeds, false if it fails.</returns>
        // ===========================================================================================================
        private static bool Download(string file)
        {
            try
            {
                var sessionOptions = new SessionOptions
                                                    {
                                                        Protocol = Protocol.Ftp,
                                                        HostName = Properties.Settings.Default.TravelineSite,
                                                        UserName = Properties.Settings.Default.TravelineUsername,
                                                        Password = Properties.Settings.Default.TravelinePassword
                                                    };

                using (var session = new Session())
                {
                    session.Open(sessionOptions);

                    var transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };

                    TransferOperationResult transferResult = session.GetFiles(file, Path.Combine(Properties.Settings.Default.LocalPath, file), false, transferOptions);

                    transferResult.Check();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}", e);
                return false;
            }

            return true;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 29 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets file list.</summary>
        ///
        /// <returns>An array of string.</returns>
        // ===========================================================================================================
        private static string[] GetFileList()
        {
            var result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                var reqFtp = (FtpWebRequest)WebRequest.Create(
                    new Uri("ftp://" + Properties.Settings.Default.TravelineSite + "/"));
                reqFtp.UseBinary = true;
                reqFtp.Credentials = new NetworkCredential(
                    Properties.Settings.Default.TravelineUsername,
                    Properties.Settings.Default.TravelinePassword);
                reqFtp.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFtp.Proxy = null;
                reqFtp.KeepAlive = false;
                reqFtp.UsePassive = false;
                response = reqFtp.GetResponse();
                Stream stream = response.GetResponseStream();
                if (stream == null)
                {
                    return result.ToString().Split('\n');
                }

                reader = new StreamReader(stream);
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }

                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);

                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                reader?.Close();
                response?.Close();
                return null;
            }
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

            string[] files = GetFileList();
            int filesCount = files.Length;
            var counter = 0;
            var allDownloaded = true;

            foreach (string file in files)
            {
                if (worker != null && worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                if (!Download(file))
                {
                    allDownloaded = false;
                }

                counter += 1;
                worker?.ReportProgress(100 * counter / filesCount);
            }

            if (!allDownloaded)
            {
                return;
            }

            Properties.Settings.Default.LastTravelineDownload = DateTime.Today;
            Properties.Settings.Default.Save();
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
        private void TravelineDownloadForm_Load(object sender, EventArgs e)
        {
            if (this.downloadBackgroundWorker.IsBusy != true)
            {
                this.downloadBackgroundWorker.RunWorkerAsync();
            }
        }
    }
}