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
        public List<ItemInventory> Inventory = new();

        public int Gold { get; set; }


        // starting items for a party 
        // Missing zone
        private void BaseItems()
        {
            Gold += 200;

            ItemInventory HealthPotions = new(DefaultData.Usables["Health potion"], 5);
            ItemInventory ManaPotions = new(DefaultData.Usables["Mana potion"], 5);
            ItemInventory Shuriken = new(DefaultData.Usables["Shuriken"], 3);
            ItemInventory Bomb = new(DefaultData.Usables["Bomb"], 1);

            Inventory.Add(HealthPotions);
            Inventory.Add(ManaPotions);
            Inventory.Add(Shuriken);
            Inventory.Add(Bomb);

        }

    }
}
