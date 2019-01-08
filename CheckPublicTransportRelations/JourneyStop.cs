// ===========================================================================================================
// <copyright file="JourneyStop.cs" company="N/A">
// Copyright (c) 2019 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>8 January 2019</date>
// <summary>Implements the journey stop class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 8 January 2019 (1.0.0.0)</createdBy>
    ///
    /// <summary>A journey stop.</summary>
    ///
    /// ### <inheritdoc/>
    // ===========================================================================================================
    public class JourneyStop : IEquatable<JourneyStop>
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 8 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="JourneyStop"/> class.</summary>
        // ===========================================================================================================
        public JourneyStop()
        {
            this.Activity = string.Empty;
            this.StopPointRef = string.Empty;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 8 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the activity.</summary>
        ///
        /// <value>The activity.</value>
        // ===========================================================================================================
        public string Activity { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 8 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the stop point reference.</summary>
        ///
        /// <value>The stop point reference.</value>
        // ===========================================================================================================
        public string StopPointRef { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 8 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        ///
        /// <param name="other">An object to compare with this object.</param>
        ///
        /// <returns><see langword="true" /> if the current object is equal to the
        ///                    <paramref name="other" /> parameter; otherwise,
        ///                    <see langword="false" />.</returns>
        ///
        /// <inheritdoc/>
        // ===========================================================================================================
        public bool Equals(JourneyStop other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Activity.Equals(other.Activity) && this.StopPointRef.Equals(other.StopPointRef);
        }
    }
}