using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sleepy_Tom_Cat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме броя почивни дни
            int restDays = int.Parse(Console.ReadLine());

            //2. Изчисляваме колко са работните дни
            int workDays = 365 - restDays;

            //3. Изчисляваме колко време за игра ще получи Том през годината
            int playWorkDays = workDays * 63;
            int playRestDays = restDays * 127;
            int yearPlay = playRestDays + playWorkDays;

            int difference = 30000 - yearPlay;
            int h = Math.Abs(difference) / 60;
            int m = Math.Abs(difference) % 60;


            if (difference < 0)
            {
                Console.WriteLine($"Tom will run away");
                Console.WriteLine($"{h} hours and {m} minutes more for play");
            }
            else
            {
                Console.WriteLine($"Tom sleeps well");
                Console.WriteLine($"{h} hours and {m} minutes less for play");
            }
        }
    }
}
