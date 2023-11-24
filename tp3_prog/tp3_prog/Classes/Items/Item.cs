namespace tp3_prog
{

    public class Item
    {
        public int Id { get; set; } // 3201832
        public string? Name { get; set; } // X's sword
        public int Price { get; set; } // 5 Golds
        public Hero? CurrentOwner { get; set; } // Who owns it
        public int Amount { get; set; }

        // Now it's easier to access the guy's inventory. ^^^


        public virtual void Sell()
        {
            if (CurrentOwner != null)
            {
                foreach (Item item in CurrentOwner.Inventory)
                {
                    if (item == this)
                    {
                        // Enleve l'item de l'inventaire du hero
                        CurrentOwner.Inventory.Remove(this);
                        // Rajoute le gold
                        CurrentOwner.Gold += item.Price;
                    }
                }
            }
        }

        public virtual void Buy(Hero hero)
        {
            if (hero != null)
            {
                if (hero.Gold > Price)
                {
                    // I take his gold
                    hero.Gold -= Price;
                    // I give the item
                    hero.Inventory.Add(this);
                    // The owner is now the hero!
                    CurrentOwner = hero;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Amount})";
        }

    }


}
