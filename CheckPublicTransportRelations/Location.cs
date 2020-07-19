// ===========================================================================================================
// <copyright file="Location.cs" company="N/A">
// Copyright (c) 2019 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>10 January 2019</date>
// <summary>Implements the location class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
    ///
    /// <summary>A location.</summary>
    // ===========================================================================================================
    public class Location
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="Location"/> class.</summary>
        // ===========================================================================================================
        public Location()
        {
            this.Type = Enums.LocationType.BoundingBox;
            this.Description = @"New Location";
            this.BoundingBox = @"51.767,0.93,51.96,1.294";
            this.AreaQuery = string.Empty;
            this.BusStopTimeOut = 25;
            this.TransportTimeOut = 45;
            this.OrphanRoutesTimeOut = 45;
            this.BusStopQuery = @"[out:json][timeout:{{timeout}}];(node[""naptan: AtcoCode""][!""railway""]({{bbox}}););out;>;out skel qt;";
            this.TransportQuery = @"[out:json][timeout:{{timeout}}];((node[""naptan:AtcoCode""][!""railway""]({{bbox}}););<<;)->.b;relation.b[""route""!=""bus""][""type""!=""network""];(._;>>;);out;";
            this.OrphansQuery =
                @"[out:json][timeout:35];((relation({{bbox}})[""route""=""bus""];);<<;)->.b;relation.b[""route""=""bus""];(._;>>;);out;";
            this.LastOpenStreetMapBusStopRefresh = DateTime.MinValue;
            this.LastServiceExtract = DateTime.MinValue;
            this.LastOpenStreetMapDownload = DateTime.MinValue;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the area query.</summary>
        ///
        /// <value>The area query.</value>
        // ===========================================================================================================
        public string AreaQuery { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the orphans query.</summary>
        ///
        /// <value>The orphans query.</value>
        // ===========================================================================================================
        public string OrphansQuery { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the transport time out.</summary>
        ///
        /// <value>The transport time out.</value>
        // ===========================================================================================================
        public int TransportTimeOut { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the bus stop time out.</summary>
        ///
        /// <value>The bus stop time out.</value>
        // ===========================================================================================================
        public int BusStopTimeOut { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the orphan routes time out.</summary>
        ///
        /// <value>The orphan routes time out.</value>
        // ===========================================================================================================
        public int OrphanRoutesTimeOut { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the type.</summary>
        ///
        /// <value>The type.</value>
        // ===========================================================================================================
        public Enums.LocationType Type { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the Date/Time of the last open street map bus stop refresh.</summary>
        ///
        /// <value>The last open street map bus stop refresh.</value>
        // ===========================================================================================================
        public DateTime LastOpenStreetMapBusStopRefresh { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the Date/Time of the last service extract.</summary>
        ///
        /// <value>The last service extract.</value>
        // ===========================================================================================================
        public DateTime LastServiceExtract { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the Date/Time of the last open street map download.</summary>
        ///
        /// <value>The last open street map download.</value>
        // ===========================================================================================================
        public DateTime LastOpenStreetMapDownload { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the description.</summary>
        ///
        /// <value>The description.</value>
        // ===========================================================================================================
        public string Description { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the bounding box.</summary>
        ///
        /// <value>The bounding box.</value>
        // ===========================================================================================================
        public string BoundingBox { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the bus stop query.</summary>
        ///
        /// <value>The bus stop query.</value>
        // ===========================================================================================================
        public string BusStopQuery { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the transport query.</summary>
        ///
        /// <value>The transport query.</value>
        // ===========================================================================================================
        public string TransportQuery { get; set; }
    }
}