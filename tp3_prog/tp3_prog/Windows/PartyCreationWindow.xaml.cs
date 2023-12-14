using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace tp3_prog
{
    // Fait Par Samuel Therrien-Côté

    public partial class PartyCreationWindow : Window
    {
        private readonly List<UserControlPartyCreation> windowsList = new();
        private readonly List<Hero> heroList = new();
        private readonly List<Classe> ClassesPossibles = new();
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



            // Test

            List<Enemy> enemyList = new()
            {
                DefaultData.Enemies["Skeleton"],
                DefaultData.Enemies["Bandit"],
                DefaultData.Enemies["Ogre"]
            };

            EnemyGroup enemyGroup = new(enemyList);

            Window fighting = new FightWindow(newParty, enemyGroup);
            fighting.Show();

            Close();
        }
    }
}
