using System.Collections.Generic;

namespace tp3_prog
{
    public class Npc
    {
        public string Name = "";
        public List<ItemInventory> Inventory = new();

        public void AddItem(Item item, int amount)
        {
            if (Inventory != null)
            {

                foreach (var usable in Inventory)
                {
                    if (usable.Item.Name == item.Name)
                    {
                        if (usable.Amount != -1)
                        {
                            usable.Amount += amount;
                        }
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
                        if (Inventory[i].Amount >= amount && Inventory[i].Amount != -1)
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
    }



}
