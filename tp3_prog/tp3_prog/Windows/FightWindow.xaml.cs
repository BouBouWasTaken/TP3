using System.Windows;

namespace tp3_prog
{
    public partial class FightWindow : Window
    {
        public FightWindow()
        {
            InitializeComponent();

            // Exemple pour créer dynamiquement des UserControls
            PanelEnemies.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                var userControlEnemy = new UserControlEnemy();
                PanelEnemies.Children.Add(userControlEnemy);
            }
        }
    }
}
