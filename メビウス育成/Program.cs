using System;
using System.IO;

namespace メビウス育成
{
    class Program
    {
        static void Main(string[] args)
        {
            var レベル10が3個あるMEBIUS = 0;
            var レベル10が2個あるMEBIUS = 0;
            var レベル10が1個あるMEBIUS = 0;
            var レベル10が2個あるMEBIUS_耐久除く = 0;
            var レベル10が1個あるMEBIUS_耐久除く = 0;
            
            for (int i = 0; i < 100000; i++)
            {
                var mebius = Grow.Mine();
                mebius.Level++;
                Grow.LevelUp(mebius,"修繕");
                for (int j = 0; j < 28; j++)
                {
                    Grow.RandomLevelUp(mebius);
                }

                mebius.Level++;
                Grow.LevelUp(mebius,"耐久無限");

                var NumOfLevel10 = Inspection.CountEnchantmentLevel10(mebius);
                var NumOfLevel10_耐久なし = Inspection.CountEnchantmentLevel10ExceptDurability(mebius);
                switch (NumOfLevel10)
                {
                    case 3:
                        レベル10が3個あるMEBIUS++;
                        WriteFile("レベル10が3個あるMEBIUS.txt",mebius.ToString());
                        break;
                    case 2:
                        レベル10が2個あるMEBIUS++;
                        WriteFile("レベル10が2個あるMEBIUS.txt",mebius.ToString());
                        break;
                    case 1:
                        レベル10が1個あるMEBIUS++;
                        WriteFile("レベル10が1個あるMEBIUS.txt",mebius.ToString());
                        break;
                }
                switch (NumOfLevel10_耐久なし)
                {
                    case 2:
                        レベル10が2個あるMEBIUS_耐久除く++;
                        WriteFile("レベル10が2個あるMEBIUS_耐久除く.txt",mebius.ToString());
                        break;
                    case 1:
                        レベル10が1個あるMEBIUS_耐久除く++;
                        WriteFile("レベル10が1個あるMEBIUS_耐久除く.txt",mebius.ToString());
                        break;
                }
                WriteFile("MEBIUSたち.txt",mebius.ToString());
            }
        }

        static void WriteFile(string FileName, string text)
        {
            File.AppendAllText(FileName,text+Environment.NewLine);
        }
    }
}