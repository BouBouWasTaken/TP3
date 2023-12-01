
namespace tp3_prog
{
    public class Skill
    {
        public Classe Classe { get; set; }
        public string Name { get; set; }
        public int LevelRequired { get; set; }
        public int MagicPoints { get; set; }
        public MagicEffectType Type { get; set; }
        public MagicTarget Targets { get; set; }
        public double Multiplier { get; set; }
    }
}
