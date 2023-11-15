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
    }


}
