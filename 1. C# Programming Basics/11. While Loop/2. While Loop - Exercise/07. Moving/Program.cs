using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Moving
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Потребителят въвежда следните данни на отделни редове:
            //      1.Широчина на свободното пространство - цяло число в интервала[1...1000]
            int width = int.Parse(Console.ReadLine());
            //      2.Дължина на свободното пространство - цяло число в интервала[1...1000]
            int length = int.Parse(Console.ReadLine());
            //      3.Височина на свободното пространство - цяло число в интервала[1...1000]
            int height = int.Parse(Console.ReadLine());

            string input;
            int currentBoxes = 0;
            int coutBoxes = 0;
            int leftPlace = width * length * height;
            //      4.На следващите редове(до получаване на команда "Done") -брой кашони, които се пренасят в квартирата - цяло число в интервала[1...10000]
            //      Програмата трябва да приключи прочитането на данни при команда "Done" или ако свободното място свърши.
            while ((input = Console.ReadLine()) != "Done")
            {
                currentBoxes = int.Parse(input);
                leftPlace -= currentBoxes;
                if (leftPlace <=0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(leftPlace)} Cubic meters more.");
                    return;
                }
            }
            Console.WriteLine($"{leftPlace} Cubic meters left.");
        }
    }
}
