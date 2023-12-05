using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sum_Seconds
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Четем от конзолата времето на 3мата състезатели (в сек.)
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            //2. Намираме сумарно за колко секунди са финиширали (в сек.)
            int time = first + second + third;

            //3. Намираме това време - колко минути и колко секунди
            int min = time / 60; // example: 100/60=1;
            int sec = time % 60; // example: 100%60=40;

            /*4. Отпечатваме резултата в конзолата
             *  => 4.1 секундите да бъдат >= 10 сек. => мин:сек
             *  => 4.2 секундите да бъдат < 10 сек. => мин:0сек */
            if (sec >= 10)
            {
                Console.WriteLine($"{min}:{sec}");
            }
            else
            {
                Console.WriteLine($"{min}:0{sec}");
            }
        }
    }
}
