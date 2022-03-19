using System;
using System.Collections.Generic;
using System.Linq;

namespace メビウス育成
{
    public static class Grow
    { 
        public static Mebius Mine()
        {
            return new Mebius();
        }

        private static IEnumerable<MebiusEnchantment> UpgradableEnchants(Mebius mebius)
        {
            return mebius.Values.Where(i => i.UnlockLevel <= mebius.Level && i.NowLevel < i.MaxLevel);
        }
        
        public static void RandomLevelUp(Mebius mebius)
        {
            mebius.Level++;
            var enchants = UpgradableEnchants(mebius).ToArray();
            Random r = new();
            var selectedEnchant = enchants[r.Next(0, enchants.Length)].DisplayName;
            AddEnchant(mebius, selectedEnchant);
        }

        public static void AddEnchant(Mebius mebius,string enchant)
        {
            switch (enchant)
            {
                case "ダメージ軽減":
                    mebius.Protection.NowLevel++;
                    break;
                case "耐久力":
                    mebius.Durability.NowLevel++;
                    break;
                case "修繕":
                    mebius.Mending.NowLevel++;
                    break;
                case "火炎耐性":
                    mebius.FireProtection.NowLevel++;
                    break;
                case "飛び道具耐性":
                    mebius.ProjectileProtection.NowLevel++;
                    break;
                case "爆発耐性":
                    mebius.ExplosionProtection.NowLevel++;
                    break;
                case "水中呼吸":
                    mebius.Respiration.NowLevel++;
                    break;
                case "水中採掘":
                    mebius.WaterAffinity.NowLevel++;
                    break;
                case "耐久無限":
                    mebius.Unbreakable.NowLevel++;
                    break;
            }
        }
    }
}