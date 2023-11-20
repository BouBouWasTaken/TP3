using System.Collections.Generic;

namespace tp3_prog
{
    public class Crafter : Characters
    {
        public List<DialogOptions> DialogOptions { get; set; } = new List<DialogOptions>();
        public List<Item> Inventory { get; set; } = new List<Item>();
        public List<Recipie> Recipies { get; set; } = new List<Recipie>();

    }
}
