using System.Windows.Controls;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for UserControlPartyMember.xaml
    /// </summary>
    public partial class UserControlPartyMember : UserControl
    {
        public UserControlPartyMember(Hero hero)
        {
            InitializeComponent();
            FillWindow(hero);
        }

        private void FillWindow(Hero hero)
        {
            TextBlockLevel.Text = "Lv. " + hero.Level.ToString();
            TextBlockExperience.Text = "Xp: " + hero.Experience.ToString() + "/ 100";
            TextBlockName.Text = hero.Name;
            TextBlockHP.Text = "HP: " + hero.Health.ToString();
            TextBlockMP.Text = "HP: " + hero.MagicPoints.ToString();
            TextBlockAttack.Text = "HP: " + hero.Attack.ToString();
            TextBlockDefense.Text = "HP: " + hero.Defense.ToString();
            if (hero.Classe.Portrait != null)
            {
                ImagePortrait.Source = App.GetImage(hero.Classe.Portrait);
            }
            ListViewEquipments.Items.Clear();

            FillListView(hero);
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
