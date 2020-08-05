// ===========================================================================================================
// <copyright file="NaptanStopAreaForm.cs" company="N/A">
// Copyright (c) 2019 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>24 February 2019</date>
// <summary>Implements the naptan Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using CheckPublicTransportRelations.Properties;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the naptan information.</summary>
    ///
    /// ### <inheritdoc/>
    // ===========================================================================================================
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public partial class NaptanStopAreaForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the
        ///          <see cref="T:CheckPublicTransportRelations.NaptanStopAreaForm" /> class.</summary>
        ///
        /// <param name="areaCode">The area code to find and display.</param>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public NaptanStopAreaForm(string areaCode)
        {
            this.InitializeComponent();
            this.StopAreaCode = areaCode;
            this.Stops = new Dictionary<string, string>();
        }
        
        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets the atco code.</summary>
        ///
        /// <value>The atco code.</value>
        // ===========================================================================================================
        private string StopAreaCode { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the zero-based index of the stop area code.</summary>
        ///
        /// <value>The stop area code index.</value>
        // ===========================================================================================================
        private int StopAreaCodeIndex { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the column heading.</summary>
        ///
        /// <value>The column heading.</value>
        // ===========================================================================================================
        private string[] ColumnHeading { get; set; }
        
        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the naptan stop.</summary>
        ///
        /// <value>The naptan stop.</value>
        // ===========================================================================================================
        private string[] NaptanStop { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the stop details.</summary>
        ///
        /// <value>The stop details.</value>
        // ===========================================================================================================
        private Dictionary<string, string> StopDetails { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 4 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets the stops.</summary>
        ///
        /// <value>The stops.</value>
        // ===========================================================================================================
        private Dictionary<string, string> Stops { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by AddStopButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void AddStopButton_Click(object sender, EventArgs e)
        {
            var tags = new StringBuilder();
            tags.Append("name\t");
            tags.AppendLine(this.StopDetails["Name"]);
            tags.Append("naptan:StopAreaCode\t");
            tags.AppendLine(this.StopDetails["StopAreaCode"]);
            tags.Append("naptan:StopAreaType\t");
            tags.AppendLine(this.StopDetails["StopAreaType"]);
            tags.AppendLine("naptan:verified\tno");
            tags.AppendLine("source\tnaptan");
            tags.AppendLine("type\tpublic_transport");
            tags.AppendLine("public_transport\tstop_area");
            var tagsText = tags.ToString();
            Clipboard.SetText(tagsText);
            MessageBox.Show(
                @"Clipboard text set to:" + Environment.NewLine + tagsText,
                @"Stop Area Tags",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by cancelButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by FindCodeButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void FindCodeButton_Click(object sender, EventArgs e)
        {
            string value =
                "http://127.0.0.1:8111/import?url=https%3A%2F%2Foverpass-api.de%2Fapi%2Fxapi_meta%3F*%5Bnaptan%253AStopAreaCode%253D"
                + this.StopAreaCode + "%5D";
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by NaptanForm for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void NaptanForm_Load(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Settings.Default.LocalPath, "naptandata", "NaPTANcsv.zip");
            this.StopDetails = new Dictionary<string, string>();
            this.addStopAreaButton.Enabled = false;

            if (File.Exists(fileName))
            {
                using (ZipArchive archive = ZipFile.OpenRead(fileName))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (!entry.FullName.StartsWith("StopAreas.csv", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        using (Stream stream = entry.Open())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                string line;
                                string columnHeadings = string.Empty;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (columnHeadings == string.Empty)
                                    {
                                        columnHeadings = line;
                                        this.ColumnHeading = columnHeadings.Replace(@"""", string.Empty).Split(',');
                                        this.StopAreaCodeIndex = Array.IndexOf(this.ColumnHeading, "StopAreaCode");
                                        if (this.StopAreaCodeIndex == -1)
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        this.NaptanStop = line.Replace(@"""", string.Empty).Split(',');
                                        if (!this.StopAreaCode.Equals(this.NaptanStop[this.StopAreaCodeIndex]))
                                        {
                                            continue;
                                        }

                                        for (var index = 0; index < this.ColumnHeading.Length; index++)
                                        {
                                            this.StopDetails.Add(this.ColumnHeading[index], this.NaptanStop[index]);
                                        }

                                        this.addStopAreaButton.Enabled = true;
                                        break;
                                    }
                                }
                            }
                        }

                        break;
                    }

                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (!entry.FullName.StartsWith("StopsInArea.csv", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        using (Stream stream = entry.Open())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                string line;
                                string columnHeadings = string.Empty;
                                var stopStopAreaCodeIndex = 0;
                                var stopAtcoCodeIndex = 0;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (columnHeadings == string.Empty)
                                    {
                                        columnHeadings = line;
                                        this.ColumnHeading = columnHeadings.Replace(@"""", string.Empty).Split(',');
                                        stopStopAreaCodeIndex = Array.IndexOf(this.ColumnHeading, "StopAreaCode");
                                        stopAtcoCodeIndex = Array.IndexOf(this.ColumnHeading, "AtcoCode");
                                        if (stopStopAreaCodeIndex == -1 || stopAtcoCodeIndex == -1)
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        var naptanStop = line.Replace(@"""", string.Empty).Split(',');
                                        if (!this.StopAreaCode.Equals(naptanStop[stopStopAreaCodeIndex]))
                                        {
                                            continue;
                                        }

                                        this.Stops.Add(naptanStop[stopAtcoCodeIndex], naptanStop[stopAtcoCodeIndex]);
                                    }
                                }
                            }
                        }

                        break;
                    }
                }
            }

            this.naptanDataGridView.DataSource = this.StopDetails.ToList();
            this.areaStopsDataGridView.DataSource = this.Stops.ToList();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 4 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by AreaStopsDataGridView for cell content click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Data grid view cell event information.</param>
        // ===========================================================================================================
        private void AreaStopsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (this.areaStopsDataGridView.Columns["atcoCodeColumn"] == null)
            {
                return;
            }

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                 || e.RowIndex < 0)
            {
                return;
            }

            if (this.areaStopsDataGridView.Columns["atcoLookupButtonColumn"] != null && e.ColumnIndex == this.areaStopsDataGridView.Columns["atcoLookupButtonColumn"].Index)
            {
                this.Enabled = false;
                var editForm = new NaptanForm(this.areaStopsDataGridView.Rows[e.RowIndex].Cells[this.areaStopsDataGridView.Columns["atcoCodeColumn"].Index].Value.ToString());
                editForm.ShowDialog();
                this.Enabled = true;
            }
        }
    }
}