using System.Collections.Generic;

namespace tp3_prog
{

    public class Equipment : Item
    {

        public int Price { get; set; }
        public EquipmentSlot Slot { get; set; }
        public List<Hero> Users { get; set; }
        public int ItemValue { get; set; }
    }
}

