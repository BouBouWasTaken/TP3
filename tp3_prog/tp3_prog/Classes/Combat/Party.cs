using System.Collections.Generic;

namespace tp3_prog
{
    public class Party
    {
        public Party(List<Hero> heroes)
        {
            Members = heroes;
            BaseItems();
        }

        public Zone Zone { get; set; }
        public List<Hero> Members { get; set; }
        public List<Item> Inventory = new List<Item>();

        public int Gold { get; set; }


        // starting items for a party 
        // Missing zone
        private void BaseItems()
        {
            Gold += 200;
            for (int i = 0; i < 5; i++)
            {
                Inventory.Add(DefaultData.Usables["Health potion"]);
                Inventory.Add(DefaultData.Usables["Mana potion"]);

            }
            for (int i = 0; i < 3; i++)
            {
                Inventory.Add(DefaultData.Usables["Shuriken"]);
            }
            Inventory.Add(DefaultData.Usables["Bomb"]);

        }

    }
}
