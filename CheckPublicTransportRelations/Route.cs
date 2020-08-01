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

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the description.</summary>
        ///
        /// <value>The description.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Description { get; }

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
        /// <summary>Gets the route section.</summary>
        ///
        /// <value>The route section.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public List<RouteSection> RouteSection { get; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the route section reference.</summary>
        ///
        /// <value>The route section reference.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string RouteSectionRef { get; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 1 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the stops.</summary>
        ///
        /// <value>The stops.</value>
        // ===========================================================================================================
        public List<JourneyStop> Stops { get; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the vehicle journeys.</summary>
        ///
        /// <value>The vehicle journeys.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string VehicleJourneys { get; set; }
    }
}