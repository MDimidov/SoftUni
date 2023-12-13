using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Sequence_2k_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int k = 1;
            while (k <= num)
            {
                Console.WriteLine(k);
                k = k * 2 + 1;
            }
        }
    }
}
