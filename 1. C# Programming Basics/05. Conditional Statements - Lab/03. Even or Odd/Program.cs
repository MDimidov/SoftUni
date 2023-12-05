using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Even_or_Odd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Input
            int a = int.Parse(Console.ReadLine());

            //act
            if (a % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
                Console.WriteLine("odd");

        }
    }
}
