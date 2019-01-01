// ===========================================================================================================
// <copyright file="OpenStreetMapRouteVariant.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the open street map route variant class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System.Collections.Generic;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>An open street map route variant.</summary>
    // ===========================================================================================================
    public class OpenStreetMapRouteVariant
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="OpenStreetMapRouteVariant"/> class.</summary>
        // ===========================================================================================================
        public OpenStreetMapRouteVariant()
        {
            this.Id = -1;
            this.Reference = string.Empty;
            this.Operator = string.Empty;
            this.BusStops = new List<string>();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the bus stops.</summary>
        ///
        /// <value>The bus stops.</value>
        // ===========================================================================================================
        public List<string> BusStops { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the identifier.</summary>
        ///
        /// <value>The identifier.</value>
        // ===========================================================================================================
        public long Id { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the operator.</summary>
        ///
        /// <value>The operator.</value>
        // ===========================================================================================================
        public string Operator { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the reference.</summary>
        ///
        /// <value>The reference.</value>
        // ===========================================================================================================
        public string Reference { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the number of stops.</summary>
        ///
        /// <value>The number of stops.</value>
        // ===========================================================================================================
        public int StopsCount => this.BusStops.Count;
    }
}