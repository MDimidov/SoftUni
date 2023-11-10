using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Challenge_the_Wedding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int girls = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            int cntTables = 0;
            for (int i = 1; i <= men; i++)
            {
                for (int j = 1; j <= girls; j++)
                {
                    cntTables++;
                    if (cntTables == tables)
                    {
                        Console.Write($"({i} <-> {j}) ");
                        return;
                    }
                    else
                    {
                        Console.Write($"({i} <-> {j}) ");
                    }
                }
            }
        }
    }
}
