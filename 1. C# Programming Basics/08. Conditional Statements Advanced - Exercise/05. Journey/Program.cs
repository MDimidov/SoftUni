using System;

namespace _05._Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Четем от конзолата
            //      •	Първи ред – Бюджет, реално число в интервала[10.00...5000.00].
            double budget = double.Parse(Console.ReadLine());
            //      •	Втори ред –  Един от двата възможни сезона: „summer” или “winter”
            string season = Console.ReadLine();

            string destination = String.Empty;
            string restPlace = String.Empty;
            //2. Съобразяваме се с условията
            //      •	При 100лв.или по-малко – някъде в България
            //          o   Лято – 30 % от бюджета
            //          o   Зима – 70 % от бюджета
            //      •	При повече от 1000лв. – някъде из Европа
            //          o   При пътуване из Европа, независимо от сезона ще похарчи 90 % от бюджета.

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    budget *= 0.3;
                    restPlace = "Camp";
                }
                else
                {
                    budget *= 0.7;
                    restPlace = "Hotel";
                }
            }
            //      •	При 1000лв.или по малко – някъде на Балканите
            //          o   Лято – 40 % от бюджета
            //          o   Зима – 80 % от бюджета
            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    budget *= 0.4;
                    restPlace = "Camp";
                }
                else
                {
                    budget *= 0.8;
                    restPlace = "Hotel";
                }

            }
            else
            {
                destination = "Europe";
                budget *= 0.9;
                restPlace = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}\n{restPlace} - {budget:f2}");

        }
    }
}
