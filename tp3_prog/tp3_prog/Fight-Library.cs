using System.Collections.Generic;

namespace tp3_prog
{
    internal class Fight_Library
    {
        public void SkillManaRegen(List<int> targets, double multiplier)
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

        public void SkillHeal(List<int> targets, double multiplier)
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

        public void SkillAttack(List<int> targets, double multiplier)
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


        public void DealingDamage_Skill(List<int> targets, MagicEffectType type, double multiplier)
        {
            // If it's damage, we call the function
            if (type == MagicEffectType.Damage)
            {
                SkillAttack(targets, multiplier);
            }
            // Else if it's healing
            else if (type == MagicEffectType.HealHp)
            {
                SkillHeal(targets, multiplier);
            }
            // Else if it's ManaRegen
            else
            {
                SkillManaRegen(targets, multiplier);
            }
        }
    }
}
