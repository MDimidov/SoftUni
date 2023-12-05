using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Pets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата четем
            //      •	Първи ред – брой дни – цяло число в интервал[1…5000]
            int days = int.Parse(Console.ReadLine());
            //      •	Втори ред – оставена храна в килограми – цяло число в интервал[0…100000]
            int food = int.Parse(Console.ReadLine());
            //      •	Трети ред – храна на ден за кучето в килограми – реално число в интервал[0.00…100.00]
            double foodForDog = double.Parse(Console.ReadLine());
            //      •	Четвърти ред – храна на ден за котката в килограми– реално число в интервал[0.00…100.00]
            double foodForCat = double.Parse(Console.ReadLine());
            //      •	Пети ред – храна на ден за костенурката в грамове – реално число в интервал[0.00…10000.00]
            double foodForTurtle = double.Parse(Console.ReadLine());

            //2. Изчисляваме колко храна ще изяде всяко животно за целият период
            double dog = days * foodForDog;
            double cat = days * foodForCat;
            double turtle = days * (foodForTurtle / 1000.0);

            double total = dog + cat + turtle;
            double difference = food - total;

            if (difference >= 0)
            {
                Console.WriteLine($"{Math.Floor(Math.Abs(difference))} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(Math.Abs(difference))} more kilos of food are needed.");
            }

        }
    }
}
