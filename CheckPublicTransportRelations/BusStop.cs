// ===========================================================================================================
// <copyright file="BusStop.cs" company="EdLoach">
// Copyright (c) 2018 EdLoach. All rights reserved.
// </copyright>
// <author>Ed</author>
// <date>27 December 2018</date>
// <summary>Implements the bus stop class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>The bus stop.</summary>
    // ===========================================================================================================
    public class BusStop
    {
        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="BusStop"/> class.</summary>
        ///
        /// <param name="elementType">    Type of the element.</param>
        /// <param name="elementId">      Identifier for the element.</param>
        /// <param name="elementAtcoCode">The element atco code.</param>
        // ===========================================================================================================
        public BusStop(string elementType, long elementId, string elementAtcoCode)
        {
            this.Type = elementType;
            this.Id = elementId;
            this.AtcoCode = elementAtcoCode;
        }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the atco code.</summary>
        ///
        /// <value>The atco code.</value>
        // ===========================================================================================================
        public string AtcoCode { get; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the identifier.</summary>
        ///
        /// <value>The identifier.</value>
        // ===========================================================================================================
        public long Id { get; }

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the type.</summary>
        ///
        /// <value>The type.</value>
        // ===========================================================================================================
        public string Type { get; }
    }
}