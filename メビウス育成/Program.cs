using System;
using System.IO;

namespace メビウス育成
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("育てる個数を入力してください");
            var num = Convert.ToInt32(Console.ReadLine());
            
            var レベル10が3個あるMEBIUS = 0;
            var レベル10が2個あるMEBIUS = 0;
            var レベル10が1個あるMEBIUS = 0;
            var レベル10が2個あるMEBIUS_耐久除く = 0;
            var レベル10が1個あるMEBIUS_耐久除く = 0;
            
            for (var i = 0; i < num; i++)
            {
                var mebius = Grow.Mine();
                mebius.Level++;
                Grow.LevelUp(mebius,"修繕");
                for (var j = 0; j < 28; j++)
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
            Console.WriteLine($"育てたMEBIUSの個数:{num} 個");
            Console.WriteLine($"レベル10が3個あるMEBIUS:{レベル10が3個あるMEBIUS} 個");
            Console.WriteLine($"レベル10が2個あるMEBIUS:{レベル10が2個あるMEBIUS} 個");
            Console.WriteLine($"レベル10が1個あるMEBIUS:{レベル10が1個あるMEBIUS} 個");
            Console.WriteLine($"レベル10が2個あるMEBIUS(耐久除く):{レベル10が2個あるMEBIUS_耐久除く} 個");
            Console.WriteLine($"レベル10が1個あるMEBIUS(耐久除く):{レベル10が1個あるMEBIUS_耐久除く} 個");
            Console.WriteLine("キーを押して終了");
            Console.ReadKey();
        }

        static void WriteFile(string fileName, string text)
        {
            File.AppendAllText(fileName,text+Environment.NewLine);
        }
    }
}