using System.Collections.Generic;
using System.Linq;

namespace メビウス育成
{
    public class MebiusEnchantment
    {
        public MebiusEnchantment(int unlockLevel,int maxLevel,string displayName)
        {
            UnlockLevel = unlockLevel;
            MaxLevel = maxLevel;
            DisplayName = displayName;
        }
        public int UnlockLevel { get; }
        public int MaxLevel { get; }
        public string DisplayName { get; }
        public int NowLevel { get; set; }
        public override string ToString()
        {
            return DisplayName;
        }
    }

    public class Mebius
    {
        public int Level { get; set; } = 1;
        public MebiusEnchantment Protection { get; set; } = new(2, 10, "ダメージ軽減");
        public MebiusEnchantment Durability { get; set; } = new(1, 10, "耐久力");
        public MebiusEnchantment Mending { get; set; } = new(1, 1, "修繕");
        public MebiusEnchantment FireProtection { get; set; } = new(6, 10, "火炎耐性");
        public MebiusEnchantment ProjectileProtection { get; set; } = new(6, 10, "飛び道具耐性");
        public MebiusEnchantment ExplosionProtection { get; set; } = new(6, 10, "爆発耐性");
        public MebiusEnchantment Respiration { get; set; } = new(15, 3, "水中呼吸");
        public MebiusEnchantment WaterAffinity { get; set; } = new(15, 1, "水中採掘");
        public MebiusEnchantment Unbreakable { get; set; } = new(30, 1, "耐久無限");

        public Mebius()
        {
            Mending.NowLevel = 1;
            Durability.NowLevel = 3;
        }
        
        public IEnumerable<MebiusEnchantment> Values => new[] {Protection,Durability,Mending,FireProtection,ProjectileProtection,ExplosionProtection,Respiration,WaterAffinity,Unbreakable};
        public override string ToString()
        {
            return Values.Aggregate("", (current, enchantment) => current + $"{enchantment.DisplayName}:{enchantment.NowLevel}, ");
        }
    }
}