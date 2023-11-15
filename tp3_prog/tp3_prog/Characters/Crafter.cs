using System.Collections.Generic;

namespace tp3_prog
{
    public partial class App
    {
        public class Crafter : Characters
        {
            public List<string> DialogOptions { get; set; }
            public List<string> Inventory { get; set; }
            public List<string> Ingredients { get; set; }
            public List<string> Items { get; set; }
            public List<string> Recipies { get; set; }

        }
    }


}
