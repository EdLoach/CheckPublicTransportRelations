// ===========================================================================================================
// <copyright file="BusStopNameMappingsForm.cs" company="N/A">
// Copyright (c) 2020 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>1 August 2020</date>
// <summary>Implements the bus stop name mappings Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the bus stop name mappings.</summary>
    // ===========================================================================================================
    public partial class BusStopNameMappingsForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="BusStopNameMappingsForm"/> class.</summary>
        // ===========================================================================================================
        public BusStopNameMappingsForm()
        {
            this.InitializeComponent();
            this.DialogResult = DialogResult.Cancel; // default value
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by BusStopNameMappingsForm for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void BusStopNameMappingsForm_Load(object sender, EventArgs e)
        {
            foreach (Tuple<string, string> mapping in NameMappings.Mappings)
            {
                this.mappingDataGridView.Rows.Add(mapping.Item1, mapping.Item2);
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by CloseButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Move down.</summary>
        // ===========================================================================================================
        private void MoveDown()
        {
            if (this.mappingDataGridView.RowCount > 0)
            {
                if (this.mappingDataGridView.SelectedRows.Count > 0)
                {
                    int rowCount = this.mappingDataGridView.Rows.Count;
                    int index = this.mappingDataGridView.SelectedCells[0].OwningRow.Index;

                    if (index == rowCount - 2)
                    {
                        // include the header row
                        return;
                    }

                    DataGridViewRowCollection rows = this.mappingDataGridView.Rows;

                    // remove the next row and add it in front of the selected row.
                    DataGridViewRow nextRow = rows[index + 1];
                    rows.Remove(nextRow);
                    nextRow.Frozen = false;
                    rows.Insert(index, nextRow);
                    this.mappingDataGridView.ClearSelection();
                    this.mappingDataGridView.Rows[index + 1].Selected = true;
                }
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by MoveDownButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            this.MoveDown();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Move up.</summary>
        // ===========================================================================================================
        private void MoveUp()
        {
            if (this.mappingDataGridView.RowCount > 0)
            {
                if (this.mappingDataGridView.SelectedRows.Count > 0)
                {
                    int index = this.mappingDataGridView.SelectedCells[0].OwningRow.Index;

                    if (index == 0)
                    {
                        return;
                    }

                    DataGridViewRowCollection rows = this.mappingDataGridView.Rows;

                    // remove the previous row and add it behind the selected row.
                    DataGridViewRow prevRow = rows[index - 1];
                    rows.Remove(prevRow);
                    prevRow.Frozen = false;
                    rows.Insert(index, prevRow);
                    this.mappingDataGridView.ClearSelection();
                    this.mappingDataGridView.Rows[index - 1].Selected = true;
                }
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by MoveUpButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            this.MoveUp();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by SaveButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var newMappings = new List<Tuple<string, string>>();
            foreach (DataGridViewRow row in this.mappingDataGridView.Rows)
            {
                newMappings.Add(
                    new Tuple<string, string>(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));
            }

            NameMappings.Save(newMappings);
            NameMappings.Refresh();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by RemoveButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (this.mappingDataGridView.SelectedRows.Count > 0)
            {
                this.mappingDataGridView.Rows.Remove(this.mappingDataGridView.SelectedRows[0]);
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by AddButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void AddButton_Click(object sender, EventArgs e)
        {
            this.mappingDataGridView.Rows.Add(" <from>", " <to>");
        }
    }
}