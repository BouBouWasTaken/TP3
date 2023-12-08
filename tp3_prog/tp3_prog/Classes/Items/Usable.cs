namespace tp3_prog
{
    public class Usable : Item
    {
        public MagicEffectType EffectType { get; set; } // Damage, Heal
        public MagicTarget Target { get; set; } // User, RandomEnemy, AllEnemies

        public int Power { get; set; }

        public void Use()
        {
            if (CurrentOwner == null) return;

            // Enlever la potion de son inventaire.
            if (EffectType == MagicEffectType.HealHp && Target == MagicTarget.Self)
            {
                CurrentOwner.Health += Value;
            }
            else
            {
                // Call a function that redirects the effect
                // Attack(Target, Value);
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}

