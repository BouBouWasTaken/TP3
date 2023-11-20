using System.Windows;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public void Test()
        {
            Item test = new Equipment();

            test.Id = 1;


            Hero hero = new();

            hero.Inventory.Add(test);

            // If I want to sell test
            int location = hero.Inventory.IndexOf(test);
            hero.Inventory[location].Sell();
            // ------------

        }


    }

}
