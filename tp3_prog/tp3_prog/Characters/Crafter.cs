using System.Collections.Generic;
using tp3_prog.Enums;

namespace tp3_prog
{
    public class Crafter : Characters
    {
        public List<DialogOptions> DialogOptions { get; set; }
        public List<Item> Inventory { get; set; } = new List<Item>();
        public List<string> Recipies { get; set; }

    }
}
