using System.Collections.Generic;

namespace tp3_prog
{

    public class Enemy : Characters
    {
        public int Level { get; set; }
        public int Max_Hp { get; set; }
        public int Current_HP { get; set; }
        public int Atk { get; set; }
        public int Max_MP { get; set; }
        public int Current_MP { get; set; }
        public int Def { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }
        public double Drop_Chance { get; set; }

        public Enemy()
        {
            Current_HP = Max_Hp;

        }
        public List<Component> Drop_Items { get; set; } = new();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
