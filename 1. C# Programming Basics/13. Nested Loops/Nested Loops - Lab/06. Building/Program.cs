using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Building
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int floorsCnt = int.Parse(Console.ReadLine());
            int roomsCnt = int.Parse(Console.ReadLine());

            for (int fl = floorsCnt; fl >0 ; fl--)
            {
                for (int ro = 0; ro < roomsCnt; ro++)
                {
                    if (fl == floorsCnt)
                    {
                        Console.Write($"L{fl}{ro} ");
                    }
                    else if (fl % 2 == 0)
                    {
                        Console.Write($"O{fl}{ro} ");
                    }
                    else
                    {
                        Console.Write($"A{fl}{ro} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
