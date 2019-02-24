using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckPublicTransportRelations
{
    public partial class LocationForm : Form
    {
        public LocationForm()
        {
            this.InitializeComponent();
            this.SelectedLocation = new Location();
            this.IsNew = true;
        }

        private bool IsNew { get; set; }

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

        public Location SelectedLocation { get; set; }

        private void LocationForm_Load(object sender, EventArgs e)
        {
            this.typeComboBox.DisplayMember = "Description";
            this.typeComboBox.ValueMember = "Value";
            this.typeComboBox.DataSource = Enum.GetValues(typeof(Enums.LocationType))
                .Cast<Enum>()
                .Select(value => new
                                     {
                                         (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute)?.Description,
                                         value
                                     })
                .OrderBy(item => item.value)
                .ToList();

            this.typeComboBox.SelectedValue = this.SelectedLocation.Type;
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

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedLocation.Type = (Enums.LocationType)this.typeComboBox.SelectedValue;
            switch ((Enums.LocationType)this.typeComboBox.SelectedValue)
            {
                case Enums.LocationType.BoundingBox:
                    this.SelectedLocation.BusStopQuery =
                        @"[out:json][timeout:{{timeout}}];(node[""naptan: AtcoCode""][!""railway""]({{bbox}}););out;>;out skel qt;";
                    this.stopsQueryTextBox.Enabled = false;
                    this.SelectedLocation.TransportQuery =
                        @"[out:json][timeout:{{timeout}}];((node[""naptan: AtcoCode""][!""railway""]({{bbox}}););<<;)->.b;relation.b[""route""!=""bus""];(._;>>;);out;";
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
                        @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;((node(area.a)[""naptan:AtcoCode""][!""railway""];);<<;)->.b;relation.b[""route""!=""bus""];(._;>>;);out;";
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.SelectedLocation.BoundingBox = this.boundingBoxTextBox.Text;
            this.SelectedLocation.AreaQuery = this.areaQueryTextBox.Text;

            this.SelectedLocation.BusStopTimeOut = (int)this.stopsTimeoutNumericUpDown.Value;
            this.SelectedLocation.TransportTimeOut = (int)this.dataQueryNumericUpDown.Value;
            this.SelectedLocation.OrphanRoutesTimeOut = (int)this.orphanRoutesNumericUpDown.Value;
            this.SelectedLocation.BusStopQuery = this.stopsQueryTextBox.Text;
            this.SelectedLocation.TransportQuery = this.dataQueryTextBox.Text;
            this.SelectedLocation.OrphansQuery = this.orphanRoutesTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
