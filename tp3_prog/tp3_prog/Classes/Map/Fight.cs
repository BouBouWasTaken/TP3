using System.Collections.Generic;

namespace tp3_prog
{
    public class Fight
    {
        public EnemyGroup EnemyGroup { get; set; }
        public bool Killed = false;

        public int FightId { get; set; }

        public Fight(int id, List<Enemy> list)
        {
            FightId = id;
            EnemyGroup = new EnemyGroup(list);
        }

    }
}