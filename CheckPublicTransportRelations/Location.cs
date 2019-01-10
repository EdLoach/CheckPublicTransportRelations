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
            this.Description = @"New Location";
            this.BoundingBox = @"51.767,0.93,51.96,1.294";
            this.BusStopQuery = @"[out:json][timeout:25];(node[""naptan: AtcoCode""][!""railway""]({{bbox}}););out;>;out skel qt;";
            this.TransportQuery = @"[out:json][timeout:25];((relation[""route""=""bus""]({{bbox}}););<<;)->.b;relation.b[""route""!=""bus""];(._;>>;);out;";
        }

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