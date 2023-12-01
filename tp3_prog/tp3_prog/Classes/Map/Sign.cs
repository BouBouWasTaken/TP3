using System.Collections.Generic;

namespace tp3_prog
{

    public class Sign : Item
    {
        public List<Zone> ZonesConnected { get; set; } = new();
        public List<Zone> ZonesVisited { get; set; } = new();
        public List<Zone> ZonesNotVisited { get; set; } = new();


    }
}
