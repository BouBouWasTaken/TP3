using System.Collections.Generic;
using System.Windows;
using tp3_prog.Classes.Characters;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {



    }

    static class DefaultData
    {
        public static Dictionary<int, Classe> Classes = new Dictionary<int, Classe>()
        {
            {
                0,
                new Classe()
                {
                    Name = "Fighter",
                    HpByLevel = 10,
                    MpByLevel = 3,
                    AtkByLevel = 2,
                    DefByLevel = 3
                }
             },
             {
                1,
                new Classe()
                {
                    Name = "Thief",
                    HpByLevel = 8,
                    MpByLevel = 3,
                    AtkByLevel = 3,
                    DefByLevel = 2
                }
             },
             {
                2,
                new Classe()
                {
                    Name = "Cleric",
                    HpByLevel = 8,
                    MpByLevel = 4,
                    AtkByLevel = 2,
                    DefByLevel = 2
                }
            },
            {
                3,
                new Classe()
                {
                    Name = "Mage",
                    HpByLevel = 6,
                    MpByLevel = 6,
                    AtkByLevel = 2,
                    DefByLevel = 2
                }
            },
        };

    }
}
