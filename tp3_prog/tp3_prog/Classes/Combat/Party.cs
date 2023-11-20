using System.Collections.Generic;

namespace tp3_prog
{
    internal class Party
    {
        public Party(List<Hero> heroes)
        {
            Hero_Party = heroes;
        }

        public List<Hero> Hero_Party { get; set; }

        // Any function that concernes a party, much like targetting the entire party.

    }
}
