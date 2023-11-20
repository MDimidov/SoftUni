using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Even_Times
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, int> countNumbers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                if(!countNumbers.ContainsKey(currNum))
                {
                    countNumbers.Add(currNum, 0);
                }
                countNumbers[currNum]++;
            }
            Console.WriteLine(countNumbers.Single(n => n.Value % 2 == 0).Key);
        }
    }
}
