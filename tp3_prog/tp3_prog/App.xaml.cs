using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
}
