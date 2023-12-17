using System.Collections.Generic;
using System.Linq;

namespace tp3_prog
{
    public class Zone
    {
        public string? Name { get; set; }

        public bool Discovered = false;
        public double ChanceOfCombat { get; set; }
        public List<int> LinkedZones { get; set; } = new();
        // North = 1
        // South = 2
        // East  = 3
        // West  = 4

        public List<Interaction> Interactions => DefaultData.Interaction.Values.Where(x => x.Zone == this).ToList();

        public Zone(string name, List<int> keys, double chances)
        {
            Name = name;
            ChanceOfCombat = chances;

            LinkedZones = keys;
        }

        public Zone? North => DefaultData.Locations.ContainsKey(LinkedZones[0]) ? DefaultData.Locations[LinkedZones[0]] : null;
        public Zone? South => DefaultData.Locations.ContainsKey(LinkedZones[1]) ? DefaultData.Locations[LinkedZones[1]] : null;
        public Zone? East => DefaultData.Locations.ContainsKey(LinkedZones[2]) ? DefaultData.Locations[LinkedZones[2]] : null;
        public Zone? West => DefaultData.Locations.ContainsKey(LinkedZones[3]) ? DefaultData.Locations[LinkedZones[3]] : null;


    }
}
