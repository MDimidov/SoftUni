using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Fuel_Tank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме в конзолата
            //      1.1. Вида гориво
            string fuel = Console.ReadLine();
            //      1.2. Количество гориво
            double liters = double.Parse(Console.ReadLine());

            string lit;
            if (liters >= 25)
            {
                lit = $"You have enough {fuel.ToLower()}.";
            }
            else
            {
                lit = $"Fill your tank with {fuel.ToLower()}!";
            }

            //2. Извпълняваме условията в задачата
            
            if (fuel == "Diesel" || fuel == "Gasoline" || fuel == "Gas")
            {
                Console.WriteLine(lit);
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }

        }
    }
}
