using System.Windows.Controls;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for UserControlPartyMember.xaml
    /// </summary>
    public partial class UserControlPartyMember : UserControl
    {
        // Fait Par Samuel Therrien-Côté

        Hero CurrentHero { get; set; }
        public UserControlPartyMember(Hero hero)
        {
            InitializeComponent();
            CurrentHero = hero;
            FillWindow();
        }

        public void FillWindow()
        {
            TextBlockLevel.Text = "Lv. " + CurrentHero.Level.ToString();
            TextBlockExperience.Text = "Xp: " + CurrentHero.Experience.ToString() + "/ 100";
            TextBlockName.Text = CurrentHero.Name;
            TextBlockHP.Text = "HP: " + CurrentHero.Health.ToString();
            TextBlockMP.Text = "MP: " + CurrentHero.MagicPoints.ToString();
            TextBlockAttack.Text = "ATK: " + CurrentHero.Attack.ToString();
            TextBlockDefense.Text = "DEF: " + CurrentHero.Defense.ToString();
            if (CurrentHero.Classe.Portrait != null)
            {
                ImagePortrait.Source = App.GetImage(CurrentHero.Classe.Portrait);
            }
            ListViewEquipments.Items.Clear();

            FillListView(CurrentHero);
        }

        private void FillListView(Hero hero)
        {
            if (hero.Equipment != null)
            {

                foreach (var item in hero.Equipment)
                {
                    ListViewEquipments.Items.Add(item);
                }
            }
            if (hero.Usables != null)
            {

                foreach (var item in hero.Usables)
                {
                    ListViewEquipments.Items.Add(item);
                }
            }
        }
    }
}
