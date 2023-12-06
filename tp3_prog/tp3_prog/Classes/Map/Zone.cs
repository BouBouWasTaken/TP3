using System.Collections.Generic;
using System.Linq;

namespace tp3_prog
{
    public class Zone
    {
        public string? Name { get; set; }
        public double ChanceOfCombat { get; set; }
        public List<string> LinkedZones { get; set; } = new();
        // North = 1
        // South = 2
        // East  = 3
        // West  = 4

        public Zone(string name, List<string> locations_string, double chances)
        {
            Name = name;
            // North = DefaultData.Locations.Values.FirstOrDefault(x => x.Name == locations_string[0]);
            South = (Zone)DefaultData.Locations.Values.Where(x => x.Name == locations_string[1]);
            East = (Zone)DefaultData.Locations.Values.Where(x => x.Name == locations_string[2]);
            West = (Zone)DefaultData.Locations.Values.Where(x => x.Name == locations_string[3]);

            ChanceOfCombat = chances;

            // DefaultData.Locations.Keys.Contains(locations_string[0]) ? North = DefaultData.Locations.Values[locations_string[0];
        }

        // public Zone North = (Zone)DefaultData.Locations.Values.Where(x => x.Name == LinkedZones[0]);
        public Zone South;
        public Zone East;
        public Zone West;

        public bool Known = false;
    }
}
