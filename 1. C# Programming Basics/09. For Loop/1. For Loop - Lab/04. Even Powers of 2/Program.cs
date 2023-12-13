using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Even_Powers_of_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i+=2)
            {
                
                    Console.WriteLine(Math.Pow(2, i));
                
            }
        }
    }
}
