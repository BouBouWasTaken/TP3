using System.Windows;

namespace _3C4_TP2
{
    public partial class PartyWindow : Window
    {
        public PartyWindow()
        {
            InitializeComponent();

            // Créer dynamiquement les UserControls, passer les objets nécessaires en paramètre au UserControl
            PanelPartyMembers.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                var userControlPartyMember = new UserControlPartyMember();
                PanelPartyMembers.Children.Add(userControlPartyMember);
            }
        }
    }
}
