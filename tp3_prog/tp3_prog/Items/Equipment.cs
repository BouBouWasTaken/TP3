using System.Collections.Generic;

namespace tp3_prog
{
    public partial class App
    {
        public class Equipment : Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public int Slot { get; set; }
            public List<Hero> Users { get; set; }
            public int ItemValue { get; set; }
        }
    }


}
