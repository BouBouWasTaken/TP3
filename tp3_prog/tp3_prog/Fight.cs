using System.Collections.Generic;

namespace tp3_prog
{
    public class Fight
    {
        public List<Hero> Heroes { get; set; } = new List<Hero>();

        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public int Rounds { get; set; }
        public bool Finished { get; set; }
        public TypeCombat Type { set; get; }
    }
}