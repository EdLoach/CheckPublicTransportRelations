// ===========================================================================================================
// <copyright file="JourneyPatternSection.cs" company="N/A">
// Copyright (c) 2020 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>1 August 2020</date>
// <summary>Implements the journey pattern section class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System.Collections.Generic;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
    ///
    /// <summary>A journey pattern section.</summary>
    // ===========================================================================================================
    public class JourneyPatternSection
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="JourneyPatternSection"/> class.</summary>
        // ===========================================================================================================
        public JourneyPatternSection()
        {
            this.Id = string.Empty;
            this.JourneyStops = new List<JourneyStop>();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the identifier.</summary>
        ///
        /// <value>The identifier.</value>
        // ===========================================================================================================
        public string Id { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Gets the journey stops.</summary>
        ///
        /// <value>The journey stops.</value>
        // ===========================================================================================================
        public List<JourneyStop> JourneyStops { get; }
    }
}