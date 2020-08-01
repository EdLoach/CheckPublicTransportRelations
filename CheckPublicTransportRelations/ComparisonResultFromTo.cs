// ===========================================================================================================
// <copyright file="ComparisonResultFromTo.cs" company="N/A">
// Copyright (c) 2019 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>5 January 2019</date>
// <summary>Implements the comparison result from to class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
    ///
    /// <summary>A comparison result from to.</summary>
    // ===========================================================================================================
    public class ComparisonResultFromTo
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>The stop from.</summary>
        // ===========================================================================================================
        private string stopFrom;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>The stop to.</summary>
        // ===========================================================================================================
        private string stopTo;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Initializes a new instance of the <see cref="ComparisonResultFromTo"/> class.</summary>
        // ===========================================================================================================
        public ComparisonResultFromTo()
        {
            this.RelationId = -1;
            this.RelationService = string.Empty;
            this.RelationFrom = string.Empty;
            this.RelationTo = string.Empty;
            this.StopFrom = string.Empty;
            this.StopTo = string.Empty;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the identifier of the relation.</summary>
        ///
        /// <value>The identifier of the relation.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public long RelationId { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the relation service.</summary>
        ///
        /// <value>The relation service.</value>
        // ===========================================================================================================
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string RelationService { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the relation from.</summary>
        ///
        /// <value>The relation from.</value>
        // ===========================================================================================================
        public string RelationFrom { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the relation to.</summary>
        ///
        /// <value>The relation to.</value>
        // ===========================================================================================================
        public string RelationTo { get; set; }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the stop from.</summary>
        ///
        /// <value>The stop from.</value>
        // ===========================================================================================================
        public string StopFrom
        {
            get
            {
                string returnValue = this.stopFrom.Contains("(")
                                         ? this.stopFrom.Substring(
                                             0,
                                             this.stopFrom.IndexOf("(", StringComparison.Ordinal) - 1).Trim()
                                         : this.stopFrom;
                if (returnValue.Contains(" - ") && !returnValue.Contains("Co - Op"))
                {
                    return returnValue.Substring(0, returnValue.IndexOf(" - ", StringComparison.Ordinal) - 1).Trim();
                }

                return returnValue;
            }

            set => this.stopFrom = value;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets or sets the stop to.</summary>
        ///
        /// <value>The stop to.</value>
        // ===========================================================================================================
        public string StopTo
        {
            get
            {
                string returnValue = this.stopTo.Contains("(")
                                         ? this.stopTo.Substring(
                                             0,
                                             this.stopTo.IndexOf("(", StringComparison.Ordinal) - 1).Trim()
                                         : this.stopTo;
                if (returnValue.Contains(" - ") && !returnValue.Contains("Co - Op"))
                {
                    return returnValue.Substring(0, returnValue.IndexOf(" - ", StringComparison.Ordinal) - 1).Trim();
                }

                return returnValue;
            }

            set => this.stopTo = value;
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether from name found.</summary>
        ///
        /// <value>True if from name found, false if not.</value>
        // ===========================================================================================================
        public bool FromNameFound => this.RelationFrom?.Contains(this.StopFrom) ?? false;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 5 January 2019 (1.0.0.0)</createdBy>
        ///
        /// <summary>Gets a value indicating whether to name found.</summary>
        ///
        /// <value>True if to name found, false if not.</value>
        // ===========================================================================================================
        public bool ToNameFound => this.RelationTo?.Contains(this.StopTo) ?? false;
    }
}