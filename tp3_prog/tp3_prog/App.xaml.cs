using System.Collections.Generic;
using System.Windows;
using tp3_prog.Enums;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public class Fight
        {
            public List<Hero> Heroes { get; set; } = new List<Hero>();

            public List<Enemy> Enemies { get; set; } = new List<Enemy>();
            public int Rounds { get; set; }
            public bool Finished { get; set; }
            public TypeCombat Type { set; get; }
        }
        public class Interaction
        {
            public List<string> DialogOptions { get; set; } = new List<string>();
            public List<string> CombatOptions { get; set; } = new List<string>();
        }
    }


}
