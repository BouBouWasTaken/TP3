using System.Collections.Generic;

namespace tp3_prog
{
    internal class Fight
    {
        // When a fight breaks out, this is called and generates it.

        public Fight(Party heroes, TypeCombat type)
        {
            Heroes = heroes;
            Enemies = generateEnemies();
            Type = type;
        }

        // Function that will make the rounds one after the other and concludes when it's done

        public EnemyGroup generateEnemies()
        {
            List<Enemy> newList = new List<Enemy>();

            EnemyGroup enemies = new EnemyGroup(newList);

            return enemies;
        }

        public Party Heroes { get; set; }

        public EnemyGroup Enemies { get; set; }

        public bool Finished { get; set; }
        public TypeCombat Type { set; get; }
    }
}
