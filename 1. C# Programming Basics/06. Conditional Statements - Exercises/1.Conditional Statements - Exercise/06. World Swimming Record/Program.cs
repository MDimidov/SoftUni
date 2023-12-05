using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace _06.World_Swimming_Record
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Четем от конзолата
            //      1.Рекордът в секунди – реално число в интервала[0.00 … 100000.00]
            double worldRecord = double.Parse(Console.ReadLine());
            //      2.Разстоянието в метри – реално число в интервала[0.00 … 100000.00]
            double meters = double.Parse(Console.ReadLine());
            //      3.Времето в секунди, за което плува разстояние от 1 м. - реално число в интервала[0.00 … 1000.00]
            double timePerMeter = double.Parse(Console.ReadLine());

            //2. Изчисляваме с колко ще забави общо през цялото трасе
            double delay = Math.Floor(meters / 15) * 12.5;

            //3. Изчисляваме времето което му е нужно за да стигне финала
            double timeIvan = meters * timePerMeter + delay;

            double difference = worldRecord - timeIvan;
            if (difference > 0)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeIvan:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {Math.Abs(difference):f2} seconds slower.");
            }



        }
    }
}
