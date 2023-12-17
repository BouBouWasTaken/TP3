using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace tp3_prog
{
    // Fait Par Samuel Therrien-Côté

    public partial class PartyWindow : Window
    {
        private readonly Party party;
        private readonly List<UserControlPartyMember> windowsList = new();
        public PartyWindow(Party party)
        {
            InitializeComponent();
            this.party = party;
            ButtonUnequip.Click += ButtonUnequip_Click;
            RefreshData.Click += RefreshData_Click;

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
            foreach (var window in windowsList)
            {
                ListView listView = window.ListViewEquipments;

                if (listView.SelectedItem != null)
                {
                    if (listView.SelectedItem is Equipment equipment)
                    {
                        //window.CurrentHero.Equipment.Remove(equipment);
                        equipment.Unequip(window.CurrentHero);
                        party.Inventory.Add(new ItemInventory(equipment, 1));
                    }
                    if (listView.SelectedItem is ItemInventory itemInv)
                    {
                        window.CurrentHero.RemoveUsable((Usable)itemInv.Item, 1);
                        party.AddItem((Usable)itemInv.Item, 1);
                    }
                }
            }
            Refresh();
        }
        public void Refresh()
        {
            foreach (var window in windowsList)
            {
                window.FillWindow();
            }
        }


        // To test Shop window since we're not there yet
        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            /*Test for the shop window
            // ShopWindow Test with Merchant
            Merchant merchant = DefaultData.Merchants["Basic Armorsmith"];
            Window shopWindow = new ShopWindow(merchant, this.party);

            // ShopWindow Test with Crafter
            //Crafter newCrafter = DefaultData.Crafters[1];
            //Window shopWindow = new ShopWindow(newCrafter, this.party);
            shopWindow.Show();
            */
        }
    }
}
