using System.Windows.Controls;

namespace tp3_prog
{
    public partial class UserControlEnemy : UserControl
    {
        private readonly Enemy Enemy;
        public UserControlEnemy(Enemy enemy)
        {
            InitializeComponent();
            Enemy = enemy;
            FillWindow();
        }

        private void FillWindow()
        {
            TextBoxName.Text = Enemy.Name;
            TextBlockHP.Text = $"HP: {Enemy.Current_HP}/{Enemy.Max_Hp}";
            TextBlockLevel.Text = $"LVL: {Enemy.Level}";
            TextBlockMP.Text = $"MP: {Enemy.Current_MP}/{Enemy.Max_MP}";
            TextBlockDefense.Text = $"DEF: {Enemy.Def}";
            TextBlockAttack.Text = $"LVL: {Enemy.Atk}";
        }
    }
}
