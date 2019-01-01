// ===========================================================================================================
// <copyright file="MainForm.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>27 December 2018</date>
// <summary>Implements the main Windows Form</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;

    using CheckPublicTransportRelations.Properties;

    using Newtonsoft.Json.Linq;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>Form for viewing the main.</summary>
    ///
    /// ### <inheritdoc/>
    // ===========================================================================================================
    public partial class MainForm : Form
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>The client.</summary>
        // ===========================================================================================================
        private static readonly HttpClient Client = new HttpClient();

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the
        ///          <see cref="T:CheckPublicTransportRelations.MainForm" /> class.</summary>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public MainForm()
        {
            this.InitializeComponent();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the open street map routes.</summary>
        ///
        /// <value>The open street map routes.</value>
        // ===========================================================================================================
        private List<OpenStreetMapRouteMaster> OpenStreetMapRoutes { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the comparison results.</summary>
        ///
        /// <value>The comparison results.</value>
        // ===========================================================================================================
        private List<ComparisonResultService> ComparisonResults { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the traveline routes.</summary>
        ///
        /// <value>The traveline routes.</value>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        private List<RouteMaster> TravelineRoutes { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the comparison results routes.</summary>
        ///
        /// <value>The comparison results routes.</value>
        // ===========================================================================================================
        private List<ComparisonResultRoute> ComparisonResultsRoutes { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the overpass bus stops.</summary>
        ///
        /// <value>The overpass bus stops.</value>
        // ===========================================================================================================
        private List<BusStop> OverpassBusStops { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets bus stops asynchronous.</summary>
        ///
        /// <param name="path">Full pathname of the file.</param>
        ///
        /// <returns>The bus stops asynchronous.</returns>
        // ===========================================================================================================
        private static async Task<List<BusStop>> GetBusStopsAsync(string path)
        {
            var overpassBusStops = new List<BusStop>();
            HttpResponseMessage response = await Client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return overpassBusStops;
            }

            string overpassBusStopsJson = await response.Content.ReadAsStringAsync();
            string fileName = Path.Combine(Application.LocalUserAppDataPath, "OsmBusStops.json");
            File.WriteAllText(fileName, overpassBusStopsJson);
            dynamic stops = JToken.Parse(overpassBusStopsJson);
            foreach (dynamic element in stops.elements)
            {
                string type = element.type;
                long id = element.id;
                string atcoCode = element.tags["naptan:AtcoCode"];
                var busStop = new BusStop(type, id, atcoCode);
                overpassBusStops.Add(busStop);
            }

            return overpassBusStops;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets data asynchronous.</summary>
        ///
        /// <param name="overPassQuery">The over pass query.</param>
        ///
        /// <returns>The data asynchronous.</returns>
        // ===========================================================================================================
        private static async Task<bool> GetDataAsync(string overPassQuery)
        {
            HttpResponseMessage response = await Client.GetAsync(overPassQuery);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            string overpassTransportDataXml = await response.Content.ReadAsStringAsync();
            string fileName = Path.Combine(Application.LocalUserAppDataPath, "OsmData.json");
            File.WriteAllText(fileName, overpassTransportDataXml);

            return true;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Closes button click.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by Download Traveline National DataSet Tool Strip Menu Item for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        private void DownloadTravelineNationalDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var downloadForm = new TravelineDownloadForm();
            downloadForm.ShowDialog(this);
            this.RefreshStatus();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Exit tool strip menu item click.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ExtractLocalRoutesToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ExtractLocalRoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var extractRoutesForm = new ExtractRoutesForm(this.OverpassBusStops);
            extractRoutesForm.ShowDialog(this);
            this.RefreshStatus();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Extracts the traveline routes.</summary>
        ///
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        private void ExtractTravelineRoutes()
        {
            this.TravelineRoutes = new List<RouteMaster>();

            string subFolder = Settings.Default.LastRouteExtract.ToString("yyyyMMdd");
            if (!Directory.Exists(Path.Combine(Settings.Default.LocalPath, subFolder)))
            {
                return;
            }

            foreach (string file in Directory.GetFiles(
                Path.Combine(Settings.Default.LocalPath, subFolder),
                "*.xml",
                SearchOption.TopDirectoryOnly))
            {
                var routeMaster = new RouteMaster { FileName = file };
                try
                {
                    XDocument doc = XDocument.Load(file);
                    var stopPoints = new Hashtable();
                    XElement stops = null;
                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        stops = doc.Root.Elements().ElementAt(i);
                        if (stops.ToString().StartsWith("<StopPoints"))
                        {
                            break;
                        }

                        stops = null;
                    }

                    if (stops != null && stops.ToString().StartsWith("<StopPoints"))
                    {
                        foreach (XElement stop in stops.Elements())
                        {
                            stopPoints.Add(
                                stop.Elements().ElementAt(0).Value,
                                stop.Elements().ElementAt(1).Value + ", " + stop.Elements().ElementAt(2).Value);
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

                    XElement vehicleJourneys = null;
                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        vehicleJourneys = doc.Root.Elements().ElementAt(i);
                        if (vehicleJourneys.ToString().StartsWith("<VehicleJourneys"))
                        {
                            break;
                        }

                        vehicleJourneys = null;
                    }

                    XElement routes = null;
                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        routes = doc.Root.Elements().ElementAt(i);
                        if (routes.ToString().StartsWith("<Routes"))
                        {
                            break;
                        }

                        routes = null;
                    }

                    XElement routeSections = null;
                    for (var i = 0; i < doc.Root.Elements().Count(); i++)
                    {
                        routeSections = doc.Root.Elements().ElementAt(i);
                        if (routeSections.ToString().StartsWith("<RouteSections"))
                        {
                            break;
                        }
                    }

                    if (routes != null)
                    {
                        foreach (XElement route in routes.Elements())
                        {
                            var routeRoute = new Route
                                                 {
                                                     Id = route.Attribute("id").Value,
                                                     Description = route.Elements().ElementAt(1).Value,
                                                     RouteSectionRef = route.Elements().ElementAt(2).Value,
                                                     VehicleJourneys = string.Empty
                                                 };

                            if (services != null)
                            {
                                foreach (XElement service in services.Elements())
                                {
                                    // find JourneyPattern where RouteRef = routeRoute.Id
                                    if (service.Elements().Count() < 9 || !service.Elements().ElementAt(8).ToString()
                                            .StartsWith("<StandardService"))
                                    {
                                        continue;
                                    }

                                    XElement standardService = service.Elements().ElementAt(8);
                                    foreach (XElement standardServiceElement in standardService.Elements())
                                    {
                                        // find a journey pattern
                                        if (!standardServiceElement.ToString().StartsWith("<JourneyPattern")
                                            || standardServiceElement.Elements().ElementAt(1).Value != routeRoute.Id)
                                        {
                                            continue;
                                        }

                                        string journeyPattern = standardServiceElement.Attribute("id").Value;
                                        foreach (XElement vehicleJourney in vehicleJourneys.Elements())
                                        {
                                            bool journeyPatternMatched = vehicleJourney.Elements()
                                                .Where(
                                                    vehicleJourneyElement =>
                                                        vehicleJourneyElement.ToString()
                                                            .StartsWith("<JourneyPatternRef")).Any(
                                                    vehicleJourneyElement =>
                                                        vehicleJourneyElement.Value == journeyPattern);

                                            if (!journeyPatternMatched)
                                            {
                                                continue;
                                            }

                                            // vehicleJourneysTextBox.Text += vehicleJourney.ToString() + System.Environment.NewLine ;
                                            foreach (XElement vehicleJourneyElement in vehicleJourney.Elements())
                                            {
                                                if (!vehicleJourneyElement.ToString().StartsWith("<DepartureTime"))
                                                {
                                                    continue;
                                                }

                                                routeRoute.VehicleJourneys += vehicleJourneyElement.Value + " ";
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            if (routeSections != null)
                            {
                                foreach (XElement routeSection in routeSections.Elements())
                                {
                                    if (routeSection.Attribute("id").Value != routeRoute.RouteSectionRef)
                                    {
                                        continue;
                                    }

                                    foreach (XElement routeLink in routeSection.Elements())
                                    {
                                        var routeRouteSection = new RouteSection
                                                                    {
                                                                        FromRef = routeLink.Elements().ElementAt(0)
                                                                            .Elements().ElementAt(0).Value
                                                                    };
                                        routeRouteSection.FromDesc = stopPoints[routeRouteSection.FromRef].ToString();
                                        routeRouteSection.ToRef = routeLink.Elements().ElementAt(1).Elements()
                                            .ElementAt(0).Value;
                                        routeRouteSection.ToDesc = stopPoints[routeRouteSection.ToRef].ToString();
                                        routeRoute.RouteSection.Add(routeRouteSection);
                                        if (routeRoute.Stops.Count == 0)
                                        {
                                            routeRoute.Stops.Add(routeRouteSection.FromRef);
                                        }

                                        routeRoute.Stops.Add(routeRouteSection.ToRef);
                                    }

                                    break;
                                }
                            }

                            routeRoute.VehicleJourneys = routeRoute.VehicleJourneys.TrimEnd();
                            routeMaster.RouteVariants.Add(routeRoute);
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
                            if (thing.Name.ToString().Contains("OperatorNameOnLicence") || thing.Name.ToString().Contains("TradingName"))
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
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by GetOpenStreetMapDataToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private async void GetOpenStreetMapDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            string overPassQuery = Settings.Default.OverpassServer + Settings.Default.OverpassQueryPrefix
                                                                   + Settings.Default.OverpassTransportData.Replace(
                                                                       "{{bbox}}",
                                                                       Settings.Default.BoundingBox);

            if (!await GetDataAsync(overPassQuery))
            {
                this.Enabled = true;
                return;
            }

            Settings.Default.LastOpenStreetMapDownload = DateTime.Today;
            Settings.Default.Save();
            this.RefreshStatus();
            this.CompareResults();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by MainForm for load events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ComparisonResults = new List<ComparisonResultService>();
            this.RefreshStatus();
            this.ExtractTravelineRoutes();
            this.travelineDataGridView.DataSource = this.TravelineRoutes;
            this.ExtractOpenStreetMapRoutes();
            this.openStreetMapDataGridView.DataSource = this.OpenStreetMapRoutes;
            this.CompareResults();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Extracts the open street map routes.</summary>
        // ===========================================================================================================
        private void ExtractOpenStreetMapRoutes()
        {
            // Code below assumed the .json file has all nodes, before all ways, before all relations
            // so that the stopsHashtable will be populated before we populate routesHashtable, before
            // we populate this.OpenStreetMapRoutes. 
            // This was false as relations weren't all routes before route masters, so split to two loops
            var stopsDictionary = new Dictionary<long, string>();
            var routesStopsDictionary = new Dictionary<long, List<string>>();
            var routesReferenceDictionary = new Dictionary<long, string>();
            var routesOperatorDictionary = new Dictionary<long, string>();
            this.OpenStreetMapRoutes = new List<OpenStreetMapRouteMaster>();
            string fileName = Path.Combine(Application.LocalUserAppDataPath, "OsmData.json");
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
                        if (atcoCode.Length > 0)
                        {
                            stopsDictionary.Add(nodeId, atcoCode);
                        }
                    }
                    else if (element.tags != null && element.tags["public_transport"] == "platform")
                    {
                        stopsDictionary.Add(nodeId, string.Empty);
                    }
                }

                if (type != "relation")
                {
                    continue;
                }

                long id = element.id;
                string relationType = element.tags["type"];

                if (relationType == "route")
                {
                    var routeStops = new List<string>();
                    foreach (dynamic member in element.members)
                    {
                        if (member.role == "platform")
                        {
                            long routeId = member.@ref;
                            routeStops.Add(stopsDictionary[routeId]);
                        }
                    }

                    routesStopsDictionary.Add(id, routeStops);
                    if (element.tags != null && element.tags["ref"] != null)
                    {
                        string routeRef = element.tags["ref"];
                        routesReferenceDictionary.Add(id, routeRef);
                    }

                    if (element.tags != null && element.tags["operator"] != null)
                    {
                        string routeOperator = element.tags["operator"];
                        routesOperatorDictionary.Add(id, routeOperator);
                    }
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
                if (relationType == "route_master")
                {
                    var routeMaster =
                        new OpenStreetMapRouteMaster { Id = id, Reference = reference, Operator = routeOperator };
                    foreach (dynamic routeVariant in element.members)
                    {
                        long relationId = routeVariant.@ref;
                        reference = routesReferenceDictionary[relationId];
                        routeOperator = routesOperatorDictionary[relationId];
                        var openStreetMapRouteVariant = new OpenStreetMapRouteVariant
                                                            {
                                                                Reference = reference,
                                                                BusStops = routesStopsDictionary[relationId],
                                                                Operator = routeOperator,
                                                                Id = relationId
                                                            };
                        routeMaster.RouteVariants.Add(openStreetMapRouteVariant);
                    }

                    this.OpenStreetMapRoutes.Add(routeMaster);
                }
            }
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by RefreshBusStopsToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private async void RefreshBusStopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            string overPassQuery = Settings.Default.OverpassServer + Settings.Default.OverpassQueryPrefix
                                                                   + Settings.Default.OverpassBusStops.Replace(
                                                                       "{{bbox}}",
                                                                       Settings.Default.BoundingBox);
            this.OverpassBusStops = await GetBusStopsAsync(overPassQuery);
            this.busStopsLabel.Text = @"Bus stops read: " + this.OverpassBusStops.Count;
            Settings.Default.LastOpenStreetMapBusStopRefresh = DateTime.Today;
            Settings.Default.Save();
            this.RefreshStatus();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Refresh status.</summary>
        // ===========================================================================================================
        private void RefreshStatus()
        {
            var overpassBusStops = new List<BusStop>();
            string fileName = Path.Combine(Application.LocalUserAppDataPath, "OsmBusStops.json");
            if (File.Exists(fileName))
            {
                dynamic stops = JToken.Parse(File.ReadAllText(fileName));
                foreach (dynamic element in stops.elements)
                {
                    string type = element.type;
                    long id = element.id;
                    string atcoCode = element.tags["naptan:AtcoCode"];
                    var busStop = new BusStop(type, id, atcoCode);
                    overpassBusStops.Add(busStop);
                }
            }

            this.OverpassBusStops = overpassBusStops;
            this.busStopsLabel.Text = @"Bus stops read: " + this.OverpassBusStops.Count;
            if (Settings.Default.LastOpenStreetMapBusStopRefresh > DateTime.MinValue)
            {
                this.busStopsLastDownloadedLabel.Text = @"Last downloaded: "
                                                        + Settings.Default.LastOpenStreetMapBusStopRefresh
                                                            .ToLongDateString();
            }

            if (Directory.Exists(Settings.Default.LocalPath))
            {
                this.travelineZipsLabel.Text = @"TNDS zips: " + Directory.GetFiles(
                                                   Settings.Default.LocalPath,
                                                   "*.zip",
                                                   SearchOption.TopDirectoryOnly).Length;
                if (Settings.Default.LastTravelineDownload > DateTime.MinValue)
                {
                    this.travelineLastDownloadedLabel.Text = @"Last downloaded: "
                                                             + Settings.Default.LastTravelineDownload
                                                                 .ToLongDateString();
                }
            }

            string subFolder = Settings.Default.LastRouteExtract.ToString("yyyyMMdd");
            if (Directory.Exists(Path.Combine(Settings.Default.LocalPath, subFolder)))
            {
                this.localRoutesLabel.Text = @"Local routes extracted: " + Directory.GetFiles(
                                                 Path.Combine(Settings.Default.LocalPath, subFolder),
                                                 "*.xml",
                                                 SearchOption.TopDirectoryOnly).Length;
                if (Settings.Default.LastRouteExtract > DateTime.MinValue)
                {
                    this.localRoutesLastExtractedLabel.Text = @"Last extracted: "
                                                              + Settings.Default.LastRouteExtract.ToLongDateString();
                }
            }

            if (Settings.Default.LastOpenStreetMapDownload > DateTime.MinValue)
            {
                this.openstreetMapLastDownloadedLabel.Text = @"Last downloaded: "
                                                             + Settings.Default.LastOpenStreetMapDownload
                                                                 .ToLongDateString();
            }
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by SettingsToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
            this.RefreshStatus();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by CompareDataToolStripMenuItem for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void CompareDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.CompareResults();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Compare results.</summary>
        // ===========================================================================================================
        private void CompareResults()
        { 
            this.ComparisonResults = new List<ComparisonResultService>();
            this.ComparisonResultsRoutes = new List<ComparisonResultRoute>();
            var matchedRoutes = new HashSet<string>();
            var matchedRelations = new HashSet<long>();

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

                if (comparisonResult.TravelineFile.Length > 0)
                {
                    this.ComparisonResults.Add(comparisonResult);
                    this.CompareRouteVariants(openStreetMapRouteMaster, foundRoute);
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

                if (comparisonResult.TravelineFile.Length > 0)
                {
                    this.ComparisonResults.Add(comparisonResult);
                    this.CompareRouteVariants(openStreetMapRouteMaster, foundRoute);
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
            }

            this.compareRouteMasterDataGridView.DataSource = this.ComparisonResults;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Compare route variants.</summary>
        ///
        /// <param name="routeMaster">          The route variants.</param>
        /// <param name="travelineRouteMaster">The found route variants.</param>
        // ===========================================================================================================
        private void CompareRouteVariants(OpenStreetMapRouteMaster routeMaster, RouteMaster travelineRouteMaster)
        {
            var matchedRouteVariants = new HashSet<long>();
            var matchedRouteVariantsTraveline = new HashSet<string>();
            foreach (OpenStreetMapRouteVariant routeVariant in routeMaster.RouteVariants)
            {
                var comparisonResult = new ComparisonResultRoute
                                           {
                                               ServiceRouteRelationId = routeMaster.Id,
                                               RouteRelationId = routeVariant.Id,
                                               RelationOperator = routeVariant.Operator,
                                               RelationReference = routeVariant.Reference,
                                               RelationStops = routeVariant.BusStops
                                           };
                foreach (Route travelineRouteVariant in travelineRouteMaster.RouteVariants)
                {
                    if (matchedRouteVariantsTraveline.Contains(travelineRouteVariant.Id))
                    {
                        continue;
                    }

                    if (routeVariant.BusStops.SequenceEqual(travelineRouteVariant.Stops))
                    {
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
                                               RelationStops = routeVariant.BusStops
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

            this.comparedRoutesDataGridView.DataSource = this.ComparisonResultsRoutes;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by ComparedRoutesDataGridView for selection changed events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information.</param>
        // ===========================================================================================================
        private void ComparedRoutesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.openStreetMapStopsGroupBox.Text = @"OSM";
            this.travelineStopsGroupBox.Text = @"TNDS";
            this.openStreetMapStopsListBox.DataSource = null;
            this.travelineStopsListBox.DataSource = null;
            foreach (DataGridViewRow selectedRow in this.comparedRoutesDataGridView.SelectedRows)
            {
                if (((ComparisonResultRoute)selectedRow.DataBoundItem).RelationStops.Count > 0
                    && this.openStreetMapStopsListBox.DataSource == null)
                {
                    this.openStreetMapStopsListBox.DataSource =
                        ((ComparisonResultRoute)selectedRow.DataBoundItem).RelationStops;
                    this.openStreetMapStopsGroupBox.Text = @"OSM: " + ((ComparisonResultRoute)selectedRow.DataBoundItem).RelationStops.Count;
                }

                if (((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops.Count > 0
                    && this.travelineStopsListBox.DataSource == null)
                {
                    this.travelineStopsListBox.DataSource =
                        ((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops;
                    this.travelineStopsGroupBox.Text = @"TNDS: " + ((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops.Count;
                }

                if (this.travelineStopsListBox.DataSource != null && this.openStreetMapStopsListBox.DataSource != null)
                {
                    break;
                }
            }
        }
    }
}