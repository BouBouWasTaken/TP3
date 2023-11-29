using System.Windows;

namespace tp3_prog
{
    public partial class PartyWindow : Window
    {

        public PartyWindow(Party party)
        {
            InitializeComponent();

            // Créer dynamiquement les UserControls, passer les objets nécessaires en paramètre au UserControl
            PanelPartyMembers.Children.Clear();

            for (int i = 0; i < party.Members.Count; i++)
            {
                var userControlPartyMember = new UserControlPartyMember(party.Members[i]);
                PanelPartyMembers.Children.Add(userControlPartyMember);
            }

        }
    }
}
