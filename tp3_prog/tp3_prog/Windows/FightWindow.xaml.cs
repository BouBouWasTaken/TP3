using System;
using System.Collections.Generic;
using System.Windows;

namespace tp3_prog
{
    public partial class FightWindow : Window
    {
        private readonly Party Party;
        private readonly EnemyGroup Monsters;
        private int Rounds = 1;
        private List<Characters> Initiative = new List<Characters>();
        private bool initialisation_Initiative = true;
        private int TabIndex = 5;
        public FightWindow(Party party, EnemyGroup enemyGroup)
        {
            if (enemyGroup == null) return;
            if (party == null) return;

            Party = party;
            Monsters = enemyGroup;

            InitializeComponent();

            // Exemple pour créer dynamiquement des UserControls
            PanelEnemies.Children.Clear();

            for (int i = 0; i < Monsters.Enemies_Party.Count; i++)
            {
                var userControlEnemy = new UserControlEnemy(Monsters.Enemies_Party[i]);
                PanelEnemies.Children.Add(userControlEnemy);
            }

            SetInitiative();
            Fighting();
        }

        private void Fighting()
        {

            // Updates the initiative for next turn
            UpdateInitiative();
            // Changes the number to announce next turn
            Rounds++;
        }

        private void UpdateInitiative()
        {
            // Clear the ListView
            ListViewTurnOrder.Items.Clear();

            // Create my next list
            List<String> list = new List<String>();

            // Initialises it for the first time
            if (initialisation_Initiative)
            {
                for (int i = 0; i < 4; i++)
                {
                    list.Add(Initiative[i].Name);
                }

                initialisation_Initiative = false;
                return;
            }

            // If the tab is over the total amount of characters,
            // reset it
            if (TabIndex > Initiative.Count)
            {
                TabIndex = 0;
            }

            // removes the first element/player who just played
            list.RemoveAt(0);
            // add the fourth player who's on deck
            list.Add(Initiative[TabIndex].Name);

            // Show it
            ShowInitiative(list);

        }

        private void ShowInitiative(List<string> list)
        {
            // Since it was already cleared, we 
            // can just straight add it
            foreach (string name in list)
            {
                ListViewTurnOrder.Items.Add(name);
            }
        }

        private void SetInitiative()
        {
            // Creates a list
            List<Characters> list = new List<Characters>();

            // Put every hero in the list
            foreach (Hero hero in Party.Members)
            {
                list.Add(hero);
            }
            // Put every monster in the list
            foreach (Enemy enemy in Monsters.Enemies_Party)
            {
                list.Add(enemy);
            }

            // Sort it as a "Random" initiative
            list.Sort();

            // Set my public list for it
            Initiative = list;
        }
    }
}
