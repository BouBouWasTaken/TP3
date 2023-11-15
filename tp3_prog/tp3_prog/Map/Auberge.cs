using System.Collections.Generic;

namespace tp3_prog
{
    public class Auberge
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
        public int Cost { get; set; }
        public int LifeRegen { get; set; }
        public int MpRegen { get; set; }

    }


}
