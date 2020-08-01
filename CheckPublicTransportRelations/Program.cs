// ===========================================================================================================
// <copyright file="Program.cs" company="N/A">
// Copyright (c) 2020 EdLoach. All rights reserved.
// </copyright>
// <author>EdLoach</author>
// <date>1 August 2020</date>
// <summary>Implements the program class</summary>
// ===========================================================================================================
namespace CheckPublicTransportRelations
{
    using System;
    using System.Windows.Forms;

    using CheckPublicTransportRelations.Properties;

    // ===========================================================================================================
    /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
    ///
    /// <summary>The program startup class.</summary>
    // ===========================================================================================================
    internal static class Program
    {
        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>The main entry point for the application.</summary>
        ///
        /// <param name="args">Array of command-line argument strings.</param>
        // ===========================================================================================================
        [STAThread]
        private static void Main(string[] args)
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
        }
    }
}