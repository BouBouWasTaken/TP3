using System.Collections.Generic;

namespace tp3_prog
{
    public class Party
    {
        public Party(List<Hero> heroes)
        {
            Members = heroes;
        }

        public List<Hero> Members { get; set; }
        public List<Item> Inventory = new List<Item>();
        public int Gold { get; set; }

        // Any function that concernes a party, much like targetting the entire party.

    }
}
