using System.Collections.Generic;

namespace tp3_prog
{
    public class Zone
    {
        public string Name { get; set; }
        public int ChanceOfCombat { get; set; }
        public List<Zone> LinkedZones { get; set; } = new List<Zone>();
        public bool Known;
    }
}
