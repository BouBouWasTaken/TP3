namespace tp3_prog
{
    public class ItemInventory
    {
        public Item Item { get; set; }
        public int Amount { get; set; }

        public ItemInventory(Item item, int amount)
        {
            Item = item;
            Amount = amount;
        }
        public override string ToString()
        {
            return Item.Name + " ( " + Amount + " )";
        }
    }
}
