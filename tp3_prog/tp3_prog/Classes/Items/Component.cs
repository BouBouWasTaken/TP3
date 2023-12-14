namespace tp3_prog
{
    public class Component : Item
    {
        public override string ToString()
        {
            if (Name == null) return string.Empty;
            return Name;
        }

    }
}
