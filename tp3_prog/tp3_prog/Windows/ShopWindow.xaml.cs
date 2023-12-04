using System;
using System.Windows;
using System.Windows.Controls;

namespace tp3_prog
{
    /// <summary>
    /// Window utilisé pour tous les types de Merchant/Crafter
    /// </summary>
    public partial class ShopWindow : Window
    {
        private ItemType SelectedItemType { get => (ItemType)ComboBoxType.SelectedItem; }
        // Fait Par Samuel Therrien-Côté
        public ShopWindow(Merchant merchant, Party party)
        {
            InitializeComponent();
            ActionsInitialisation();
            FillWindows(merchant, party);
        }

        private void FillWindows(Merchant merchant, Party party)
        {
            ComboBoxType.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(ItemType)))
            {
                ComboBoxType.Items.Add(item);
            }
            ComboBoxType.SelectedIndex = 0;

            // Items du merchant
            ListViewMerchant.Items.Clear();
            foreach (var item in merchant.Inventory)
            {
                ListViewMerchant.Items.Add(item);
            }
            // Items du player
            ListViewPlayer.Items.Clear();
            ListViewPlayer.Items.Add("Gold (" + party.Gold + ")");
            foreach (var item in party.Inventory)
            {
                ListViewPlayer.Items.Add(item);
            }
            TextBlockItemName.Text = "";
            TextBlockItemValue.Text = "";
            TextBlockItemType.Text = "";
            TextBoxAmount.Text = "1";
        }

        private void ButtonAmountMinus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {
                if (number > 0)
                {
                    number--;
                    TextBoxAmount.Text = number.ToString();
                }
            }
        }

        private void ButtonAmountPlus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxAmount.Text, out int number))
            {
                if (number < 999)
                {
                    number++;
                    TextBoxAmount.Text = number.ToString();
                }
            }
        }

        private void CheckboxBuyableOnly_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void ListViewPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ListViewMerchant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void ComboBoxType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        private void ButtonAction_Click(object sender, RoutedEventArgs e)
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
