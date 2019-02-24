// ===========================================================================================================
// <copyright file="Enums.cs" company="N/A">
// Copyright (c) 2019 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>10 February 2019</date>
// <summary>Implements the enums class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
    ///
    /// <summary>Enumerations used in solution.</summary>
    // ===========================================================================================================
    public static class Enums
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Values that represent location types.</summary>
        // ===========================================================================================================
        public enum LocationType
        {
            /// <summary>An enumeration constant representing the custom option.</summary>
            [Description("Custom")]
            Custom,

            /// <summary>An enumeration constant representing the bounding box option.</summary>
            [Description("Bounding Box")]
            BoundingBox,

            /// <summary>An enumeration constant representing the area option.</summary>
            [Description("Area")]
            Area
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 February 2019 (1.5.0.0)</createdBy>
        ///
        /// <summary>Gets a description.</summary>
        ///
        /// <param name="value">An enumeration constant representing the value option.</param>
        ///
        /// <returns>The description.</returns>
        // ===========================================================================================================
        public static string GetDescription(Enum value)
        {
            return value.GetType().GetMember(value.ToString()).FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>()?.Description;
        }
    }
}