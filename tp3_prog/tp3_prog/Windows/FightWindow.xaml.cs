using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace tp3_prog
{
    public partial class FightWindow : Window
    {
        private readonly Party? Party;
        private readonly EnemyGroup? Monsters;
        private int Rounds = 1;
        private List<Characters> Initiative = new List<Characters>();
        private bool initialisation_Initiative = true;
        private new int TabIndex = 5;
        private Hero? CurrentHero = null;
        private readonly Random Random = new Random();
        private Fight_Library Fight_Library = new();
        Skill SelectedSkill => (Skill)ListViewSkills.SelectedItem;
        Usable SelectedItem => (Usable)ListViewItems.SelectedItem;
        public FightWindow(Party party, EnemyGroup enemyGroup)
        {
            if (enemyGroup == null) return;
            if (party == null) return;

            Party = party;
            Monsters = enemyGroup;

            InitializeComponent();
            ButtonAttack.Click += ButtonAttack_Click;
            ButtonSkill.Click += ButtonSkill_Click;
            ButtonItem.Click += ButtonItem_Click;

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

        private void ButtonItem_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null) return;

            List<int> targets = FindMyTarget(SelectedItem.Target);
            if (targets.Count == 0) return;

            DealingDamage_Item(targets);
        }

        private void DealingDamage_Item(List<int> targets)
        {
            // If it's damage, we call the function
            if (SelectedSkill.Type == MagicEffectType.Damage)
            {
                ItemAttack(targets, SelectedSkill.Multiplier);
            }
            // Else if it's healing
            else if (SelectedSkill.Type == MagicEffectType.HealHp)
            {
                ItemHeal(targets, SelectedSkill.Multiplier);
            }
            // Else if it's ManaRegen
            else
            {
                ItemManaRegen(targets, SelectedSkill.Multiplier);
            }
        }

        private void ItemManaRegen(List<int> targets, double multiplier)
        {
            // I NEED A HERO!
            if (SelectedItem == null) return;

            // For every 'int'
            foreach (int target in targets)
            {
                if (Initiative[target] is Hero hero)
                {
                    // Regens the mana
                    int mana = (int)(SelectedItem.Value * multiplier);
                    hero.Current_MagicPoints += mana;
                    if (hero.Current_MagicPoints > hero.MagicPoints)
                    {
                        hero.Current_MagicPoints = hero.MagicPoints;
                    }
                }
            }
        }

        private void ItemHeal(List<int> targets, double multiplier)
        {
            // Is there a hero
            if (SelectedItem == null) return;

            // You get what it does
            foreach (int target in targets)
            {
                if (Initiative[target] is Hero hero)
                {
                    // It heals the amount
                    int heal = (int)(SelectedItem.Value * multiplier);
                    hero.Current_Health += heal;
                    if (hero.Current_Health > hero.Health)
                    {
                        hero.Current_Health = hero.Health;
                    }
                }
            }
        }

        private void ItemAttack(List<int> targets, double multiplier)
        {
            // Is there a hero
            if (SelectedItem == null) return;

            // Foreach int in my list
            foreach (int target in targets)
            {
                // If the character in the initiative at the 'int' is an enemy
                if (Initiative[target] is Enemy enemy)
                {
                    // Deals the damage
                    int damage = (int)(SelectedItem.Value * multiplier);
                    enemy.Current_HP -= damage;
                }
            }
        }

        private void ButtonSkill_Click(object sender, RoutedEventArgs e)
        {
            // Is there a selectedSkill
            if (SelectedSkill == null) return;

            // Creates a list of int to find where in my initiative my targets are
            List<int> targets = FindMyTarget(SelectedSkill.Targets);

            // If it doesn't give me any targets, we fucked
            if (targets.Count == 0) return;

            DealingDamage_Skill(targets);
        }

        private void DealingDamage_Skill(List<int> targets)
        {
            // If it's damage, we call the function
            if (SelectedSkill.Type == MagicEffectType.Damage)
            {
                SkillAttack(targets, SelectedSkill.Multiplier);
            }
            // Else if it's healing
            else if (SelectedSkill.Type == MagicEffectType.HealHp)
            {
                SkillHeal(targets, SelectedSkill.Multiplier);
            }
            // Else if it's ManaRegen
            else
            {
                SkillManaRegen(targets, SelectedSkill.Multiplier);
            }
        }

        private void SkillManaRegen(List<int> targets, double multiplier)
        {
            // I NEED A HERO!
            if (CurrentHero == null) return;

            // For every 'int'
            foreach (int target in targets)
            {
                if (Initiative[target] is Hero hero)
                {
                    // Regens the mana
                    int mana = (int)(CurrentHero.Attack * multiplier);
                    hero.Current_MagicPoints += mana;
                    if (hero.Current_MagicPoints > hero.MagicPoints)
                    {
                        hero.Current_MagicPoints = hero.MagicPoints;
                    }
                }
            }
        }

        private void SkillHeal(List<int> targets, double multiplier)
        {
            // Is there a hero
            if (CurrentHero == null) return;

            // You get what it does
            foreach (int target in targets)
            {
                if (Initiative[target] is Hero hero)
                {
                    // It heals the amount
                    int heal = (int)(CurrentHero.Attack * multiplier);
                    hero.Current_Health += heal;
                    if (hero.Current_Health > hero.Health)
                    {
                        hero.Current_Health = hero.Health;
                    }
                }
            }
        }

        private void SkillAttack(List<int> targets, double multiplier)
        {
            // Is there a hero
            if (CurrentHero == null) return;

            // Foreach int in my list
            foreach (int target in targets)
            {
                // If the character in the initiative at the 'int' is an enemy
                if (Initiative[target] is Enemy enemy)
                {
                    // Deals the damage
                    int damage = (int)(CurrentHero.Attack * multiplier);
                    enemy.Current_HP -= damage;
                }
            }
        }

        private List<int> FindMyTarget(MagicTarget target)
        {
            List<int> list = new List<int>();

            if (!(Party == null) && !(Monsters == null))
            {

                if (target == MagicTarget.AllEnemies)
                {
                    for (int i = 0; i < Initiative.Count; i++)
                    {
                        if (Initiative[i] is Enemy)
                        {
                            list.Add(i);
                        }
                    }

                }

                if (target == MagicTarget.Self)
                {
                    for (int i = 0; i < Initiative.Count; i++)
                    {
                        if (Initiative[i] == CurrentHero)
                        {
                            list.Add(i);
                        }
                    }
                }

                if (target == MagicTarget.AllAllies)
                {
                    for (int i = 0; i < Initiative.Count; i++)
                    {
                        if (Initiative[i] is Hero)
                        {
                            list.Add(i);
                        }
                    }
                }

                if (target == MagicTarget.RandomAlly)
                {
                    while (true)
                    {
                        int randomNb = Random.Next(0, Party.Members.Count);
                        if (Initiative[randomNb] is Hero)
                        {
                            list.Add(randomNb);
                            break;
                        }
                    }
                }

                if (target == MagicTarget.RandomEnemy)
                {
                    while (true)
                    {
                        int randomNb = Random.Next(0, Party.Members.Count);
                        if (Initiative[randomNb] is Enemy)
                        {
                            list.Add(randomNb);
                            break;
                        }
                    }
                }
            }

            return list;
        }

        private void ButtonAttack_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentHero == null) return;
            if (Monsters == null) return;


            int nbOfMonsters = Monsters.Enemies_Party.Count + 1;
            int target = Random.Next(0, nbOfMonsters);
            Monsters.Enemies_Party[target].Current_HP -= CurrentHero.Attack;

        }

        private void Fighting()
        {
            // Checks and enables the available buttons
            Buttons();
            // Chnages information in the little screen
            UpdateCurrentHero();

            // Updates the initiative for next turn
            UpdateInitiative();



            // Changes the number to announce next turn
            Rounds++;
        }

        private void UpdateCurrentHero()
        {
            if (CurrentHero == null) return;

            TextBlockHeroHP.Text = $"{CurrentHero.Current_Health}/{CurrentHero.Health}";
            TextBlockHeroMP.Text = $"{CurrentHero.Current_MagicPoints}/{CurrentHero.MagicPoints}";
            TextBlockHeroName.Text = CurrentHero.Name;
        }

        private void Buttons()
        {
            CheckSkills();

            CheckInventory();
        }

        private void CheckInventory()
        {
            if (Party == null) return;

            ListViewItems.Items.Clear();

            // If he doesn't have items 
            if (Party.Inventory.Count == 0)
            {
                // Deactivate it
                ButtonItem.IsEnabled = false;
            }
            else
            {
                // Active it
                ButtonItem.IsEnabled = true;
                FillItemsList();
            }
        }

        private void CheckSkills()
        {
            if (CurrentHero == null) return;

            ListViewSkills.Items.Clear();

            // If he doesn't have skills or no points to spare
            if (CurrentHero.MagicPoints == 0 || CurrentHero.Skills.Count == 0)
            {
                // Deativate it
                ButtonSkill.IsEnabled = false;
            }
            else
            {
                // Activate it
                ButtonSkill.IsEnabled = true;
                FillSkillList();
            }
        }

        private void FillItemsList()
        {
            if (Party == null) return;

            foreach (ItemInventory item in Party.Inventory)
            {
                if (item.Item is Usable)
                {
                    ListViewItems.Items.Add(item.Item);
                }
            }
        }

        private void FillSkillList()
        {
            if (CurrentHero == null) return;

            foreach (Skill skill in CurrentHero.Skills)
            {
                ListViewSkills.Items.Add(skill);
            }
        }

        private void UpdateInitiative()
        {
            // TODO :: CHANGE IT SO IT'S ENEMY - PARTY - ENEMY - PARTY
            // TODO :: CHECK IF THERE'S SOMEONE DEAD, REMOVE IF SO 

            // Clear the ListView
            ListViewTurnOrder.Items.Clear();

            // Create my next list
            List<string> list = new();

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

            try
            {
                // Might crash since if it's an enemy at '0', it won't be able to convert it
                CurrentHero = (Hero)Initiative.Where(x => x.Name == list[0]);
            }
            catch { }

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
            if (Party == null) return;
            if (Monsters == null) return;

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
