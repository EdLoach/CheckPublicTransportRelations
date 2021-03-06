﻿// ===========================================================================================================
// <copyright file="MainForm.cs" company="N/A">
// Copyright (c) 2019 N/A. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>3 January 2019</date>
// <summary>Implements the main Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Mail;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web;
    using System.Windows.Forms;
    using System.Xml.Linq;

    using CheckPublicTransportRelations.Properties;

    using Newtonsoft.Json.Linq;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the main.</summary>
    // ===========================================================================================================
    public partial class MainForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>The client.</summary>
        // ===========================================================================================================
        private static readonly HttpClient Client = new HttpClient();

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>The arguments.</summary>
        // ===========================================================================================================
        private readonly string[] arguments;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>The last write time.</summary>
        // ===========================================================================================================
        private DateTime lastWriteTime;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>True if running unattended.</summary>
        // ===========================================================================================================
        private bool runningUnattended;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>True to unattended exception.</summary>
        // ===========================================================================================================
        private bool unattendedException;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the
        ///          <see cref="T:CheckPublicTransportRelations.MainForm" /> class.</summary>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public MainForm(string[] args)
        {
            this.arguments = args;
            this.InitializeComponent();
        }

        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>EdLoach - 30 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the naptan stops.</summary>
        ///
        /// <value>The naptan stops.</value>
        // ===========================================================================================================
        public List<BusStop> NaptanStops { get; set; }

        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>EdLoach - 28 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the Traveline stops.</summary>
        ///
        /// <value>The Traveline stops.</value>
        // ===========================================================================================================
        public List<string> TravelineStops { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the comparison results.</summary>
        ///
        /// <value>The comparison results.</value>
        // ===========================================================================================================
        private List<ComparisonResultService> ComparisonResults { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the comparison results routes.</summary>
        ///
        /// <value>The comparison results routes.</value>
        // ===========================================================================================================
        private List<ComparisonResultRoute> ComparisonResultsRoutes { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets from to checks.</summary>
        ///
        /// <value>from to checks.</value>
        // ===========================================================================================================
        private List<ComparisonResultFromTo> FromToChecks { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the locations.</summary>
        ///
        /// <value>The locations.</value>
        // ===========================================================================================================
        private Locations Locations { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the orphan routes.</summary>
        ///
        /// <value>The orphan routes.</value>
        // ===========================================================================================================
        private List<OpenStreetMapRouteVariant> OrphanRoutes { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the open street map routes.</summary>
        ///
        /// <value>The open street map routes.</value>
        // ===========================================================================================================
        private List<OpenStreetMapRouteMaster> OpenStreetMapRoutes { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the overpass bus stops.</summary>
        ///
        /// <value>The overpass bus stops.</value>
        // ===========================================================================================================
        private List<BusStop> OverpassBusStops { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the route bus stops.</summary>
        ///
        /// <value>The route bus stops.</value>
        // ===========================================================================================================
        private List<BusStop> RouteBusStops { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the selected location.</summary>
        ///
        /// <value>The selected location.</value>
        // ===========================================================================================================
        private Location SelectedLocation { get; set; }

        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the traveline routes.</summary>
        ///
        /// <value>The traveline routes.</value>
        // ===========================================================================================================
        private List<RouteMaster> TravelineRoutes { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Loads the locations.</summary>
        ///
        /// <returns>The locations.</returns>
        // ===========================================================================================================
        internal static Locations LoadLocations()
        {
            var returnValue = new Locations();
            string fileName = Path.Combine(
                Directory.GetParent(Application.LocalUserAppDataPath).FullName,
                "Locations.json");
            if (File.Exists(fileName))
            {
                string locationsText = File.ReadAllText(fileName);
                returnValue = Newtonsoft.Json.JsonConvert.DeserializeObject<Locations>(locationsText);
            }

            if (returnValue.Count >= 1)
            {
                return returnValue;
            }

            returnValue.Add(new Location { Description = @"Tendring (Essex) - BBox" });
            returnValue.Add(
                new Location
                    {
                        Description = @"Tendring (Essex) - Boundary Relation",
                        Type = Enums.LocationType.Area,
                        BoundingBox = string.Empty,
                        AreaQuery = @"official_name=""Tendring District""",
                        BusStopTimeOut = 25,
                        TransportTimeOut = 45,
                        OrphanRoutesTimeOut = 45,
                        BusStopQuery =
                            @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;(node(area.a)[""naptan:AtcoCode""][!""railway""];);out;>;out skel qt;",
                        TransportQuery =
                            @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;((node(area.a)[""naptan:AtcoCode""][!""railway""];);rel(bn);rel(br);)->.b;relation.b[""route""!=""bus""][""type""!=""network""];(._;>>;);out;",
                        OrphansQuery =
                            @"[out:json][timeout:{{timeout}}]; area[{{area}}]->.a;((relation(area.a)[""route""=""bus""];);<<;)->.b; relation.b[""route""=""bus""];(._;>>;);out meta;"
                });
            returnValue.Add(
                new Location
                    {
                        Description = @"Colchester (Essex) - Boundary Relation",
                        Type = Enums.LocationType.Area,
                        BoundingBox = string.Empty,
                        AreaQuery = @"official_name=""Borough of Colchester""",
                        BusStopTimeOut = 25,
                        TransportTimeOut = 45,
                        OrphanRoutesTimeOut = 45,
                        BusStopQuery =
                            @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;(node(area.a)[""naptan:AtcoCode""][!""railway""];);out;>;out skel qt;",
                        TransportQuery =
                            @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;((node(area.a)[""naptan:AtcoCode""][!""railway""];);rel(bn);rel(br);)->.b;relation.b[""route""!=""bus""][""type""!=""network""];(._;>>;);out;",
                        OrphansQuery =
                            @"[out:json][timeout:{{timeout}}]; area[{{area}}]->.a;((relation(area.a)[""route""=""bus""];);<<;)->.b; relation.b[""route""=""bus""];(._;>>;);out meta;"
                });
            returnValue.Add(
                new Location
                    {
                        Description = @"Tendring/Colchester",
                        Type = Enums.LocationType.Custom,
                        BoundingBox = string.Empty,
                        AreaQuery = string.Empty,
                        BusStopTimeOut = 35,
                        TransportTimeOut = 45,
                        OrphanRoutesTimeOut = 45,
                        BusStopQuery =
                            @"[out:json][timeout:{{timeout}}];area[official_name=""Tendring District""]->.a;area[official_name=""Borough of Colchester""]->.b;(node(area.a)[""naptan:AtcoCode""][!""railway""];node(area.b)[""naptan:AtcoCode""][!""railway""];);out;>;out skel qt;",
                        TransportQuery =
                            @"[out:json][timeout:{{timeout}}];area[official_name=""Tendring District""]->.a;area[official_name=""Borough of Colchester""]->.b;((node(area.a)[""naptan:AtcoCode""][!""railway""];node(area.b)[""naptan:AtcoCode""][!""railway""];);rel(bn);rel(br);)->.c;relation.c[""route""!=""bus""][""type""!=""network""];(._;>>;);out;",
                        OrphansQuery =
                            @"[out:json][timeout:{{timeout}}];area[official_name=""Tendring District""]->.a;area[official_name=""Borough of Colchester""]->.b;((relation(area.a)[""route""=""bus""];relation(area.b)[""route""=""bus""];);<<;)->.c; relation.c[""route""=""bus""];(._;>>;);out meta;"
                });
            returnValue.Add(
                new Location
                    {
                        Description = @"Maldon (Essex) - Boundary Relation",
                        Type = Enums.LocationType.Area,
                        BoundingBox = string.Empty,
                        AreaQuery = @"council_name=""Maldon District Council""",
                        BusStopTimeOut = 25,
                        TransportTimeOut = 45,
                        OrphanRoutesTimeOut = 45,
                        BusStopQuery =
                            @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;(node(area.a)[""naptan:AtcoCode""][!""railway""];);out;>;out skel qt;",
                        TransportQuery =
                            @"[out:json][timeout:{{timeout}}];area[{{area}}]->.a;((node(area.a)[""naptan:AtcoCode""][!""railway""];);rel(bn);rel(br);)->.b;relation.b[""route""!=""bus""][""type""!=""network""];(._;>>;);out;",
                        OrphansQuery =
                            @"[out:json][timeout:{{timeout}}]; area[{{area}}]->.a;((relation(area.a)[""route""=""bus""];);<<;)->.b; relation.b[""route""=""bus""];(._;>>;);out meta;"
                });
            returnValue.Add(
                new Location
                    {
                        Description = @"Tendring/Colchester/Maldon",
                        BoundingBox = string.Empty,
                        BusStopQuery =
                            @"[out:json][timeout:{{timeout}}];area[official_name=""Tendring District""]->.a;area[official_name=""Borough of Colchester""]->.b;area[council_name=""Maldon District Council""]->.c;(node(area.a)[""naptan:AtcoCode""][!""railway""];node(area.b)[""naptan:AtcoCode""][!""railway""];node(area.c)[""naptan:AtcoCode""][!""railway""];);out;>;out skel qt;",
                        TransportQuery =
                            @"[out:json][timeout:{{timeout}}];area[official_name=""Tendring District""]->.a;area[official_name=""Borough of Colchester""]->.b;area[council_name=""Maldon District Council""]->.c;((node(area.a)[""naptan:AtcoCode""][!""railway""];node(area.b)[""naptan:AtcoCode""][!""railway""];node(area.c)[""naptan:AtcoCode""][!""railway""];);rel(bn);rel(br);)->.d;relation.d[""route""!=""bus""][""type""!=""network""];(._;>>;);out;",
                        OrphansQuery =
                            @"[out:json][timeout:{{timeout}}];area[official_name=""Tendring District""]->.a;area[official_name=""Borough of Colchester""]->.b;area[council_name=""Maldon District Council""]->.c;((relation(area.a)[""route""=""bus""];relation(area.b)[""route""=""bus""];(relation(area.c)[""route""=""bus""];);<<;)->.d; relation.d[""route""=""bus""];(._;>>;);out meta;"
                });

            Settings.Default.SelectedLocation = @"Tendring (Essex) - Boundary Relation";
            Settings.Default.Save();
            try
            {
                string outputText = Newtonsoft.Json.JsonConvert.SerializeObject(
                    returnValue,
                    Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(fileName, outputText + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Might not have permissions, for example, in which case likely to only ever have the default location
                Debug.WriteLine(ex.Message);
            }

            return returnValue;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Valid path string.</summary>
        ///
        /// <param name="anyString">any string.</param>
        ///
        /// <returns>A string.</returns>
        // ===========================================================================================================
        internal static string ValidPathString(string anyString)
        {
            var illegalInFileName = new Regex(
                $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars()))}]",
                RegexOptions.Compiled);

            return illegalInFileName.Replace(anyString, string.Empty);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets bus stops asynchronous.</summary>
        ///
        /// <param name="path">             Full pathname of the file.</param>
        /// <param name="locationSubfolder">The location subfolder.</param>
        ///
        /// <returns>The bus stops asynchronous.</returns>
        // ===========================================================================================================
        private static async Task<List<BusStop>> GetBusStopsAsync(string path, string locationSubfolder)
        {
            var overpassBusStops = new List<BusStop>();
            HttpResponseMessage response = await Client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return overpassBusStops;
            }

            string overpassBusStopsJson = await response.Content.ReadAsStringAsync();
            string filePath = Path.Combine(
                Directory.GetParent(Application.LocalUserAppDataPath).FullName,
                locationSubfolder);
            Directory.CreateDirectory(filePath);
            string fileName = Path.Combine(filePath, "OsmBusStops.json");
            File.WriteAllText(fileName, overpassBusStopsJson);
            dynamic stops = JToken.Parse(overpassBusStopsJson);
            foreach (dynamic element in stops.elements)
            {
                BusStop busStop = BusStop(element);
                overpassBusStops.Add(busStop);
            }

            return overpassBusStops;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Bus stop.</summary>
        ///
        /// <param name="element">The element.</param>
        ///
        /// <returns>A BusStop.</returns>
        // ===========================================================================================================
        private static BusStop BusStop(dynamic element)
        {
            string type = element.type;
            long id = element.id;
            string atcoCode = element.tags["naptan:AtcoCode"] ?? string.Empty;
            string stopName = element.tags["name"] ?? string.Empty;
            string naptanCode = element.tags["naptan:NaptanCode"] ?? string.Empty;
            string stopStatus = element.tags["naptan:Status"] ?? string.Empty;
            string busStopType = element.tags["naptan:BusStopType"] ?? string.Empty;
            string notName = element.tags["not:name"] ?? string.Empty;
            string highway = element.tags["highway"] ?? string.Empty;

            // layby tag ignored in this list as may be visible on imagery and not indicative of a survey
            string physicallyPresent = element.tags["physically_present"] ?? string.Empty;
            string flagTagValue = element.tags["flag"] ?? string.Empty;
            string shelterTagValue = element.tags["shelter"] ?? string.Empty;
            string kerbTagValue = element.tags["kerb"] ?? string.Empty;
            string timetableCaseTagValue = element.tags["timetable_case"] ?? string.Empty;
            string surveyedValue = !string.IsNullOrEmpty(physicallyPresent) || !string.IsNullOrEmpty(flagTagValue)
                                                                            || !string.IsNullOrEmpty(shelterTagValue)
                                                                            || !string.IsNullOrEmpty(kerbTagValue)
                                                                            || !string.IsNullOrEmpty(
                                                                                timetableCaseTagValue)
                                       ? "yes"
                                       : string.Empty;

            string naptanVerified = element.tags["naptan:verified"] ?? string.Empty;
            var busStop = new BusStop(
                type,
                id,
                atcoCode,
                stopName,
                naptanCode,
                stopStatus,
                busStopType,
                notName,
                surveyedValue,
                highway,
                naptanVerified);
            return busStop;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets data asynchronous.</summary>
        ///
        /// <param name="overPassQuery">    The over pass query.</param>
        /// <param name="locationSubfolder">The location subfolder.</param>
        ///
        /// <returns>The data asynchronous.</returns>
        // ===========================================================================================================
        private static async Task<bool> GetDataAsync(string overPassQuery, string locationSubfolder)
        {
            HttpResponseMessage response = await Client.GetAsync(overPassQuery);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            string overpassTransportDataXml = await response.Content.ReadAsStringAsync();
            dynamic entities = JToken.Parse(overpassTransportDataXml);
            if (entities.elements == null || entities.elements.Count <= 0)
            {
                string remark = entities.remark;
                MessageBox.Show(
                    remark,
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return false;
            }

            string fileName = Path.Combine(
                Directory.GetParent(Application.LocalUserAppDataPath).FullName,
                locationSubfolder,
                "OsmData.json");
            File.WriteAllText(fileName, overpassTransportDataXml);
            return true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets orphans asynchronous.</summary>
        ///
        /// <param name="overPassQuery">    The over pass query.</param>
        /// <param name="locationSubfolder">The location subfolder.</param>
        ///
        /// <returns>The orphans asynchronous.</returns>
        // ===========================================================================================================
        private static async Task<bool> GetOrphansAsync(string overPassQuery, string locationSubfolder)
        {
            HttpResponseMessage response = await Client.GetAsync(overPassQuery);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            string overpassTransportDataXml = await response.Content.ReadAsStringAsync();
            dynamic entities = JToken.Parse(overpassTransportDataXml);
            if (entities.elements == null || entities.elements.Count <= 0)
            {
                string remark = entities.remark;
                MessageBox.Show(
                    remark,
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return false;
            }

            string fileName = Path.Combine(
                Directory.GetParent(Application.LocalUserAppDataPath).FullName,
                locationSubfolder,
                "OsmOrphans.json");
            File.WriteAllText(fileName, overpassTransportDataXml);
            return true;
        }

        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>EdLoach - 8 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Adds a traveline route variants.</summary>
        ///
        /// <param name="travelineRouteMaster">The traveline route master.</param>
        // ===========================================================================================================
        private void AddTravelineRouteVariants(RouteMaster travelineRouteMaster)
        {
            foreach (Route travelineRouteVariant in travelineRouteMaster.RouteVariants)
            {
                var comparisonResult = new ComparisonResultRoute
                                           {
                                               ServiceFile = travelineRouteMaster.FileName,
                                               ServiceOperator = travelineRouteMaster.Operator,
                                               ServiceReference = travelineRouteMaster.Reference,
                                               ServiceStops = travelineRouteVariant.Stops
                                           };

                this.ComparisonResultsRoutes.Add(comparisonResult);
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
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
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ComparedRoutesDataGridView for selection changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ComparedRoutesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.RefreshStopLists();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Compare results.</summary>
        // ===========================================================================================================
        private void CompareResults()
        {
            this.compareRouteMasterDataGridView.DataSource = null;
            this.comparedRoutesDataGridView.DataSource = null;
            this.fromToDataGridView.DataSource = null;
            this.ComparisonResults = new List<ComparisonResultService>();
            this.ComparisonResultsRoutes = new List<ComparisonResultRoute>();
            var matchedRoutes = new HashSet<string>();
            var matchedRelations = new HashSet<long>();
            this.FromToChecks = new List<ComparisonResultFromTo>();

            foreach (OpenStreetMapRouteMaster openStreetMapRouteMaster in this.OpenStreetMapRoutes)
            {
                var comparisonResult = new ComparisonResultService
                                           {
                                               RouteMasterRelationId = openStreetMapRouteMaster.Id,
                                               RouteMasterOperator = openStreetMapRouteMaster.Operator,
                                               RouteMasterReference = openStreetMapRouteMaster.Reference,
                                               RouteMasterRouteVariants = openStreetMapRouteMaster.RouteVariantsCount
                                           };

                // Try match on operator, reference and route variants
                RouteMaster foundRoute = null;
                foreach (RouteMaster routeMaster in this.TravelineRoutes)
                {
                    if (matchedRoutes.Contains(routeMaster.FileName))
                    {
                        continue;
                    }

                    if (openStreetMapRouteMaster.Reference != routeMaster.Reference
                        || openStreetMapRouteMaster.Operator != routeMaster.Operator
                        || openStreetMapRouteMaster.RouteVariantsCount != routeMaster.RouteVariantsCount)
                    {
                        continue;
                    }

                    matchedRoutes.Add(routeMaster.FileName);
                    matchedRelations.Add(openStreetMapRouteMaster.Id);
                    comparisonResult.TravelineFile = routeMaster.FileName;
                    comparisonResult.TravelineOperator = routeMaster.Operator;
                    comparisonResult.TravelineReference = routeMaster.Reference;
                    comparisonResult.TravelineRouteVariants = routeMaster.RouteVariantsCount;
                    foundRoute = routeMaster;
                    break;
                }

                if (comparisonResult.TravelineFile.Length <= 0)
                {
                    continue;
                }

                this.ComparisonResults.Add(comparisonResult);
                this.CompareRouteVariants(openStreetMapRouteMaster, foundRoute);
            }

            foreach (OpenStreetMapRouteMaster openStreetMapRouteMaster in this.OpenStreetMapRoutes)
            {
                if (matchedRelations.Contains(openStreetMapRouteMaster.Id))
                {
                    continue;
                }

                var comparisonResult = new ComparisonResultService
                                           {
                                               RouteMasterRelationId = openStreetMapRouteMaster.Id,
                                               RouteMasterOperator = openStreetMapRouteMaster.Operator,
                                               RouteMasterReference = openStreetMapRouteMaster.Reference,
                                               RouteMasterRouteVariants = openStreetMapRouteMaster.RouteVariantsCount
                                           };

                // Try Operator and Reference
                RouteMaster foundRoute = null;
                foreach (RouteMaster routeMaster in this.TravelineRoutes)
                {
                    if (matchedRoutes.Contains(routeMaster.FileName))
                    {
                        continue;
                    }

                    if (openStreetMapRouteMaster.Reference != routeMaster.Reference
                        || openStreetMapRouteMaster.Operator != routeMaster.Operator)
                    {
                        continue;
                    }

                    matchedRoutes.Add(routeMaster.FileName);
                    matchedRelations.Add(openStreetMapRouteMaster.Id);
                    comparisonResult.TravelineFile = routeMaster.FileName;
                    comparisonResult.TravelineOperator = routeMaster.Operator;
                    comparisonResult.TravelineReference = routeMaster.Reference;
                    comparisonResult.TravelineRouteVariants = routeMaster.RouteVariantsCount;
                    foundRoute = routeMaster;
                    break;
                }

                if (comparisonResult.TravelineFile.Length <= 0)
                {
                    continue;
                }

                this.ComparisonResults.Add(comparisonResult);
                this.CompareRouteVariants(openStreetMapRouteMaster, foundRoute);
            }

            foreach (OpenStreetMapRouteMaster openStreetMapRouteMaster in this.OpenStreetMapRoutes)
            {
                if (matchedRelations.Contains(openStreetMapRouteMaster.Id))
                {
                    continue;
                }

                var comparisonResult = new ComparisonResultService
                                           {
                                               RouteMasterRelationId = openStreetMapRouteMaster.Id,
                                               RouteMasterOperator = openStreetMapRouteMaster.Operator,
                                               RouteMasterReference = openStreetMapRouteMaster.Reference,
                                               RouteMasterRouteVariants = openStreetMapRouteMaster.RouteVariantsCount
                                           };

                // Try just reference
                foreach (RouteMaster routeMaster in this.TravelineRoutes)
                {
                    if (matchedRoutes.Contains(routeMaster.FileName))
                    {
                        continue;
                    }

                    if (openStreetMapRouteMaster.Reference != routeMaster.Reference)
                    {
                        continue;
                    }

                    matchedRoutes.Add(routeMaster.FileName);
                    matchedRelations.Add(openStreetMapRouteMaster.Id);
                    comparisonResult.TravelineFile = routeMaster.FileName;
                    comparisonResult.TravelineOperator = routeMaster.Operator;
                    comparisonResult.TravelineReference = routeMaster.Reference;
                    comparisonResult.TravelineRouteVariants = routeMaster.RouteVariantsCount;
                    break;
                }

                if (comparisonResult.TravelineFile.Length > 0)
                {
                    this.ComparisonResults.Add(comparisonResult);
                }
            }

            foreach (OpenStreetMapRouteMaster openStreetMapRouteMaster in this.OpenStreetMapRoutes)
            {
                if (matchedRelations.Contains(openStreetMapRouteMaster.Id))
                {
                    continue;
                }

                var comparisonResult = new ComparisonResultService
                                           {
                                               RouteMasterRelationId = openStreetMapRouteMaster.Id,
                                               RouteMasterOperator = openStreetMapRouteMaster.Operator,
                                               RouteMasterReference = openStreetMapRouteMaster.Reference,
                                               RouteMasterRouteVariants = openStreetMapRouteMaster.RouteVariantsCount
                                           };

                // No Match
                this.ComparisonResults.Add(comparisonResult);
            }

            foreach (RouteMaster routeMaster in this.TravelineRoutes)
            {
                if (matchedRoutes.Contains(routeMaster.FileName))
                {
                    continue;
                }

                var comparisonResult = new ComparisonResultService
                                           {
                                               TravelineFile = routeMaster.FileName,
                                               TravelineOperator = routeMaster.Operator,
                                               TravelineReference = routeMaster.Reference,
                                               TravelineRouteVariants = routeMaster.RouteVariantsCount
                                           };

                // No Match
                this.ComparisonResults.Add(comparisonResult);
                this.AddTravelineRouteVariants(routeMaster);
            }

            this.compareRouteMasterDataGridView.DataSource = this.showMatchedServicesCheckBox.Checked
                                                                 ? this.ComparisonResults
                                                                 : this.ComparisonResults.Where(
                                                                         item => (item.OperatorsMatch
                                                                                  && item.ReferencesMatch
                                                                                  && item.RouteVariantsMatch) == false)
                                                                     .ToList();
            this.comparedRoutesDataGridView.DataSource = this.showMatchedRoutesCheckBox.Checked
                                                             ? this.ComparisonResultsRoutes
                                                             : this.ComparisonResultsRoutes.Where(
                                                                 item => item.StopsEqual == false
                                                                         || item.NameFormatting == false).ToList();
            this.fromToDataGridView.DataSource = this.fromToShowMatchedCheckBox.Checked
                                                     ? this.FromToChecks
                                                     : this.FromToChecks.Where(
                                                             item => (item.FromNameFound && item.ToNameFound) == false)
                                                         .ToList();

            this.wikiTextButton.Visible = !this.showMatchedRoutesCheckBox.Checked
                                          && this.comparedRoutesDataGridView.RowCount == 0
                                          && this.ComparisonResultsRoutes.Count > 0;
        }

        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Compare route variants.</summary>
        ///
        /// <param name="routeMaster">         The route master.</param>
        /// <param name="travelineRouteMaster">The traveline route master.</param>
        // ===========================================================================================================
        private void CompareRouteVariants(OpenStreetMapRouteMaster routeMaster, RouteMaster travelineRouteMaster)
        {
            var matchedRouteVariants = new HashSet<long>();
            var matchedRouteVariantsTraveline = new HashSet<string>();
            foreach (OpenStreetMapRouteVariant routeVariant in routeMaster.RouteVariants)
            {
                var fromToResult = new ComparisonResultFromTo
                                       {
                                           RelationId = routeVariant.Id,
                                           RelationService = routeVariant.Reference,
                                           RelationFrom = routeVariant.RelationFrom,
                                           RelationTo = routeVariant.RelationTo
                                       };

                if (routeVariant.BusStops.Count > 0)
                {
                    fromToResult.StopFrom = this.RouteBusStops.FirstOrDefault(
                        item => item.AtcoCode == routeVariant.BusStops[0].StopPointRef)?.StopName;
                    fromToResult.StopTo = this.RouteBusStops.FirstOrDefault(
                            item => item.AtcoCode
                                    == routeVariant.BusStops[routeVariant.BusStops.Count - 1].StopPointRef)
                        ?.StopName;
                }
                else
                {
                    fromToResult.StopTo = string.Empty;
                    fromToResult.StopFrom = string.Empty;
                }

                this.FromToChecks.Add(fromToResult);

                var comparisonResult = new ComparisonResultRoute
                                           {
                                               ServiceRouteRelationId = routeMaster.Id,
                                               RouteRelationId = routeVariant.Id,
                                               RelationOperator = routeVariant.Operator,
                                               RelationReference = routeVariant.Reference,
                                               RelationStops = routeVariant.BusStops,
                                               RelationName = routeVariant.Name,
                                               RelationFrom = routeVariant.RelationFrom,
                                               RelationTo = routeVariant.RelationTo,
                                               RelationEndNodes = routeVariant.EndNodes,
                                               LondonBus = routeVariant.LondonBus
                                           };
                foreach (Route travelineRouteVariant in travelineRouteMaster.RouteVariants)
                {
                    if (matchedRouteVariantsTraveline.Contains(travelineRouteVariant.Id))
                    {
                        continue;
                    }

                    if (!routeVariant.BusStops.SequenceEqual(travelineRouteVariant.Stops))
                    {
                        continue;
                    }

                    matchedRouteVariantsTraveline.Add(travelineRouteVariant.Id);
                    matchedRouteVariants.Add(routeVariant.Id);
                    comparisonResult.ServiceFile = travelineRouteMaster.FileName;
                    comparisonResult.ServiceOperator = travelineRouteMaster.Operator;
                    comparisonResult.ServiceReference = travelineRouteMaster.Reference;
                    comparisonResult.ServiceStops = travelineRouteVariant.Stops;
                    this.ComparisonResultsRoutes.Add(comparisonResult);
                    break;
                }
            }

            foreach (OpenStreetMapRouteVariant routeVariant in routeMaster.RouteVariants)
            {
                if (matchedRouteVariants.Contains(routeVariant.Id))
                {
                    continue;
                }

                var comparisonResult = new ComparisonResultRoute
                                           {
                                               ServiceRouteRelationId = routeMaster.Id,
                                               RouteRelationId = routeVariant.Id,
                                               RelationOperator = routeVariant.Operator,
                                               RelationReference = routeVariant.Reference,
                                               RelationStops = routeVariant.BusStops,
                                               RelationName = routeVariant.Name,
                                               RelationFrom = routeVariant.RelationFrom,
                                               RelationTo = routeVariant.RelationTo,
                                               RelationEndNodes = routeVariant.EndNodes,
                                               LondonBus = routeVariant.LondonBus
                                           };

                this.ComparisonResultsRoutes.Add(comparisonResult);
            }

            foreach (Route travelineRouteVariant in travelineRouteMaster.RouteVariants)
            {
                if (matchedRouteVariantsTraveline.Contains(travelineRouteVariant.Id))
                {
                    continue;
                }

                var comparisonResult = new ComparisonResultRoute
                                           {
                                               ServiceFile = travelineRouteMaster.FileName,
                                               ServiceOperator = travelineRouteMaster.Operator,
                                               ServiceReference = travelineRouteMaster.Reference,
                                               ServiceStops = travelineRouteVariant.Stops
                                           };

                this.ComparisonResultsRoutes.Add(comparisonResult);
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by various DataGridViews for link cell formatting events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Data grid view cell formatting event information.</param>
        // ===========================================================================================================
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].GetType() != typeof(DataGridViewLinkColumn))
            {
                return;
            }

            if (grid.CurrentCell.ColumnIndex == e.ColumnIndex && grid.CurrentCell.RowIndex == e.RowIndex)
            {
                ((DataGridViewLinkCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex]).LinkColor =
                    SystemColors.HighlightText;
            }
            else
            {
                Color linkColor = ((DataGridViewLinkColumn)grid.Columns[e.ColumnIndex]).LinkColor;
                Color visitedLinkColor = ((DataGridViewLinkColumn)grid.Columns[e.ColumnIndex]).LinkColor;
                var cell = (DataGridViewLinkCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.LinkColor = cell.LinkVisited ? visitedLinkColor : linkColor;
            }
        }

        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by DownloadTravelineNationalDataSetToolStripMenuItem for click
        ///          events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void DownloadTravelineNationalDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var downloadForm = new TravelineDownloadForm();
            downloadForm.ShowDialog(this);
            this.RefreshStatus();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ExitToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ExtractLocalRoutesToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ExtractLocalRoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (this.OverpassBusStops.Count == 0)
            {
                MessageBox.Show(
                    this,
                    @"No local stops downloaded  - do that first",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                this.Enabled = true;
                return;
            }

            var extractRoutesForm = new ExtractRoutesForm(this.OverpassBusStops, this.Locations, this.SelectedLocation);
            extractRoutesForm.ShowDialog(this);
            this.travelineDataGridView.DataSource = null;
            this.ExtractTravelineRoutes();
            this.travelineDataGridView.DataSource = this.TravelineRoutes;
            this.RefreshStatus();
            string areaPath = Path.Combine(
                Settings.Default.LocalPath,
                ValidPathString(this.SelectedLocation.Description));
            string areaFileName = Path.Combine(areaPath, "LocalStops.csv");
            if (File.Exists(areaFileName))
            {
                File.Delete(areaFileName);
            }

            this.ExtractNaptanStops();
            this.RefreshStopsGrid();
            this.CompareResults();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Extracts the naptan stops.</summary>
        // ===========================================================================================================
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private void ExtractNaptanStops()
        {
            string fileName = Path.Combine(Settings.Default.LocalPath, "naptandata", "NaPTANcsv.zip");
            string areaPath = Path.Combine(
                Settings.Default.LocalPath,
                ValidPathString(this.SelectedLocation.Description));
            Directory.CreateDirectory(areaPath);
            string areaFileName = Path.Combine(areaPath, "LocalStops.csv");
            if (File.Exists(fileName) && !File.Exists(areaFileName) && this.TravelineStops.Count > 0)
            {
                using (ZipArchive archive = ZipFile.OpenRead(fileName))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (!entry.FullName.StartsWith("Stops.csv", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        using (var file = new StreamWriter(areaFileName))
                        {
                            using (Stream stream = entry.Open())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    string line;
                                    string columnHeadings = string.Empty;
                                    var atcoCodeIndex = 0;
                                    while ((line = reader.ReadLine()) != null)
                                    {
                                        if (columnHeadings == string.Empty)
                                        {
                                            columnHeadings = line;
                                            file.WriteLine(line);
                                            string[] columnHeading =
                                                columnHeadings.Replace(@"""", string.Empty).Split(',');
                                            atcoCodeIndex = Array.IndexOf(columnHeading, "ATCOCode");
                                            int commonNameIndex = Array.IndexOf(columnHeading, "CommonName");
                                            if (atcoCodeIndex == -1 || commonNameIndex == -1)
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            string[] naptanStop = line.Replace(@"""", string.Empty).Split(',');
                                            if (this.TravelineStops.Contains(naptanStop[atcoCodeIndex]))
                                            {
                                                file.WriteLine(line);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                }
            }

            if (File.Exists(areaFileName))
            {
                this.NaptanStops = new List<BusStop>();
                using (var reader = new StreamReader(areaFileName))
                {
                    string line;
                    string columnHeadings = string.Empty;
                    var atcoCodeIndex = 0;
                    var naptanCodeIndex = 1;
                    var commonNameIndex = 4;
                    var longitudeIndex = 30;
                    var latitudeIndex = 31;
                    var busStopTypeIndex = 32;
                    var statusIndex = 42;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (columnHeadings == string.Empty)
                        {
                            columnHeadings = line;
                            string[] columnHeading = columnHeadings.Replace(@"""", string.Empty).Split(',');
                            atcoCodeIndex = Array.IndexOf(columnHeading, "ATCOCode");
                            naptanCodeIndex = Array.IndexOf(columnHeading, "NaptanCode");
                            latitudeIndex = Array.IndexOf(columnHeading, "Latitude");
                            longitudeIndex = Array.IndexOf(columnHeading, "Longitude");
                            commonNameIndex = Array.IndexOf(columnHeading, "CommonName");
                            busStopTypeIndex = Array.IndexOf(columnHeading, "BusStopType");
                            statusIndex = Array.IndexOf(columnHeading, "Status");
                            if (atcoCodeIndex == -1 || commonNameIndex == -1)
                            {
                                break;
                            }
                        }
                        else
                        {
                            string[] naptanStop = line.Replace(@"""", string.Empty).Split(',');
                            int length = naptanStop[commonNameIndex].IndexOf("(", StringComparison.Ordinal);
                            string returnValue = naptanStop[commonNameIndex].Contains("(")
                                                     ? naptanStop[commonNameIndex].Substring(0, length - 1).Trim()
                                                     : naptanStop[commonNameIndex];
                            if (returnValue.Contains(" - ") && !returnValue.Contains("Co - Op"))
                            {
                                returnValue = returnValue.Substring(
                                    0,
                                    returnValue.IndexOf(" - ", StringComparison.Ordinal) - 1).Trim();
                            }

                            var newNaptanStop =
                                new BusStop(
                                    "node",
                                    -1,
                                    naptanStop[atcoCodeIndex],
                                    returnValue,
                                    naptanStop[naptanCodeIndex],
                                    naptanStop[statusIndex],
                                    naptanStop[busStopTypeIndex],
                                    string.Empty,
                                    string.Empty,
                                    string.Empty,
                                    string.Empty)
                                    {
                                        NaptanName = returnValue,
                                        NaptanBusStopType = naptanStop[busStopTypeIndex],
                                        NaptanStatus = naptanStop[statusIndex],
                                        Latitude = decimal.Parse(naptanStop[latitudeIndex]),
                                        Longitude = decimal.Parse(naptanStop[longitudeIndex]),
                                        NaptanNaptanCode = naptanStop[naptanCodeIndex]
                                    };
                            this.NaptanStops.Add(newNaptanStop);

                            BusStop stop = this.RouteBusStops.FirstOrDefault(
                                i => i.AtcoCode == naptanStop[atcoCodeIndex]);
                            if (stop != null)
                            {
                                this.RouteBusStops.Remove(stop);
                                stop.NaptanName = returnValue;
                                stop.NaptanBusStopType = naptanStop[busStopTypeIndex];
                                stop.NaptanStatus = naptanStop[statusIndex];
                                stop.Latitude = decimal.Parse(naptanStop[latitudeIndex]);
                                stop.Longitude = decimal.Parse(naptanStop[longitudeIndex]);
                                stop.NaptanNaptanCode = naptanStop[naptanCodeIndex];
                                this.RouteBusStops.Add(stop);
                            }
                        }
                    }
                }
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Extracts the open street map orphan routes.</summary>
        // ===========================================================================================================
        private void ExtractOpenStreetMapOrphans()
        {
            // To determine orphan routes we check which routes are in the Orphans query that aren't a member of a route_master relation
            // I couldn't work out an overpass query to do this without comparing results.
            string fileName = Path.Combine(
                Directory.GetParent(Application.LocalUserAppDataPath).FullName,
                ValidPathString(this.SelectedLocation.Description),
                "OsmOrphans.json");
            if (!File.Exists(fileName))
            {
                return;
            }

            var routesDictionary = new Dictionary<long, long>();
            var routesReferenceDictionary = new Dictionary<long, string>();
            var routesOperatorDictionary = new Dictionary<long, string>();
            var routesFromDictionary = new Dictionary<long, string>();
            var routesToDictionary = new Dictionary<long, string>();
            var routesNameDictionary = new Dictionary<long, string>();

            string openStreetMapData = File.ReadAllText(fileName);
            dynamic entities = JToken.Parse(openStreetMapData);
            foreach (dynamic element in entities.elements)
            {
                string type = element.type;

                if (type != "relation")
                {
                    continue;
                }

                long id = element.id;
                if (element.tags == null)
                {
                    continue;
                }

                string relationType = element.tags["type"];

                if (relationType != "route")
                {
                    continue;
                }

                routesDictionary.Add(id, id);
                if (element.tags != null && element.tags["ref"] != null)
                {
                    string routeRef = element.tags["ref"];
                    routesReferenceDictionary.Add(id, routeRef);
                }
                else
                {
                    routesReferenceDictionary.Add(id, string.Empty);
                }

                string routeOperator = element.tags["operator"] ?? string.Empty;
                routesOperatorDictionary.Add(id, routeOperator);
                string relationFrom = element.tags["from"] ?? string.Empty;
                routesFromDictionary.Add(id, relationFrom);
                string relationTo = element.tags["to"] ?? string.Empty;
                routesToDictionary.Add(id, relationTo);
                string relationName = element.tags["name"] ?? string.Empty;
                routesNameDictionary.Add(id, relationName);
            }

            foreach (var service in this.OpenStreetMapRoutes)
            {
                foreach (var routeVariant in service.RouteVariants)
                {
                    if (routesDictionary.ContainsKey(routeVariant.Id))
                    {
                        routesDictionary.Remove(routeVariant.Id);
                    }
                }
            }

            this.OrphanRoutes = new List<OpenStreetMapRouteVariant>();
            foreach (long routeId in routesDictionary.Keys)
            {
                long relationId = routeId;
                string reference = routesReferenceDictionary[relationId];
                string routeOperator = routesOperatorDictionary[relationId];
                var openStreetMapRouteVariant = new OpenStreetMapRouteVariant
                                                    {
                                                        Reference = reference,
                                                        Operator = routeOperator,
                                                        Id = relationId,
                                                        RelationFrom = routesFromDictionary[relationId],
                                                        RelationTo = routesToDictionary[relationId],
                                                        Name = routesNameDictionary[relationId]
                                                    };
                this.OrphanRoutes.Add(openStreetMapRouteVariant);
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Extracts the open street map routes.</summary>
        // ===========================================================================================================
        private void ExtractOpenStreetMapRoutes()
        {
            // Code below assumed the .json file has all nodes, before all ways, before all relations
            // so that the stopsHashtable will be populated before we populate routesHashtable, before
            // we populate this.OpenStreetMapRoutes. 
            // This was false as relations weren't all routes before route masters, so split to two loops
            var routeBusStops = new List<BusStop>();
            var wayEndNodes = new Dictionary<long, string>();
            var stopsDictionary = new Dictionary<long, string>();
            var routeEndNodesDictionary = new Dictionary<long, int>();
            var routesStopsDictionary = new Dictionary<long, List<JourneyStop>>();
            var routesReferenceDictionary = new Dictionary<long, string>();
            var routesOperatorDictionary = new Dictionary<long, string>();
            var routesFromDictionary = new Dictionary<long, string>();
            var routesToDictionary = new Dictionary<long, string>();
            var routesNameDictionary = new Dictionary<long, string>();
            var routesNetworkDictionary = new Dictionary<long, string>();
            this.OpenStreetMapRoutes = new List<OpenStreetMapRouteMaster>();
            string fileName = Path.Combine(
                Directory.GetParent(Application.LocalUserAppDataPath).FullName,
                ValidPathString(this.SelectedLocation.Description),
                "OsmData.json");
            if (!File.Exists(fileName))
            {
                return;
            }

            string openStreetMapData = File.ReadAllText(fileName);
            dynamic entities = JToken.Parse(openStreetMapData);
            foreach (dynamic element in entities.elements)
            {
                string type = element.type;

                if (type == "node")
                {
                    long nodeId = element.id;
                    if (element.tags != null && element.tags["naptan:AtcoCode"] != null)
                    {
                        string atcoCode = element.tags["naptan:AtcoCode"];
                        BusStop busStop = BusStop(element);
                        if (atcoCode.Length > 0)
                        {
                            stopsDictionary.Add(nodeId, atcoCode);
                        }

                        routeBusStops.Add(busStop);
                    }
                    else if (element.tags != null && element.tags["public_transport"] == "platform")
                    {
                        stopsDictionary.Add(nodeId, string.Empty);
                        BusStop busStop = BusStop(element);
                        routeBusStops.Add(busStop);
                    }
                    else if (element.tags != null && element.tags["highway"] == "bus_stop")
                    {
                        stopsDictionary.Add(nodeId, string.Empty);
                        BusStop busStop = BusStop(element);
                        routeBusStops.Add(busStop);
                    }
                }

                if (type == "way")
                {
                    long id = element.id;
                    bool foundFirst = false;
                    string firstAndLast = string.Empty;
                    string lastNode = string.Empty;
                    foreach (dynamic node in element.nodes)
                    {
                        if (!foundFirst)
                        {
                            firstAndLast = node.ToString() + "+";
                            foundFirst = true;
                        }

                        lastNode = node.ToString();
                    }

                    firstAndLast += lastNode;
                    if (!wayEndNodes.ContainsKey(id))
                    {
                        wayEndNodes.Add(id, firstAndLast);
                    }
                    else
                    {
                        // error - way id should be unique to the extract
                    }
                }

                if (type == "relation")
                {
                    long id = element.id;
                    if (element.tags == null)
                    {
                        continue;
                    }

                    string relationType = element.tags["type"];

                    if (relationType != "route")
                    {
                        continue;
                    }

                    var routeStops = new List<JourneyStop>();
                    var routeEndNodes = new List<string>();
                    foreach (dynamic member in element.members)
                    {
                        string memberRole = member.role ?? string.Empty;
                        if (memberRole.Contains("platform"))
                        {
                            long routeId = member.@ref;
                            if (stopsDictionary.ContainsKey(routeId))
                            {
                                var journeyStop = new JourneyStop
                                                      {
                                                          StopPointRef = stopsDictionary[routeId], Activity = memberRole
                                                      };
                                routeStops.Add(journeyStop);
                            }
                            else
                            {
                                routeStops.Add(new JourneyStop { Activity = memberRole });
                            }
                        }
                        else if (member.type.ToString() == "way")
                        {
                            if (wayEndNodes.ContainsKey(long.Parse(member.@ref.ToString())))
                            {
                                string endNodes = wayEndNodes[long.Parse(member.@ref.ToString())].ToString();
                                string[] endNodeArray = endNodes.Split('+');
                                if (endNodeArray.Length > 1)
                                {
                                    if (routeEndNodes.Contains(endNodeArray[0]))
                                    {
                                        routeEndNodes.Remove(endNodeArray[0]);
                                    }
                                    else
                                    {
                                        routeEndNodes.Add(endNodeArray[0]);
                                    }

                                    if (routeEndNodes.Contains(endNodeArray[1]))
                                    {
                                        routeEndNodes.Remove(endNodeArray[1]);
                                    }
                                    else
                                    {
                                        routeEndNodes.Add(endNodeArray[1]);
                                    }
                                }
                            }
                        }
                    }

                    routeEndNodesDictionary.Add(id, routeEndNodes.Count);
                    routesStopsDictionary.Add(id, routeStops);
                    if (element.tags != null && element.tags["ref"] != null)
                    {
                        string routeRef = element.tags["ref"];
                        routesReferenceDictionary.Add(id, routeRef);
                    }
                    else
                    {
                        routesReferenceDictionary.Add(id, string.Empty);
                    }

                    string routeOperator = element.tags["operator"] ?? string.Empty;
                    routesOperatorDictionary.Add(id, routeOperator);
                    string relationFrom = element.tags["from"] ?? string.Empty;
                    routesFromDictionary.Add(id, relationFrom);
                    string relationTo = element.tags["to"] ?? string.Empty;
                    routesToDictionary.Add(id, relationTo);
                    string relationName = element.tags["name"] ?? string.Empty;
                    routesNameDictionary.Add(id, relationName);
                    string networkName = element.tags["network"] ?? string.Empty;
                    routesNetworkDictionary.Add(id, networkName);
                }
            }

            foreach (dynamic element in entities.elements)
            {
                string type = element.type;

                if (type != "relation")
                {
                    continue;
                }

                long id = element.id;
                string relationType = element.tags["type"];
                string reference = element.tags["ref"];
                string routeOperator = element.tags["operator"];

                if (relationType != "route_master")
                {
                    continue;
                }

                string network = element.tags["network"] ?? string.Empty;
                bool londonBus = network == "London Buses";

                var routeMaster =
                    new OpenStreetMapRouteMaster { Id = id, Reference = reference, Operator = routeOperator, LondonBus = londonBus };
                foreach (dynamic routeVariant in element.members)
                {
                    if (routeVariant.type != "relation")
                    {
                        continue;
                    }

                    long relationId = routeVariant.@ref;
                    reference = routesReferenceDictionary[relationId];
                    routeOperator = routesOperatorDictionary[relationId];
                    var openStreetMapRouteVariant = new OpenStreetMapRouteVariant
                                                        {
                                                            Reference = reference,
                                                            BusStops = routesStopsDictionary[relationId],
                                                            Operator = routeOperator,
                                                            Id = relationId,
                                                            RelationFrom = routesFromDictionary[relationId],
                                                            RelationTo = routesToDictionary[relationId],
                                                            Name = routesNameDictionary[relationId],
                                                            EndNodes = routeEndNodesDictionary[relationId],
                                                            LondonBus = routesNetworkDictionary[relationId] == "London Buses"
                    };
                    routeMaster.RouteVariants.Add(openStreetMapRouteVariant);
                }

                this.OpenStreetMapRoutes.Add(routeMaster);
            }

            this.RouteBusStops = routeBusStops;
            this.ExtractOpenStreetMapOrphans();
        }

        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Extracts the traveline routes.</summary>
        // ===========================================================================================================
        private void ExtractTravelineRoutes()
        {
            this.TravelineRoutes = new List<RouteMaster>();
            this.TravelineStops = new List<string>();
            foreach (BusStop stop in this.OverpassBusStops)
            {
                this.TravelineStops.Add(stop.AtcoCode);
            }

            string subFolder = this.SelectedLocation.LastServiceExtract.ToString("yyyyMMdd");
            if (!Directory.Exists(
                    Path.Combine(
                        Settings.Default.LocalPath,
                        ValidPathString(this.SelectedLocation.Description),
                        subFolder)))
            {
                return;
            }

            foreach (string file in Directory.GetFiles(
                Path.Combine(Settings.Default.LocalPath, ValidPathString(this.SelectedLocation.Description), subFolder),
                "*.xml",
                SearchOption.TopDirectoryOnly))
            {
                var routeMaster = new RouteMaster { FileName = file };
                try
                {
                    XDocument doc = XDocument.Load(file);

                    var journeyPatterns = new List<JourneyPatternSection>();
                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        XElement journeyPatternSections = doc.Root.Elements().ElementAt(i);
                        if (journeyPatternSections.ToString().StartsWith("<JourneyPatternSections"))
                        {
                            foreach (XElement journeyPatternSection in journeyPatternSections.Elements())
                            {
                                var journeyPattern =
                                    new JourneyPatternSection { Id = journeyPatternSection.Attribute("id").Value };
                                foreach (XElement journeyPatternTimingLink in journeyPatternSection.Elements())
                                {
                                    XElement fromElement = journeyPatternTimingLink.Elements().ElementAt(0);
                                    XElement toElement = journeyPatternTimingLink.Elements().ElementAt(1);
                                    JourneyStop journeyStop;
                                    if (journeyPattern.JourneyStops.Count == 0)
                                    {
                                        journeyStop = new JourneyStop();
                                        foreach (XElement element in fromElement.Elements())
                                        {
                                            if (element.Name.ToString().Contains("Activity"))
                                            {
                                                journeyStop.Activity = element.Value.Trim()
                                                    .Replace("pickUpAndSetDown", "platform")
                                                    .Replace("pickUp", "platform_entry_only").Replace(
                                                        "setDown",
                                                        "platform_exit_only");
                                            }

                                            if (element.Name.ToString().Contains("StopPointRef"))
                                            {
                                                journeyStop.StopPointRef = element.Value;
                                            }
                                        }

                                        journeyPattern.JourneyStops.Add(journeyStop);
                                        if (!this.TravelineStops.Contains(journeyStop.StopPointRef))
                                        {
                                            this.TravelineStops.Add(journeyStop.StopPointRef);
                                        }
                                    }

                                    journeyStop = new JourneyStop();
                                    foreach (XElement element in toElement.Elements())
                                    {
                                        if (element.Name.ToString().Contains("Activity"))
                                        {
                                            journeyStop.Activity = element.Value.Trim()
                                                .Replace("pickUpAndSetDown", "platform")
                                                .Replace("pickUp", "platform_entry_only").Replace(
                                                    "setDown",
                                                    "platform_exit_only");
                                        }

                                        if (element.Name.ToString().Contains("StopPointRef"))
                                        {
                                            journeyStop.StopPointRef = element.Value;
                                        }
                                    }

                                    journeyPattern.JourneyStops.Add(journeyStop);
                                    if (!this.TravelineStops.Contains(journeyStop.StopPointRef))
                                    {
                                        this.TravelineStops.Add(journeyStop.StopPointRef);
                                    }
                                }

                                journeyPatterns.Add(journeyPattern);
                            }

                            break;
                        }
                    }

                    XElement services = null;
                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        services = doc.Root.Elements().ElementAt(i);
                        if (services.ToString().StartsWith("<Services"))
                        {
                            break;
                        }

                        services = null;
                    }

                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        XElement vehicleJourneys = doc.Root.Elements().ElementAt(i);
                        if (vehicleJourneys.ToString().StartsWith("<VehicleJourneys"))
                        {
                            break;
                        }
                    }

                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        XElement routes = doc.Root.Elements().ElementAt(i);
                        if (routes.ToString().StartsWith("<Routes"))
                        {
                            break;
                        }
                    }

                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        XElement routeSections = doc.Root.Elements().ElementAt(i);
                        if (routeSections.ToString().StartsWith("<RouteSections"))
                        {
                            break;
                        }
                    }

                    XElement operators = null;
                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        operators = doc.Root.Elements().ElementAt(i);
                        if (operators.ToString().StartsWith("<Operators"))
                        {
                            break;
                        }
                    }

                    if (operators != null)
                    {
                        var operatorNode = (XElement)operators.FirstNode;
                        foreach (XElement thing in operatorNode.Descendants())
                        {
                            if (thing.Name.ToString().Contains("OperatorShortName")
                                || thing.Name.ToString().Contains("TradingName"))
                            {
                                routeMaster.Operator = thing.Value;
                            }
                        }
                    }

                    if (services != null)
                    {
                        var serviceNode = (XElement)services.FirstNode;
                        foreach (XElement lines in serviceNode.Descendants())
                        {
                            if (!lines.Name.ToString().Contains("Lines"))
                            {
                                continue;
                            }

                            foreach (XElement line in lines.Descendants())
                            {
                                if (!line.Name.ToString().Contains("Line"))
                                {
                                    continue;
                                }

                                foreach (XElement lineName in line.Descendants())
                                {
                                    if (lineName.Name.ToString().Contains("LineName"))
                                    {
                                        routeMaster.Reference = lineName.Value;
                                    }
                                }
                            }
                        }

                        foreach (XElement standardService in serviceNode.Elements())
                        {
                            if (!standardService.Name.ToString().Contains("StandardService"))
                            {
                                continue;
                            }

                            foreach (XElement routeVariant in standardService.Elements())
                            {
                                if (!routeVariant.Name.ToString().Contains("JourneyPattern"))
                                {
                                    continue;
                                }

                                var routeRoute = new Route
                                                     {
                                                         Id = routeVariant.Attribute("id").Value,
                                                         VehicleJourneys = string.Empty
                                                     };

                                foreach (XElement section in routeVariant.Elements())
                                {
                                    if (!section.Name.ToString().Contains("JourneyPatternSectionRefs"))
                                    {
                                        continue;
                                    }

                                    JourneyPatternSection journeyPattern =
                                        journeyPatterns.Where(item => item.Id == section.Value)?.First();
                                    foreach (JourneyStop stop in journeyPattern.JourneyStops)
                                    {
                                        if (routeRoute.Stops.Count == 0
                                            || !routeRoute.Stops[routeRoute.Stops.Count - 1].Equals(stop))
                                        {
                                            routeRoute.Stops.Add(stop);
                                        }

                                        if (!this.TravelineStops.Contains(stop.StopPointRef))
                                        {
                                            this.TravelineStops.Add(stop.StopPointRef);
                                        }
                                    }
                                }

                                // don't add duplicates
                                var matchFound = false;
                                foreach (Route routeVariantCheck in routeMaster.RouteVariants)
                                {
                                    if (!routeVariantCheck.Stops.SequenceEqual(routeRoute.Stops))
                                    {
                                        continue;
                                    }

                                    matchFound = true;
                                    break;
                                }

                                if (!matchFound)
                                {
                                    routeMaster.RouteVariants.Add(routeRoute);
                                }
                            }
                        }
                    }

                    this.TravelineRoutes.Add(routeMaster);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 23 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by FromToDataGridView for cell content click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Data grid view cell event information.</param>
        // ===========================================================================================================
        private void FromToDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.fromToDataGridView.Columns["fromToRelationColumn"] == null
                || e.ColumnIndex != this.fromToDataGridView.Columns["fromToRelationColumn"].Index || e.RowIndex == -1)
            {
                return;
            }

            string value = "http://127.0.0.1:8111/zoom?left=0&right=0&top=0&bottom=0&select=r"
                           + this.fromToDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by FromToShowMatchedCheckBox for checked changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void FromToShowMatchedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.fromToDataGridView.DataSource = null;
            this.fromToDataGridView.DataSource = this.fromToShowMatchedCheckBox.Checked
                                                     ? this.FromToChecks
                                                     : this.FromToChecks.Where(
                                                             item => (item.FromNameFound && item.ToNameFound) == false)
                                                         .ToList();

            Settings.Default.ShowMatchedFromToNames = this.fromToShowMatchedCheckBox.Checked;
            Settings.Default.Save();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by GetOpenStreetMapDataToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private async void GetOpenStreetMapDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            string overPassQuery = Settings.Default.OverpassServer + Settings.Default.OverpassQueryPrefix + this
                                       .SelectedLocation.TransportQuery
                                       .Replace("{{bbox}}", this.SelectedLocation.BoundingBox)
                                       .Replace("{{area}}", this.SelectedLocation.AreaQuery).Replace(
                                           "{{timeout}}",
                                           this.SelectedLocation.TransportTimeOut.ToString());

            if (!await GetDataAsync(overPassQuery, ValidPathString(this.SelectedLocation.Description)))
            {
                this.Enabled = true;
                return;
            }

            this.SelectedLocation.LastOpenStreetMapDownload = DateTime.Now;
            this.Locations.Save();
            this.RefreshStatus();
            this.openStreetMapDataGridView.DataSource = null;
            this.ExtractOpenStreetMapRoutes();
            this.ExtractNaptanStops();
            this.openStreetMapDataGridView.DataSource = this.OpenStreetMapRoutes;
            this.RefreshStopsGrid();
            this.CompareResults();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by HighlightStopsComboBox for selected index changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void HighlightStopsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshStopLists();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by MainForm for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.travelineDataGridView.AutoGenerateColumns = false;
            this.openStreetMapDataGridView.AutoGenerateColumns = false;
            this.compareRouteMasterDataGridView.AutoGenerateColumns = false;
            this.comparedRoutesDataGridView.AutoGenerateColumns = false;
            this.fromToDataGridView.AutoGenerateColumns = false;
            this.openStreetMapStopsDataGridView.AutoGenerateColumns = false;
            this.travelineStopsDataGridView.AutoGenerateColumns = false;
            this.stopsDataGridView.AutoGenerateColumns = false;
            this.orphansDataGridView.AutoGenerateColumns = false;
            this.RefreshForm();
            this.runningUnattended = false;
            if (this.arguments.Contains("unattended"))
            {
                this.unattendedDelayedStartTimer.Enabled = true;
                this.runningUnattended = true;
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Refresh form.</summary>
        // ===========================================================================================================
        private void RefreshForm()
        {
            this.Locations = LoadLocations();
            this.SetLocation();
            this.TravelineStops = new List<string>();
            this.RouteBusStops = new List<BusStop>();
            this.FromToChecks = new List<ComparisonResultFromTo>();
            this.ComparisonResults = new List<ComparisonResultService>();
            this.ReadBusStops();
            this.RefreshStatus();
            this.ExtractTravelineRoutes();
            this.travelineDataGridView.SuspendLayout();
            this.travelineDataGridView.DataSource = null;
            this.travelineDataGridView.DataSource = this.TravelineRoutes;
            this.travelineDataGridView.ResumeLayout();
            this.ExtractOpenStreetMapRoutes();
            this.openStreetMapDataGridView.SuspendLayout();
            this.openStreetMapDataGridView.DataSource = null;
            this.openStreetMapDataGridView.DataSource = this.OpenStreetMapRoutes;
            this.openStreetMapDataGridView.ResumeLayout();
            this.orphansDataGridView.SuspendLayout();
            this.orphansDataGridView.DataSource = null;
            this.orphansDataGridView.DataSource = this.OrphanRoutes;
            this.orphansDataGridView.ResumeLayout();
            this.CompareResults();
            this.ExtractNaptanStops();
            this.showMatchedServicesCheckBox.Checked = Settings.Default.ShowMatchedServices;
            this.showMatchedRoutesCheckBox.Checked = Settings.Default.ShowMatchedRoutes;
            this.fromToShowMatchedCheckBox.Checked = Settings.Default.ShowMatchedFromToNames;
            this.showMatchedStopsCheckBox.Checked = Settings.Default.ShowMatchedStops;
            this.RefreshStopsGrid();
            this.highlightStopsComboBox.SelectedIndex = 0;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by NaptanStopsDownloadToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private void NaptanStopsDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            
            try
            {
                string fileName = Path.Combine(Settings.Default.LocalPath, "naptandata", "NaPTANcsv.zip");
                string temporaryFileName = Path.Combine(Settings.Default.LocalPath, "naptandata", "TempNaPTANcsv.zip");
                using (var client = new WebClient())
                {
                    client.DownloadFile(Settings.Default.NaptanUrl, temporaryFileName);
                }

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                File.Move(temporaryFileName, fileName);

                foreach (Location location in this.Locations)
                {
                    string areaFileName = Path.Combine(
                        Settings.Default.LocalPath,
                        ValidPathString(location.Description),
                        "LocalStops.csv");
                    if (File.Exists(areaFileName))
                    {
                        File.Delete(areaFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                this.unattendedException = true;
                this.Email(ex.Message + Environment.NewLine + ex.StackTrace);
                // Download timeout
            }

            // Even if download fails, re-extract from previous zip if it exists
            this.RefreshStatus();
            this.ExtractNaptanStops();
            this.RefreshStopsGrid();

            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 25 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Reads bus stops.</summary>
        // ===========================================================================================================
        private void ReadBusStops()
        {
            var overpassBusStops = new List<BusStop>();
            string fileName = Path.Combine(
                Directory.GetParent(Application.LocalUserAppDataPath).FullName,
                ValidPathString(this.SelectedLocation.Description),
                "OsmBusStops.json");
            if (File.Exists(fileName))
            {
                dynamic stops = JToken.Parse(File.ReadAllText(fileName));
                foreach (dynamic element in stops.elements)
                {
                    BusStop busStop = BusStop(element);
                    overpassBusStops.Add(busStop);
                }
            }

            this.OverpassBusStops = overpassBusStops;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by RefreshBusStopsToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private async void RefreshBusStopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            string overPassQuery = Settings.Default.OverpassServer + Settings.Default.OverpassQueryPrefix + this
                                       .SelectedLocation.BusStopQuery
                                       .Replace("{{bbox}}", this.SelectedLocation.BoundingBox)
                                       .Replace("{{area}}", this.SelectedLocation.AreaQuery).Replace(
                                           "{{timeout}}",
                                           this.SelectedLocation.BusStopTimeOut.ToString());
            try
            {
                this.OverpassBusStops = await GetBusStopsAsync(
                                            overPassQuery,
                                            ValidPathString(this.SelectedLocation.Description));
                this.busStopsLabel.Text = @"Bus stops read: " + this.OverpassBusStops.Count;
                this.SelectedLocation.LastOpenStreetMapBusStopRefresh = DateTime.Today;
                this.Locations.Save();
                this.RefreshStatus();
                string areaPath = Path.Combine(
                    Settings.Default.LocalPath,
                    ValidPathString(this.SelectedLocation.Description));
                string areaFileName = Path.Combine(areaPath, "LocalStops.csv");
                if (File.Exists(areaFileName))
                {
                    File.Delete(areaFileName);
                }

                this.ExtractNaptanStops();
                this.RefreshStopsGrid();
            }
            catch (HttpRequestException exception)
            {
                Debug.WriteLine(exception);
                this.unattendedException = true;
                if (!this.runningUnattended)
                {
                    MessageBox.Show(
                        this,
                        @"Internet connection issue",
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception exception)
            {
                this.unattendedException = true;
                if (!this.runningUnattended)
                {
                    MessageBox.Show(
                        this,
                        exception.Message,
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
                else
                {
                    this.Email(exception.Message + Environment.NewLine + exception.StackTrace);
                }
            }

            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Refresh status.</summary>
        // ===========================================================================================================
        private void RefreshStatus()
        {
            this.statusGroupBox.Text = @"Status - " + this.SelectedLocation.Description;
            string naptanFileName = Path.Combine(Settings.Default.LocalPath, "naptandata", "NaPTANcsv.zip");
            if (File.Exists(naptanFileName))
            {
                var naptanInfo = new FileInfo(naptanFileName);
                this.naptanDownloadedLabel.Text = @"Naptan Downloaded: " + naptanInfo.LastWriteTime.ToLongDateString()
                                                                         + @" " + naptanInfo.LastWriteTime
                                                                             .ToShortTimeString();
            }

            this.busStopsLabel.Text = @"Bus stops read: " + this.OverpassBusStops.Count;
            if (this.SelectedLocation.LastOpenStreetMapBusStopRefresh > DateTime.MinValue)
            {
                this.busStopsLastDownloadedLabel.Text = @"Last downloaded: "
                                                        + this.SelectedLocation.LastOpenStreetMapBusStopRefresh
                                                            .ToLongDateString();
            }

            if (Directory.Exists(Settings.Default.LocalPath))
            {
                int zipFiles = Directory.GetFiles(
                    Path.Combine(Settings.Default.LocalPath, "tndsdata"),
                    "*.zip",
                    SearchOption.TopDirectoryOnly).Length;
                if (File.Exists(Path.Combine(Settings.Default.LocalPath, "tndsdata", "NaPTANcsv.zip")))
                {
                    // don't count Naptan zip as TNDS zip
                    zipFiles -= 1;
                }

                var directory = new DirectoryInfo(Path.Combine(Settings.Default.LocalPath, "tndsdata"));
                FileInfo myFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();

                this.travelineZipsLabel.Text = @"TNDS zips: " + zipFiles;
                this.travelineLastDownloadedLabel.Text = @"Newest zip: " + myFile.LastWriteTime.ToLongDateString()
                                                                         + @" " + myFile.LastWriteTime
                                                                             .ToShortTimeString();
                this.lastWriteTime = myFile.LastWriteTime;
            }

            string subFolder = this.SelectedLocation.LastServiceExtract.ToString("yyyyMMdd");
            if (Directory.Exists(
                Path.Combine(
                    Settings.Default.LocalPath,
                    ValidPathString(this.SelectedLocation.Description),
                    subFolder)))
            {
                this.localServicesLabel.Text = @"Local services extracted: " + Directory.GetFiles(
                                                   Path.Combine(
                                                       Settings.Default.LocalPath,
                                                       ValidPathString(this.SelectedLocation.Description),
                                                       subFolder),
                                                   "*.xml",
                                                   SearchOption.TopDirectoryOnly).Length;
                if (this.SelectedLocation.LastServiceExtract > DateTime.MinValue)
                {
                    this.localRoutesLastExtractedLabel.Text = @"Last extracted: "
                                                              + this.SelectedLocation.LastServiceExtract
                                                                  .ToLongDateString();
                }
            }

            if (this.SelectedLocation.LastOpenStreetMapDownload > DateTime.MinValue)
            {
                this.openstreetMapLastDownloadedLabel.Text = @"Last downloaded: "
                                                             + this.SelectedLocation.LastOpenStreetMapDownload
                                                                 .ToLongDateString() + @" "
                                                             + this.SelectedLocation.LastOpenStreetMapDownload
                                                                 .ToShortTimeString();
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Refresh stop lists.</summary>
        // ===========================================================================================================
        private void RefreshStopLists()
        {
            var osmStops = new List<JourneyStop>();
            var travelineStops = new List<JourneyStop>();
            this.openStreetMapStopsGroupBox.Text = @"OSM";
            this.travelineStopsGroupBox.Text = @"TNDS";
            this.openStreetMapStopsDataGridView.DataSource = null;
            this.travelineStopsDataGridView.DataSource = null;
            foreach (DataGridViewRow selectedRow in this.comparedRoutesDataGridView.SelectedRows)
            {
                if (((ComparisonResultRoute)selectedRow.DataBoundItem).RelationStops.Count > 0
                    && this.openStreetMapStopsDataGridView.DataSource == null)
                {
                    osmStops = ((ComparisonResultRoute)selectedRow.DataBoundItem).RelationStops;
                    this.openStreetMapStopsDataGridView.DataSource = osmStops;
                    this.openStreetMapStopsGroupBox.Text =
                        @"OSM: " + ((ComparisonResultRoute)selectedRow.DataBoundItem).RelationStops.Count;
                }

                if (((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops.Count > 0
                    && this.travelineStopsDataGridView.DataSource == null)
                {
                    travelineStops = ((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops;
                    this.travelineStopsDataGridView.DataSource = travelineStops;
                    this.travelineStopsGroupBox.Text =
                        @"TNDS: " + ((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops.Count;
                }

                if (this.travelineStopsDataGridView.DataSource != null
                    && this.openStreetMapStopsDataGridView.DataSource != null)
                {
                    break;
                }
            }

            int mostStops = this.travelineStopsDataGridView.RowCount > this.openStreetMapStopsDataGridView.RowCount
                                ? this.travelineStopsDataGridView.RowCount
                                : this.openStreetMapStopsDataGridView.RowCount;
            if (this.highlightStopsComboBox.SelectedIndex == 0)
            {
                for (var i = 0; i < mostStops; i++)
                {
                    if (i < this.openStreetMapStopsDataGridView.RowCount
                        && i < this.travelineStopsDataGridView.RowCount)
                    {
                        var openStreetMapStop = new JourneyStop
                                                    {
                                                        StopPointRef =
                                                            this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Value
                                                                .ToString(),
                                                        Activity = this.openStreetMapStopsDataGridView.Rows[i].Cells[1]
                                                            .Value.ToString()
                                                    };
                        if (!travelineStops.Contains(openStreetMapStop))
                        {
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                        }

                        var travelineDataStop = new JourneyStop
                                                    {
                                                        StopPointRef =
                                                            this.travelineStopsDataGridView.Rows[i].Cells[0].Value
                                                                .ToString(),
                                                        Activity = this.travelineStopsDataGridView.Rows[i].Cells[1]
                                                            .Value.ToString()
                                                    };
                        if (!osmStops.Contains(travelineDataStop))
                        {
                            this.travelineStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                            this.travelineStopsDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                        }
                    }
                    else if (i < this.openStreetMapStopsDataGridView.RowCount)
                    {
                        var openStreetMapStop = new JourneyStop
                                                    {
                                                        StopPointRef =
                                                            this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Value
                                                                .ToString(),
                                                        Activity = this.openStreetMapStopsDataGridView.Rows[i].Cells[1]
                                                            .Value.ToString()
                                                    };
                        if (!travelineStops.Contains(openStreetMapStop))
                        {
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                        }
                    }
                    else if (i < this.travelineStopsDataGridView.RowCount)
                    {
                        var travelineDataStop = new JourneyStop
                                                    {
                                                        StopPointRef =
                                                            this.travelineStopsDataGridView.Rows[i].Cells[0].Value
                                                                .ToString(),
                                                        Activity = this.travelineStopsDataGridView.Rows[i].Cells[1]
                                                            .Value.ToString()
                                                    };
                        if (!osmStops.Contains(travelineDataStop))
                        {
                            this.travelineStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                            this.travelineStopsDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                for (var i = 0; i < mostStops; i++)
                {
                    if (i < this.openStreetMapStopsDataGridView.RowCount
                        && i < this.travelineStopsDataGridView.RowCount)
                    {
                        if (this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Value.ToString()
                            != this.travelineStopsDataGridView.Rows[i].Cells[0].Value.ToString())
                        {
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            this.travelineStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                            this.travelineStopsDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                        }
                    }
                    else if (i < this.openStreetMapStopsDataGridView.RowCount)
                    {
                        this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                        this.openStreetMapStopsDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else if (i < this.travelineStopsDataGridView.RowCount)
                    {
                        this.travelineStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                        this.travelineStopsDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Sets the location.</summary>
        // ===========================================================================================================
        private void SetLocation()
        {
            string selectedLocation = Settings.Default.SelectedLocation;
            this.SelectedLocation = null;
            foreach (Location location in this.Locations)
            {
                if (location.Description != selectedLocation)
                {
                    continue;
                }

                this.SelectedLocation = location;
                break;
            }

            if (this.SelectedLocation != null)
            {
                return;
            }

            this.SelectedLocation = this.Locations[0];
            Settings.Default.SelectedLocation = this.Locations[0].Description;
            Settings.Default.Save();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by SettingsToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            string oldLocation = this.SelectedLocation.Description;
            var settingsForm = new SettingsForm(this.SelectedLocation, this.Locations);
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                if (oldLocation != settingsForm.SelectedLocation.Description)
                {
                    this.RefreshForm();
                }
            }

            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ShowMatchedRoutesCheckBox for checked changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ShowMatchedRoutesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.comparedRoutesDataGridView.DataSource = null;
            this.comparedRoutesDataGridView.DataSource = this.showMatchedRoutesCheckBox.Checked
                                                             ? this.ComparisonResultsRoutes
                                                             : this.ComparisonResultsRoutes.Where(
                                                                     item => item.OperatorsEqual == false
                                                                             || item.ReferencesEqual == false
                                                                             || item.StopsEqual == false
                                                                             || item.NameFormatting == false
                                                                             || item.Gaps)
                                                                 .ToList();
            this.wikiTextButton.Visible = !this.showMatchedRoutesCheckBox.Checked
                                          && this.comparedRoutesDataGridView.RowCount == 0
                                          && this.ComparisonResultsRoutes.Count > 0;

            Settings.Default.ShowMatchedRoutes = this.showMatchedRoutesCheckBox.Checked;
            Settings.Default.Save();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ShowMatchedServicesCheckBox for checked changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ShowMatchedServicesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.compareRouteMasterDataGridView.DataSource = null;
            this.compareRouteMasterDataGridView.DataSource = this.showMatchedServicesCheckBox.Checked
                                                                 ? this.ComparisonResults
                                                                 : this.ComparisonResults.Where(
                                                                         item => item.OperatorsMatch == false
                                                                                 || item.ReferencesMatch == false
                                                                                 || item.RouteVariantsMatch == false)
                                                                     .ToList();

            Settings.Default.ShowMatchedServices = this.showMatchedServicesCheckBox.Checked;
            Settings.Default.Save();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ShowMatchedStopsCheckBox for checked changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ShowMatchedStopsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshStopsGrid();
            this.downloadUnmatchedStopsButton.Visible =
                !this.showMatchedStopsCheckBox.Checked && this.stopsDataGridView.Rows.Count > 0;
            Settings.Default.ShowMatchedStops = this.showMatchedStopsCheckBox.Checked;
            Settings.Default.Save();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Refresh stops grid.</summary>
        // ===========================================================================================================
        private void RefreshStopsGrid()
        {
            this.stopsDataGridView.DataSource = null;
            this.stopsDataGridView.DataSource = this.showMatchedStopsCheckBox.Checked
                                                    ? this.RouteBusStops
                                                    : this.RouteBusStops.Where(
                                                            item => item.NamesMatch == false
                                                                    || item.StatusesMatch == false
                                                                    || item.TypesMatch == false)
                                                        .ToList();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 13 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by StopsDataGridView for cell content click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Data grid view cell event information.</param>
        // ===========================================================================================================
        private void StopsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (this.stopsDataGridView.Columns["stopIdColumn"] != null
                && e.ColumnIndex == this.stopsDataGridView.Columns["stopIdColumn"].Index && e.RowIndex != -1)
            {
                string value = "http://127.0.0.1:8111/zoom?left=0&right=0&top=0&bottom=0&select=n"
                               + this.stopsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                Process.Start(value);
            }

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                || senderGrid.Columns[e.ColumnIndex].Name != this.naptanInfoStopButtonColumn.Name || e.RowIndex < 0)
            {
                return;
            }

            this.Enabled = false;
            var selectedRow = (BusStop)senderGrid.Rows[e.RowIndex].DataBoundItem;
            var editForm = new NaptanForm(selectedRow);
            editForm.ShowDialog();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by OpenStreetMapStopsListBox for selection changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void StopsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            string openStreetMapStopName = string.Empty;
            string travelineStopName = string.Empty;
            if (this.openStreetMapStopsDataGridView.SelectedCells.Count > 0)
            {
                if (this.OverpassBusStops != null)
                {
                    openStreetMapStopName = this.NaptanStops.FirstOrDefault(
                        item => item.AtcoCode
                                == ((JourneyStop)this.openStreetMapStopsDataGridView.SelectedCells[0].OwningRow
                                           .DataBoundItem).StopPointRef)?.JourneyStopName;
                }
            }

            this.addNodeButton.Visible = false;
            if (this.travelineStopsDataGridView.SelectedCells.Count > 0)
            {
                if (this.OverpassBusStops != null)
                {
                    BusStop naptanStop = this.NaptanStops.FirstOrDefault(
                        item => item.AtcoCode
                                == ((JourneyStop)this.travelineStopsDataGridView.SelectedCells[0].OwningRow
                                           .DataBoundItem).StopPointRef);
                    if (naptanStop != null)
                    {
                        travelineStopName = naptanStop.JourneyStopName;
                        this.addNodeButton.Visible = true;
                    }
                }
            }

            this.stopNameLabel.Text = openStreetMapStopName + @" / " + travelineStopName;
        }

        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>EdLoach - 21 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by TravelineStopsDataGridView for cell content double click
        ///          events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Data grid view cell event information.</param>
        // ===========================================================================================================
        private void TravelineStopsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // moved to double-click, so still possible to click and ctrl-C to paste reference in JOSM search box
            // import doesn't zoom, so I envision this method as being used to add stops that are already in OSM but
            // not in the currently downloaded data to the existing data layer (and a search for the AtcoCode will then find it)
            if (this.travelineStopsDataGridView.Columns["tndsStopPointRefColumn"] == null
                || e.ColumnIndex != this.travelineStopsDataGridView.Columns["tndsStopPointRefColumn"].Index
                || e.RowIndex == -1)
            {
                return;
            }

            // ReSharper disable once StringLiteralTypo
            string value =
                "http://127.0.0.1:8111/import?url=https%3A%2F%2Foverpass-api.de%2Fapi%2Fxapi_meta%3F*%5Bnaptan%253AAtcoCode%253D"
                + this.travelineStopsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "%5D";
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by WikiTextButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void WikiTextButton_Click(object sender, EventArgs e)
        {
            var wikiText = new StringBuilder();
            wikiText.Append(
                @"[https://github.com/EdLoach/CheckPublicTransportRelations Last full check with this tool] : ");
            wikiText.AppendLine(DateTime.Today.ToLongDateString());
            wikiText.AppendLine();
            if (this.SelectedLocation.BusStopQuery.ToLower().Contains("{{bbox}}")
                || this.SelectedLocation.TransportQuery.Contains("{{bbox}}"))
            {
                wikiText.Append(@"Using bbox :");
                wikiText.AppendLine(this.SelectedLocation.BoundingBox);
                wikiText.AppendLine();
            }

            wikiText.Append(@"Overpass bus stops query : <code><nowiki>");
            wikiText.Append(this.SelectedLocation.BusStopQuery);
            wikiText.AppendLine(@"</nowiki></code>");
            wikiText.AppendLine();

            wikiText.Append(@"Overpass transport data query : <code><nowiki>");
            wikiText.Append(this.SelectedLocation.TransportQuery);
            wikiText.AppendLine(@"</nowiki></code>");
            wikiText.AppendLine();

            wikiText.AppendLine(@"{|class=""wikitable sortable""");
            wikiText.AppendLine(@"|- ");
            wikiText.AppendLine(@"|- style = ""background-color:#E9E9E9""");
            wikiText.AppendLine(@"!| Operator");
            wikiText.AppendLine(@"!| Service Ref");
            wikiText.AppendLine(@"!| Relation");
            wikiText.AppendLine(@"!| Last checked");
            wikiText.AppendLine(@"!| Notes");

            List<OpenStreetMapRouteMaster> sortedList =
                this.OpenStreetMapRoutes.OrderBy(o => o.Reference).ThenBy(o => o.Operator).ToList();
            foreach (OpenStreetMapRouteMaster service in sortedList)
            {
                wikiText.AppendLine(@"|- ");

                wikiText.Append(@"| ");
                wikiText.Append(service.Operator);
                wikiText.Append(@" || ");
                wikiText.Append(service.Reference);
                wikiText.Append(@" || '''{{BrowseRelation|");
                wikiText.Append(service.Id);
                wikiText.Append(@"}}''' || ");
                wikiText.Append(DateTime.Today.ToShortDateString());
                wikiText.AppendLine(@" || ");
            }

            wikiText.AppendLine(@"|}");

            Clipboard.SetText(wikiText.ToString());
            MessageBox.Show(
                this,
                @"Text copied to clipboard",
                @"Check Public Transport Relations",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by sparseEditAreaRemoteControlToolStripMenuItem for click
        ///          events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SparseEditAreaRemoteControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string overpassQuery = this.SelectedLocation.TransportQuery
                .Replace("{{bbox}}", this.SelectedLocation.BoundingBox).Replace("[out:json]", "[out:xml]")
                .Replace("{{area}}", this.SelectedLocation.AreaQuery).Replace(
                    "{{timeout}}",
                    this.SelectedLocation.TransportTimeOut.ToString()).Replace("out;", "out meta;");
            string value = "http://127.0.0.1:8111/import?url=https%3A%2F%2Foverpass-api.de%2Fapi%2Finterpreter"
                           + HttpUtility.UrlEncode("?data=" + overpassQuery);
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.1.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by AddNodeButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            if (this.travelineStopsDataGridView.SelectedCells.Count <= 0)
            {
                return;
            }

            if (this.OverpassBusStops == null)
            {
                return;
            }

            BusStop naptanStop = this.NaptanStops.FirstOrDefault(
                item => item.AtcoCode
                        == ((JourneyStop)this.travelineStopsDataGridView.SelectedCells[0].OwningRow.DataBoundItem)
                        .StopPointRef);
            if (naptanStop == null)
            {
                return;
            }

            decimal latitude = naptanStop.Latitude;
            decimal longitude = naptanStop.Longitude;

            var remoteCommand = new StringBuilder();
            remoteCommand.Append("http://127.0.0.1:8111/add_node?lon=");
            remoteCommand.Append(longitude);
            remoteCommand.Append("&lat=");
            remoteCommand.Append(latitude);
            remoteCommand.Append("&addtags=");
            remoteCommand.Append(HttpUtility.UrlEncode("highway=bus_stop"));
            remoteCommand.Append(HttpUtility.UrlEncode("|"));
            remoteCommand.Append(HttpUtility.UrlEncode("public_transport=platform"));
            remoteCommand.Append(HttpUtility.UrlEncode("|"));
            remoteCommand.Append(HttpUtility.UrlEncode("source=naptan"));
            remoteCommand.Append(HttpUtility.UrlEncode("|"));
            remoteCommand.Append(HttpUtility.UrlEncode("naptan:verified=no"));
            remoteCommand.Append(HttpUtility.UrlEncode("|"));
            remoteCommand.Append(HttpUtility.UrlEncode("name="));
            remoteCommand.Append(HttpUtility.UrlEncode(naptanStop.NaptanName));
            remoteCommand.Append(HttpUtility.UrlEncode("|"));
            remoteCommand.Append(HttpUtility.UrlEncode("naptan:AtcoCode="));
            remoteCommand.Append(HttpUtility.UrlEncode(naptanStop.AtcoCode));
            remoteCommand.Append(HttpUtility.UrlEncode("|"));
            remoteCommand.Append(HttpUtility.UrlEncode("naptan:NaptanCode="));
            remoteCommand.Append(HttpUtility.UrlEncode(naptanStop.NaptanNaptanCode));
            if (naptanStop.NaptanBusStopType != "MKD")
            {
                remoteCommand.Append(HttpUtility.UrlEncode("|"));
                remoteCommand.Append(HttpUtility.UrlEncode("naptan:BusStopType="));
                remoteCommand.Append(HttpUtility.UrlEncode(naptanStop.NaptanBusStopType));
            }

            if (naptanStop.NaptanStatus != "act")
            {
                remoteCommand.Append(HttpUtility.UrlEncode("|"));
                remoteCommand.Append(HttpUtility.UrlEncode("naptan:Status="));
                remoteCommand.Append(HttpUtility.UrlEncode(naptanStop.NaptanStatus));
            }

            Process.Start(remoteCommand.ToString());
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.1.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by downloadUnmatchedStopsButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void DownloadUnmatchedStopsButton_Click(object sender, EventArgs e)
        {
            if (this.showMatchedStopsCheckBox.Checked || this.stopsDataGridView.Rows.Count <= 0)
            {
                return;
            }

            if (this.stopsDataGridView.Columns["stopIdColumn"] == null)
            {
                return;
            }

            int index = this.stopsDataGridView.Columns["stopIdColumn"].Index;
            string value = this.stopsDataGridView.Rows.Cast<DataGridViewRow>().Aggregate(
                "http://127.0.0.1:8111/load_object?new_layer=false&objects=",
                (current, row) => current + "n" + row.Cells[index].Value + ",");
            value = value.Substring(0, value.Length - 1);
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by CheckForOrphanRoutesToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private async void CheckForOrphanRoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            string overPassQuery = Settings.Default.OverpassServer + Settings.Default.OverpassQueryPrefix + this
                                       .SelectedLocation.OrphansQuery
                                       .Replace("{{bbox}}", this.SelectedLocation.BoundingBox)
                                       .Replace("{{area}}", this.SelectedLocation.AreaQuery).Replace(
                                           "{{timeout}}",
                                           this.SelectedLocation.OrphanRoutesTimeOut.ToString());

            if (!await GetOrphansAsync(overPassQuery, ValidPathString(this.SelectedLocation.Description)))
            {
                this.Enabled = true;
                return;
            }

            this.ExtractOpenStreetMapOrphans();
            this.orphansDataGridView.DataSource = this.OrphanRoutes;
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Orphans data grid view cell content click.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Data grid view cell event information.</param>
        // ===========================================================================================================
        private void OrphansDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.orphansDataGridView.Columns["idOrphanColumn"] == null
                || e.ColumnIndex != this.orphansDataGridView.Columns["idOrphanColumn"].Index || e.RowIndex == -1)
            {
                return;
            }

            string value =
                "http://127.0.0.1:8111/load_object?new_layer=false&relation_members=true&referrers=true&objects=r"
                + this.orphansDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 24 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by TravelineStopsDataGridView for cell content click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Data grid view cell event information.</param>
        // ===========================================================================================================
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private void TravelineStopsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                || senderGrid.Columns[e.ColumnIndex].Name != this.naptanInfoButtonColumn.Name || e.RowIndex < 0)
            {
                return;
            }

            this.Enabled = false;
            var selectedRow = (JourneyStop)senderGrid.Rows[e.RowIndex].DataBoundItem;
            var editForm = new NaptanForm(selectedRow);
            editForm.ShowDialog();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 6 May 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by SelectAllButton for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            if (this.travelineStopsDataGridView.RowCount <= 0)
            {
                return;
            }

            var value = "http://127.0.0.1:8111/zoom?left=0&right=0&top=0&bottom=0&select=";
            foreach (DataGridViewRow stopRow in this.travelineStopsDataGridView.Rows)
            {
                BusStop naptanStop = this.RouteBusStops.FirstOrDefault(
                    item => item.AtcoCode == ((JourneyStop)stopRow.DataBoundItem).StopPointRef);
                if (naptanStop == null)
                {
                    continue;
                }

                value += "n" + naptanStop.Id + ",";
                this.addNodeButton.Visible = true;
            }

            if (!value.EndsWith(","))
            {
                return;
            }

            value = value.Substring(0, value.Length - 1);
            Process.Start(value);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by UnattendedDelayedStartTimer for tick events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void UnattendedDelayedStartTimer_Tick(object sender, EventArgs e)
        {
            this.unattendedException = false;
            DateTime startTime = DateTime.MinValue;
            if (Directory.Exists(Settings.Default.LocalPath))
            {
                int zipFiles = Directory.GetFiles(
                    Path.Combine(Settings.Default.LocalPath, "tndsdata"),
                    "*.zip",
                    SearchOption.TopDirectoryOnly).Length;
                if (File.Exists(Path.Combine(Settings.Default.LocalPath, "tndsdata", "NaPTANcsv.zip")))
                {
                    // don't count Naptan zip as TNDS zip
                    zipFiles -= 1;
                }

                var directory = new DirectoryInfo(Path.Combine(Settings.Default.LocalPath, "tndsdata"));
                FileInfo myFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();

                this.travelineZipsLabel.Text = @"TNDS zips: " + zipFiles;
                this.travelineLastDownloadedLabel.Text = @"Newest zip: " + myFile.LastWriteTime.ToLongDateString()
                                                                         + @" " + myFile.LastWriteTime
                                                                             .ToShortTimeString();
                startTime = myFile.LastWriteTime;
            }

            this.unattendedDelayedStartTimer.Enabled = false;
            this.Locations = LoadLocations();
            this.SetLocation();
            this.RefreshBusStopsToolStripMenuItem_Click(sender, e);
            if (!this.unattendedException)
            {
                this.GetOpenStreetMapDataToolStripMenuItem_Click(sender, e);
            }

            if (!this.unattendedException)
            {
                this.NaptanStopsDownloadToolStripMenuItem_Click(sender, e);
            }

            if (!this.unattendedException)
            {
                this.DownloadTravelineNationalDataSetToolStripMenuItem_Click(sender, e);
            }

            if (!this.unattendedException)
            {
                if (this.lastWriteTime > startTime)
                {
                    this.ExtractLocalRoutesToolStripMenuItem_Click(sender, e);
                    List<ComparisonResultRoute> routes = this.ComparisonResultsRoutes.Where(
                        item => item.OperatorsEqual == false || item.ReferencesEqual == false
                                                             || item.StopsEqual == false || item.NameFormatting == false
                                                             || item.Gaps).ToList();
                    if (routes.Count > 0)
                    {
                        string body = "Routes Changed : " + routes.Count + Environment.NewLine;
                        foreach (ComparisonResultRoute route in routes)
                        {
                            body += route.RelationOperator + " " + route.RelationReference + "/ "
                                    + route.ServiceOperator + " " + route.ServiceReference + Environment.NewLine;
                        }

                        this.Email(body);
                    }
                }
            }

            this.CloseButton_Click(sender, e);
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Sends an email.</summary>
        ///
        /// <param name="messageBody">The message body.</param>
        /// <param name="isBodyHtml"> True if this  is body HTML.</param>
        // ===========================================================================================================
        private void Email(string messageBody, bool isBodyHtml = false)
        {
            try
            {
                var message = new MailMessage
                                  {
                                      From = new MailAddress(Settings.Default.EmailFrom),
                                      Subject = "TNDS Routes Notification - " + this.SelectedLocation.Description,
                                      IsBodyHtml = isBodyHtml,
                                      Body = messageBody
                                  };

                message.To.Add(new MailAddress(Settings.Default.EmailTo));

                var smtp = new SmtpClient
                               {
                                   Port = Settings.Default.SmtpPort,
                                   Host = Settings.Default.SmtpHost,
                                   EnableSsl = Settings.Default.SmtpEnableSsl,
                                   UseDefaultCredentials = Settings.Default.SmtpUseDefaultCredentials,
                                   Credentials = new NetworkCredential(
                                       Settings.Default.SmtpUsername,
                                       Settings.Default.SmtpPassword),
                                   DeliveryMethod = SmtpDeliveryMethod.Network
                               };

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by BusStopNameMappingsToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void BusStopNameMappingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var mappingsForm = new BusStopNameMappingsForm();
            mappingsForm.ShowDialog(this);
            this.Enabled = true;
        }
    }
}