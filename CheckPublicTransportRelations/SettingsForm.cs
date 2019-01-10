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
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    using CheckPublicTransportRelations.Properties;

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
        /// <param name="selectedLocation"></param>
        /// <param name="locations"></param>
        /// <inheritdoc/>
        // ===========================================================================================================
        public SettingsForm(Location selectedLocation, List<Location> locations)
        {
            this.InitializeComponent();
            this.SelectedLocation = selectedLocation;
            this.Locations = locations;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the selected location as at the time the form loads.</summary>
        ///
        /// <value>The selected location.</value>
        // ===========================================================================================================
        private Location SelectedLocation { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the locations.</summary>
        ///
        /// <value>The locations.</value>
        // ===========================================================================================================
        private List<Location> Locations { get; }

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
            Settings.Default.OverpassServer = this.overpassServerTextBox.Text;
            Settings.Default.OverpassQueryPrefix = this.overpassQueryPrefixTextBox.Text;

            Settings.Default.TravelineSite = this.ftpSiteTextBox.Text;
            Settings.Default.TravelineUsername = this.usernameTextBox.Text;
            Settings.Default.TravelinePassword = this.passwordTextBox.Text;
            Settings.Default.LocalPath = this.pathTextBox.Text;
            Settings.Default.SelectedLocation = ((Location)this.locationsComboBox.SelectedItem).Description;
            Settings.Default.Save();

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
            this.locationsComboBox.DataSource = this.Locations;
            foreach (object item in this.locationsComboBox.Items)
            {
                if ((Location)item != this.SelectedLocation)
                {
                    continue;
                }

                this.locationsComboBox.SelectedItem = item;
                break;
            }
            
            this.overpassServerTextBox.Text = Settings.Default.OverpassServer;
            this.overpassQueryPrefixTextBox.Text = Settings.Default.OverpassQueryPrefix;

            this.ftpSiteTextBox.Text = Settings.Default.TravelineSite;
            this.usernameTextBox.Text = Settings.Default.TravelineUsername;
            this.passwordTextBox.Text = Settings.Default.TravelinePassword;
            this.pathTextBox.Text = Settings.Default.LocalPath;
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

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by LocationsButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void LocationsButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var settingsForm = new LocationsForm(this.Locations);
            settingsForm.ShowDialog(this);
            MainForm.LoadLocations();
            string selectedLocationName = Settings.Default.SelectedLocation;
            Location selectedLocation = null;
            foreach (Location location in this.Locations)
            {
                if (location.Description != selectedLocationName)
                {
                    continue;
                }

                selectedLocation = location;
                break;
            }

            this.SelectedLocation = selectedLocation;
            if (selectedLocation != null)
            {
                Settings.Default.SelectedLocation = selectedLocation.Description;
            }

            Settings.Default.Save();

            this.Enabled = true;
        }
    }
}