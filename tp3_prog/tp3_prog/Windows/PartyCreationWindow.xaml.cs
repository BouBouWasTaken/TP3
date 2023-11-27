using System.Windows;

namespace tp3_prog
{
    public partial class PartyCreationWindow : Window
    {
        public PartyCreationWindow()
        {
            InitializeComponent();
            ButtonStart.Click += ButtonStart_Click;
            // Créer dynamiquement les UserControls, passer les objets nécessaires en paramètre au UserControl
            PanelPartyCreations.Children.Clear();

            for (int i = 0; i < DefaultData.Classes.Count; i++)
            {
                var userControlPartyCreation = new UserControlPartyCreation(DefaultData.Classes[i]);
                PanelPartyCreations.Children.Add(userControlPartyCreation);
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
