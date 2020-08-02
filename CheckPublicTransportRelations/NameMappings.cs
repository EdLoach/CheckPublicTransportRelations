// ===========================================================================================================
// <copyright file="NameMappings.cs" company="N/A">
// Copyright (c) 2020 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>1 August 2020</date>
// <summary>Implements the name mappings class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using CheckPublicTransportRelations.Properties;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
    ///
    /// <summary>A name mappings.</summary>
    // ===========================================================================================================
    public static class NameMappings
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Filename of the file.</summary>
        // ===========================================================================================================
        private static readonly string FileName = Path.Combine(
            Settings.Default.LocalPath, 
            "Mappings.json");

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>The mappings.</summary>
        // ===========================================================================================================
        private static List<Tuple<string, string>> mappings = new List<Tuple<string, string>>();

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Gets the mappings.</summary>
        ///
        /// <value>The mappings.</value>
        // ===========================================================================================================
        public static List<Tuple<string, string>> Mappings
        {
            get
            {
                if (mappings.Count < 1)
                {
                    mappings = LoadMappings();
                }

                return mappings;
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Refreshes this. </summary>
        // ===========================================================================================================
        public static void Refresh()
        {
            mappings = LoadMappings();
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Saves the given new mappings.</summary>
        ///
        /// <param name="newMappings">The new mappings to save.</param>
        // ===========================================================================================================
        public static void Save(List<Tuple<string, string>> newMappings)
        {
            try
            {
                string outputText = Newtonsoft.Json.JsonConvert.SerializeObject(
                    newMappings,
                    Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(FileName, outputText + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Might not have permissions, for example, in which case likely to only ever have the default location
                Debug.WriteLine(ex.Message);
            }
        }

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>Loads the mappings.</summary>
        ///
        /// <returns>The mappings.</returns>
        // ===========================================================================================================
        [SuppressMessage("ReSharper", "StringLiteralTypo", Justification = "fixes data spelling issues")]
        private static List<Tuple<string, string>> LoadMappings()
        {
            var returnValue = new List<Tuple<string, string>>();
            if (File.Exists(FileName))
            {
                string mappingsText = File.ReadAllText(FileName);
                returnValue = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tuple<string, string>>>(mappingsText);
            }

            if (returnValue.Count >= 1)
            {
                return returnValue;
            }

            returnValue.Add(new Tuple<string, string>(" Rdbt", " Roundabout"));
            returnValue.Add(new Tuple<string, string>(" Rbt", " Roundabout"));
            returnValue.Add(new Tuple<string, string>(" RdGallows", " Road Gallows"));
            returnValue.Add(new Tuple<string, string>(" Rd", " Road"));
            returnValue.Add(new Tuple<string, string>(" Ln", " Lane"));
            returnValue.Add(new Tuple<string, string>(" Gdns", " Gardens"));
            returnValue.Add(new Tuple<string, string>(" Cotts", " Cottages"));
            returnValue.Add(new Tuple<string, string>(" Ave", " Avenue"));
            returnValue.Add(new Tuple<string, string>(" Ind Estate", " Industrial Estate"));
            returnValue.Add(new Tuple<string, string>(" Prom", " Promenade"));
            returnValue.Add(new Tuple<string, string>(" Avenuenue", " Avenue"));
            returnValue.Add(new Tuple<string, string>("(", string.Empty));
            returnValue.Add(new Tuple<string, string>(")", string.Empty));
            returnValue.Add(new Tuple<string, string>(" / ", " "));
            returnValue.Add(new Tuple<string, string>("  ", " "));
            returnValue.Add(new Tuple<string, string>(" Cnr", " Corner"));
            returnValue.Add(new Tuple<string, string>(" StnSt", " Station St"));
            returnValue.Add(new Tuple<string, string>(" Stn", " Station"));
            returnValue.Add(new Tuple<string, string>(" 6th Form Col", " Sixth Form College"));
            returnValue.Add(
                new Tuple<string, string>("Gale St Goresbrook Leisure C", "Gale Street Goresbrook Leisure Centre"));

            Save(returnValue);

            return returnValue;
        }
    }
}