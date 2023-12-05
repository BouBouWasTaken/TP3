﻿using System.Collections.Generic;

namespace tp3_prog
{
    public class Hero : Characters
    {
        public Classe Classe { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int Current_Health { get; set; }
        public int MagicPoints { get; set; }
        public int Current_MagicPoints { get; set; }
        public List<Skill> Skills = new();
        public int Attack { get; set; }
        public int Defense { get; set; }
        public List<ItemInventory>? Equipment { get; set; } = new();
        public List<ItemInventory>? Usables { get; set; } = new();

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
