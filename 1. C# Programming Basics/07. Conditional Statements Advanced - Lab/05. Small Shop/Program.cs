using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Small_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвждаме от конзолата
            //      - продукт
            string product = Console.ReadLine();
            //      - град
            string city = Console.ReadLine();
            //      - количество
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            //2. Съобразяваме се с условията
            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        price = 0.5;
                        break;
                    case "water":
                        price = 0.8;
                        break;
                    case "beer":
                        price = 1.20;
                        break;
                    case "sweets":
                        price = 1.45;
                        break;
                    case "peanuts":
                        price = 1.60;
                        break;
                }
            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        price = 0.4;
                        break;
                    case "water":
                        price = 0.7;
                        break;
                    case "beer":
                        price = 1.15;
                        break;
                    case "sweets":
                        price = 1.30;
                        break;
                    case "peanuts":
                        price = 1.50;
                        break;
                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        price = 0.45;
                        break;
                    case "water":
                        price = 0.7;
                        break;
                    case "beer":
                        price = 1.10;
                        break;
                    case "sweets":
                        price = 1.35;
                        break;
                    case "peanuts":
                        price = 1.55;
                        break;
                }
            }

            Console.WriteLine(quantity * price);



        }
    }
}
