using System;
using System.Linq;

namespace メビウス育成
{
    public static class Inspection
    {
        public static int CountEnchantmentLevel10(MEBIUS mebius)
        {
            if (mebius.Level != 30) throw new Exception();
            return mebius.Values.Count(i => i.NowLevel == 10);
        }

        public static int CountEnchantmentLevel10ExceptDurability(MEBIUS mebius)
        {
            if (mebius.Level != 30) throw new Exception();
            return mebius.Values.Count(i => i.DisplayName != "耐久力" && i.NowLevel == 10);
        }
    }
}