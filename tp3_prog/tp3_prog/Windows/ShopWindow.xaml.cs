using System;
using System.Windows;
using System.Windows.Controls;

namespace tp3_prog
{
    /// <summary>
    /// Window utilisé pour tous les types de Merchant/Crafter
    /// </summary>
    // Fait Par Samuel Therrien-Côté
    public partial class ShopWindow : Window
    {
        private ItemType SelectedItemType { get => (ItemType)ComboBoxType.SelectedItem; }
        ItemInventory? SelectedItem;
        private string Searchbox { get => TextBoxSearch.Text; }
        string BuyOrSell = "";

        private readonly Npc currentNpc = new();
        private readonly Party currentParty;
        private bool craftableOnly = false;
        public ShopWindow(Npc npc, Party party)
        {

            InitializeComponent();
            currentParty = party;
            currentNpc = npc;
            TextBlockTitle.Text = currentNpc.Name;
            ComboBoxType.Items.Clear();

            foreach (var item in Enum.GetValues(typeof(ItemType)))
            {
                ComboBoxType.Items.Add(item);
            }
            ComboBoxType.SelectedIndex = 0;
            TextBlockItemName.Text = "";
            TextBlockItemValue.Text = "";
            TextBlockItemType.Text = "";
            TextBoxAmount.Text = "1";
            ButtonAction.Content = "Buy / Sell";
            ActionsInitialisation();
            FillWindows();
        }

        private void FillWindows()
        {
            MerchantInventory();
            PlayerInventory();

        }

        private void MerchantInventory()
        {
            int merchantInventoryCount = 0;
            int itemsShown = 0;

            ListViewMerchant.Items.Clear();

            foreach (var item in currentNpc.Inventory)
            {
                bool isItemTypeMatch =
                    SelectedItemType == ItemType.All ||
                    (SelectedItemType == ItemType.Equipement && item.Item is Equipment) ||
                    (SelectedItemType == ItemType.Usable && item.Item is Usable) ||
                    (SelectedItemType == ItemType.Component && item.Item is Component) ||
                    (SelectedItemType == ItemType.Recipie && item.Item is Recipie);
                if (craftableOnly)
                {
                    if (item.Item is Recipie)
                    {
                        isItemTypeMatch = true;
                    }
                    else
                    {
                        isItemTypeMatch = false;
                    }
                }
                if (isItemTypeMatch)
                {
                    if (item.Item.Name.ToLower().Contains(Searchbox.ToLower()))
                    {

                        ListViewMerchant.Items.Add(item);
                        itemsShown++;
                    }
                }

                merchantInventoryCount++;
            }

            TextBlockMerchant.Text = $"Merchant Inventory ({itemsShown}/{merchantInventoryCount})";
        }

        private void PlayerInventory()
        {
            int playerInventoryCount = 1;
            int itemsShown = 1;

            ListViewPlayer.Items.Clear();
            ListViewPlayer.Items.Add($"Gold ({currentParty.Gold})");

            foreach (var item in currentParty.Inventory)
            {
                bool isItemTypeMatch =
                    SelectedItemType == ItemType.All ||
                    (SelectedItemType == ItemType.Equipement && item.Item is Equipment) ||
                    (SelectedItemType == ItemType.Usable && item.Item is Usable) ||
                    (SelectedItemType == ItemType.Component && item.Item is Component) ||
                    (SelectedItemType == ItemType.Recipie && item.Item is Recipie);

                if (isItemTypeMatch)
                {
                    if (item.Item.Name.ToLower().Contains(Searchbox.ToLower()))
                    {
                        ListViewPlayer.Items.Add(item);
                        itemsShown++;
                    }
                }

                playerInventoryCount++;
            }

            TextBlockPlayer.Text = $"Player Inventory ({itemsShown}/{playerInventoryCount})";
        }

        private void ButtonAmountMinus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {

                if (SelectedItem != null)
                {
                    if (SelectedItem.Item is Recipie)
                    {
                        TextBlockBroke.Text = "Only craft 1 at a time";
                    }
                    else if (number > 0)
                    {
                        number--;
                        TextBoxAmount.Text = number.ToString();
                    }
                }
            }
            WriteTotal();
        }


        private void ButtonAmountPlus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {
                if (SelectedItem != null)
                {
                    if (SelectedItem.Item is Recipie)
                    {
                        TextBlockBroke.Text = "Only craft 1 at a time";
                    }
                    else if (number < SelectedItem.Amount || SelectedItem.Amount == -1)
                    {
                        number++;
                        TextBoxAmount.Text = number.ToString();
                    }
                }
            }
            WriteTotal();
        }



        private void ListViewPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewPlayer.SelectedItem is ItemInventory inventory)
            {

                SelectedItem = inventory;
                BuyOrSell = "Sell ";
                TextBoxAmount.Text = "0";
                WriteTotal();
                WriteItemInfos();
            }
        }

        private void ListViewMerchant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMerchant.SelectedItem is ItemInventory inventory)
            {
                if (inventory.Item is Recipie)
                {
                    SelectedItem = inventory;
                    BuyOrSell = "Craft ";
                    TextBoxAmount.Text = "1";
                }
                else
                {

                    SelectedItem = inventory;
                    BuyOrSell = "Buy ";
                    TextBoxAmount.Text = "0";
                }
                WriteTotal();
                WriteItemInfos();
            }
        }

        private void WriteItemInfos()
        {
            TextBlockBroke.Text = "";
            string type = "";
            if (SelectedItem != null)
            {
                TextBlockItemName.Text = SelectedItem.Item.Name;
                TextBlockItemValue.Text = SelectedItem.Item.Value.ToString() + " gold";
                switch (SelectedItem.Item)
                {
                    case Usable:
                        type = "Usable- ";
                        TextBlockItemValue.Text = SelectedItem.Item.Value.ToString() + " gold";
                        break;
                    case Equipment:
                        type = "Equipment- ";
                        TextBlockItemValue.Text = SelectedItem.Item.Value.ToString() + " gold";
                        break;
                    case Component:
                        type = "Component- ";
                        TextBlockItemValue.Text = SelectedItem.Item.Value.ToString() + " gold";
                        break;
                    case Recipie:
                        type = "Recipie- ";
                        TextBlockItemValue.Text = "Ingredients:";
                        break;
                }
                TextBlockItemType.Text = type + SelectedItem.Item.ToString();



            }
        }
        private void WriteTotal()
        {
            int total = CalculateTotal();
            ButtonAction.Content = BuyOrSell + " (" + total + " gold)";

        }
        private int CalculateTotal()
        {

            int amount = 0;
            int price = 0;
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {
                amount = number;
            }
            if (SelectedItem is ItemInventory) // Have to check because of Gold
            {
                price = SelectedItem.Item.Value * amount;

            }
            return price;

        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillWindows();
        }

        private void ComboBoxType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FillWindows();
        }

        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            int amount = 0;
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {
                amount = number;
            }
            if (SelectedItem != null)
            {
                if (BuyOrSell == "Sell " && CalculateTotal() > 0)
                {
                    currentParty.Gold += CalculateTotal();
                    currentParty.RemoveItem(SelectedItem.Item, amount);
                    currentNpc.AddItem(SelectedItem.Item, amount);
                    TextBlockBroke.Text = "";
                    TextBoxAmount.Text = "0";
                }
                else if (BuyOrSell == "Buy " && CalculateTotal() > 0)
                {
                    if (currentParty.Gold >= CalculateTotal())
                    {
                        currentParty.Gold -= CalculateTotal();
                        currentParty.AddItem(SelectedItem.Item, amount);
                        currentNpc.RemoveItem(SelectedItem.Item, amount);
                        TextBlockBroke.Text = "";
                        TextBoxAmount.Text = "0";
                    }
                    else
                    {
                        TextBlockBroke.Text = "You do not have enough!";
                    }
                }
                else if (BuyOrSell == "Craft ")
                {
                    if (SelectedItem.Item is Recipie recipie)
                    {
                        if (recipie.HasIngredients(currentParty.Inventory))
                        {
                            currentParty.AddItem(recipie.ItemCrafted, recipie.AmountCrafted);

                            foreach (var item in recipie.Ingredients)
                            {
                                currentParty.RemoveItem(item.Item, item.Amount);
                            }
                            TextBlockBroke.Text = "Crafted!";
                        }
                        else
                        {
                            TextBlockBroke.Text = "Missing Ingredients!";
                        }
                    }
                }
            }
            FillWindows();
        }
        private void CheckboxBuyableOnly_Checked(object sender, RoutedEventArgs e)
        {
            // when checked, only recipies are shown
            if (craftableOnly == false)
            {
                craftableOnly = true;
            }
            else
            {
                craftableOnly = false;
            }
            FillWindows();
        }
        private void ActionsInitialisation()
        {
            ComboBoxType.SelectionChanged += ComboBoxType_SelectionChanged;
            ButtonAction.Click += ButtonAction_Click;
            TextBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            ListViewMerchant.SelectionChanged += ListViewMerchant_SelectionChanged;
            ListViewPlayer.SelectionChanged += ListViewPlayer_SelectionChanged;
            CheckboxBuyableOnly.Checked += CheckboxBuyableOnly_Checked;
            CheckboxBuyableOnly.Unchecked += CheckboxBuyableOnly_Checked;
            ButtonAmountPlus.Click += ButtonAmountPlus_Click;
            ButtonAmountMinus.Click += ButtonAmountMinus_Click;

        }
    }
}
