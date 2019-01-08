// ===========================================================================================================
// <copyright file="Route.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the route class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System.Collections.Generic;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>A route.</summary>
    // ===========================================================================================================
    public class Route
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the identifier.</summary>
        ///
        /// <value>The identifier.</value>
        // ===========================================================================================================
        public string Id { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the description.</summary>
        ///
        /// <value>The description.</value>
        // ===========================================================================================================
        public string Description { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the route section reference.</summary>
        ///
        /// <value>The route section reference.</value>
        // ===========================================================================================================
        public string RouteSectionRef { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the vehicle journeys.</summary>
        ///
        /// <value>The vehicle journeys.</value>
        // ===========================================================================================================
        public string VehicleJourneys { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the route section.</summary>
        ///
        /// <value>The route section.</value>
        // ===========================================================================================================
        public List<RouteSection> RouteSection { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the stops.</summary>
        ///
        /// <value>The stops.</value>
        // ===========================================================================================================
        public List<JourneyStop> Stops { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="Route"/> class.</summary>
        // ===========================================================================================================
        public Route()
        {
            this.Id = string.Empty;
            this.Description = string.Empty;
            this.RouteSectionRef = string.Empty;
            this.RouteSection = new List<RouteSection>();
            this.Stops = new List<JourneyStop>();
        }
    }
}