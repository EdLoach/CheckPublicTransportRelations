// ===========================================================================================================
// <copyright file="ComparisonResultService.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the comparison result class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>Encapsulates the result of a comparison.</summary>
    // ===========================================================================================================
    public class ComparisonResultService
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="ComparisonResultService"/> class.</summary>
        // ===========================================================================================================
        public ComparisonResultService()
        {
            this.RouteMasterRelationId = -1;
            this.RouteMasterReference = string.Empty;
            this.RouteMasterOperator = string.Empty;
            this.RouteMasterRouteVariants = 0;
            this.TravelineFile = string.Empty;
            this.TravelineReference = string.Empty;
            this.TravelineOperator = string.Empty;
            this.TravelineRouteVariants = 0;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the operators match.</summary>
        ///
        /// <value>True if operators match, false if not.</value>
        // ===========================================================================================================
        public bool OperatorsMatch
        {
            get
            {
                string routeMasterOperator = this.RouteMasterOperator;
                return routeMasterOperator != null && routeMasterOperator.Equals(
                           this.TravelineOperator,
                           StringComparison.OrdinalIgnoreCase);
            }
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the references match.</summary>
        ///
        /// <value>True if references match, false if not.</value>
        // ===========================================================================================================
        public bool ReferencesMatch => this.RouteMasterReference == this.TravelineReference;

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the route master operator.</summary>
        ///
        /// <value>The route master operator.</value>
        // ===========================================================================================================
        public string RouteMasterOperator { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the route master reference.</summary>
        ///
        /// <value>The route master reference.</value>
        // ===========================================================================================================
        public string RouteMasterReference { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the identifier of the route master relation.</summary>
        ///
        /// <value>The identifier of the route master relation.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public long RouteMasterRelationId { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the route master route variants.</summary>
        ///
        /// <value>The route master route variants.</value>
        // ===========================================================================================================
        public int RouteMasterRouteVariants { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the route variants match.</summary>
        ///
        /// <value>True if route variants match, false if not.</value>
        // ===========================================================================================================
        public bool RouteVariantsMatch => this.RouteMasterRouteVariants == this.TravelineRouteVariants;

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the traveline file.</summary>
        ///
        /// <value>The traveline file.</value>
        // ===========================================================================================================
        public string TravelineFile { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the traveline operator.</summary>
        ///
        /// <value>The traveline operator.</value>
        // ===========================================================================================================
        public string TravelineOperator { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the traveline reference.</summary>
        ///
        /// <value>The traveline reference.</value>
        // ===========================================================================================================
        public string TravelineReference { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the traveline route variants.</summary>
        ///
        /// <value>The traveline route variants.</value>
        // ===========================================================================================================
        public int TravelineRouteVariants { get; set; }
    }
}