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
    using System;
    using System.Diagnostics.CodeAnalysis;

    // ===========================================================================================================
    /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
    ///
    /// <summary>The bus stop.</summary>
    // ===========================================================================================================
    public class BusStop
    {
        // ===========================================================================================================

        // ===========================================================================================================
        /// <createdBy>Ed (EdLoach) - 27 December 2018 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="BusStop"/> class.</summary>
        ///
        /// <param name="elementType">    Type of the element.</param>
        /// <param name="elementId">      Identifier for the element.</param>
        /// <param name="elementAtcoCode">The element atco code.</param>
        /// <param name="stopName">       The stop name.</param>
        /// <param name="naptanCode">     The naptan code.</param>
        /// <param name="stopStatus">     The stop status.</param>
        /// <param name="busStopType">    The type of the bus stop.</param>
        /// <param name="street">         The street.</param>
        /// <param name="notName">        The name of the not.</param>
        /// <param name="surveyed">       The physically present.</param>
        /// <param name="highway">        The highway.</param>
        /// <param name="naptanVerified"> The naptan verified.</param>
        // ===========================================================================================================
        public BusStop(string elementType, long elementId, string elementAtcoCode, string stopName, string naptanCode, string naptanIndicator, string stopStatus, string busStopType, string street, string notName, string surveyed, string highway, string naptanVerified)
        {
            this.Type = elementType;
            this.Id = elementId;
            this.AtcoCode = elementAtcoCode;
            this.StopName = stopName ?? string.Empty;
            this.NaptanCode = naptanCode;
            this.BusStopType = busStopType;
            this.Status = stopStatus;
            this.NaptanName = string.Empty;
            this.NaptanStatus = string.Empty;
            this.NaptanBusStopType = string.Empty;
            this.NaptanStreet = street;
            this.NaptanIndicator = naptanIndicator;
            this.Latitude = -1.0M;
            this.Longitude = -1.0M;
            this.NaptanNaptanCode = string.Empty;
            this.NotName = notName;
            this.Surveyed = surveyed;
            this.Highway = highway;
            this.NaptanVerified = naptanVerified;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 29 September 2020 (1.9.1.0)</createdBy>
        ///
        /// <summary>Gets or sets the naptan indicator.</summary>
        ///
        /// <value>The naptan indicator.</value>
        // ===========================================================================================================
        public string NaptanIndicator { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 27 September 2020 (1.9.1.0)</createdBy>
        ///
        /// <summary>Gets the naptan street.</summary>
        ///
        /// <value>The naptan street.</value>
        // ===========================================================================================================
        public string NaptanStreet { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets the not name tag value.</summary>
        ///
        /// <value>The not name value.</value>
        // ===========================================================================================================
        public string NotName { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets whether any tags indicating a physical survey are present on the OSM node.</summary>
        ///
        /// <value>yes or blank.</value>
        // ===========================================================================================================
        public string Surveyed { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets highway tag value.</summary>
        ///
        /// <value>The highway value.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Highway { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets the naptan verified tag value.</summary>
        ///
        /// <value>The naptan verified value.</value>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        public string NaptanVerified { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets the naptan code.</summary>
        ///
        /// <value>The naptan code.</value>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string NaptanCode { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets the status.</summary>
        ///
        /// <value>The status.</value>
        // ===========================================================================================================
        public string Status { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets the type of the bus stop.</summary>
        ///
        /// <value>The type of the bus stop.</value>
        // ===========================================================================================================
        public string BusStopType { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.1.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the naptan code from naptan.</summary>
        ///
        /// <value>The naptan code from naptan.</value>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        public string NaptanNaptanCode { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.1.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the longitude.</summary>
        ///
        /// <value>The longitude.</value>
        // ===========================================================================================================
        public decimal Longitude { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.1.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the latitude.</summary>
        ///
        /// <value>The latitude.</value>
        // ===========================================================================================================
        public decimal Latitude { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 25 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the naptan type of the bus stop.</summary>
        ///
        /// <value>The naptan type of the bus stop.</value>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        public string NaptanBusStopType { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 25 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the naptan status.</summary>
        ///
        /// <value>The naptan status.</value>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        public string NaptanStatus { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the name from naptan.</summary>
        ///
        /// <value>The name from naptan.</value>
        // ===========================================================================================================
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string NaptanName { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Gets the naptan name cleaned.</summary>
        ///
        /// <value>The naptan name cleaned.</value>
        // ===========================================================================================================
        public string NaptanNameCleaned
        {
            get
            {
                string returnValue = this.NaptanName.TrimStart();
                foreach (Tuple<string, string> mapping in NameMappings.Mappings)
                {
                    returnValue = returnValue.Replace(mapping.Item1, mapping.Item2);
                }

                return returnValue;
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the name of the stop.</summary>
        ///
        /// <value>The name of the stop.</value>
        // ===========================================================================================================
        public string StopName { get; }

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
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Type { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the names match.</summary>
        ///
        /// <value>True if names match, false if not.</value>
        // ===========================================================================================================
        public bool NamesMatch => this.AtcoCode.StartsWith("4300")
            ? string.Equals(this.StopName, this.NaptanStreet + " / " + this.NaptanName,
                StringComparison.OrdinalIgnoreCase) || this.NaptanIndicator.Contains(this.StopName)
            : (this.StopName.Replace("(", string.Empty)
                   .Replace(")", string.Empty)
                   .Replace(" / ", " ")
                   .Contains(this.NaptanNameCleaned)
               && this.NaptanName.Length > 0)
              || this.NaptanIndicator.Contains(this.StopName)
              || this.NotName == this.NaptanName;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the statuses match.</summary>
        ///
        /// <value>True if statuses match, false if not.</value>
        // ===========================================================================================================
        public bool StatusesMatch => this.NaptanStatus == "act" || this.Status == this.NaptanStatus;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the types match.</summary>
        ///
        /// <value>True if types match, false if not.</value>
        // ===========================================================================================================
        public bool TypesMatch => this.NaptanBusStopType == "MKD" || 
                                  this.BusStopType == this.NaptanBusStopType || 
                                  (string.IsNullOrEmpty(this.BusStopType) && string.IsNullOrEmpty(this.NaptanBusStopType)) || 
                                  (this.NaptanBusStopType == "CUS" && this.NaptanVerified != "no" && this.Surveyed == "yes");

        // ===========================================================================================================
        /// <createdBy>EdLoach - 25 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets the name of the journey stop.</summary>
        ///
        /// <value>The name of the journey stop.</value>
        // ===========================================================================================================
        public string JourneyStopName =>
            this.StopName + " (" + this.NaptanBusStopType + "/" + this.NaptanStatus + ")";
    }
}