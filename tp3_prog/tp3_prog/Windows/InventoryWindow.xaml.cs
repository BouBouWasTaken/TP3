using System;
using System.Collections.Generic;
using System.Windows;

namespace tp3_prog
{
    public partial class InventoryWindow : Window
    {
        Party Party { get; set; }
        EquipmentSlot SelectedEquipmentSlot => (EquipmentSlot)ComboBoxType.SelectedItem;
        ItemInventory SelectedItem => (ItemInventory)ListViewPlayer.SelectedItem;
        Hero SelectedHeroToEquip => (Hero)ListViewPartyMembers.SelectedItem;

        public InventoryWindow(Party party)
        {
            InitializeComponent();

            ComboBoxType.Items.Clear();
            ListViewPartyMembers.Items.Clear();

            // Fill the 'Item Type' comboBox
            foreach (EquipmentSlot slot in Enum.GetValues(typeof(EquipmentSlot)))
            {
                ComboBoxType.Items.Add(slot);
            }

            // Give the methods to the Texts/ Buttons
            TextBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            ComboBoxType.SelectionChanged += ComboBoxType_SelectionChanged;
            ListViewPlayer.SelectionChanged += ListViewPlayer_SelectionChanged;
            ButtonEquip.Click += ButtonEquip_Click;

            // Ease the access to the party's inventory
            Party = party;

            // Fill the Listview with the party's inventory
            foreach (Hero member in Party.Members)
            {
                ListViewPartyMembers.Items.Add(member);
                foreach (ItemInventory item in Party.Inventory)
                {
                    ListViewPlayer.Items.Add(item);
                }
            }

            // Starting index
            ComboBoxType.SelectedIndex = 0;
            ListViewPlayer.SelectedIndex = 0;
            ListViewPartyMembers.SelectedIndex = 0;

        }

        private void ButtonEquip_Click(object sender, RoutedEventArgs e)
        {
            // If there's a selected hero and an item
            if (SelectedHeroToEquip != null && SelectedItem != null)
            {
                // TODO :: if it's equipement, add it to the hero's equipment list and make him equip it
                // therefore changing his stats.
                if (SelectedItem.Item is Equipment equipment)
                {
                    //SelectedHeroToEquip.Equipment.Add(SelectedItem.Item as Equipment);
                    equipment.Equip(SelectedHeroToEquip);
                    SelectedItem.Amount--;
                }
                else if (SelectedItem.Item is Usable)
                {
                    SelectedHeroToEquip.AddUsable(SelectedItem.Item, 1);
                    SelectedItem.Amount--;
                }
            }
            ListViewPlayer.Items.Clear();
            foreach (ItemInventory item in Party.Inventory)
            {
                if (item.Amount == 0)
                {
                    Party.Inventory.Remove(item);
                    break;
                }
            }
            foreach (ItemInventory item in Party.Inventory)
            {
                ListViewPlayer.Items.Add(item);
            }
        }

        private void ListViewPlayer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // If there's no selected item
            if (SelectedItem == null) return;

            // Change the infos
            TextBlockItemName.Text = SelectedItem.Item.Name;
            TextBlockItemValue.Text = SelectedItem.Item.Value > 1 ? $"{SelectedItem.Item.Value} Golds" : $"{SelectedItem.Item.Value} Gold";
            TextBlockItemDescription.Text = SelectedItem.Item.Description;

            RefreshMyDetails();

        }

        private void RefreshMyDetails()
        {
            // if it's equipement
            if (SelectedItem.Item is Equipment equipment)
            {
                // Add the more specific infos
                TextBlockItemType.Text = "Equipement - ";
                TextBlockItemType.Text += $"{equipment.Type} - ";

                foreach (Classe classe in equipment.Required_Class)
                {
                    TextBlockItemType.Text += $"{classe.Name} ";
                }
            }
            else if (SelectedItem.Item is Usable usable)
            {
                TextBlockItemType.Text = "Usable -";
                TextBlockItemType.Text += $"\n{usable.EffectType} ({usable.Power}) on {usable.Target}";
            }
            else if (SelectedItem.Item is Component)
            {
                TextBlockItemType.Text = "Component -";
            }
        }

        private void ComboBoxType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // If the type is All, show all
            if (SelectedEquipmentSlot == EquipmentSlot.All)
            {
                RefreshInventory(Party.Inventory);
                return;
            }

            // else make a new selection
            List<ItemInventory> newSelection = new();

            // Foreach item that respects the new type
            foreach (ItemInventory item in Party.Inventory)
            {
                if (item.Item is Equipment equipment && equipment.Type == SelectedEquipmentSlot)
                {
                    newSelection.Add(item);
                }
            }

            // Refresh the inventory with the new selection
            RefreshInventory(newSelection);
        }

        private void TextBoxSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Checks if there's a party
            if (Party == null) return;

            // If there's something in the searchBar
            if (TextBoxSearch.Text != null)
            {
                RefreshInventory(Party.Inventory, TextBoxSearch.Text);
            }
            // if there's nothing in the searchBar
            else
            {
                RefreshInventory(Party.Inventory);
            }

        }

        private void RefreshInventory(List<ItemInventory> inventory, string condition = "")
        {
            // TODO :: Make it so that the refresh respects both the condition from the 
            // searchBar AND the type.

            // Clears my inventory
            ListViewPlayer.Items.Clear();
            int count = 0;
            // For every item in his inventory
            foreach (ItemInventory item in inventory)
            {
                if (item.Item.Name == null) continue;
                // If the item's name contains what's in the SearchBar
                if (item.Item.Name.Contains(condition))
                {
                    // Increments a count
                    count++;
                    // add it to the list
                    ListViewPlayer.Items.Add(item);
                }
            }

            // Informs the player on how many items results his search / conditions
            TextBlockPlayer.Text = $"Party inventory : {count}/{Party.Inventory.Count}";
        }
    }
}
