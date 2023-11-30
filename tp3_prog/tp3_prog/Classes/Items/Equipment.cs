using System.Collections.Generic;

namespace tp3_prog
{

    public class Equipment : Item
    {

        public EquipmentSlot Type { get; set; } // Helmet
        public int? Atk { get; set; }
        public int? Def { get; set; }
        public int? Mp { get; set; }
        public int? Hp { get; set; }
        public List<int> Required_Class { get; set; } = new List<int>(); // Gives the Id of the classes that can use it

        public void Equip()
        {
            // Check if he already has an equiped


            // If YES, put the current equiped in the inventory
            // put the new on in the slot

            // If NO, put the new on in the slot
        }

    }
}

