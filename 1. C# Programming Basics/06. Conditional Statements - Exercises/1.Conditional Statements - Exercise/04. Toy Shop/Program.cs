using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Toy_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            /*Цени на играчките:
                •	Пъзел - 2.60 лв.
                •	Говореща кукла - 3 лв.
                •	Плюшено мече - 4.10 лв.
                •	Миньон - 8.20 лв.
                •	Камионче - 2 лв. */
                
            int totalQuantity = puzzles + dolls + bears + minions + trucks;

            double finalPrice = puzzles * 2.6 + dolls * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;

            if (totalQuantity >= 50)
            {
                finalPrice -= finalPrice * 0.25;
            }

            finalPrice -= finalPrice * 0.1;

            if (finalPrice >= tripPrice)
            {
                Console.WriteLine($"Yes! {finalPrice-tripPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripPrice-finalPrice:f2} lv needed.");
            }
        }
    }
}
