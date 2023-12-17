using System.Collections.Generic;

namespace tp3_prog
{
    public class Recipie : Item
    {
        public Item ItemCrafted { get; set; } = new(); // The item that it crafts
        public int AmountCrafted { get; set; } // how many of that item are crafted
        public List<ItemInventory> Ingredients { get; set; } = new(); // Ingredients & amount needed for it


        public override string ToString()
        {
            string returnString = "";
            foreach (var item in Ingredients)
            {
                returnString += item.Item.Name + "(" + item.Amount + ")\n";
            }
            return returnString;
        }


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


        public bool HasIngredients(List<ItemInventory> playerInventory)
        {
            foreach (var ingredient in Ingredients)
            {
                bool ingredientFound = false;

                foreach (var playerItem in playerInventory)
                {
                    if (playerItem.Item.Equals(ingredient.Item) && playerItem.Amount >= ingredient.Amount)
                    {
                        ingredientFound = true;
                        break;
                    }
                }
                if (!ingredientFound)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
