using System;
using System.Collections.Generic;
using System.Windows;

namespace tp3_prog
{
    public partial class InventoryWindow : Window
    {
        Party Party { get; set; }
        EquipmentSlot SelectedEquipmentSlot => (EquipmentSlot)ComboBoxType.SelectedItem;
        Item SelectedItem => (Item)ListViewPlayer.SelectedItem;
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
                foreach (Item item in Party.Inventory)
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
                // Make the hero the currentOwner
                SelectedItem.CurrentOwner = SelectedHeroToEquip;
                // TODO :: if it's equipement, add it to the hero's equipment list and make him equip it
                // therefore changing his stats.
            }
        }

        private void ListViewPlayer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // If there's no selected item
            if (SelectedItem == null) return;

            // Change the infos
            TextBlockItemName.Text = SelectedItem.Name;
            TextBlockItemValue.Text = SelectedItem.Price.ToString();
            TextBlockItemDescription.Text = SelectedItem.Description;

            // if it's equipement
            if (SelectedItem is Equipment item)
            {
                // Add the more specific infos
                TextBlockItemType.Text = "Equipement - ";
                TextBlockItemType.Text += $"{item.Type} - ";

                /*  required_class is a list of Int so you have to compare the int with the classes to find the names
                foreach (Classe classe in item.Required_Class)
                {
                    TextBlockItemType.Text += $"{classe.Name} ";
                }
                */
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
            List<Item> newSelection = new();

            // Foreach item that respects the new type
            foreach (Item item in Party.Inventory)
            {
                if (item is Equipment equipment && equipment.Type == SelectedEquipmentSlot)
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

        private void RefreshInventory(List<Item> inventory, string condition = "")
        {
            // TODO :: Make it so that the refresh respects both the condition from the 
            // searchBar AND the type.

            // Clears my inventory
            ListViewPlayer.Items.Clear();
            int count = 0;
            // For every item in his inventory
            foreach (Item item in inventory)
            {
                // If the item's name contains what's in the SearchBar
                if (item.Name.Contains(condition))
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
