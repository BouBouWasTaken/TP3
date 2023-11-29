using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using tp3_prog.Classes.Characters;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ImageSource GetImage(string imageUrl)
        {
            return new BitmapImage(new Uri("pack://application:,,,/tp3_prog;component/assets/" + imageUrl));
        }


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
                    DefByLevel = 3,
                    Portrait = "fighter.png"
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
                    DefByLevel = 2,
                    Portrait = "thief.png"
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
                    DefByLevel = 2,
                    Portrait = "cleric.png"
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
                    DefByLevel = 2,
                    Portrait = "mage.png"
                }
            },
        };

    }
}
