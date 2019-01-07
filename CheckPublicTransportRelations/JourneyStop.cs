using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPublicTransportRelations
{
    public class JourneyStop
    {
        public JourneyStop()
        {
            this.Activity = string.Empty;
            this.StopPointRef = string.Empty;
        }
        public string Activity { get; set; }
        public string StopPointRef { get; set; }
    }
}
