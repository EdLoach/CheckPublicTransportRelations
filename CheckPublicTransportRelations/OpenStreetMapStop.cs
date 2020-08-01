// ===========================================================================================================
// <copyright file="OpenStreetMapStop.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>31 December 2018</date>
// <summary>Implements the open street map stop class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>An open street map stop.</summary>
    // ===========================================================================================================
    // ReSharper disable once UnusedMember.Global
    public class OpenStreetMapStop
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="OpenStreetMapStop"/> class.</summary>
        // ===========================================================================================================
        public OpenStreetMapStop()
        {
            this.Id = -1;
            this.AtcoCode = string.Empty;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the atco code.</summary>
        ///
        /// <value>The atco code.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string AtcoCode { get; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 31 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the identifier.</summary>
        ///
        /// <value>The identifier.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public long Id { get; }
    }
}