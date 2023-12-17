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
            CurrentOwner = hero;

            hero.Equipment.Add(this);
            CurrentOwner.UpdateMyStats(this);

        }


        public void Unequip(Hero hero)
        {
            if (hero.Equipment == null) return;
            // NOTE: Don't forget to add the item back in the party's inventory

            // if the hero does have the item
            if (hero.Equipment.Contains(this))
            {
                // Takes it out
                hero.Equipment.Remove(this);
                // Erases the stats
                hero.EraseItemStats(this);
                // Changes the owner
                CurrentOwner = null;
            }
            // if he doesn't for 'x' reasons
            else
            {
                return;
            }
        }

        public override string ToString()
        {
            if (Name == null) return string.Empty;
            return Name + Description;
        }

    }
}

