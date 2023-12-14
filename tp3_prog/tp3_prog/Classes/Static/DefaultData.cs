using System.Collections.Generic;

namespace tp3_prog
{
    public static class DefaultData
    {
        public static Dictionary<int, Zone> Locations = new()
        {
            { 1 , new Zone("Noob Town", new List<int>() { 3, 0, 0, 2 }, 0)},
            { 2, new Zone("Slums", new List<int>() { 0, 0, 1, 0}, 0)},
            { 3, new Zone("Forest entrance", new List < int >() { 4, 1, 0, 0 }, 0) },
            { 4, new Zone("Forest crossroads", new List<int>() { 5, 3, 8, 0 }, 0) },
            { 5, new Zone("Dark Forest", new List <int>() { 0, 4, 6, 0 }, 0) },
            { 6, new Zone("Cemetary", new List<int>() { 7, 0, 0, 5 }, 0) },
            { 7, new Zone("Evil crypt", new List <int>() { 0, 6, 0, 0 }, 0) },
            { 8, new Zone("Adventurer City", new List < int >() { 6, 0, 0, 9 }, 0) },
            { 9, new Zone("Cave entrance", new List < int >() { 0, 10, 0, 8 }, 0) },
            { 10, new Zone("Cave", new List < int >() { 9, 11, 0, 0 }, 0) },
            { 11, new Zone("Dragon's Den", new List < int >() { 0, 0, 0, 1 }, 0) },
        };
        public static Dictionary<string, Classe> Classes = new()
        {
             {"Fighter",    new Classe(){Name = "Fighter",  HpByLevel = 10,MpByLevel = 3,   AtkByLevel = 2,DefByLevel = 3,Portrait = "fighter.png"}},
             {"Thief",      new Classe(){Name = "Thief",    HpByLevel = 8,MpByLevel = 3,    AtkByLevel = 3,DefByLevel = 2,Portrait = "thief.png"}},
             {"Cleric",     new Classe(){Name = "Cleric",   HpByLevel = 8,MpByLevel = 4,    AtkByLevel = 2,DefByLevel = 2,Portrait = "cleric.png"}},
             {"Mage",       new Classe(){Name = "Mage",     HpByLevel = 6,MpByLevel = 6,    AtkByLevel = 2,DefByLevel = 2,Portrait = "mage.png"}},
        };
        public static Dictionary<string, Skill> Skills = new()
        {
            {"Bash",            new Skill() { Classe = Classes["Fighter"], Name = "Bash",           LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomEnemy, Type= MagicEffectType.Damage, Multiplier = 1.5} },
            {"Rallying Shout",  new Skill() { Classe = Classes["Fighter"], Name = "Rallying Shout", LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllAllies,   Type= MagicEffectType.HealHp, Multiplier = 0.35} },
            {"Backstab",        new Skill() { Classe = Classes["Thief"],   Name = "Backstab",       LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomEnemy, Type= MagicEffectType.Damage, Multiplier = 1.75} },
            {"Fan of knives",   new Skill() { Classe = Classes["Thief"],   Name = "Fan of knives",  LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllEnemies,  Type= MagicEffectType.Damage, Multiplier = 0.5} },
            {"Heal",            new Skill() { Classe = Classes["Cleric"],  Name = "Heal",           LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomAlly,  Type= MagicEffectType.HealHp, Multiplier = 1} },
            {"Benediction",     new Skill() { Classe = Classes["Cleric"],  Name = "Benediction",    LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllAllies,   Type= MagicEffectType.HealHp, Multiplier = 0.5} },
            {"Fireball",        new Skill() { Classe = Classes["Mage"],    Name = "Fireball",       LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.AllEnemies,  Type= MagicEffectType.Damage, Multiplier = 0.5} },
            {"Meteor",          new Skill() { Classe = Classes["Mage"],    Name = "Meteor",         LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllEnemies,  Type= MagicEffectType.Damage, Multiplier = 0.75} },
        };
        public static Dictionary<string, Usable> Usables = new()
        {
            {"Health potion",   new Usable(){Name = "Health potion",Value = 25, Target = MagicTarget.Self,       EffectType = MagicEffectType.HealHp, Power = 10} },
            {"Mana potion",     new Usable(){Name = "Mana potion",  Value = 35, Target = MagicTarget.Self,       EffectType = MagicEffectType.HealMp, Power = 10} },
            {"Bomb",            new Usable(){Name = "Bomb",         Value = 50, Target = MagicTarget.AllEnemies, EffectType = MagicEffectType.Damage, Power = 15} },
            {"Shuriken",        new Usable(){Name = "Shuriken",     Value = 10, Target = MagicTarget.RandomEnemy,EffectType = MagicEffectType.Damage, Power = 10} }
        };
        public static Dictionary<string, Component> Components = new()
        {
            {"Bone",        new Component(){Name = "Bone",          Value = 5} },
            {"Cloth",       new Component(){Name = "Cloth",         Value = 5 } },
            {"Herb",        new Component(){Name = "Herb",          Value = 5 } },
            {"Hide",        new Component(){Name = "Hide",          Value = 5 } },
            {"Iron ore",    new Component(){Name = "Iron ore",      Value = 10 } },
            {"Leather",     new Component(){Name = "Leather",       Value = 10 } },
            {"Ruby",        new Component(){Name = "Ruby",          Value =  10 } },
            {"Sapphire",    new Component(){Name = "Sapphire",      Value =  10 } },
            {"Steel ore",   new Component(){Name = "Steel ore",     Value = 10 } },
            {"Iron ingot",  new Component(){Name = "Iron ingot",    Value = 25 } },
            {"Steel ingot", new Component(){Name = "Steel ingot",   Value = 100 } },
            {"Amethyst",    new Component(){Name = "Amethyst",      Value = 150 } },
            {"Magical cloth",new Component(){Name = "Magical cloth",      Value = 100 } }

        };
        public static Dictionary<string, Equipment> Equipments = new()
        {
            {"Bronze sword",          new Equipment(){Name = "Bronze sword",          Value = 50,    Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  { Classes["Fighter"], Classes["Thief"] } }},
            {"Iron sword",            new Equipment(){Name = "Iron sword",            Value = 100,   Type = EquipmentSlot.Weapon, Atk = 2, Def = 1, Required_Class =  { Classes["Fighter"], Classes["Thief"] } }},
            {"Excalibur",             new Equipment(){Name = "Excalibur",             Value = 10000, Type = EquipmentSlot.Weapon, Atk = 10, Def = 5,Required_Class =  { Classes["Fighter"] } }},
            {"Pine staff",            new Equipment(){Name = "Pine staff",            Value = 50,    Type = EquipmentSlot.Weapon, Atk = 1, Mp = 3,  Required_Class =  { Classes["Cleric"], Classes["Mage"] } }},
            {"Oak staff",             new Equipment(){Name = "Oak staff",             Value = 100,   Type = EquipmentSlot.Weapon, Atk = 2, Mp = 4,  Required_Class =  { Classes["Cleric"], Classes["Mage"] } }},
            {"Mahogany staff",        new Equipment(){Name = "Mahogany staff",        Value = 200,   Type = EquipmentSlot.Weapon, Atk = 3, Mp = 5,  Required_Class =  { Classes["Cleric"], Classes["Mage"] } }},
            {"Bronze knife",          new Equipment(){Name = "Bronze knife",          Value = 25,    Type = EquipmentSlot.Weapon, Atk = 1,          Required_Class =  { Classes["Fighter"], Classes["Thief"] } }},
            {"Iron knife",            new Equipment(){Name = "Iron knife",            Value = 75,    Type = EquipmentSlot.Weapon, Atk = 2,          Required_Class =  { Classes["Fighter"], Classes["Thief"], Classes["Cleric"], Classes["Mage"] } }},
            {"Bronze mace",           new Equipment(){Name = "Bronze mace",           Value = 35,    Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  { Classes["Fighter"], Classes["Cleric"] } }},
            {"Iron mace",             new Equipment(){Name = "Iron mace",             Value = 80,    Type = EquipmentSlot.Weapon, Atk = 2, Def = 1, Required_Class =  { Classes["Fighter"], Classes["Cleric"] } }},
            {"Bronze chestpiece",     new Equipment(){Name = "Bronze chestpiece",     Value = 100,   Type = EquipmentSlot.Armor,                    Required_Class =  { Classes["Fighter"] } }},
            {"Iron chestpiece",       new Equipment(){Name = "Iron chestpiece",       Value = 200,   Type = EquipmentSlot.Armor,                    Required_Class =  { Classes["Fighter"] } }},
            {"Leather armor",         new Equipment(){Name = "Leather armor",         Value = 50,    Type = EquipmentSlot.Armor, Atk = 1, Def = 1,  Required_Class =  { Classes["Thief"], Classes["Cleric"] } }},
            {"Studded leather armor", new Equipment(){Name = "Studded leather armor", Value = 100,   Type = EquipmentSlot.Armor,                    Required_Class =  { Classes["Thief"], Classes["Cleric"] } }},
            {"Tattered robes",        new Equipment(){Name = "Tattered robes",        Value = 25,    Type = EquipmentSlot.Armor,Def=0,Mp=3,         Required_Class =  { Classes["Cleric"], Classes["Mage"] } }},
            {"Mage robes",            new Equipment(){Name = "Mage robes",            Value = 250,   Type = EquipmentSlot.Armor,Def=1,Mp=4,         Required_Class =  { Classes["Cleric"], Classes["Mage"] } }},
            {"Enchanted robes",       new Equipment(){Name = "Enchanted robes",       Value = 1000,  Type = EquipmentSlot.Armor,Def=2,Mp=8,         Required_Class =  { Classes["Cleric"], Classes["Mage"] } }},
            {"Basic pants",           new Equipment(){Name = "Basic pants",           Value = 25,    Type = EquipmentSlot.Pants,Def=1,Hp=3,         Required_Class =  { Classes["Fighter"], Classes["Thief"] } }},
            {"Well-woven pants",      new Equipment(){Name = "Well-woven pants",      Value = 100,   Type = EquipmentSlot.Pants,Def=1,Hp=5,         Required_Class =  { Classes["Fighter"], Classes["Thief"] } }}

        };
        public static Dictionary<string, Enemy> Enemies = new()
        {
            {"Goblin",      new Enemy(){Name = "Goblin"  , Level = 1, Max_Hp = 5 , Atk = 4 , Def = 0, Gold = 3 , Exp = 5 , Drop_Chance = 0.5,  Drop_Items = { Components["Herb"], Components["Cloth"] } } },
            {"Wolf",        new Enemy(){Name = "Wolf"    , Level = 1, Max_Hp = 6 , Atk = 5 , Def = 0, Gold = 2 , Exp = 6 , Drop_Chance = 0.75, Drop_Items = { Components["Herb"], Components["Hide"] } } },
            {"Skeleton",    new Enemy(){Name = "Skeleton", Level = 2, Max_Hp = 8 , Atk = 4 , Def = 2, Gold = 1 , Exp = 8 , Drop_Chance = 3,    Drop_Items = { Components["Herb"], Components["Bone"] } } },
            {"Bandit",      new Enemy(){Name = "Bandit"  , Level = 2, Max_Hp = 10, Atk = 6 , Def = 1, Gold = 8 , Exp = 10, Drop_Chance = 0.5,  Drop_Items = { Components["Cloth"], Components["Hide"], Components["Ruby"] } } },
            {"Ogre",        new Enemy(){Name = "Ogre"    , Level = 3, Max_Hp = 20, Atk = 8 , Def = 2, Gold = 15, Exp = 15, Drop_Chance = 0.5,  Drop_Items = { Components["Ruby"], Components["Sapphire"] } } },
            {"Golem",       new Enemy(){Name = "Golem"   , Level = 3, Max_Hp = 12, Atk = 8 , Def = 4, Gold = 10, Exp = 12, Drop_Chance = 1.25, Drop_Items = { Components["Iron ore"], Components["Ruby"], Components["Sapphire"] } } },
            {"Dragon",      new Enemy(){Name = "Dragon"  , Level = 4, Max_Hp = 25, Atk = 12, Def = 6, Gold = 20, Exp = 20, Drop_Chance = 1.25, Drop_Items = { Components["Steel ore"], Components["Amethyst"] } } }

        };

        public static Dictionary<string, Merchant> Merchants = new()
        {
            {
                "Basic Weaponsmith",
                new Merchant()
                {
                    Name = "Basic Weaponsmith",
                    Inventory =
                    {
                        new ItemInventory(item: Equipments["Bronze sword"], amount: 1),
                        new ItemInventory(item: Equipments["Pine staff"], amount: 1),
                        new ItemInventory(item: Equipments["Bronze knife"], amount: -1),
                        new ItemInventory(item: Equipments["Bronze mace"], amount: 1),
                        new ItemInventory(item: Components["Iron ore"], amount: 3),
                        new ItemInventory(item: Usables["Shuriken"], amount: -1)
                    },
                    WeaponMult = .5,
                    ArmorMult = .35,
                    OtherMult = .1,
                }
            },
            {
                "Basic Armorsmith",
                new Merchant()
                {
                    Name = "Basic Armorsmith",
                    Inventory =
                    {
                        new ItemInventory(item: Equipments["Bronze chestpiece"], amount: 1),
                        new ItemInventory(item: Equipments["Leather armor"], amount: 2),
                        new ItemInventory(item: Equipments["Tattered robes"], amount: -1),
                        new ItemInventory(item: Equipments["Basic pants"], amount: -1),
                        new ItemInventory(item: Components["Leather"], amount: 3),
                    },
                    WeaponMult = .25,
                    ArmorMult = .5,
                    OtherMult = .1,
                }
            },
            {
                "Advanced Smith",
                new Merchant()
                {
                    Name = "Advanced Smith",
                    Inventory =
                    {
                        new ItemInventory(item: Equipments["Iron sword"], amount: 1),
                        new ItemInventory(item: Equipments["Oak staff"], amount: 1),
                        new ItemInventory(item: Equipments["Iron knife"], amount: -1),
                        new ItemInventory(item: Equipments["Iron mace"], amount: 1),
                        new ItemInventory(item: Equipments["Iron chestpiece"], amount: 1),
                        new ItemInventory(item: Equipments["Studded leather armor"], amount: 1),
                        new ItemInventory(item: Equipments["Mage robes"], amount: 1),
                        new ItemInventory(item: Equipments["Well-woven pants"], amount: 2),
                        new ItemInventory(item: Components["Ruby"], amount: 5),
                        new ItemInventory(item: Components["Sapphire"], amount: 5),
                        new ItemInventory(item: Usables["Bomb"], amount: -1),
                    },
                    WeaponMult = .35,
                    ArmorMult = .35,
                    OtherMult = .1,
                }
            },
        };
        public static Dictionary<string, Recipie> Recipies = new()
        {
            {
                "Health potion",
                new Recipie()
                {
                    Name = "Health potion x 1",
                    ItemCrafted = Usables["Health potion"],
                    AmountCrafted = 1,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Herb"], amount: 3)
                    }

                }
            },
            {
                "Health potion3",
                new Recipie()
                {
                    Name = "Health potion x 3",
                    ItemCrafted = Usables["Health potion"],
                    AmountCrafted = 3,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Herb"], amount: 5),
                        new ItemInventory(item: Components["Ruby"], amount: 1)
                    }

                }
            },
            {
                "Mana potion1",
                new Recipie()
                {
                    Name = "Mana potion x 1",
                    ItemCrafted = Usables["Mana potion"],
                    AmountCrafted = 1,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Herb"], amount: 3)
                    }

                }
            },
            {
                "Mana potion3",
                new Recipie()
                {
                    Name = "Mana potion x 3",
                    ItemCrafted = Usables["Mana potion"],
                    AmountCrafted = 3,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Herb"], amount: 5),
                        new ItemInventory(item: Components["Sapphire"], amount: 1)
                    }

                }
            },
            {
                "Leather",
                new Recipie()
                {
                    Name = "Leather",
                    ItemCrafted = Components["Leather"],
                    AmountCrafted = 1,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Hide"], amount: 1),
                        new ItemInventory(item: Components["Bone"], amount: 3)
                    }

                }
            },
            {
                "Iron ingot",
                new Recipie()
                {
                    Name = "Iron ingot",
                    ItemCrafted = Components["Iron ingot"],
                    AmountCrafted = 1,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Iron ore"], amount: 3)
                    }

                }
            },
            {
                "Steel ingot",
                new Recipie()
                {
                    Name = "Steel ingot",
                    ItemCrafted = Components["Steel ingot"],
                    AmountCrafted = 1,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Steel ore"], amount: 3),
                        new ItemInventory(item: Components["Iron ingot"], amount: 1)
                    }

                }
            },
            {
                "Magical cloth",
                new Recipie()
                {
                    Name = "Magical cloth",
                    ItemCrafted = Components["Magical cloth"],
                    AmountCrafted = 1,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Cloth"], amount: 3),
                        new ItemInventory(item: Components["Sapphire"], amount: 1)
                    }

                }
            },
            {
                "Enchanted robes",
                new Recipie()
                {
                    Name = "Enchanted robes",
                    ItemCrafted = Equipments["Enchanted robes"],
                    AmountCrafted = 1,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Magical cloth"], amount: 5),
                        new ItemInventory(item: Components["Sapphire"], amount: 2),
                        new ItemInventory(item: Components["Leather"], amount: 5)
                    }

                }
            },
            {
                "Excalibur",
                new Recipie()
                {
                    Name = "Excalibur",
                    ItemCrafted = Equipments["Excalibur"],
                    AmountCrafted = 1,
                    Ingredients =
                    {
                        new ItemInventory(item: Components["Steel ingot"], amount: 10),
                        new ItemInventory(item: Components["Magical cloth"], amount: 3),
                        new ItemInventory(item: Components["Leather"], amount: 10)
                    }

                }
            }

        }; public static Dictionary<int, Crafter> Crafters = new()
        {
            {
                1,
                new Crafter()
                {
                    Name = "Noob Town Crafter",
                    Inventory =
                    {
                        new ItemInventory(item: Recipies["Excalibur"], amount: -1),
                        new ItemInventory(item: Recipies["Enchanted robes"], amount: -1)

                    }
                }
            }
        };

    }
}
