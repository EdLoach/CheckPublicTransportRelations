// ===========================================================================================================
// <copyright file="RouteSection.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the route section class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>A route section.</summary>
    // ===========================================================================================================
    public class RouteSection
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets from reference.</summary>
        ///
        /// <value>from reference.</value>
        // ===========================================================================================================
        public string FromRef { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets information describing from.</summary>
        ///
        /// <value>Information describing from.</value>
        // ===========================================================================================================
        public string FromDesc { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets to reference.</summary>
        ///
        /// <value>to reference.</value>
        // ===========================================================================================================
        public string ToRef { get; set; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets information describing to.</summary>
        ///
        /// <value>Information describing to.</value>
        // ===========================================================================================================
        public string ToDesc { get; set; }
    }
}