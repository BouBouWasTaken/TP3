using System;
using System.Collections.Generic;
using System.Windows;

namespace tp3_prog
{
    public partial class InventoryWindow : Window
    {
        Hero SelectedHero { get; set; }
        EquipmentSlot SelectedEquipmentSlot => (EquipmentSlot)ComboBoxType.SelectedItem;

        Item SelectedItem => (Item)ListViewPlayer.SelectedItem;

        public InventoryWindow(Hero hero)
        {
            InitializeComponent();

            ComboBoxType.Items.Clear();

            // Fill the 'Item Type' comboBox
            foreach (EquipmentSlot slot in Enum.GetValues(typeof(EquipmentSlot)))
            {
                ComboBoxType.Items.Add(slot);
            }

            // Fill the Listview with the party's inventory
            foreach (Item item in hero.Inventory)
            {
                ListViewPlayer.Items.Add(item);
            }

            // For the searchBar
            TextBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            ComboBoxType.SelectionChanged += ComboBoxType_SelectionChanged;
            ListViewPlayer.SelectionChanged += ListViewPlayer_SelectionChanged;

            // Can access to it everywhere
            SelectedHero = hero;

            // Changes the hero's name in the header
            TextBlockTitle.Text = hero.Name;

            // Starting index
            ComboBoxType.SelectedIndex = 0;
            ListViewPlayer.SelectedIndex = 0;

        }

        private void ListViewPlayer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TextBlockItemName.Text = SelectedItem.Name;
            TextBlockItemValue.Text = SelectedItem.Price.ToString();
            // TextBlockItemDescription.Text = SelectedItem.Description;
            // TextBlockItemType.Text = SelectedItem.Slot;
        }

        private void ComboBoxType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (SelectedEquipmentSlot == EquipmentSlot.All)
            {
                RefreshInventory(SelectedHero.Inventory);
                return;
            }

            List<Item> newSelection = new List<Item>();

            foreach (Item item in SelectedHero.Inventory)
            {
                if (item is Equipment equipment && equipment.Slot == SelectedEquipmentSlot)
                {
                    newSelection.Add(item);
                }
            }

            RefreshInventory(newSelection);
        }

        // Refresh selection with what written in the TextBoxSearch
        private void TextBoxSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Checks if there's a hero
            if (SelectedHero == null) return;

            if (TextBoxSearch.Text != null)
            {
                RefreshInventory(SelectedHero.Inventory, TextBoxSearch.Text);
            }
            else
            {
                RefreshInventory(SelectedHero.Inventory);
            }

        }

        private void RefreshInventory(List<Item> inventory, string condition = "")
        {
            ListViewPlayer.Items.Clear();

            // For every item in his inventory
            foreach (Item item in inventory)
            {
                // If the item's name contains what's in the SearchBar
                if (item.Name.Contains(condition))
                {

                    // add it to the list
                    ListViewPlayer.Items.Add(item);
                }
            }
        }
    }
}
