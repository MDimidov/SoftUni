using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Greater_Number
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Input
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            //Act
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
    }
}
