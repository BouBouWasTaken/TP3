using System.Collections.Generic;

namespace tp3_prog.Combat
{
    internal class EnemyGroup
    {
        public EnemyGroup(List<Enemy> enemies)
        {
            Enemies_Party = enemies;
        }

        public List<Enemy> Enemies_Party { get; set; }

        // Any function that concernes a party, much like targetting the entire party.
    }
}
