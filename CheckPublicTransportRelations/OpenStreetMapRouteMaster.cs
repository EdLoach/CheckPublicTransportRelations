// ===========================================================================================================
// <copyright file="OpenStreetMapRouteMaster.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the OpenStreetMapRouteMaster class</summary>
// ===========================================================================================================

namespace CheckPublicTransportRelations
{
    using System.Collections.Generic;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>A routes.</summary>

    // ===========================================================================================================

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>An open street map route master.</summary>
    // ===========================================================================================================
    public class OpenStreetMapRouteMaster
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="OpenStreetMapRouteMaster"/> class.</summary>
        // ===========================================================================================================
        public OpenStreetMapRouteMaster()
        {
            this.Id = -1;
            this.Reference = string.Empty;
            this.Operator = string.Empty;
            this.RouteVariants = new List<OpenStreetMapRouteVariant>();
        }

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
        /// <summary>Gets or sets the route variants.</summary>
        ///
        /// <value>The route variants.</value>
        // ===========================================================================================================
        public List<OpenStreetMapRouteVariant> RouteVariants { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the number of route variants.</summary>
        ///
        /// <value>The number of route variants.</value>
        // ===========================================================================================================
        public int RouteVariantsCount => this.RouteVariants.Count;
    }
}