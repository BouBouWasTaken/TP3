using System.Windows;

namespace _3C4_TP2
{
    public partial class PartyCreationWindow : Window
    {
        public PartyCreationWindow()
        {
            InitializeComponent();

            // Créer dynamiquement les UserControls, passer les objets nécessaires en paramètre au UserControl
            PanelPartyCreations.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                var userControlPartyCreation = new UserControlPartyCreation();
                PanelPartyCreations.Children.Add(userControlPartyCreation);
            }
        }
    }
}
