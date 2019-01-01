// ===========================================================================================================
// <copyright file="SettingsForm.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the settings Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the settings.</summary>
    ///
    /// ### <inheritdoc/>
    // ===========================================================================================================
    public partial class SettingsForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the
        ///          <see cref="T:CheckPublicTransportRelations.SettingsForm" /> class.</summary>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public SettingsForm()
        {
            this.InitializeComponent();
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
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by SaveButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BoundingBox = this.boundingBoxTextBox.Text;

            Properties.Settings.Default.OverpassServer = this.overpassServerTextBox.Text;
            Properties.Settings.Default.OverpassQueryPrefix = this.overpassQueryPrefixTextBox.Text;
            Properties.Settings.Default.OverpassBusStops = this.overpassBusStopQueryTextBox.Text;
            Properties.Settings.Default.OverpassTransportData = this.overpassTransportDataTextBox.Text;

            Properties.Settings.Default.TravelineSite = this.ftpSiteTextBox.Text;
            Properties.Settings.Default.TravelineUsername = this.usernameTextBox.Text;
            Properties.Settings.Default.TravelinePassword = this.passwordTextBox.Text;
            Properties.Settings.Default.LocalPath = this.pathTextBox.Text;

            Properties.Settings.Default.Save();

            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by SettingsForm for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.boundingBoxTextBox.Text = Properties.Settings.Default.BoundingBox;

            this.overpassServerTextBox.Text = Properties.Settings.Default.OverpassServer;
            this.overpassQueryPrefixTextBox.Text = Properties.Settings.Default.OverpassQueryPrefix;
            this.overpassBusStopQueryTextBox.Text = Properties.Settings.Default.OverpassBusStops;
            this.overpassTransportDataTextBox.Text = Properties.Settings.Default.OverpassTransportData;

            this.ftpSiteTextBox.Text = Properties.Settings.Default.TravelineSite;
            this.usernameTextBox.Text = Properties.Settings.Default.TravelineUsername;
            this.passwordTextBox.Text = Properties.Settings.Default.TravelinePassword;
            this.pathTextBox.Text = Properties.Settings.Default.LocalPath;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by LocalPathBrowseButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void LocalPathBrowseButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(this.pathTextBox.Text))
            {
                this.localFolderBrowserDialog.SelectedPath = this.pathTextBox.Text;
            }

            DialogResult result = this.localFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pathTextBox.Text = this.localFolderBrowserDialog.SelectedPath;
            }
        }
    }
}