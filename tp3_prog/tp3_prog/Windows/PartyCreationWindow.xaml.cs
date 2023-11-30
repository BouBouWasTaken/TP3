using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace tp3_prog
{
    public partial class PartyCreationWindow : Window
    {
        List<UserControlPartyCreation> windowsList = new List<UserControlPartyCreation>();
        List<Hero> heroList = new List<Hero>();
        List<Classe> ClassesPossibles = new List<Classe>();
        public PartyCreationWindow()
        {
            InitializeComponent();
            ButtonStart.Click += ButtonStart_Click;
            // Créer dynamiquement les UserControls, passer les objets nécessaires en paramètre au UserControl
            PanelPartyCreations.Children.Clear();
            ClassesPossibles = DefaultData.Classes.Values.ToList();
            for (int i = 0; i < DefaultData.Classes.Count; i++)
            {
                var userControlPartyCreation = new UserControlPartyCreation(ClassesPossibles[i]);
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
