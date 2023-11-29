using System.Collections.Generic;
using System.Windows;

namespace tp3_prog
{
    public partial class PartyCreationWindow : Window
    {
        List<UserControlPartyCreation> windowsList = new List<UserControlPartyCreation>();
        List<Hero> heroList = new List<Hero>();
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
                windowsList.Add(userControlPartyCreation);

            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in windowsList)
            {
                heroList.Add(item.CreateHero());
            }

            Party newParty = new(heroList);

            Window windowLocation = new LocationWindow();
            windowLocation.Show();
            Window inventoryWindow = new InventoryWindow(newParty);
            inventoryWindow.Show();
            Window partyWindow = new PartyWindow(newParty);
            partyWindow.Show();
            Close();
        }
    }
}
