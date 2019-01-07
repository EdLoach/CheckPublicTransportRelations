using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPublicTransportRelations
{
    public class JourneyPatternSection
    {
        public JourneyPatternSection()
        {
            this.Id = string.Empty;
            this.JourneyStops = new List<JourneyStop>();
        }
        public string Id { get; set; }

        public List<JourneyStop> JourneyStops { get; set; }
    }
}
