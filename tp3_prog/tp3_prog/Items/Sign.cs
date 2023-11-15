using System.Collections.Generic;

namespace tp3_prog
{
    public partial class App
    {
        public class Sign : Item
        {
            public List<Zone> ZonesConnected { get; set; }
            public List<Zone> ZonesVisited { get; set; }

            public List<Zone> ZonesNotVisited { get; set; }
            public RestingArea RestArea { get; set; }

        }
    }


}
