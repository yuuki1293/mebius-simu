using System;
using System.IO;

namespace メビウス育成
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("育てる個数を入力してください");
            var num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("最大レベルを入力してください");
            var maxLevel = Convert.ToInt32(Console.ReadLine());
            
            if(maxLevel>30)
            {
                Console.WriteLine("30以下で入力してください");
                return;
            }

            var レベル10が3個あるMEBIUS = 0;
            var レベル10が2個あるMEBIUS = 0;
            var レベル10が1個あるMEBIUS = 0;
            var レベル10が2個あるMEBIUS_耐久除く = 0;
            var レベル10が1個あるMEBIUS_耐久除く = 0;
            
            for (var i = 0; i < num; i++)
            {
                var mebius = Grow.Mine();

                for (var j = 0; j < maxLevel; j++)
                {
                    Grow.RandomLevelUp(mebius);

                    if (j != 29) continue;
                    mebius.Level++;
                    Grow.AddEnchant(mebius, "耐久無限");
                }

                var NumOfLevel10 = Inspection.CountEnchantmentLevel10(mebius);
                var NumOfLevel10_耐久なし = Inspection.CountEnchantmentLevel10ExceptDurability(mebius);
                while (true)
                {
                    try
                    {
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
                        break;
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                while (true)
                {
                    try
                    {
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
                        break;
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                }

                while (true)
                {
                    try
                    {
                        WriteFile("MEBIUSたち.txt",mebius.ToString());
                        break;
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                }
                
                Console.Write($"\r[ {i+1} / {num} ]");
            }
            
            Console.WriteLine("");
            Console.WriteLine($"育てたMEBIUSの個数:{num} 個");
            Console.WriteLine($"レベル10が3個あるMEBIUS:{レベル10が3個あるMEBIUS} 個 {レベル10が3個あるMEBIUS / (float)num *100} %");
            Console.WriteLine($"レベル10が2個あるMEBIUS:{レベル10が2個あるMEBIUS} 個 {レベル10が2個あるMEBIUS / (float)num *100} %");
            Console.WriteLine($"レベル10が1個あるMEBIUS:{レベル10が1個あるMEBIUS} 個 {レベル10が1個あるMEBIUS / (float)num*100} %");
            Console.WriteLine($"レベル10が2個あるMEBIUS(耐久除く):{レベル10が2個あるMEBIUS_耐久除く} 個 {レベル10が2個あるMEBIUS_耐久除く / (float)num *100} %");
            Console.WriteLine($"レベル10が1個あるMEBIUS(耐久除く):{レベル10が1個あるMEBIUS_耐久除く} 個 {レベル10が1個あるMEBIUS_耐久除く / (float)num*100} %");
            Console.WriteLine("キーを押して終了");
            Console.ReadKey();
        }

        private static void WriteFile(string fileName, string text)
        {
            File.AppendAllText(fileName,text+Environment.NewLine);
        }
    }
}