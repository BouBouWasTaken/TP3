using System.Collections.Generic;
using System.Windows;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public class Npc
        {
            public int Name { get; set; }
        }
        public class Enemy
        {
            public string Name { get; set; }

        }
        public class Hero
        {
            public string Name { get; set; }
            public Classe Classe { get; set; }
            public int Level { get; set; }
            public int Experience { get; set; }
            public int Health { get; set; }
            public int MagicPoints { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }

        }

        public class Classe
        {
            public string Name { get; set; }
            public string Portrait { get; set; }
            public int AtkByLevel { get; set; }
            public int DefByLevel { get; set; }
            public int HpByLevel { get; set; }
            public int MpByLevel { get; set; }
            public List<Magic> Magic { get; set; }
        }
        public class Magic
        {
            public int MinimumLevel { get; set; }
            public int MagicPoints { get; set; }
            public string type { get; set; }
            public string Targets { get; set; }
            public int AtkMultip { get; set; }



        }

        public class Zone
        {
            public string Name { get; set; }
            public int ChanceOfCombat { get; set; }
        }

    }
}
