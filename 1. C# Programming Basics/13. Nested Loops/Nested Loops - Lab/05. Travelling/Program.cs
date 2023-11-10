using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Travelling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Create variable for destination
            string destination;
            //2. check if destination different from End we enter in the loop
            while ((destination = Console.ReadLine()) != "End")
            {
                double sum = 0;
                double minSum = double.Parse(Console.ReadLine());
                while (sum < minSum)
                {
                    double currentSum = double.Parse(Console.ReadLine());
                    sum += currentSum;
                }
                Console.WriteLine($"Going to {destination}!");
                //sum = 0;
            }
        }
    }
}
