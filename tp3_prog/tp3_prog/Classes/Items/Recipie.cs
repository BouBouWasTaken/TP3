using System.Collections.Generic;

namespace tp3_prog
{
    public class Recipie
    {
        public Item ItemCrafted { get; set; } // The item that it crafts
        public int AmountCrafted { get; set; } // how many of that item are crafted
        public List<ItemInventory> Ingredients { get; set; } // Ingredients & amount needed for it




        public List<ItemInventory> MakeItem(List<ItemInventory> inventory, int toMake = 1)
        {
            // Check if the guy has every ingredient necessary
            if (HasIngredients(inventory))
            {
                // Create the item
                // Equipment craftedItem = new Equipment();
                // Maybe a dictionnary link

                // Add the crafted item to the inventory
                //for (int i = 0; i < toMake; i++)
                //{
                // inventory.Add(craftedItem);
                //}

                // Remove consumed ingredients from the inventory
                //foreach (var ingredient in Ingredients)
                //{
                //    inventory.Remove(ingredient);
                //}
            }

            // Return the updated inventory with the made items
            return inventory;
        }


        private bool HasIngredients(List<ItemInventory> inventory)
        {
            // Check if the inventory contains all the necessary ingredients
            foreach (var ingredient in Ingredients)
            {
                if (!inventory.Contains(ingredient))
                {
                    // The inventory is missing at least one ingredient
                    return false;
                }
            }

            // All ingredients are present in the inventory
            return true;
        }
    }
}
