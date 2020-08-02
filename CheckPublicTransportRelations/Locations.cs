// ===========================================================================================================
// <copyright file="Locations.cs" company="N/A">
// Copyright (c) 2020 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>1 August 2020</date>
// <summary>Implements the locations class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    using CheckPublicTransportRelations.Properties;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
    ///
    /// <summary>A list of locations.</summary>
    // ===========================================================================================================
    public class Locations : List<Location>
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Saves the list. </summary>
        // ===========================================================================================================
        public void Save()
        {
            try
            {
                string fileName = Path.Combine(Settings.Default.LocalPath, "Locations.json");
                string outputText = Newtonsoft.Json.JsonConvert.SerializeObject(
                    this,
                    Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(fileName, outputText + Environment.NewLine);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }
    }
}