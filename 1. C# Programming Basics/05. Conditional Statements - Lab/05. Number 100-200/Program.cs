using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Number_100_200
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            if (a < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (a > 200)
                Console.WriteLine("Greater than 200");
            else
                Console.WriteLine("Between 100 and 200");
        }
    }
}
