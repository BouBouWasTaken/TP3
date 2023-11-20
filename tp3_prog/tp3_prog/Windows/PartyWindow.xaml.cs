using System.Windows;

namespace tp3_prog
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
