using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Number_in_Range
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number != 0 && number >= -100 && number <= 100)
            {
                Console.WriteLine("Yes");
            }    
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
