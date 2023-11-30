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
        public List<ItemInventory> Inventory = new List<ItemInventory>();

        public int Gold { get; set; }


        // starting items for a party 
        // Missing zone
        private void BaseItems()
        {
            //Gold += 200;
            for (int i = 0; i < 5; i++)
            {

                ItemInventory b = new ItemInventory(DefaultData.Usables["Health potion"], 5);
                ItemInventory c = new ItemInventory(DefaultData.Usables["Mana potion"], 5);
                Inventory.Add(b);
                Inventory.Add(c);
            }
            /*for (int i = 0; i < 3; i++)
            {
                Inventory.Add(DefaultData.Usables["Shuriken"]);
            }
            Inventory.Add(DefaultData.Usables["Bomb"]);
            */
        }

    }
}
