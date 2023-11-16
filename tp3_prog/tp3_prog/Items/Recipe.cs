using System.Collections.Generic;

namespace tp3_prog
{
    internal class Recipe
    {
        public Recipe(List<Ingredient> ingredients)
        {
            this.Ingredients = ingredients;
        }

        public List<Ingredient> Ingredients { get; set; }

        public List<Item> MakeItem(List<Item> inventory, int queued = 1)
        {
            // Check if the guy has every ingredient necessary
            if (HasIngredients(inventory))
            {
                // Create the item
                // Equipment craftedItem = new Equipment();
                // Maybe a dictionnary link

                // Add the crafted item to the inventory
                for (int i = 0; i < queued; i++)
                {
                    // inventory.Add(craftedItem);
                }

                // Remove consumed ingredients from the inventory
                foreach (var ingredient in Ingredients)
                {
                    inventory.Remove(ingredient);
                }
            }

            // Return the updated inventory with the made items
            return inventory;
        }

        public List<Item> MakePotion(List<Item> inventory, int queued = 1)
        {
            // Check if the guy has every ingredient necessary
            if (HasIngredients(inventory))
            {
                // Create the item
                // Usable craftedItem = new Usable();
                // Maybe a dictionnary link

                // Add the crafted item to the inventory
                for (int i = 0; i < queued; i++)
                {
                    // inventory.Add(craftedItem);
                }

                // Remove consumed ingredients from the inventory
                foreach (var ingredient in Ingredients)
                {
                    inventory.Remove(ingredient);
                }
            }

            // Return the updated inventory with the made items
            return inventory;
        }

        private bool HasIngredients(List<Item> inventory)
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
