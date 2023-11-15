using System.Collections.Generic;

namespace tp3_prog
{
    public class Hero : Characters
    {
        public Classe Classe { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int MagicPoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public List<Equipment> Equipment { get; set; } = new List<Equipment>();

    }
}
