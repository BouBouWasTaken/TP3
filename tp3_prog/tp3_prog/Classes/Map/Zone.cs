using System.Collections.Generic;

namespace tp3_prog
{
    public class Zone
    {
        public string? Name { get; set; }
        public int ChanceOfCombat { get; set; }
        public List<Zone> LinkedZones { get; set; } = new();
        // North =1
        // East =2
        // South = 3
        // West = 4
        public bool Known = false;
    }
}
