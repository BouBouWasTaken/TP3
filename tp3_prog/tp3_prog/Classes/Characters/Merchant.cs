using System.Collections.Generic;

namespace tp3_prog
{
    public class MerchantStore : Characters
    {
        public List<ItemInventory> Inventory = new();
        public double WeaponMult { get; set; }
        public double ArmorMult { get; set; }
        public double OtherMult { get; set; }
    }
}