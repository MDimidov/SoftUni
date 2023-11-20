using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Count_Symbols
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SortedDictionary<char, int> countSymbols = new SortedDictionary<char, int>();

            char[] symbols = Console.ReadLine()
                .ToCharArray();
            foreach (char symbol in symbols)
            {
                if (!countSymbols.ContainsKey(symbol))
                {
                    countSymbols[symbol] = 0;
                }
                countSymbols[symbol]++;
            }
            foreach((char symbol, int count) in countSymbols)
            {
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}
