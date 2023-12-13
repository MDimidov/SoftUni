using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers_1_N_with_Step_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i+=3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
