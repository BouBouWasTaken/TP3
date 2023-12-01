using System.Collections.Generic;
using System.Windows;

namespace tp3_prog
{
    // Fait Par Samuel Therrien-Côté

    public partial class PartyWindow : Window
    {
        List<UserControlPartyMember> windowsList = new();
        public PartyWindow(Party party)
        {
            InitializeComponent();
            ButtonUnequip.Click += ButtonUnequip_Click;
            Title = "Current Party";
            // Créer dynamiquement les UserControls, passer les objets nécessaires en paramètre au UserControl
            PanelPartyMembers.Children.Clear();

            for (int i = 0; i < party.Members.Count; i++)
            {
                var userControlPartyMember = new UserControlPartyMember(party.Members[i]);
                PanelPartyMembers.Children.Add(userControlPartyMember);
                windowsList.Add(userControlPartyMember);
            }

        }

        private void ButtonUnequip_Click(object sender, RoutedEventArgs e)
        {
        }
        public void Refresh()
        {
            foreach (var window in windowsList)
            {
                window.FillWindow();
            }
        }
    }
}
