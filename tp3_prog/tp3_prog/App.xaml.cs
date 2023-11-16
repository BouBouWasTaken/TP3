using System.Collections.Generic;
using System.Windows;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public class Interaction
        {
            public List<string> DialogOptions { get; set; } = new List<string>();
            public List<string> CombatOptions { get; set; } = new List<string>();
        }

        public void Test()
        {
            Item test = new Equipment();

            test.Id = 1;


            Hero hero = new Hero();

            hero.Inventory.Add(test);

            // If I want to sell test
            int location = hero.Inventory.IndexOf(test);
            hero.Inventory[location].Sell();
            // ------------

        }


    }

}
