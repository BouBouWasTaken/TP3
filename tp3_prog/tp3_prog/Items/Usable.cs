namespace tp3_prog
{
    public partial class App
    {
        public class Usable : Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public string EffectType { get; set; }
            public int Target { get; set; }
            public int EffectValue { get; set; }
        }
    }


}
