// ===========================================================================================================
// <copyright file="RouteMaster.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the RouteMaster class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System.Collections.Generic;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>A routes.</summary>
    // ===========================================================================================================
    public class RouteMaster
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="RouteMaster"/> class.</summary>
        // ===========================================================================================================
        public RouteMaster()
        {
            this.FileName = string.Empty;
            this.Reference = string.Empty;
            this.Operator = string.Empty;
            this.RouteVariants = new List<Route>();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the filename of the file.</summary>
        ///
        /// <value>The name of the file.</value>
        // ===========================================================================================================
        public string FileName { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the operator.</summary>
        ///
        /// <value>The operator.</value>
        // ===========================================================================================================
        public string Operator { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the reference.</summary>
        ///
        /// <value>The reference.</value>
        // ===========================================================================================================
        public string Reference { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the route variants.</summary>
        ///
        /// <value>The route variants.</value>
        // ===========================================================================================================
        public List<Route> RouteVariants { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the number of route variants.</summary>
        ///
        /// <value>The number of route variants.</value>
        // ===========================================================================================================
        public int RouteVariantsCount => this.RouteVariants.Count;
    }
}