// ===========================================================================================================
// <copyright file="LocationsForm.cs" company="N/A">
// Copyright (c) 2019 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>10 January 2019</date>
// <summary>Implements the locations Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the locations.</summary>
    // ===========================================================================================================
    public partial class LocationsForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="LocationsForm"/> class.</summary>
        ///
        /// <param name="locations">The locations.</param>
        // ===========================================================================================================
        public LocationsForm(Locations locations)
        {
            this.InitializeComponent();
            this.locationsDataGridView.AutoGenerateColumns = false;
            this.Locations = locations;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the locations.</summary>
        ///
        /// <value>The locations.</value>
        // ===========================================================================================================
        public Locations Locations { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
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
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by SaveButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SaveButton_Click(object sender, EventArgs e)
        {
            ((Locations)this.locationsDataGridView.DataSource).Save();
            
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by LocationsForm for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void LocationsForm_Load(object sender, EventArgs e)
        {
            this.locationsDataGridView.DataSource = this.Locations;
            this.deleteButton.Enabled = this.locationsDataGridView.SelectedRows.Count == 1 && this.locationsDataGridView.Rows.Count > 1;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by AddButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void AddButton_Click(object sender, EventArgs e)
        {
            this.locationsDataGridView.DataSource = null;
            this.Locations.Add(new Location());
            this.locationsDataGridView.DataSource = this.Locations;
            this.deleteButton.Enabled = this.locationsDataGridView.SelectedRows.Count == 1 && this.locationsDataGridView.Rows.Count > 1;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by LocationsDataGridView for selection changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void LocationsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.deleteButton.Enabled = this.locationsDataGridView.SelectedRows.Count == 1 && this.locationsDataGridView.Rows.Count > 1;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by DeleteButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.Locations.Remove((Location)this.locationsDataGridView.SelectedRows[0].DataBoundItem);
            this.locationsDataGridView.DataSource = null;
            this.locationsDataGridView.DataSource = this.Locations;
            this.deleteButton.Enabled = this.locationsDataGridView.SelectedRows.Count == 1 && this.locationsDataGridView.Rows.Count > 1;
        }
    }
}
