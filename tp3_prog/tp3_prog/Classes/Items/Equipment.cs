using System.Collections.Generic;
using tp3_prog.Classes.Characters;

namespace tp3_prog
{

    public class Equipment : Item
    {

        public EquipmentSlot Slot { get; set; } // Helmet
        public int Value { get; set; } // ATK : 2 OR DEF : 2
        public List<Classe> Required_Class { get; set; } = new List<Classe>();

        public void Equip()
        {
            // Check if he already has an equiped


            // If YES, put the current equiped in the inventory
            // put the new on in the slot

            // If NO, put the new on in the slot
        }
    }
}

