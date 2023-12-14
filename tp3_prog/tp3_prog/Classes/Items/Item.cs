namespace tp3_prog
{

    public class Item
    {
        public string Name { get; set; } = ""; // X's sword
        public string? Description { get; set; }
        public Hero? CurrentOwner { get; set; } // Who owns it
        public int Value { get; set; }
    }


}
