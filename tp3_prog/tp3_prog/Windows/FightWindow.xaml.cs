﻿using System;
using System.Collections.Generic;
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
        private bool initialisation_Panel = true;
        private new int TabIndex = 4;
        private Hero? CurrentHero = null;
        private readonly Random Random = new Random();
        private List<Characters> Sliced_Initiative = new List<Characters>();
        private string Log = "";
        private int Log_Target_Counter = 0;


        Skill SelectedSkill => (Skill)ListViewSkills.SelectedItem;
        Item SelectedItem => (Item)ListViewItems.SelectedItem;
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

            ListViewLog.Items.Clear();

            SetInitiative();
            Fighting();
        }

        private void RefreshPanelEnemies()
        {
            if (Monsters == null) return;

            PanelEnemies.Children.Clear();

            for (int i = 0; i < Monsters.Enemies_Party.Count; i++)
            {
                if (initialisation_Panel)
                {
                    Monsters.Enemies_Party[i].Current_HP = Monsters.Enemies_Party[i].Max_Hp;
                    Monsters.Enemies_Party[i].Current_MP = Monsters.Enemies_Party[i].Max_MP;
                }
                if (Monsters.Enemies_Party[i].Current_HP > 1)
                {
                    var userControlEnemy = new UserControlEnemy(Monsters.Enemies_Party[i]);
                    PanelEnemies.Children.Add(userControlEnemy);
                }
            }

            if (PanelEnemies.Children.Count == 0)
            {
                Close();
            }
            initialisation_Panel = false;
        }

        private void ButtonItem_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null) return;
            if (SelectedItem is Usable usable)
            {
                List<int> targets = FindMyTarget(usable.Target);

                if (targets.Count == 0) return;

                // TODO :: REMOVE ITEM FROM INVENTORY

                DealingDamage_Item(targets);
                Fighting();
            }
        }

        private void DealingDamage_Item(List<int> targets)
        {
            // If it's damage, we call the function
            if (SelectedItem is Usable usable)
            {
                if (usable.EffectType == MagicEffectType.Damage)
                {
                    ItemAttack(targets);
                }
                // Else if it's healing
                else if (usable.EffectType == MagicEffectType.HealHp)
                {
                    ItemHeal(targets);
                }
                // Else if it's ManaRegen
                else
                {
                    ItemManaRegen(targets);
                }
            }
        }

        private void ItemManaRegen(List<int> targets)
        {
            // I NEED A HERO!
            if (SelectedItem == null) return;

            // For every 'int'
            foreach (int target in targets)
            {
                if (SelectedItem is Usable usable)
                {
                    int mana = usable.Power;
                    if (Initiative[target] is Hero hero)
                    {
                        // Regens the mana
                        hero.Current_MagicPoints += mana;
                        if (hero.Current_MagicPoints > hero.MagicPoints)
                        {
                            hero.Current_MagicPoints = hero.MagicPoints;
                        }
                    }
                    LogPrintItem(target, mana);
                }
            }
        }

        private void ItemHeal(List<int> targets)
        {
            // Is there a hero
            if (SelectedItem == null) return;

            // You get what it does
            foreach (int target in targets)
            {
                if (SelectedItem is Usable usable)
                {

                    int heal = usable.Power;
                    if (Initiative[target] is Hero hero)
                    {
                        // It heals the amount
                        hero.Current_Health += heal;
                        if (hero.Current_Health > hero.Health)
                        {
                            hero.Current_Health = hero.Health;
                        }
                    }
                    LogPrintItem(target, heal);
                }
            }


        }

        private void ItemAttack(List<int> targets)
        {
            // Is there a hero
            if (SelectedItem == null) return;

            // Foreach int in my list
            foreach (int target in targets)
            {
                if (SelectedItem is Usable usable)
                {
                    int damage = usable.Power;
                    // If the character in the initiative at the 'int' is an enemy
                    if (Initiative[target] is Enemy enemy)
                    {
                        // Deals the damage
                        if (damage > enemy.Def)
                        {
                            damage -= enemy.Def;
                            enemy.Current_HP -= damage;
                            TakeAwayItem();
                        }
                    }
                    LogPrintItem(target, damage);
                }
            }
            RemoveDeadPeople();
        }

        private void TakeAwayItem()
        {
            if (Party == null) return;

            foreach (ItemInventory item in Party.Inventory)
            {
                if (item.Item == SelectedItem)
                {
                    item.Amount--;
                }
            }

            List<ItemInventory> itemsToRemove = new List<ItemInventory>();

            foreach (ItemInventory item in Party.Inventory)
            {
                if (item.Amount == 0)
                {
                    itemsToRemove.Add(item);
                }
            }

            foreach (ItemInventory item in itemsToRemove)
            {
                Party.Inventory.Remove(item);
            }
        }

        private void LogPrintItem(int target, int amount)
        {
            if (SelectedItem is Usable usable)
            {
                if (usable.EffectType == MagicEffectType.Damage)
                {
                    if (Log_Target_Counter == 0)
                    {
                        Log = $"Round {Rounds} - {CurrentHero} used {SelectedItem} and dealt {amount} damage to ";
                        Log_Target_Counter++;
                    }

                    if (Log_Target_Counter > 1)
                    {
                        Log += $", {Initiative[target]}";
                        Log_Target_Counter++;
                    }
                    else
                    {
                        Log += $"{Initiative[target]}";
                        Log_Target_Counter++;
                    }
                }
                else if (usable.EffectType == MagicEffectType.HealHp)
                {
                    if (Log_Target_Counter == 0)
                    {
                        Log = $"Round {Rounds} - {CurrentHero} used {SelectedItem} and healed {amount} health to ";
                    }

                    if (Log_Target_Counter > 1)
                    {
                        Log += $"{Initiative[target]},";
                    }
                    else
                    {
                        Log += $"{Initiative[target]}";
                    }

                }
                else
                {
                    if (Log_Target_Counter == 0)
                    {
                        Log = $"Round {Rounds} - {CurrentHero} used {SelectedItem} and gave {amount} mana to ";
                    }

                    if (Log_Target_Counter > 1)
                    {
                        Log += $"{Initiative[target]},";
                    }
                    else
                    {
                        Log += $"{Initiative[target]}";
                    }
                }
            }
        }

        private void ButtonSkill_Click(object sender, RoutedEventArgs e)
        {
            // Is there a selectedSkill
            if (SelectedSkill == null) return;
            if (CurrentHero == null) return;

            if (CurrentHero.Current_MagicPoints >= SelectedSkill.MagicPoints)
            {
                // Creates a list of int to find where in my initiative my targets are
                List<int> targets = FindMyTarget(SelectedSkill.Targets);

                // If it doesn't give me any targets, we fucked
                if (targets.Count == 0) return;

                DealingDamage_Skill(targets);
                Fighting();
                return;
            }
            MessageBox.Show("Not enough MagicPoints", "Fuck");
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
                int mana = (int)(CurrentHero.Attack * multiplier);
                if (Initiative[target] is Hero hero)
                {
                    // Regens the mana
                    hero.Current_MagicPoints += mana;
                    if (hero.Current_MagicPoints > hero.MagicPoints)
                    {
                        hero.Current_MagicPoints = hero.MagicPoints;
                    }
                }
                LogPrintSkill(target, mana);
            }
        }

        private void SkillHeal(List<int> targets, double multiplier)
        {
            // Is there a hero
            if (CurrentHero == null) return;

            // You get what it does
            foreach (int target in targets)
            {
                int heal = (int)(CurrentHero.Attack * multiplier);

                if (Initiative[target] is Hero hero)
                {
                    // It heals the amount
                    hero.Current_Health += heal;
                    if (hero.Current_Health > hero.Health)
                    {
                        hero.Current_Health = hero.Health;
                    }
                }

                LogPrintSkill(target, heal);
            }
        }

        private void LogPrintSkill(int target, int amount)
        {
            if (SelectedSkill.Type == MagicEffectType.Damage)
            {
                if (Log_Target_Counter == 0)
                {
                    Log = $"Round {Rounds} - {CurrentHero} used {SelectedSkill} and dealt {amount} damage to ";
                }

                if (Log_Target_Counter > 1)
                {
                    Log += $"{Initiative[target]},";
                }
                else
                {
                    Log += $"{Initiative[target]}";
                }
            }
            else if (SelectedSkill.Type == MagicEffectType.HealHp)
            {
                if (Log_Target_Counter == 0)
                {
                    Log = $"Round {Rounds} - {CurrentHero} used {SelectedSkill} and healed {amount} health to ";
                }

                if (Log_Target_Counter > 1)
                {
                    Log += $"{Initiative[target]},";
                }
                else
                {
                    Log += $"{Initiative[target]}";
                }

            }
            else
            {
                if (Log_Target_Counter == 0)
                {
                    Log = $"Round {Rounds} - {CurrentHero} used {SelectedSkill} and gave {amount} mana to ";
                }

                if (Log_Target_Counter > 1)
                {
                    Log += $"{Initiative[target]},";
                }
                else
                {
                    Log += $"{Initiative[target]}";
                }
            }
        }

        private void SkillAttack(List<int> targets, double multiplier)
        {
            // Is there a hero
            if (CurrentHero == null) return;

            int damage = (int)(CurrentHero.Attack * multiplier);

            // Foreach int in my list
            foreach (int target in targets)
            {
                // If the character in the initiative at the 'int' is an enemy
                if (Initiative[target] is Enemy enemy)
                {
                    // Deals the damage
                    if (damage > enemy.Def)
                    {
                        damage -= enemy.Def;
                        enemy.Current_HP -= damage;
                        CurrentHero.Current_MagicPoints -= SelectedSkill.MagicPoints;
                    }
                }
                LogPrintSkill(target, damage);
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
                        int randomNb = Random.Next(0, Initiative.Count);
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
                        int randomNb = Random.Next(0, Initiative.Count);
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

            Log = $"Round {Rounds} - ";

            int nbOfMonsters = Monsters.Enemies_Party.Count;
            int target = Random.Next(0, nbOfMonsters++);
            Enemy enemy = Monsters.Enemies_Party[target];
            int damage = 0;

            if (CurrentHero.Attack > enemy.Def)
            {
                damage = CurrentHero.Attack - enemy.Def;
                enemy.Current_HP -= damage;
            }

            Log += $"{CurrentHero} attacked {enemy} for {damage}";

            Fighting();
        }

        private void Fighting()
        {
            // TODO :: GIVE EXP WHEN KILL THINGS

            RefreshPanelEnemies();

            // Updates the initiative for next turn
            UpdateInitiativeAndLogs();

            // Chnages information in the little screen
            UpdateCurrentHero();

            // Checks and enables the available buttons
            Buttons();

            Log = "";
            Log_Target_Counter = 0; ;
        }

        private void UpdateCurrentHero()
        {
            if (CurrentHero == null) return;

            TextBlockHeroHP.Text = $"HP: {CurrentHero.Current_Health}/{CurrentHero.Health}";
            TextBlockHeroMP.Text = $"MP: {CurrentHero.Current_MagicPoints}/{CurrentHero.MagicPoints}";
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
                // Deactivate it
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

        private void UpdateInitiativeAndLogs()
        {
            // TODO :: CHANGE IT SO IT'S ENEMY - PARTY - ENEMY - PARTY
            // TODO :: CHECK IF THERE'S SOMEONE DEAD, REMOVE IF SO 

            // Clear the ListView
            ListViewTurnOrder.Items.Clear();

            // Initialises it for the first time
            if (initialisation_Initiative)
            {
                for (int i = 0; i < 4; i++)
                {
                    Sliced_Initiative.Add(Initiative[i]);
                }

                initialisation_Initiative = false;


                HeroOrEnemy(Sliced_Initiative[0]);


                ShowInitiative(Sliced_Initiative);
                return;
            }
            else
            {

                // If the tab is over the total amount of characters,
                // reset it
                CheckIndex();

                if (ListViewLog.Items.Count > 2)
                {
                    ListViewLog.Items.RemoveAt(0);
                }

                ListViewLog.Items.Add(Log);

                Sliced_Initiative.Add(Initiative[TabIndex]);

                // TODO :: CHECK SO THEY DON'T PLAY RIGHT AFTER THE OTHER

                Sliced_Initiative.Remove(Sliced_Initiative[0]);

                RemoveDeadPeople();

                HeroOrEnemy(Sliced_Initiative[0]);

                // Show it
                ShowInitiative(Sliced_Initiative);
                TabIndex++;


            }
        }

        private void CheckIndex()
        {
            if (TabIndex >= Initiative.Count)
            {
                TabIndex = 0;
                Rounds++;
            }
        }

        private void RemoveDeadPeople()
        {
            if (Monsters == null) return;
            if (Party == null) return;

            List<Characters> dead_people = new List<Characters>();

            foreach (Characters character in Sliced_Initiative)
            {
                if (character is Hero hero)
                {
                    if (hero.Current_Health < 1)
                    {
                        dead_people.Add(character);
                        // We don't want to remove the hero from the party cuz he died
                    }
                }
                if (character is Enemy enemy)
                {
                    if (enemy.Current_HP < 1)
                    {
                        dead_people.Add(character);
                        Initiative.Remove(enemy);
                        Monsters.Enemies_Party.Remove((Enemy)character);
                    }
                }

            }

            foreach (Characters character in dead_people)
            {
                Sliced_Initiative.Remove(character);

            }

            while (Sliced_Initiative.Count != 4)
            {
                CheckIndex();
                Sliced_Initiative.Add(Initiative[TabIndex]);
                TabIndex++;
            }
        }

        private void HeroOrEnemy(Characters character)
        {
            if (character is Hero)
            {
                CurrentHero = (Hero)Sliced_Initiative[0];
            }
            else
            {
                MonsterAttack((Enemy)Sliced_Initiative[0]);
            }
        }



        private void MonsterAttack(Enemy monster)
        {

        }

        private void ShowInitiative(List<Characters> list)
        {
            // Since it was already cleared, we 
            // can just straight add it
            foreach (Characters character in list)
            {
                ListViewTurnOrder.Items.Add(character.Name);
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

            foreach (Enemy enemy in Monsters.Enemies_Party)
            {
                list.Add(enemy);
            }

            // Sort it as a "Random" initiative
            // TODO :: Sorting


            // Set my public list for it
            Initiative = list;
        }
    }
}
