using System.Collections.Generic;

namespace tp3_prog
{
    public class Crafter : Characters
    {
        public List<DialogOptions> DialogOptions { get; set; } = new();
        public List<Item> Inventory { get; set; } = new();
        public List<Recipie> Recipies { get; set; } = new();

    }
}
