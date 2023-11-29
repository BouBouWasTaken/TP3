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
            TextBoxName.Text = hero.Name;
            TextBlockHP.Text = "HP: " + hero.Health.ToString();
            TextBlockMP.Text = "HP: " + hero.MagicPoints.ToString();
            TextBlockAttack.Text = "HP: " + hero.Attack.ToString();
            TextBlockDefense.Text = "HP: " + hero.Defense.ToString();
            if (hero.Classe.Portrait != null)
            {
                ImagePortrait.Source = App.GetImage(hero.Classe.Portrait);

            }
        }
    }
}
