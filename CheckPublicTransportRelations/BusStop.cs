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
    using System.Diagnostics.CodeAnalysis;

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
        /// <param name="elementType">      Type of the element.</param>
        /// <param name="elementId">        Identifier for the element.</param>
        /// <param name="elementAtcoCode">  The element atco code.</param>
        /// <param name="stopName">         The stop name.</param>
        /// <param name="naptanCode">       The naptan code.</param>
        /// <param name="stopStatus">       The stop status.</param>
        /// <param name="busStopType">      The type of the bus stop.</param>
        /// <param name="notName">          The name of the not.</param>
        /// <param name="surveyed">The physically present.</param>
        /// <param name="highway">          The highway.</param>
        /// <param name="naptanVerified">   The naptan verified.</param>
        // ===========================================================================================================
        // ReSharper disable once StyleCop.SA1650
        public BusStop(string elementType, long elementId, string elementAtcoCode, string stopName, string naptanCode, string stopStatus, string busStopType, string notName, string surveyed, string highway, string naptanVerified)
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
            this.Latitude = -1.0M;
            this.Longitude = -1.0M;
            this.NaptanNaptanCode = string.Empty;
            this.NotName = notName;
            this.Surveyed = surveyed;
            this.Highway = highway;
            this.NaptanVerified = naptanVerified;
        }

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
        public string NaptanCode { get; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the status.</summary>
        ///
        /// <value>The status.</value>
        // ===========================================================================================================
        public string Status { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 2 February 2019 (1.2.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the type of the bus stop.</summary>
        ///
        /// <value>The type of the bus stop.</value>
        // ===========================================================================================================
        public string BusStopType { get; set; }

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
        /// <createdBy>EdLoach - 3 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the name of the stop.</summary>
        ///
        /// <value>The name of the stop.</value>
        // ===========================================================================================================
        public string StopName { get; set; }

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

        // ===========================================================================================================
        /// <createdBy>EdLoach - 10 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether the names match.</summary>
        ///
        /// <value>True if names match, false if not.</value>
        // ===========================================================================================================
        public bool NamesMatch => (this.StopName.Replace("(", string.Empty)
                                       .Replace(")", string.Empty)
                                       .Replace(" / ", " ")
                                       .Contains(this.NaptanName
                                                            .TrimStart()
                                                            .Replace(" Rdbt", " Roundabout")
                                                            .Replace(" Rbt", " Roundabout")
                                                            .Replace(" RdGallows", " Road Gallows")
                                                            .Replace(" Rd", " Road")
                                                            .Replace(" Ln"," Lane")
                                                            .Replace(" Gdns", " Gardens")
                                                            .Replace(" Cotts", " Cottages")
                                                            .Replace(" Ave", " Avenue")
                                                            .Replace(" Ind Estate", " Industrial Estate")
                                                            .Replace(" Prom", " Promenade")
                                                            .Replace(" Avenuenue", " Avenue")
                                                            .Replace("(", string.Empty)
                                                            .Replace(")", string.Empty)
                                                            .Replace(" / ", " ")
                                                            .Replace("  ", " ")
                                                            .Replace(" Cnr", " Corner")
                                                            .Replace(" StnSt", " Station St")
                                                            .Replace(" Stn", " Station")
                                                            .Replace(" 6th Form Col", " Sixth Form College")
                                                            .Replace("Gale St Goresbrook Leisure C", "Gale Street Goresbrook Leisure Centre")) 
                                  && this.NaptanName.Length > 0) || this.NotName == this.NaptanName;

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