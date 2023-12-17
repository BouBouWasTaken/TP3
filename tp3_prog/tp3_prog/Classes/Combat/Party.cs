using System.Collections.Generic;

namespace tp3_prog
{
    public class Party
    {
        public Party(List<Hero> heroes)
        {
            Members = heroes;
            BaseItems();
            Zone = DefaultData.Locations[1];
        }

        public Zone? Zone { get; set; }
        public List<Hero> Members { get; set; }
        public List<ItemInventory> Inventory = new();

        public double Gold { get; set; }
        public void AddItem(Item item, int amount)
        {
            if (Inventory != null)
            {

                foreach (var usable in Inventory)
                {
                    if (usable.Item.Name == item.Name)
                    {
                        usable.Amount += amount;
                        return;
                    }
                }
                Inventory.Add(new ItemInventory(item, amount));
            }
        }
        public void RemoveItem(Item item, int amount)
        {
            if (Inventory != null && Inventory.Count > 0)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (Inventory[i].Item.Name == item.Name)
                    {
                        if (Inventory[i].Amount >= amount)
                        {
                            Inventory[i].Amount -= amount;

                        }
                    }

                    if (Inventory[i].Amount == 0)
                    {
                        Inventory.Remove(Inventory[i]);
                    }
                }
            }
        }

        // starting items for a party 
        // Missing zone
        private void BaseItems()
        {
            Gold += 200;

            ItemInventory HealthPotions = new(DefaultData.Usables["Health potion"], 5);
            ItemInventory ManaPotions = new(DefaultData.Usables["Mana potion"], 5);
            ItemInventory Shuriken = new(DefaultData.Usables["Shuriken"], 3);
            ItemInventory Bomb = new(DefaultData.Usables["Bomb"], 1);
            ItemInventory sword = new(DefaultData.Equipments["Iron sword"], 1);


            Inventory.Add(HealthPotions);
            Inventory.Add(ManaPotions);
            Inventory.Add(Shuriken);
            Inventory.Add(Bomb);
            Inventory.Add(sword);

        }

    }
}
