using System.Collections.Generic;
using tp3_prog.Classes.Characters;

namespace tp3_prog
{
    public class Hero : Characters
    {
        public string Name { get; set; }
        public Classe Classe { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int MagicPoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public List<Equipment>? Equipment { get; set; }
        public Hero(string name, Classe classe, int level, int experience, int health, int magicPoints, int attack, int defense)
        {
            Name = name;
            Classe = classe;
            Level = level;
            Experience = experience;
            Health = health;
            MagicPoints = magicPoints;
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return Name;
        }
    }


}
