using System;

namespace _04._Fishing_Boat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Четем от конзолата
            //      •	Бюджет на групата – цяло число в интервала[1…8000]
            int budget = int.Parse(Console.ReadLine());
            //      •	Сезон –  текст: "Spring", "Summer", "Autumn", "Winter"
            string season = Console.ReadLine();
            //      •	Брой рибари – цяло число в интервала[4…18]
            int fishermen = int.Parse(Console.ReadLine());

            
            //2. Съобразяваме се с условията
            //      •	Цената за наем на кораба през пролетта е  3000 лв.
            //      •	Цената за наем на кораба през лятото и есента е  4200 лв.
            //      •	Цената за наем на кораба през зимата е  2600 лв.
            double price = 0;
            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Winter":
                    price = 2600;
                    break;
                default:
                    price = 4200;
                    break;
            }

            //В зависимост от броя си групата ползва отстъпка:
            //      •	Ако групата е до 6 човека включително  –  отстъпка от 10 %.
            //      •	Ако групата е от 7 до 11 човека включително  –  отстъпка от 15 %.
            //      •	Ако групата е от 12 нагоре  –  отстъпка от 25 %.

            if (fishermen <= 6)
            {
                price -= price * 0.1;
            }
            else if (fishermen >= 7 && fishermen <= 11)
            {
                price -= price * 0.15;
            }
            else
            {
                price -= price * 0.25;
            }

            //Рибарите ползват допълнително 5% отстъпка, ако са четен брой освен ако не е есен - 
            if (fishermen % 2 == 0 && season != "Autumn")
            {
                price *= 0.95;
            }

            double difference = budget - price;
            if (difference >= 0)
                Console.WriteLine($"Yes! You have {difference:f2} leva left.");
            else
                Console.WriteLine($"Not enough money! You need {Math.Abs(difference):f2} leva.");



        }
    }
}
