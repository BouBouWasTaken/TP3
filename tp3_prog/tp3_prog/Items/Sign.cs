using System.Collections.Generic;

namespace tp3_prog
{
    public partial class App
    {
        public class Sign : Item
        {
            public List<Zone> ZonesConnected { get; set; } = new List<Zone>();
            public List<Zone> ZonesVisited { get; set; } = new List<Zone>();
            public List<Zone> ZonesNotVisited { get; set; } = new List<Zone>();
            public RestingArea? RestArea { get; set; }

        }
    }


}
