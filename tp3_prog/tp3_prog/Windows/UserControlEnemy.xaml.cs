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
            TextBlockHP.Text = $"{Enemy.Current_HP}/{Enemy.Max_Hp}";
            TextBlockLevel.Text = Enemy.Level.ToString();
            TextBlockMP.Text = $"{Enemy.Current_MP}/{Enemy.Max_MP}";
            TextBlockDefense.Text = Enemy.Def.ToString();
            TextBlockAttack.Text = Enemy.Atk.ToString();
        }
    }
}
