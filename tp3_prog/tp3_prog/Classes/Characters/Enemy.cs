using System.Collections.Generic;

namespace tp3_prog
{

    public class Enemy : Characters
    {
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }
        public double Drop_Chance { get; set; }
        public List<string> Drop_Items { get; set; } = new List<string>();
    }
}
