// ===========================================================================================================
// <copyright file="NaptanForm.cs" company="N/A">
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
    public partial class NaptanForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the
        ///          <see cref="T:CheckPublicTransportRelations.NaptanForm" /> class.</summary>
        ///
        /// <param name="selectedRow">The selected row.</param>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public NaptanForm(JourneyStop selectedRow)
        {
            this.InitializeComponent();
            this.AtcoCode = selectedRow.StopPointRef;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the
        ///          <see cref="T:CheckPublicTransportRelations.NaptanForm" /> class.</summary>
        ///
        /// <param name="selectedRow">The selected row.</param>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public NaptanForm(BusStop selectedRow)
        {
            this.InitializeComponent();
            this.AtcoCode = selectedRow.AtcoCode;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets the atco code.</summary>
        ///
        /// <value>The atco code.</value>
        // ===========================================================================================================
        private string AtcoCode { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the zero-based index of the atco code.</summary>
        ///
        /// <value>The atco code index.</value>
        // ===========================================================================================================
        private int AtcoCodeIndex { get; set; }

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
        /// <summary>Gets or sets the zero-based index of the common name.</summary>
        ///
        /// <value>The common name index.</value>
        // ===========================================================================================================
        private int CommonNameIndex { get; set; }

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
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by AddStopButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void AddStopButton_Click(object sender, EventArgs e)
        {
            var command = "http://127.0.0.1:8111/add_node?";
            command += "lon=" + this.StopDetails["Longitude"] + "&lat=" + this.StopDetails["Latitude"]
                             + "&addtags=" + "public_transport=platform" + "%7Csource=naptan" + "%7Cnaptan:verified=no"
                             + "%7Cnaptan:NaptanCode=" + this.StopDetails["NaptanCode"] + "%7Cnaptan:AtcoCode="
                             + this.StopDetails["ATCOCode"] + "%7Cname=" + this.StopDetails["CommonName"];
            if (this.StopDetails["BusStopType"] == "MKD")
            {
                command += "%7Chighway=bus_stop";
            }
            else
            {
                command += "%7Cnaptan:BusStopType=" + this.StopDetails["BusStopType"];
            }

            if (this.StopDetails["Status"] != "act")
            {
                command += "%7Cnaptan:Status=" + this.StopDetails["Status"];
            }

            Process.Start(command);
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
        /// <summary>Event handler. Called by FindAtcoCodeButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void FindAtcoCodeButton_Click(object sender, EventArgs e)
        {
            string value =
                "http://127.0.0.1:8111/import?url=https%3A%2F%2Foverpass-api.de%2Fapi%2Fxapi_meta%3F*%5Bnaptan%253AAtcoCode%253D"
                + this.StopDetails["ATCOCode"] + "%5D";
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by FindNaptanCodeButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void FindNaptanCodeButton_Click(object sender, EventArgs e)
        {
            string value =
                "http://127.0.0.1:8111/import?url=https%3A%2F%2Foverpass-api.de%2Fapi%2Fxapi_meta%3F*%5Bnaptan%253ANaptanCode%253D"
                + this.StopDetails["NaptanCode"] + "%5D";
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by FindNaptanCodeInRefButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void FindNaptanCodeInRefButton_Click(object sender, EventArgs e)
        {
            string value =
                "http://127.0.0.1:8111/import?url=https%3A%2F%2Foverpass-api.de%2Fapi%2Fxapi_meta%3F*%5Bref%253D"
                + this.StopDetails["NaptanCode"] + "%5D";
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
            string fileName = Path.Combine(Settings.Default.LocalPath, "NaPTANcsv.zip");
            this.StopDetails = new Dictionary<string, string>();
            this.addStopButton.Enabled = false;

            if (File.Exists(fileName))
            {
                using (ZipArchive archive = ZipFile.OpenRead(fileName))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (!entry.FullName.StartsWith("Stops.csv", StringComparison.OrdinalIgnoreCase))
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
                                        this.AtcoCodeIndex = Array.IndexOf(this.ColumnHeading, "ATCOCode");
                                        this.CommonNameIndex = Array.IndexOf(this.ColumnHeading, "CommonName");
                                        if (this.AtcoCodeIndex == -1 || this.CommonNameIndex == -1)
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        this.NaptanStop = line.Replace(@"""", string.Empty).Split(',');
                                        if (!this.AtcoCode.Equals(this.NaptanStop[this.AtcoCodeIndex]))
                                        {
                                            continue;
                                        }

                                        for (var index = 0; index < this.ColumnHeading.Length; index++)
                                        {
                                            this.StopDetails.Add(this.ColumnHeading[index], this.NaptanStop[index]);
                                        }

                                        this.addStopButton.Enabled = true;
                                        break;
                                    }
                                }
                            }
                        }

                        break;
                    }
                }
            }

            this.naptanDataGridView.DataSource = this.StopDetails.ToList();
        }
    }
}