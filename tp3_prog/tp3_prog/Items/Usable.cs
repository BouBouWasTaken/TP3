namespace tp3_prog
{
    public class Usable : Item
    {
        public MagicEffectType EffectType { get; set; } // Damage, Heal
        public MagicTarget Target { get; set; } // User, RandomEnemy, AllEnemies

        public int Value { get; set; }

        public void Use()
        {
            if (CurrentOwner == null) return;

            // Enlever la potion de son inventaire.
            if (EffectType == MagicEffectType.Heal && Target == MagicTarget.User)
            {
                CurrentOwner.Health += Value;
            }
            else
            {
                // Attack(Target, Value);
            }
            // Call a function that redirects the effect
        }

    }
}

