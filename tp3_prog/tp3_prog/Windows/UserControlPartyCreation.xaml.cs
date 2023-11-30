using System.Collections.Generic;
using System.Windows.Controls;

namespace tp3_prog
{
    public partial class UserControlPartyCreation : UserControl
    {
        private readonly List<Classe> ClassesList = new();
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
            if (classe.Portrait != null)
            {
                ImagePortrait.Source = App.GetImage(classe.Portrait);

            }
        }
        public Hero CreateHero()
        {
            Hero newHero = new(
                    name: TextBoxName.Text,
                    classe: classe,
                    level: 1,
                    experience: 0,
                    health: classe.HpByLevel,
                    magicPoints: classe.MpByLevel,
                    attack: classe.AtkByLevel,
                    defense: classe.DefByLevel
                    );
            return newHero;

        }

    }
}
