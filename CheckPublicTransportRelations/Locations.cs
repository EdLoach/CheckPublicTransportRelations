namespace CheckPublicTransportRelations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    public class Locations : List<Location>
    {
        public void Save()
        {
            try
            {
                string fileName = Path.Combine(Application.LocalUserAppDataPath, "Locations.json");
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