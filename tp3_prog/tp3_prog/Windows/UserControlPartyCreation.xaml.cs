using System.Windows.Controls;
using tp3_prog.Classes.Characters;

namespace tp3_prog
{
    public partial class UserControlPartyCreation : UserControl
    {
        private Classe classe;


        public UserControlPartyCreation(Classe classe)
        {
            InitializeComponent();
            this.classe = classe;
            FillWindow(classe);
        }

        private void FillWindow(Classe classe)
        {
            TextBoxName.Text = classe.Name;
            TextBlockHP.Text += classe.HpByLevel.ToString();
            TextBlockMP.Text += classe.MpByLevel.ToString();
            TextBlockAttack.Text += classe.AtkByLevel.ToString();
            TextBlockDefense.Text += classe.DefByLevel.ToString();
        }
    }
}
