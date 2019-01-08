// ===========================================================================================================
// <copyright file="ComparisonResultRoute.cs" company="EdLoach">
// Copyright (c) 2019 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>1 January 2019</date>
// <summary>Implements the comparison result route class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System.Collections.Generic;
    using System.Linq;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
    ///
    /// <summary>A comparison result route.</summary>
    // ===========================================================================================================
    public class ComparisonResultRoute
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="ComparisonResultRoute"/> class.</summary>
        // ===========================================================================================================
        public ComparisonResultRoute()
        {
            this.RelationOperator = string.Empty;
            this.RelationReference = string.Empty;
            this.ServiceRouteRelationId = -1;
            this.RouteRelationId = -1;
            this.RelationStops = new List<JourneyStop>();
            this.ServiceFile = string.Empty;
            this.ServiceReference = string.Empty;
            this.ServiceOperator = string.Empty;
            this.ServiceStops = new List<JourneyStop>();
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the operators equal.</summary>
        ///
        /// <value>True if operators equal, false if not.</value>
        // ===========================================================================================================
        public bool OperatorsEqual => this.RelationOperator == this.ServiceOperator;

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the references equal.</summary>
        ///
        /// <value>True if references equal, false if not.</value>
        // ===========================================================================================================
        public bool ReferencesEqual => this.RelationReference == this.ServiceReference;

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the relation operator.</summary>
        ///
        /// <value>The relation operator.</value>
        // ===========================================================================================================
        public string RelationOperator { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the relation reference.</summary>
        ///
        /// <value>The relation reference.</value>
        // ===========================================================================================================
        public string RelationReference { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the relation stops.</summary>
        ///
        /// <value>The relation stops.</value>
        // ===========================================================================================================
        public List<JourneyStop> RelationStops { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the identifier of the route relation.</summary>
        ///
        /// <value>The identifier of the route relation.</value>
        // ===========================================================================================================
        public long RouteRelationId { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the service file.</summary>
        ///
        /// <value>The service file.</value>
        // ===========================================================================================================
        public string ServiceFile { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the service operator.</summary>
        ///
        /// <value>The service operator.</value>
        // ===========================================================================================================
        public string ServiceOperator { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the service reference.</summary>
        ///
        /// <value>The service reference.</value>
        // ===========================================================================================================
        public string ServiceReference { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the identifier of the service route relation.</summary>
        ///
        /// <value>The identifier of the service route relation.</value>
        // ===========================================================================================================
        public long ServiceRouteRelationId { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the service stops.</summary>
        ///
        /// <value>The service stops.</value>
        // ===========================================================================================================
        public List<JourneyStop> ServiceStops { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the stops equal.</summary>
        ///
        /// <value>True if stops equal, false if not.</value>
        // ===========================================================================================================
        public bool StopsEqual => this.RelationStops.SequenceEqual(this.ServiceStops);
    }
}