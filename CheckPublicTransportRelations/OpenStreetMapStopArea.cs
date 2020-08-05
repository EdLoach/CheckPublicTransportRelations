// ===========================================================================================================
// <copyright file="OpenStreetMapStopArea.cs" company="N/A">
// Copyright (c) 2020 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>2 August 2020</date>
// <summary>Implements the open street map stop area class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
    ///
    /// <summary>An open street map stop area.</summary>
    // ===========================================================================================================
    public class OpenStreetMapStopArea
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="OpenStreetMapStopArea"/> class.</summary>
        ///
        /// <param name="element">        The element.</param>
        /// <param name="stopAreaMembers">The stop area members (id, atcocode, name).</param>
        // ===========================================================================================================
        public OpenStreetMapStopArea(dynamic element, List<Tuple<long, string, string>> stopAreaMembers)
        {
            this.Id = element.id;
            this.StopAreaName = element.tags["name"];
            this.StopAreaCode = element.tags["naptan:StopAreaCode"];
            this.StopAreaType = element.tags["naptan:StopAreaType"];
            this.Stops = stopAreaMembers;
            this.NameDifferences = false;
            this.NameList = string.Empty;

            foreach (Tuple<long, string, string> stop in stopAreaMembers)
            {
                if (!this.NameList.Contains(stop.Item3))
                {
                    if (this.NameList.Length > 0)
                    {
                        this.NameList += "; ";
                    }

                    this.NameList += stop.Item3;
                }

                if (stop.Item3 != this.StopAreaName)
                {
                    this.NameDifferences = true;
                }
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the type of the stop area.</summary>
        ///
        /// <value>The type of the stop area.</value>
        // ===========================================================================================================
        public string StopAreaType { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets a list of names.</summary>
        ///
        /// <value>A List of names.</value>
        // ===========================================================================================================
        public string NameList { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets a value indicating whether the name differences.</summary>
        ///
        /// <value>True if name differences, false if not.</value>
        // ===========================================================================================================
        public bool NameDifferences { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the identifier.</summary>
        ///
        /// <value>The identifier.</value>
        // ===========================================================================================================
        public long Id { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the stop area code.</summary>
        ///
        /// <value>The stop area code.</value>
        // ===========================================================================================================
        public string StopAreaCode { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the name of the stop area.</summary>
        ///
        /// <value>The name of the stop area.</value>
        // ===========================================================================================================
        public string StopAreaName { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the stops.</summary>
        ///
        /// <value>The stops (OSM Id, AtcoCode, Name).</value>
        // ===========================================================================================================
        public List<Tuple<long, string, string>> Stops { get; set; }
    }
}