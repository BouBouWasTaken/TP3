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

    static class DefaultData
    {
        public static Dictionary<int, Classe> Classes = new Dictionary<int, Classe>()
        {
             {0,new Classe(){Name = "Fighter",HpByLevel = 10,MpByLevel = 3,AtkByLevel = 2,DefByLevel = 3,Portrait = "fighter.png"}},
             {1,new Classe(){Name = "Thief",HpByLevel = 8,MpByLevel = 3,AtkByLevel = 3,DefByLevel = 2,Portrait = "thief.png"}},
             {2,new Classe(){Name = "Cleric",HpByLevel = 8,MpByLevel = 4,AtkByLevel = 2,DefByLevel = 2,Portrait = "cleric.png"}},
             {3,new Classe(){Name = "Mage",HpByLevel = 6,MpByLevel = 6,AtkByLevel = 2,DefByLevel = 2,Portrait = "mage.png"}},
        };

        public static Dictionary<int, Skill> Skills = new Dictionary<int, Skill>()
        {
            {101, new Skill() { ClasseName = "Fighter", Name = "Bash",           LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomEnemy, Type= MagicEffectType.Damage, Multiplier = 1.5} },
            {102, new Skill() { ClasseName = "Fighter", Name = "Rallying Shout", LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllAllies,   Type= MagicEffectType.HealHp,   Multiplier = 0.35} },
            {103, new Skill() { ClasseName = "Thief",   Name = "Backstab",       LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomEnemy, Type= MagicEffectType.Damage, Multiplier = 1.75} },
            {104, new Skill() { ClasseName = "Thief",   Name = "Fan of knives",  LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllEnemies,  Type= MagicEffectType.Damage, Multiplier = 0.5} },
            {105, new Skill() { ClasseName = "Cleric",  Name = "Heal",           LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.RandomAlly,  Type= MagicEffectType.HealHp,   Multiplier = 1} },
            {106, new Skill() { ClasseName = "Cleric",  Name = "Benediction",    LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllAllies,   Type= MagicEffectType.HealHp,   Multiplier = 0.5} },
            {107, new Skill() { ClasseName = "Mage", Name = "Fireball", LevelRequired = 1, MagicPoints = 3, Targets = MagicTarget.AllEnemies, Type= MagicEffectType.Damage, Multiplier = 0.5} },
            {108, new Skill() { ClasseName = "Mage", Name = "Meteor", LevelRequired = 2, MagicPoints = 5, Targets = MagicTarget.AllEnemies, Type= MagicEffectType.Damage, Multiplier = 0.75} },
        };

        public static Dictionary<int, Usable> Usables = new Dictionary<int, Usable>()
        {
            {1001, new Usable(){Name = "Health potion", Value = 25, Target = MagicTarget.Self, EffectType = MagicEffectType.HealHp, Power = 10} },
            {1002, new Usable(){Name = "Mana potion", Value = 35, Target = MagicTarget.Self, EffectType = MagicEffectType.HealMp, Power = 10} },
            {1003, new Usable(){Name = "Bomb", Value = 50, Target = MagicTarget.AllEnemies, EffectType = MagicEffectType.Damage, Power = 15} },
            {1004, new Usable(){Name = "Shuriken", Value = 10, Target = MagicTarget.RandomEnemy, EffectType = MagicEffectType.Damage, Power = 10} }
        };
        public static Dictionary<int, Component> Components = new Dictionary<int, Component>()
        {
            {10001, new Component(){Name = "Bone", Value = 5} },
            {10002, new Component(){Name = "Cloth", Value = 5 } },
            {10003, new Component(){Name = "Herb", Value = 5 } },
            {10004, new Component(){Name = "Hide", Value = 5 } },
            {10005, new Component(){Name = "Iron ore", Value = 10 } },
            {10006, new Component(){Name = "Leather", Value = 10 } },
            {10007, new Component(){Name = "Ruby", Value =  10 } },
            {10008, new Component(){Name = "Sapphire", Value =  10 } },
            {10009, new Component(){Name = "Steel ore", Value = 10 } },
            {10010, new Component(){Name = "Iron ingot", Value = 25 } },
            {10011, new Component(){Name = "Steel ingot", Value = 100 } }
        };



        /*
        fighter = 0
        thief = 1
        cleric = 2
        mage = 3
        */
        public static Dictionary<int, Equipment> Equipments = new Dictionary<int, Equipment>()
        {
            {2001, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {0,1} }},

            // Not done
{2002, new Equipment(){Name = "Iron sword", Value = 100, Type = EquipmentSlot.Weapon, Atk = 2, Def = 1, Required_Class =  {} }},
{2003, new Equipment(){Name = "Excalibur", Value = 10000, Type = EquipmentSlot.Weapon, Atk = 10, Def = 5, Required_Class =  {} }},

{2004, new Equipment(){Name = "Pine staff", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2005, new Equipment(){Name = "Oak staff", Value = 100, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2006, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2007, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2008, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2009, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2010, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2011, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2012, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2013, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
{2014, new Equipment(){Name = "Bronze sword", Value = 50, Type = EquipmentSlot.Weapon, Atk = 1, Def = 1, Required_Class =  {} }},
        };


    }
}
