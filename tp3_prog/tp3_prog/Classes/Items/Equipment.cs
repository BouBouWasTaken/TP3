using System.Collections.Generic;

namespace tp3_prog
{

    public class Equipment : Item
    {

        public EquipmentSlot Type { get; set; } // Helmet
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Mp { get; set; }
        public int Hp { get; set; }
        public List<Classe> Required_Class { get; set; } = new(); // Gives the Id of the classes that can use it

        public void Equip(Hero hero)
        {
            bool found = false;
            // Check if he already has an equiped
            foreach (Equipment equipment in hero.Equipment)
            {
                if (equipment.Type == Type)
                {
                    hero.Equipment.Remove(equipment);
                    hero.EraseItemStats(equipment);

                    hero.Equipment.Add(this);
                    hero.UpdateMyStats(this);
                    CurrentOwner = hero;

                    found = true;
                }
            }

            if (!found)
            {
                hero.Equipment.Add(this);
                CurrentOwner.UpdateMyStats(this);
            }

            // If YES, put the current equiped in the inventory
            // put the new on in the slot

            // If NO, put the new on in the slot
        }

        public override string ToString()
        {
            return Name;
        }

    }
}

