namespace tp3_prog
{

    public class Item
    {
        public int Id { get; set; } // 3201832
        public string? Name { get; set; } // X's sword
        public int Price { get; set; } // 5 Golds
        public int Amount { get; set; }
        public string? Description { get; set; }
        public Hero? CurrentOwner { get; set; } // Who owns it
        public int Value { get; set; }

        public virtual void Sell()
        {

        }

        public virtual void Buy(Hero hero)
        {

        }

        public override string ToString()
        {
            return $"{Name} ({Amount})";
        }

    }


}
