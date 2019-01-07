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
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
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
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="MainForm"/> class.</summary>
        // ===========================================================================================================
        public MainForm()
        {
            this.InitializeComponent();
        }

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
        /// <summary>Gets or sets the route bus stops.</summary>
        ///
        /// <value>The route bus stops.</value>
        // ===========================================================================================================
        private List<BusStop> RouteBusStops { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets from to checks.</summary>
        ///
        /// <value>from to checks.</value>
        // ===========================================================================================================
        private List<ComparisonResultFromTo> FromToChecks { get; set; }

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
        /// <summary>Gets or sets the traveline routes.</summary>
        ///
        /// <value>The traveline routes.</value>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        private List<RouteMaster> TravelineRoutes { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the comparison results routes.</summary>
        ///
        /// <value>The comparison results routes.</value>
        // ===========================================================================================================
        private List<ComparisonResultRoute> ComparisonResultsRoutes { get; set; }

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
                string stopName = element.tags["name"];
                var busStop = new BusStop(type, id, atcoCode, stopName);
                overpassBusStops.Add(busStop);
            }

            return overpassBusStops;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Event handler. Called by Copy for click events.</summary>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Key event information.</param>
        // ===========================================================================================================
        private static void Copy_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.C || !e.Control)
            {
                return;
            }

            // copy logic
            var dataGridView = (DataGridView)sender;
            if (dataGridView == null)
            {
                return;
            }

            dataGridView.Select();
            DataObject clipboardContent = dataGridView.GetClipboardContent();
            if (clipboardContent != null)
            {
                try
                {
                    Clipboard.SetDataObject(clipboardContent);
                }
                catch (Exception exception)
                {
                    // ignore the error
                    Debug.WriteLine(exception);
                }
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
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
        /// <summary>Event handler. Called by DownloadTravelineNationalDataSetToolStripMenuItem for click
        ///          events.</summary>
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
            var extractRoutesForm = new ExtractRoutesForm(this.OverpassBusStops);
            extractRoutesForm.ShowDialog(this);
            this.RefreshStatus();
            this.CompareResults();
            this.Enabled = true;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Extracts the traveline routes.</summary>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        private void ExtractTravelineRoutes()
        {
            this.TravelineRoutes = new List<RouteMaster>();

            string subFolder = Settings.Default.LastServiceExtract.ToString("yyyyMMdd");
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
                                                journeyStop.Activity = element.Value;
                                            }

                                            if (element.Name.ToString().Contains("StopPointRef"))
                                            {
                                                journeyStop.StopPointRef = element.Value;
                                            }
                                        }

                                        journeyPattern.JourneyStops.Add(journeyStop);
                                    }

                                    journeyStop = new JourneyStop();
                                    foreach (XElement element in toElement.Elements())
                                    {
                                        if (element.Name.ToString().Contains("Activity"))
                                        {
                                            journeyStop.Activity = element.Value;
                                        }

                                        if (element.Name.ToString().Contains("StopPointRef"))
                                        {
                                            journeyStop.StopPointRef = element.Value;
                                        }
                                    }

                                    journeyPattern.JourneyStops.Add(journeyStop);
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
                            if (thing.Name.ToString().Contains("OperatorNameOnLicence")
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
                                    if (section.Name.ToString().Contains("JourneyPatternSectionRefs"))
                                    {
                                        JourneyPatternSection journeyPattern = journeyPatterns.Where(item => item.Id == section.Value)
                                            ?.First();
                                        foreach (JourneyStop stop in journeyPattern.JourneyStops)
                                        {
                                            routeRoute.Stops.Add(stop.StopPointRef);
                                        }
                                    }
                                }

                                // don't add duplicates
                                var matchFound = false;
                                foreach (Route routeVariantCheck in routeMaster.RouteVariants)
                                {
                                    List<string> firstNotSecond = routeVariantCheck.Stops.Except(routeRoute.Stops).ToList();
                                    List<string> secondNotFirst = routeRoute.Stops.Except(routeVariantCheck.Stops).ToList();
                                    if (firstNotSecond.Any() || secondNotFirst.Any())
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
            string overPassQuery = Settings.Default.OverpassServer + Settings.Default.OverpassQueryPrefix
                                                                   + Settings.Default.OverpassTransportData.Replace(
                                                                       "{{bbox}}",
                                                                       Settings.Default.BoundingBox);

            if (!await GetDataAsync(overPassQuery))
            {
                this.Enabled = true;
                return;
            }

            Settings.Default.LastOpenStreetMapDownload = DateTime.Now;
            Settings.Default.Save();
            this.RefreshStatus();
            this.openStreetMapDataGridView.DataSource = null;
            this.ExtractOpenStreetMapRoutes();
            this.openStreetMapDataGridView.DataSource = this.OpenStreetMapRoutes;
            this.CompareResults();
            this.Enabled = true;
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
            this.RouteBusStops = new List<BusStop>();
            this.FromToChecks = new List<ComparisonResultFromTo>();
            this.travelineDataGridView.AutoGenerateColumns = false;
            this.openStreetMapDataGridView.AutoGenerateColumns = false;
            this.compareRouteMasterDataGridView.AutoGenerateColumns = false;
            this.comparedRoutesDataGridView.AutoGenerateColumns = false;
            this.fromToDataGridView.AutoGenerateColumns = false;
            this.ComparisonResults = new List<ComparisonResultService>();
            this.RefreshStatus();
            this.ExtractTravelineRoutes();
            this.travelineDataGridView.DataSource = this.TravelineRoutes;
            this.ExtractOpenStreetMapRoutes();
            this.openStreetMapDataGridView.DataSource = this.OpenStreetMapRoutes;
            this.CompareResults();
            this.openStreetMapStopsDataGridView.KeyDown += Copy_Click;
            this.travelineStopsDataGridView.KeyDown += Copy_Click;
            this.showMatchedServicesCheckBox.Checked = Settings.Default.ShowMatchedServices;
            this.showMatchedRoutesCheckBox.Checked = Settings.Default.ShowMatchedRoutes;
            this.fromToShowMatchedCheckBox.Checked = Settings.Default.ShowMatchedFromToNames;
            this.highlightStopsComboBox.SelectedIndex = 0;
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
            var stopsDictionary = new Dictionary<long, string>();
            var routesStopsDictionary = new Dictionary<long, List<string>>();
            var routesReferenceDictionary = new Dictionary<long, string>();
            var routesOperatorDictionary = new Dictionary<long, string>();
            var routesFromDictionary = new Dictionary<long, string>();
            var routesToDictionary = new Dictionary<long, string>();
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
                        string stopName = element.tags["name"];
                        if (atcoCode.Length > 0)
                        {
                            stopsDictionary.Add(nodeId, atcoCode);
                        }

                        routeBusStops.Add(new BusStop("node", nodeId, atcoCode, stopName));
                    }
                    else if (element.tags != null && element.tags["public_transport"] == "platform")
                    {
                        stopsDictionary.Add(nodeId, string.Empty);
                        string stopName = element.tags["name"];
                        routeBusStops.Add(new BusStop("node", nodeId, string.Empty, stopName));
                    }
                }

                if (type != "relation")
                {
                    continue;
                }

                long id = element.id;
                string relationType = element.tags["type"];

                if (relationType != "route")
                {
                    continue;
                }

                var routeStops = new List<string>();
                foreach (dynamic member in element.members)
                {
                    string memberRole = member.role ?? string.Empty;
                    if (memberRole.Contains("platform"))
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

                if (element.tags == null || element.tags["operator"] == null)
                {
                    continue;
                }

                string routeOperator = element.tags["operator"] ?? string.Empty; 
                routesOperatorDictionary.Add(id, routeOperator);
                string relationFrom = element.tags["from"] ?? string.Empty;
                routesFromDictionary.Add(id, relationFrom);
                string relationTo = element.tags["to"] ?? string.Empty;
                routesToDictionary.Add(id, relationTo);
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
                                                            Id = relationId,
                                                            RelationFrom = routesFromDictionary[relationId],
                                                            RelationTo = routesToDictionary[relationId]
                                                        };
                    routeMaster.RouteVariants.Add(openStreetMapRouteVariant);
                }

                this.OpenStreetMapRoutes.Add(routeMaster);
            }

            this.RouteBusStops = routeBusStops;
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
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
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
                    string stopName = element.tags["name"];
                    var busStop = new BusStop(type, id, atcoCode, stopName);
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

            string subFolder = Settings.Default.LastServiceExtract.ToString("yyyyMMdd");
            if (Directory.Exists(Path.Combine(Settings.Default.LocalPath, subFolder)))
            {
                this.localServicesLabel.Text = @"Local services extracted: " + Directory.GetFiles(
                                                 Path.Combine(Settings.Default.LocalPath, subFolder),
                                                 "*.xml",
                                                 SearchOption.TopDirectoryOnly).Length;
                if (Settings.Default.LastServiceExtract > DateTime.MinValue)
                {
                    this.localRoutesLastExtractedLabel.Text = @"Last extracted: "
                                                              + Settings.Default.LastServiceExtract.ToLongDateString();
                }
            }

            if (Settings.Default.LastOpenStreetMapDownload > DateTime.MinValue)
            {
                this.openstreetMapLastDownloadedLabel.Text = @"Last downloaded: "
                                                             + Settings.Default.LastOpenStreetMapDownload
                                                                 .ToLongDateString() + @" " + Settings.Default.LastOpenStreetMapDownload
                                                                 .ToShortTimeString();
            }
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
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
            this.RefreshStatus();
            this.Enabled = true;
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
            }

            this.compareRouteMasterDataGridView.DataSource = this.showMatchedServicesCheckBox.Checked ? this.ComparisonResults : this.ComparisonResults.Where(item => (item.OperatorsMatch && item.ReferencesMatch && item.RouteVariantsMatch) == false).ToList();
            this.comparedRoutesDataGridView.DataSource = this.showMatchedRoutesCheckBox.Checked ? this.ComparisonResultsRoutes : this.ComparisonResultsRoutes.Where(item => item.StopsEqual == false).ToList();
            this.fromToDataGridView.DataSource = this.fromToShowMatchedCheckBox.Checked ? this.FromToChecks : this.FromToChecks.Where(item => (item.FromNameFound && item.ToNameFound) == false).ToList();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Compare route variants.</summary>
        ///
        /// <param name="routeMaster">         The route master.</param>
        /// <param name="travelineRouteMaster">The traveline route master.</param>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
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
                        item => item.AtcoCode == routeVariant.BusStops[0])?.StopName;
                    fromToResult.StopTo = this.RouteBusStops.FirstOrDefault(
                        item => item.AtcoCode == routeVariant.BusStops[routeVariant.BusStops.Count - 1])?.StopName;
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
                                               RelationStops = routeVariant.BusStops
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
        /// <summary>Refresh stop lists.</summary>
        // ===========================================================================================================
        private void RefreshStopLists()
        { 
            var osmStops = new List<string>();
            var travelineStops = new List<string>();
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
                    this.openStreetMapStopsDataGridView.DataSource = osmStops.ConvertAll(x => new { Value = x });
                    this.openStreetMapStopsGroupBox.Text =
                        @"OSM: " + ((ComparisonResultRoute)selectedRow.DataBoundItem).RelationStops.Count;
                }

                if (((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops.Count > 0
                    && this.travelineStopsDataGridView.DataSource == null)
                {
                    travelineStops = ((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops;
                    this.travelineStopsDataGridView.DataSource = travelineStops.ConvertAll(x => new { Value = x });
                    this.travelineStopsGroupBox.Text =
                        @"TNDS: " + ((ComparisonResultRoute)selectedRow.DataBoundItem).ServiceStops.Count;
                }

                if (this.travelineStopsDataGridView.DataSource != null && this.openStreetMapStopsDataGridView.DataSource != null)
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
                        if (!travelineStops.Contains(
                                this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Value.ToString()))
                        {
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                        }

                        if (!osmStops.Contains(this.travelineStopsDataGridView.Rows[i].Cells[0].Value.ToString()))
                        {
                            this.travelineStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                        }
                    }
                    else if (i < this.openStreetMapStopsDataGridView.RowCount)
                    {
                        if (!travelineStops.Contains(
                                this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Value.ToString()))
                        {
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                        }
                    }
                    else if (i < this.travelineStopsDataGridView.RowCount)
                    {
                        if (!osmStops.Contains(this.travelineStopsDataGridView.Rows[i].Cells[0].Value.ToString()))
                        {
                            this.travelineStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
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
                        if (this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Value.ToString() != this.travelineStopsDataGridView.Rows[i].Cells[0].Value.ToString())
                        {
                            this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                            this.travelineStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                        }
                    }
                    else if (i < this.openStreetMapStopsDataGridView.RowCount)
                    {
                        this.openStreetMapStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                    }
                    else if (i < this.travelineStopsDataGridView.RowCount)
                    {
                        this.travelineStopsDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                    }
                }
            }
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
            this.comparedRoutesDataGridView.DataSource = this.showMatchedRoutesCheckBox.Checked ? this.ComparisonResultsRoutes : this.ComparisonResultsRoutes.Where(item => item.StopsEqual == false).ToList();

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
            this.compareRouteMasterDataGridView.DataSource = this.showMatchedServicesCheckBox.Checked ? this.ComparisonResults : this.ComparisonResults.Where(item => (item.OperatorsMatch && item.ReferencesMatch && item.RouteVariantsMatch) == false).ToList();

            Settings.Default.ShowMatchedServices = this.showMatchedServicesCheckBox.Checked;
            Settings.Default.Save();
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
            List<BusStop> busStops = this.RouteBusStops;
            if (this.openStreetMapStopsDataGridView.SelectedCells.Count > 0)
            {
                if (busStops != null)
                {
                    openStreetMapStopName = busStops.FirstOrDefault(
                            item => item.AtcoCode == this.openStreetMapStopsDataGridView.SelectedCells[0].Value.ToString())
                        ?.StopName;
                }
            }

            if (this.travelineStopsDataGridView.SelectedCells.Count > 0)
            {
                if (busStops != null)
                {
                    travelineStopName = busStops.FirstOrDefault(
                            item => item.AtcoCode == this.travelineStopsDataGridView.SelectedCells[0].Value.ToString())
                        ?.StopName;
                }
            }

            this.stopNameLabel.Text = openStreetMapStopName + @" / " + travelineStopName;
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
            this.fromToDataGridView.DataSource = this.fromToShowMatchedCheckBox.Checked ? this.FromToChecks : this.FromToChecks.Where(item => (item.FromNameFound && item.ToNameFound) == false).ToList();

            Settings.Default.ShowMatchedFromToNames = this.fromToShowMatchedCheckBox.Checked;
            Settings.Default.Save();
        }
    }
}