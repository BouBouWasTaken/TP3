namespace tp3_prog
{

    public class Item
    {
        public int Id { get; set; } // 3201832
        public string? Name { get; set; } // X's sword
        public int Price { get; set; } // 5 Golds
        public string? Description { get; set; }
        public Hero? CurrentOwner { get; set; } // Who owns it
        public int Value { get; set; }
    }


}
