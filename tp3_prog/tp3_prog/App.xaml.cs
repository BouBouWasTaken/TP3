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
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Enemy
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }
        public class Crafter
        {
            public List<string> DialogOptions { get; set; }
            public List<string> Inventory { get; set; }
            public List<string> Ingredients { get; set; }
            public List<string> Items { get; set; }
            public List<string> Recipies { get; set; }

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
        public class Merchant
        {

        }

        public class Classe
        {
            public string Name { get; set; }
            public string Portrait { get; set; }
            public int AtkByLevel { get; set; }
            public int DefByLevel { get; set; }
            public int HpByLevel { get; set; }
            public int MpByLevel { get; set; }
            public List<Magic> Magics { get; set; }
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
            public List<Zone> Zones { get; set; }
        }

        public class Fight
        {
            public List<Enemy> Enemies { get; set; }
            public int Rounds { get; set; }
            public bool Finished { get; set; }
            public string type { set; get; }
        }

        public class Auberge
        {
            public int Rooms { get; set; }
            public int Cost { get; set; }
            public int LifeRegen { get; set; }
            public int MpRegen { get; set; }

        }
        public class Interaction
        {
            public List<string> DialogOptions { get; set; }
            public List<string> CombatOptions { get; set; }
        }

        // Items

        public class Item
        {

        }
        public class Equipment : Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public int Slot { get; set; }
            public List<Hero> Users { get; set; }
            public int ItemValue { get; set; }
        }

        public class Usable : Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public string EffectType { get; set; }
            public int Target { get; set; }
            public int EffectValue { get; set; }
        }
        public class Component : Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class Sign
        {
            public List<Zone> ZonesConnected { get; set; }
            public List<Zone> ZonesVisited { get; set; }

            public List<Zone> ZonesNotVisited { get; set; }
            public RestingArea RestArea { get; set; }

        }
        public class RestingArea
        {
            public int Id { get; set; }
            public int Regen { get; set; }
            public int ChanceOfCombat { get; set; }


        }
    }


}
