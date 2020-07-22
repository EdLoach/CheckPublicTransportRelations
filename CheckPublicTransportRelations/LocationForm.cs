// ===========================================================================================================
// <copyright file="LocationForm.cs" company="N/A">
// Copyright (c) 2019 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>24 February 2019</date>
// <summary>Implements the location Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the location.</summary>
    // ===========================================================================================================
    public partial class LocationForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="LocationForm"/> class.</summary>
        // ===========================================================================================================
        public LocationForm()
        {
            this.InitializeComponent();
            this.SelectedLocation = new Location();
            this.IsNew = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="LocationForm"/> class.</summary>
        ///
        /// <param name="selectedRow">The selected row.</param>
        // ===========================================================================================================
        public LocationForm(Location selectedRow)
        {
            this.InitializeComponent();
            this.SelectedLocation = selectedRow;
            this.IsNew = false;

            // This to cope with pre-1.5 location files
            if (selectedRow.BusStopTimeOut < 1)
            {
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets the selected location.</summary>
        ///
        /// <value>The selected location.</value>
        // ===========================================================================================================
        public Location SelectedLocation { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether this object is new.</summary>
        ///
        /// <value>True if this object is new, false if not.</value>
        // ===========================================================================================================
        private bool IsNew { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by LocationForm for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void LocationForm_Load(object sender, EventArgs e)
        {
            this.typeComboBox.DisplayMember = "Description";
            this.typeComboBox.ValueMember = "Value";
            this.typeComboBox.DataSource = Enum.GetValues(typeof(Enums.LocationType)).Cast<Enum>().Select(
                value => new
                             {
                                 (Attribute.GetCustomAttribute(
                                      value.GetType().GetField(value.ToString()),
                                      typeof(DescriptionAttribute)) as DescriptionAttribute)?.Description,
                                 value
                             })
                .OrderBy(item => item.value).ToList();

            this.typeComboBox.SelectedValue = this.SelectedLocation.Type;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);

            this.Text = this.IsNew ? "Add Location" : "Edit Location - " + this.SelectedLocation.Description;
            this.descriptionTextBox.Text = this.SelectedLocation.Description;
            this.descriptionTextBox.ReadOnly = !this.IsNew;

            this.boundingBoxTextBox.Text = this.SelectedLocation.BoundingBox;
            this.areaQueryTextBox.Text = this.SelectedLocation.AreaQuery;

            this.stopsTimeoutNumericUpDown.Value = this.SelectedLocation.BusStopTimeOut;
            this.dataQueryNumericUpDown.Value = this.SelectedLocation.TransportTimeOut;
            this.orphanRoutesNumericUpDown.Value = this.SelectedLocation.OrphanRoutesTimeOut;
            this.stopsQueryTextBox.Text = this.SelectedLocation.BusStopQuery;
            this.dataQueryTextBox.Text = this.SelectedLocation.TransportQuery;
            this.orphanRoutesTextBox.Text = this.SelectedLocation.OrphansQuery;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by SaveButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.SelectedLocation.BoundingBox = this.boundingBoxTextBox.Text;
            this.SelectedLocation.AreaQuery = this.areaQueryTextBox.Text;
            this.SelectedLocation.Description = this.descriptionTextBox.Text;
            this.SelectedLocation.BusStopTimeOut = (int)this.stopsTimeoutNumericUpDown.Value;
            this.SelectedLocation.TransportTimeOut = (int)this.dataQueryNumericUpDown.Value;
            this.SelectedLocation.OrphanRoutesTimeOut = (int)this.orphanRoutesNumericUpDown.Value;
            this.SelectedLocation.BusStopQuery = this.stopsQueryTextBox.Text;
            this.SelectedLocation.TransportQuery = this.dataQueryTextBox.Text;
            this.SelectedLocation.OrphansQuery = this.orphanRoutesTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by TypeComboBox for selected index changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedLocation.Type = (Enums.LocationType)this.typeComboBox.SelectedValue;
            switch ((Enums.LocationType)this.typeComboBox.SelectedValue)
            {
                case Enums.LocationType.BoundingBox:
                    this.SelectedLocation.BusStopQuery =
                        @"[out:json][timeout:{{timeout}}];(node[""naptan: AtcoCode""][!""railway""]({{bbox}}););out;>;out skel qt;";
                    this.stopsQueryTextBox.Enabled = false;
                    this.SelectedLocation.TransportQuery =
                        @"[out:json][timeout:{{timeout}}];((node[""naptan: AtcoCode""][!""railway""]({{bbox}}););rel(bn);rel(br);)->.b;relation.b[""route""!=""bus""][""type""!=""network""];(._;>>;);out;";
                    this.dataQueryTextBox.Enabled = false;
                    this.SelectedLocation.OrphansQuery =
                        @"[out:json][timeout:{{timeout}}];((relation[""route""=""bus""]({{bbox}}););<<;)->.b; relation.b[""route""=""bus""];(._;>>;);out meta;";
                    this.orphanRoutesTextBox.Enabled = false;
                    this.areaQueryTextBox.Enabled = false;
                    this.boundingBoxTextBox.Enabled = true;
                    this.stopsQueryTextBox.Text = this.SelectedLocation.BusStopQuery;
                    this.dataQueryTextBox.Text = this.SelectedLocation.TransportQuery;
                    this.orphanRoutesTextBox.Text = this.SelectedLocation.OrphansQuery;
                    break;
                case Enums.LocationType.Area:
                    this.SelectedLocation.BusStopQuery =
                        @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;(node(area.a)[""naptan:AtcoCode""][!""railway""];);out;>;out skel qt;";
                    this.stopsQueryTextBox.Enabled = false;
                    this.SelectedLocation.TransportQuery =
                        @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;((node(area.a)[""naptan:AtcoCode""][!""railway""];);rel(bn);rel(br);)->.b;relation.b[""route""!=""bus""][""type""!=""network""];(._;>>;);out;";
                    this.dataQueryTextBox.Enabled = false;
                    this.SelectedLocation.OrphansQuery =
                        @"[out:json][timeout:{{timeout}}]; area[{{area}}]->.a;((relation(area.a)[""route""=""bus""];);<<;)->.b; relation.b[""route""=""bus""];(._;>>;);out meta;";
                    this.orphanRoutesTextBox.Enabled = false;
                    this.areaQueryTextBox.Enabled = true;
                    this.boundingBoxTextBox.Enabled = false;
                    this.stopsQueryTextBox.Text = this.SelectedLocation.BusStopQuery;
                    this.dataQueryTextBox.Text = this.SelectedLocation.TransportQuery;
                    this.orphanRoutesTextBox.Text = this.SelectedLocation.OrphansQuery;
                    break;
                default:
                    this.stopsQueryTextBox.Enabled = true;
                    this.dataQueryTextBox.Enabled = true;
                    this.orphanRoutesTextBox.Enabled = true;
                    this.areaQueryTextBox.Enabled = true;
                    this.boundingBoxTextBox.Enabled = true;
                    break;
            }
        }
    }
}