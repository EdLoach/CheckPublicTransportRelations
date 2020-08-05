// ===========================================================================================================
// <copyright file="StopAreasStop.cs" company="N/A">
// Copyright (c) 2020 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>2 August 2020</date>
// <summary>Implements the stop areas stop class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
    ///
    /// <summary>A stop areas stop.</summary>
    // ===========================================================================================================
    public class StopAreasStop
    {
        private string stopAreaCode;

        private string naptanStopAreaCode;

        private string naptanStopAreaType;

        private string stopAreaType;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="StopAreasStop"/> class.</summary>
        ///
        /// <param name="stop">The stop.</param>
        // ===========================================================================================================
        public StopAreasStop(BusStop stop)
        {
            this.AtcoCode = stop.AtcoCode;
            this.Id = stop.Id;
            this.StopName = stop.StopName;
            this.NotName = stop.NotName;
            this.StopAreaCode = string.Empty;
            this.StopAreaName = string.Empty;
            this.StopAreaType = string.Empty;
            this.NaptanStopAreaName = string.Empty;
            this.NaptanStopAreaCode = string.Empty;
            this.NaptanStopAreaType = string.Empty;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="StopAreasStop"/> class.</summary>
        ///
        /// <param name="stop">                 The stop.</param>
        /// <param name="openStreetMapStopArea">The open street map stop area.</param>
        // ===========================================================================================================
        public StopAreasStop(BusStop stop, OpenStreetMapStopArea openStreetMapStopArea)
        {
            this.AtcoCode = stop.AtcoCode;
            this.Id = stop.Id;
            this.StopName = stop.StopName;
            this.NotName = stop.NotName;
            this.StopAreaCode = openStreetMapStopArea.StopAreaCode;
            this.StopAreaName = openStreetMapStopArea.StopAreaName;
            this.StopAreaType = openStreetMapStopArea.StopAreaType;
            this.NaptanStopAreaName = string.Empty;
            this.NaptanStopAreaCode = string.Empty;
            this.NaptanStopAreaType = string.Empty;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the atco code.</summary>
        ///
        /// <value>The atco code.</value>
        // ===========================================================================================================
        public string AtcoCode { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets the identifier.</summary>
        ///
        /// <value>The identifier.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public long Id { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets the name of the not.</summary>
        ///
        /// <value>The name of the not.</value>
        // ===========================================================================================================
        public string NotName { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the naptan stop area code.</summary>
        ///
        /// <value>The naptan stop area code.</value>
        // ===========================================================================================================
        public string NaptanStopAreaCode
        {
            get => this.naptanStopAreaCode ?? string.Empty;
            set => this.naptanStopAreaCode = value;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the name of the naptan stop area.</summary>
        ///
        /// <value>The name of the naptan stop area.</value>
        // ===========================================================================================================
        public string NaptanStopAreaName { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the type of the naptan stop area.</summary>
        ///
        /// <value>The type of the naptan stop area.</value>
        // ===========================================================================================================
        public string NaptanStopAreaType
        {
            get => this.naptanStopAreaType ?? string.Empty;
            set => this.naptanStopAreaType = value;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the stop area code.</summary>
        ///
        /// <value>The stop area code.</value>
        // ===========================================================================================================
        public string StopAreaCode
        {
            get => this.stopAreaCode ?? string.Empty;
            set => this.stopAreaCode = value;
        }

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
        /// <summary>Gets or sets the type of the stop area.</summary>
        ///
        /// <value>The type of the stop area.</value>
        // ===========================================================================================================
        public string StopAreaType
        {
            get => this.stopAreaType ?? string.Empty;
            set => this.stopAreaType = value;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the name of the stop.</summary>
        ///
        /// <value>The name of the stop.</value>
        // ===========================================================================================================
        public string StopName { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the street map names match should be opened.</summary>
        ///
        /// <value>True if open street map names match, false if not.</value>
        // ===========================================================================================================
        public bool OpenStreetMapNamesMatch => this.StopName == this.StopAreaName || this.StopAreaName.Contains(this.StopName) || (this.StopAreaName.Length < 1 && this.StopAreaCode.Length < 1 && this.NaptanStopAreaCode.Length < 1);

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the area names match.</summary>
        ///
        /// <value>True if area names match, false if not.</value>
        // ===========================================================================================================
        public bool AreaNamesMatch => this.NaptanStopAreaNameCleaned.Contains(this.StopName) || (this.StopName.Replace("(", string.Empty)
            .Replace(")", string.Empty)
            .Replace(" / ", " ")
            .Contains(this.NaptanStopAreaNameCleaned) && this.NaptanStopAreaName.Length > 0) || this.NotName == this.NaptanStopAreaName || (this.StopAreaCode == this.NaptanStopAreaCode && this.NaptanStopAreaCode.Length < 1);

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets the naptan stop area name cleaned.</summary>
        ///
        /// <value>The naptan stop area name cleaned.</value>
        // ===========================================================================================================
        public string NaptanStopAreaNameCleaned
        {
            get
            {
                string returnValue = this.NaptanStopAreaName.TrimStart();
                foreach (Tuple<string, string> mapping in NameMappings.Mappings)
                {
                    returnValue = returnValue.Replace(mapping.Item1, mapping.Item2);
                }

                return returnValue;
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the area codes match.</summary>
        ///
        /// <value>True if area codes match, false if not.</value>
        // ===========================================================================================================
        public bool AreaCodesMatch => this.StopAreaCode == this.NaptanStopAreaCode || (this.StopAreaCode.Length < 1 && this.NaptanStopAreaCode.Length < 1);

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the area codes differ.</summary>
        ///
        /// <value>True if area codes differ, false if not.</value>
        // ===========================================================================================================
        public bool AreaCodesDiffer => this.StopAreaCode != this.NaptanStopAreaCode;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the area types match.</summary>
        ///
        /// <value>True if area types match, false if not.</value>
        // ===========================================================================================================
        public bool AreaTypesMatch => this.StopAreaType == this.NaptanStopAreaType;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the match.</summary>
        ///
        /// <value>True if match, false if not.</value>
        // ===========================================================================================================
        public bool Match =>
            this.OpenStreetMapNamesMatch && this.AreaNamesMatch && this.AreaCodesMatch && this.AreaTypesMatch;
    }
}