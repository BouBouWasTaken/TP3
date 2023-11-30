using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace tp3_prog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ImageSource GetImage(string imageUrl)
        {
            return new BitmapImage(new Uri("pack://application:,,,/tp3_prog;component/assets/" + imageUrl));
        }

    }

    public static class DefaultData
    {
        public static Dictionary<string, Classe> Classes = new Dictionary<string, Classe>()
        {
             {"Fighter",    new Classe(){Name = "Fighter",  HpByLevel = 10,MpByLevel = 3,   AtkByLevel = 2,DefByLevel = 3,Portrait = "fighter.png"}},
             {"Thief",      new Classe(){Name = "Thief",    HpByLevel = 8,MpByLevel = 3,    AtkByLevel = 3,DefByLevel = 2,Portrait = "thief.png"}},
             {"Cleric",     new Classe(){Name = "Cleric",   HpByLevel = 8,MpByLevel = 4,    AtkByLevel = 2,DefByLevel = 2,Portrait = "cleric.png"}},
             {"Mage",       new Classe(){Name = "Mage",     HpByLevel = 6,MpByLevel = 6,    AtkByLevel = 2,DefByLevel = 2,Portrait = "mage.png"}},
        };

        public static Dictionary<string, Skill> Skills = new Dictionary<string, Skill>()
        {
            {"Bash",            new Skill() { ClasseName = "Fighter", Name = "Bash",           LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomEnemy, Type= MagicEffectType.Damage, Multiplier = 1.5} },
            { "Rallying Shout", new Skill() { ClasseName = "Fighter", Name = "Rallying Shout", LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllAllies,   Type= MagicEffectType.HealHp, Multiplier = 0.35} },
            {"Backstab",        new Skill() { ClasseName = "Thief",   Name = "Backstab",       LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomEnemy, Type= MagicEffectType.Damage, Multiplier = 1.75} },
            {"Fan of knives",   new Skill() { ClasseName = "Thief",   Name = "Fan of knives",  LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllEnemies,  Type= MagicEffectType.Damage, Multiplier = 0.5} },
            {"Heal",            new Skill() { ClasseName = "Cleric",  Name = "Heal",           LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomAlly,  Type= MagicEffectType.HealHp, Multiplier = 1} },
            {"Benediction",     new Skill() { ClasseName = "Cleric",  Name = "Benediction",    LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllAllies,   Type= MagicEffectType.HealHp, Multiplier = 0.5} },
            {"Fireball",        new Skill() { ClasseName = "Mage",    Name = "Fireball",       LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.AllEnemies,  Type= MagicEffectType.Damage, Multiplier = 0.5} },
            {"Meteor",          new Skill() { ClasseName = "Mage",    Name = "Meteor",         LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllEnemies,  Type= MagicEffectType.Damage, Multiplier = 0.75} },
        };

        public static Dictionary<string, Usable> Usables = new Dictionary<string, Usable>()
        {
            {"Health potion",   new Usable(){Name = "Health potion",Value = 25, Target = MagicTarget.Self,       EffectType = MagicEffectType.HealHp, Power = 10} },
            {"Mana potion",     new Usable(){Name = "Mana potion",  Value = 35, Target = MagicTarget.Self,       EffectType = MagicEffectType.HealMp, Power = 10} },
            {"Bomb",            new Usable(){Name = "Bomb",         Value = 50, Target = MagicTarget.AllEnemies, EffectType = MagicEffectType.Damage, Power = 15} },
            {"Shuriken",        new Usable(){Name = "Shuriken",     Value = 10, Target = MagicTarget.RandomEnemy,EffectType = MagicEffectType.Damage, Power = 10} }
        };
        public static Dictionary<string, Component> Components = new Dictionary<string, Component>()
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
            {"Amethyst",    new Component(){Name = "Amethyst",      Value = 150 } }

        };

        public static Dictionary<string, Equipment> Equipments = new Dictionary<string, Equipment>()
        {
            {"Bronze sword",          new Equipment(){Name = "Bronze sword",          Value = 50,    Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  { DefaultData.Classes["Fighter"], DefaultData.Classes["Thief"] } }},
            {"Iron sword",            new Equipment(){Name = "Iron sword",            Value = 100,   Type = EquipmentSlot.Weapon, Atk = 2, Def = 1, Required_Class =  {DefaultData.Classes["Fighter"], DefaultData.Classes["Thief"] } }},
            {"Excalibur",             new Equipment(){Name = "Excalibur",             Value = 10000, Type = EquipmentSlot.Weapon, Atk = 10, Def = 5,Required_Class =  { DefaultData.Classes["Fighter"] } }},
            {"Pine staff",            new Equipment(){Name = "Pine staff",            Value = 50,    Type = EquipmentSlot.Weapon, Atk = 1, Mp = 3,  Required_Class =  { DefaultData.Classes["Cleric"], DefaultData.Classes["Mage"] } }},
            {"Oak staff",             new Equipment(){Name = "Oak staff",             Value = 100,   Type = EquipmentSlot.Weapon, Atk = 2, Mp = 4,  Required_Class =  { DefaultData.Classes["Cleric"], DefaultData.Classes["Mage"] } }},
            {"Mahogany staff",        new Equipment(){Name = "Mahogany staff",        Value = 200,   Type = EquipmentSlot.Weapon, Atk = 3, Mp = 5,  Required_Class =  { DefaultData.Classes["Cleric"], DefaultData.Classes["Mage"] } }},
            {"Bronze knife",          new Equipment(){Name = "Bronze knife",          Value = 25,    Type = EquipmentSlot.Weapon, Atk = 1,          Required_Class =  { DefaultData.Classes["Fighter"], DefaultData.Classes["Thief"] } }},
            {"Iron knife",            new Equipment(){Name = "Iron knife",            Value = 75,    Type = EquipmentSlot.Weapon, Atk = 2,          Required_Class =  { DefaultData.Classes["Fighter"], DefaultData.Classes["Thief"], DefaultData.Classes["Cleric"], DefaultData.Classes["Mage"] } }},
            {"Bronze mace",           new Equipment(){Name = "Bronze mace",           Value = 35,    Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  { DefaultData.Classes["Fighter"], DefaultData.Classes["Cleric"] } }},
            {"Iron mace",             new Equipment(){Name = "Iron mace",             Value = 80,    Type = EquipmentSlot.Weapon, Atk = 2, Def = 1, Required_Class =  { DefaultData.Classes["Fighter"], DefaultData.Classes["Cleric"] } }},
            {"Bronze chestpiece",     new Equipment(){Name = "Bronze chestpiece",     Value = 100,   Type = EquipmentSlot.Armor,                    Required_Class =  { DefaultData.Classes["Fighter"] } }},
            {"Iron chestpiece",       new Equipment(){Name = "Iron chestpiece",       Value = 200,   Type = EquipmentSlot.Armor,                    Required_Class =  { DefaultData.Classes["Fighter"] } }},
            {"Leather armor",         new Equipment(){Name = "Leather armor",         Value = 50,    Type = EquipmentSlot.Armor, Atk = 1, Def = 1,  Required_Class =  { DefaultData.Classes["Thief"], DefaultData.Classes["Cleric"] } }},
            {"Studded leather armor", new Equipment(){Name = "Studded leather armor", Value = 100,   Type = EquipmentSlot.Armor,                    Required_Class =  { DefaultData.Classes["Thief"], DefaultData.Classes["Cleric"] } }},
            {"Tattered robes",        new Equipment(){Name = "Tattered robes",        Value = 25,    Type = EquipmentSlot.Armor,Def=0,Mp=3,         Required_Class =  { DefaultData.Classes["Cleric"], DefaultData.Classes["Mage"] } }},
            {"Mage robes",            new Equipment(){Name = "Mage robes",            Value = 250,   Type = EquipmentSlot.Armor,Def=1,Mp=4,         Required_Class =  { DefaultData.Classes["Cleric"], DefaultData.Classes["Mage"] } }},
            {"Enchanted robes",       new Equipment(){Name = "Enchanted robes",       Value = 1000,  Type = EquipmentSlot.Armor,Def=2,Mp=8,         Required_Class =  { DefaultData.Classes["Cleric"], DefaultData.Classes["Mage"] } }},
            {"Basic pants",           new Equipment(){Name = "Basic pants",           Value = 25,    Type = EquipmentSlot.Pants,Def=1,Hp=3,         Required_Class =  { DefaultData.Classes["Fighter"], DefaultData.Classes["Thief"] } }},
            {"Well-woven pants",      new Equipment(){Name = "Well-woven pants",      Value = 100,   Type = EquipmentSlot.Pants,Def=1,Hp=5,         Required_Class =  { DefaultData.Classes["Fighter"], DefaultData.Classes["Thief"] } }},
        };
        public static Dictionary<string, Enemy> Enemies = new Dictionary<string, Enemy>()
        {
            {"Goblin",      new Enemy(){Name = "Goblin"  , Level = 1, Hp = 5 , Atk = 4 , Def = 0, Gold = 3 , Exp = 5 , Drop_Chance = 0.5,  Drop_Items = {  DefaultData.Components["Herb"], DefaultData.Components["Cloth"] } } },
            {"Wolf",        new Enemy(){Name = "Wolf"    , Level = 1, Hp = 6 , Atk = 5 , Def = 0, Gold = 2 , Exp = 6 , Drop_Chance = 0.75, Drop_Items = { DefaultData.Components["Herb"], DefaultData.Components["Hide"] } } },
            {"Skeleton",    new Enemy(){Name = "Skeleton", Level = 2, Hp = 8 , Atk = 4 , Def = 2, Gold = 1 , Exp = 8 , Drop_Chance = 3,    Drop_Items = { DefaultData.Components["Herb"], DefaultData.Components["Bone"] } } },
            {"Bandit",      new Enemy(){Name = "Bandit"  , Level = 2, Hp = 10, Atk = 6 , Def = 1, Gold = 8 , Exp = 10, Drop_Chance = 0.5,  Drop_Items = { DefaultData.Components["Cloth"], DefaultData.Components["Hide"], DefaultData.Components["Ruby"] } } },
            {"Ogre",        new Enemy(){Name = "Ogre"    , Level = 3, Hp = 20, Atk = 8 , Def = 2, Gold = 15, Exp = 15, Drop_Chance = 0.5,  Drop_Items = { DefaultData.Components["Ruby"], DefaultData.Components["Sapphire"] } } },
            {"Golem",       new Enemy(){Name = "Golem"   , Level = 3, Hp = 12, Atk = 8 , Def = 4, Gold = 10, Exp = 12, Drop_Chance = 1.25, Drop_Items = { DefaultData.Components["Iron ore"], DefaultData.Components["Ruby"], DefaultData.Components["Sapphire"] } } },
            {"Dragon",      new Enemy(){Name = "Dragon"  , Level = 4, Hp = 25, Atk = 12, Def = 6, Gold = 20, Exp = 20, Drop_Chance = 1.25, Drop_Items = { DefaultData.Components["Steel ore"], DefaultData.Components["Amethyst"] } } }

        };
    }
}
