using System.Collections.Generic;
using System.Windows.Controls;
using tp3_prog.Classes.Characters;

namespace tp3_prog
{
    public partial class UserControlPartyCreation : UserControl
    {
        private List<Classe> ClassesList = new List<Classe>();
        private Classe classe;
        private int currentIndex = 0;

        public UserControlPartyCreation(Classe classe)
        {
            foreach (var item in DefaultData.Classes.Values)
            {
                ClassesList.Add(item);
            }
            InitializeComponent();
            ButtonClassNext.Click += ButtonClassNext_Click;
            ButtonClassPrevious.Click += ButtonClassPrevious_Click;
            this.classe = classe;
            FillWindow(classe);
        }

        private void ButtonClassPrevious_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentIndex = (currentIndex - 1 + ClassesList.Count) % ClassesList.Count;
            classe = ClassesList[currentIndex];
            FillWindow(classe);
        }

        private void ButtonClassNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentIndex = (currentIndex + 1) % ClassesList.Count;
            classe = ClassesList[currentIndex];
            FillWindow(classe);
        }

        private void FillWindow(Classe classe)
        {
            TextBoxName.Text = classe.Name;
            TextBlockHP.Text = "HP: " + classe.HpByLevel.ToString();
            TextBlockMP.Text = "HP: " + classe.MpByLevel.ToString();
            TextBlockAttack.Text = "HP: " + classe.AtkByLevel.ToString();
            TextBlockDefense.Text = "HP: " + classe.DefByLevel.ToString();
        }
    }
}
