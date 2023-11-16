using System.Collections.Generic;

namespace tp3_prog
{
    public class Recipie
    {
        public string Name { get; set; }
        public List<Component> Components { get; set; } = new List<Component>();
    }
}
