using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace tp3_prog
{
    public partial class LocationWindow : Window
    {
        Zone SelectedZone;
        Party Party { get; set; }
        Interaction SelectedInteraction => (Interaction)ListViewInteractables.SelectedItem;
        bool beatenBandit = false;
        bool beatenGoblins = false;
        public LocationWindow(Zone zone, Party party)
        {
            currentParty = party;
            InitializeComponent();
            SelectedZone = zone;
            SelectedZone.Discovered = true;
            Party = party;

            ListViewInteractables.Items.Clear();

            ListViewInteractables.SelectionChanged += ListViewInteractables_SelectionChanged;

            Refresh();
        }

        private void Refresh(bool deleteEvents = false)
        {
            TextBlockLocationName.Text = SelectedZone.Name;

            ListViewInteractables.Items.Clear();

            Interaction signs = new Interaction(999, SelectedZone, "Sign");
            ListViewInteractables.Items.Add(signs);
            foreach (Interaction interaction in SelectedZone.Interactions)
            {
                ListViewInteractables.Items.Add(interaction);
            }

            ListViewInteractables.SelectedIndex = 0;

        }

        private void EventDeleter()
        {
            ButtonAction1.Click -= GoingNorth;
            ButtonAction1.Click -= Talk;
            ButtonAction2.Click -= GoingSouth;
            ButtonAction2.Click -= PeasantRumors;
            ButtonAction2.Click -= BasicWeaponOpenShop;
            ButtonAction3.Click -= GoingEast;
            ButtonAction4.Click -= GoingWest;

            ButtonAction2.Click -= BasicWeaponOpenShop;

            ButtonAction2.Click -= CrafterOpenShop;

            ButtonAction2.Click -= RangerRumors;

            ButtonAction2.Click -= AdvancedCraftOpenShop;

            ButtonAction2.Click -= AdvancedCraftOpenShop;

            ButtonAction1.Click -= BanditTalk;
            ButtonAction2.Click -= BanditOpenFight;

            ButtonAction1.Click -= GoblinTalk;
            ButtonAction2.Click -= GoblinOpenFight;
        }


        private void ListViewInteractables_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (SelectedInteraction == null) return;

            OffAllButtons();
            EventDeleter();

            switch (SelectedInteraction.Name)
            {
                case "Sign":
                    SignButtonAssignement();
                    break;
                case "Peasant":
                    PeasantButtonAssignement();
                    break;
                case "Basic Weaponsmith":
                    BasicWeaponButtonAssignement();
                    break;
                case "Basic Armorsmith":
                    BasicArmorButtonAssignement();
                    break;
                case "Noob Town Crafter":
                    CrafterButtonAssignement();
                    break;
                case "Noob Inn":
                    InnButtonAssignement();
                    break;
                case "Ranger":
                    RangerButtonAssignement();
                    break;
                case "Advanced Smith":
                    AdvancedSmithButtonAssignement();
                    break;
                case "Adventurer City Crafter":
                    CrafterAdvancedButtonAssignement();
                    break;
                case "Bandit Gang":
                    BanditGangButtonAssignement();
                    break;
                case "Goblin Camp":
                    GoblersCampButtonAssignement();
                    break;
            }


        }

        private void GoblersCampButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;
            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = "Fight";
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += GoblinTalk;
            if (!beatenGoblins)
            {
                ButtonAction2.Click += GoblinOpenFight;
            }
        }

        private void GoblinOpenFight(object sender, RoutedEventArgs e)
        {
            List<Enemy> list = new List<Enemy>();
            for (int i = 0; i <= 3; i++)
            {

                Enemy enemy = DefaultData.Enemies.Values.FirstOrDefault(x => x.Name == "Goblin");
                if (enemy != null)
                {
                    list.Add(enemy);
                }
            }
            Enemy enemy1 = DefaultData.Enemies.Values.FirstOrDefault(x => x.Name == "Ogre");
            if (enemy1 != null)
            {
                list.Add(enemy1);
            }

            EnemyGroup enemyGroup = new EnemyGroup(list);
            Window window = new FightWindow(Party, enemyGroup);
            window.Show();
            beatenGoblins = true;
        }

        private void GoblinTalk(object sender, RoutedEventArgs e)
        {
            if (SelectedInteraction != null)
            {
                if (!beatenGoblins)
                {
                    TextBlockInteratableDescription.Text = SelectedInteraction.Lines[0].Result;
                }
                else
                {
                    TextBlockInteratableDescription.Text = SelectedInteraction.Lines[1].Result;
                }
            }
        }

        private void BanditGangButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;
            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = "Fight";
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += BanditTalk;

            if (!beatenBandit)
            {
                ButtonAction2.Click += BanditOpenFight;
            }
        }

        private void BanditOpenFight(object sender, RoutedEventArgs e)
        {
            List<Enemy> list = new List<Enemy>();
            for (int i = 0; i <= 4; i++)
            {
                Enemy enemy = DefaultData.Enemies.Values.FirstOrDefault(x => x.Name == "Bandit");
                if (enemy != null)
                    list.Add(enemy);
            }


            EnemyGroup enemyGroup = new EnemyGroup(list);
            Window window = new FightWindow(Party, enemyGroup);
            window.Show();
            beatenBandit = true;
        }

        private void BanditTalk(object sender, RoutedEventArgs e)
        {
            if (SelectedInteraction != null)
            {
                if (!beatenBandit)
                {
                    TextBlockInteratableDescription.Text = SelectedInteraction.Lines[0].Result;
                }
                else
                {
                    TextBlockInteratableDescription.Text = SelectedInteraction.Lines[1].Result;
                }
            }
        }

        private void CrafterAdvancedButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;
            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = "Shop";
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += Talk;
            ButtonAction2.Click += AdvancedCraftOpenShop;
        }

        private void AdvancedCraftOpenShop(object sender, RoutedEventArgs e)
        {
            Window window = new ShopWindow(DefaultData.Merchants.Values.ElementAt(4), Party);
            window.Show();
        }



        private void AdvancedSmithButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;
            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = "Shop";
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += Talk;
            ButtonAction2.Click += AdvancedSmithOpenShop;
        }

        private void AdvancedSmithOpenShop(object sender, RoutedEventArgs e)
        {
            Window window = new ShopWindow(DefaultData.Merchants.Values.ElementAt(2), Party);
            window.Show();
        }



        private void RangerButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;

            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = SelectedInteraction.Lines[1].Action;
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += Talk;
            ButtonAction2.Click += RangerRumors;
        }

        private void RangerRumors(object sender, RoutedEventArgs e)
        {
            if (SelectedInteraction != null)
            {
                TextBlockInteratableDescription.Text = SelectedInteraction.Lines[1].Result;
            }
        }



        private void InnButtonAssignement()
        {
            throw new NotImplementedException();
        }

        private void CrafterButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;
            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = "Shop";
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += Talk;
            ButtonAction2.Click += CrafterOpenShop;
        }

        private void CrafterOpenShop(object sender, RoutedEventArgs e)
        {
            Window window = new ShopWindow(DefaultData.Merchants.Values.ElementAt(2), Party);
            window.Show();
        }



        private void BasicArmorButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;
            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = "Shop";
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += Talk;
            ButtonAction2.Click += BasicArmorOpenShop;
        }

        private void BasicArmorOpenShop(object sender, RoutedEventArgs e)
        {
            Window window = new ShopWindow(DefaultData.Merchants.Values.ElementAt(1), Party);
            window.Show();
        }


        private void BasicWeaponButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;
            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = "Shop";
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += Talk;
            ButtonAction2.Click += BasicWeaponOpenShop;
        }


        private void BasicWeaponOpenShop(object sender, RoutedEventArgs e)
        {
            Window window = new ShopWindow(DefaultData.Merchants.Values.ElementAt(0), Party);
            window.Show();
        }

        private void PeasantButtonAssignement()
        {
            TextBlockInteratableName.Text = SelectedInteraction.Name;

            ButtonAction1.Content = SelectedInteraction.Lines[0].Action;
            ButtonAction2.Content = SelectedInteraction.Lines[1].Action;
            ButtonAction1.IsEnabled = true;
            ButtonAction2.IsEnabled = true;
            ButtonAction1.Click += Talk;
            ButtonAction2.Click += PeasantRumors;

        }

        private void PeasantRumors(object sender, RoutedEventArgs e)
        {
            if (SelectedInteraction != null)
            {
                TextBlockInteratableDescription.Text = SelectedInteraction.Lines[1].Result;

            }
        }

        private void Talk(object sender, RoutedEventArgs e)
        {
            if (SelectedInteraction != null)
            {
                TextBlockInteratableDescription.Text = SelectedInteraction.Lines[0].Result;
            }
        }

        private void SignButtonAssignement()
        {
            ButtonAction1.Content = "North";
            ButtonAction2.Content = "South";
            ButtonAction3.Content = "East";
            ButtonAction4.Content = "West";
            ButtonAction5.Content = "";
            ButtonAction6.Content = "";
            TextBlockInteratableDescription.Text = FillDirections();
            if (SelectedZone.North != null)
            {
                ButtonAction1.IsEnabled = true;
                ButtonAction1.Click += GoingNorth;
            }
            if (SelectedZone.South != null)
            {
                ButtonAction2.IsEnabled = true;
                ButtonAction2.Click += GoingSouth;
            }
            if (SelectedZone.East != null)
            {
                ButtonAction3.IsEnabled = true;
                ButtonAction3.Click += GoingEast;
            }
            if (SelectedZone.West != null)
            {
                ButtonAction4.IsEnabled = true;
                ButtonAction4.Click += GoingWest;
            }
        }

        private void GoingNorth(object sender, RoutedEventArgs e)
        {
            if (SelectedZone.North != null)
            {
                SelectedZone = SelectedZone.North;
                SelectedZone.Discovered = true;
                Refresh();
            }
        }
        private void GoingSouth(object sender, RoutedEventArgs e)
        {
            if (SelectedZone.South != null)
            {
                SelectedZone = SelectedZone.South;
                SelectedZone.Discovered = true;
                Refresh();
            }

        }
        private void GoingEast(object sender, RoutedEventArgs e)
        {
            if (SelectedZone.East != null)
            {
                SelectedZone = SelectedZone.East;
                SelectedZone.Discovered = true;
                Refresh();
            }
        }
        private void GoingWest(object sender, RoutedEventArgs e)
        {
            if (SelectedZone.West != null)
            {
                SelectedZone = SelectedZone.West;
                SelectedZone.Discovered = true;
                Refresh();
            }
        }

        private void OffAllButtons()
        {
            ButtonAction1.IsEnabled = false;
            ButtonAction2.IsEnabled = false;
            ButtonAction3.IsEnabled = false;
            ButtonAction4.IsEnabled = false;
            ButtonAction5.IsEnabled = false;
            ButtonAction6.IsEnabled = false;
        }

        private string FillDirections()
        {
            string result = "From here you can travel to : \n";
            if (SelectedZone.North != null)
            {
                result += $"North : {(SelectedZone.North.Discovered ? SelectedZone.North.Name : "???")}\n";
            }
            if (SelectedZone.South != null)
            {
                result += $"South : {(SelectedZone.South.Discovered ? SelectedZone.South.Name : "???")}\n";
            }
            if (SelectedZone.West != null)
            {
                result += $"West : {(SelectedZone.West.Discovered ? SelectedZone.West.Name : "???")}\n";
            }
            if (SelectedZone.East != null)
            {
                result += $"East : {(SelectedZone.East.Discovered ? SelectedZone.East.Name : "???")}\n";
            }
            return result;
        }

    }
}
