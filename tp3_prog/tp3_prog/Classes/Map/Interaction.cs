using System.Collections.Generic;
using System.Linq;

namespace tp3_prog
{
    public class Interaction
    {
        public Zone Zone { get; set; }
        public string Name { get; set; }
        public int InteractionId { get; set; }

        public List<Line> Lines => DefaultData.Lines.Values.Where(x => x.InteractionId == InteractionId).ToList();

        public Interaction(int id, Zone zone, string name)
        {
            InteractionId = id;
            Zone = zone;
            Name = name;
        }


        public override string ToString()
        {
            if (Name != null)
                return Name;

            return "";
        }



    }
}
