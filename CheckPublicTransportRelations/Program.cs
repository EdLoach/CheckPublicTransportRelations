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
    using System.Threading;
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
        /// <createdBy>EdLoach - 4 August 2020 (1.9.0.0)</createdBy>
        ///
        /// <summary>The mutex.</summary>
        // ===========================================================================================================
        // ReSharper disable once NotAccessedField.Local
        private static Mutex mutex = null;

        // ===========================================================================================================
        /// <createdBy>EdLoach - 1 August 2020 (1.8.0.0)</createdBy>
        ///
        /// <summary>The main entry point for the application.</summary>
        ///
        /// <param name="args">Array of command-line argument strings.</param>
        ///
        /// <returns>Exit-code for the process - 0 for success, else an error code.</returns>
        // ===========================================================================================================
        [STAThread]
        private static int Main(string[] args)
        {
            const string AppName = "CheckPublicTransportRelations";
            bool createdNew;

            mutex = new Mutex(true, AppName, out createdNew);

            if (!createdNew)
            {
                return 170; // ERROR_BUSY
            }

            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
            return 0;  // ERROR_SUCCESS
        }
    }
}