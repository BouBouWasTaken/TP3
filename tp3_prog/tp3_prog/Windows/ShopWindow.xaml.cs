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
        string BuyOrSell = "";

        private Merchant currentMerchant = new();
        private Party currentParty;
        public ShopWindow(Merchant merchant, Party party)
        {

            InitializeComponent();
            currentParty = party;
            this.currentMerchant = merchant;
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
            // Items du merchant
            ListViewMerchant.Items.Clear();
            foreach (var item in currentMerchant.Inventory)
            {
                if (SelectedItemType == ItemType.All)
                {
                    ListViewMerchant.Items.Add(item);
                    itemsShown++;
                }
                else if (SelectedItemType == ItemType.Equipement)
                {
                    if (item.Item is Equipment)
                    {
                        ListViewMerchant.Items.Add(item);
                        itemsShown++;
                    }
                }
                else if (SelectedItemType == ItemType.Usable)
                {
                    if (item.Item is Usable)
                    {
                        ListViewMerchant.Items.Add(item);
                        itemsShown++;
                    }
                }
                else if (SelectedItemType == ItemType.Component)
                {
                    if (item.Item is Component)
                    {
                        ListViewMerchant.Items.Add(item);
                        itemsShown++;
                    }
                }
                merchantInventoryCount++;
            }
            TextBlockMerchant.Text = "Merchant Inventory (" + itemsShown + "/" + merchantInventoryCount + ") ";

        }

        private void PlayerInventory()
        {
            // Items du player
            int playerInventoryCount = 1;
            int itemsShown = 1;
            ListViewPlayer.Items.Clear();
            ListViewPlayer.Items.Add("Gold (" + currentParty.Gold + ")");
            foreach (var item in currentParty.Inventory)
            {
                if (SelectedItemType == ItemType.All)
                {
                    ListViewPlayer.Items.Add(item);
                    itemsShown++;
                }
                else if (SelectedItemType == ItemType.Equipement)
                {
                    if (item.Item is Equipment)
                    {
                        ListViewPlayer.Items.Add(item);
                        itemsShown++;
                    }
                }
                else if (SelectedItemType == ItemType.Usable)
                {
                    if (item.Item is Usable)
                    {
                        ListViewPlayer.Items.Add(item);
                        itemsShown++;
                    }
                }
                else if (SelectedItemType == ItemType.Component)
                {
                    if (item.Item is Component)
                    {
                        ListViewPlayer.Items.Add(item);
                        itemsShown++;
                    }
                }
                playerInventoryCount++;
            }
            TextBlockPlayer.Text = "Player Inventory (" + itemsShown + "/" + playerInventoryCount + ") ";

        }

        private void ButtonAmountMinus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {
                if (SelectedItem != null)
                {
                    if (number > 0)
                    {
                        number--;
                        TextBoxAmount.Text = number.ToString();
                    }
                }
            }
            calculateTotal();
        }


        private void ButtonAmountPlus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {
                if (SelectedItem != null)
                {
                    if (number <= SelectedItem.Amount)
                    {
                        number++;
                        TextBoxAmount.Text = number.ToString();
                    }
                }
            }
            calculateTotal();
        }



        private void ListViewPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewPlayer.SelectedItem is ItemInventory)
            {

                SelectedItem = (ItemInventory)ListViewPlayer.SelectedItem;
                BuyOrSell = "Sell ";
                calculateTotal();
                WriteItemInfos();
            }
        }

        private void ListViewMerchant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMerchant.SelectedItem is ItemInventory)
            {
                SelectedItem = (ItemInventory)ListViewMerchant.SelectedItem;
                BuyOrSell = "Buy ";
                calculateTotal();
                WriteItemInfos();
            }
        }

        private void WriteItemInfos()
        {
            if (SelectedItem != null)
            {

                TextBlockItemName.Text = SelectedItem.Item.Name;
                TextBlockItemValue.Text = SelectedItem.Item.Value.ToString() + " gold";
                TextBlockItemType.Text = SelectedItem.Item.Description; // Fix this
            }
        }

        private void calculateTotal()
        {
            int amount = 0;
            int price = 0;
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {
                amount = number;
            }
            if (SelectedItem is ItemInventory)
            {
                price = SelectedItem.Item.Value * amount;

            }
            ButtonAction.Content = BuyOrSell + " (" + price + " gold)";

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
        }
        private void CheckboxBuyableOnly_Checked(object sender, RoutedEventArgs e)
        {
        }
        private void ActionsInitialisation()
        {
            ComboBoxType.SelectionChanged += ComboBoxType_SelectionChanged;
            ButtonAction.Click += ButtonAction_Click;
            TextBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            ListViewMerchant.SelectionChanged += ListViewMerchant_SelectionChanged;
            ListViewPlayer.SelectionChanged += ListViewPlayer_SelectionChanged;
            CheckboxBuyableOnly.Checked += CheckboxBuyableOnly_Checked;
            ButtonAmountPlus.Click += ButtonAmountPlus_Click;
            ButtonAmountMinus.Click += ButtonAmountMinus_Click;

        }
    }
}
