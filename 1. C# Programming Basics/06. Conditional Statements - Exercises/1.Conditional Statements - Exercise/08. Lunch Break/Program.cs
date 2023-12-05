using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Lunch_Break
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме от конзолата
            //      1.Име на сериал – текст
            string name = Console.ReadLine();
            //      2.Продължителност на епизод  – цяло число в диапазона[10… 90]
            int timeEpisode = int.Parse(Console.ReadLine());
            //      3.Продължителност на почивката  – цяло число в диапазона[10… 120]
            int rest = int.Parse(Console.ReadLine());

            //2. Съобразяваме се с това колкo време ни остава за филми
            double timeForMovie = rest * 5 / 8.0;

            double difference = timeForMovie - timeEpisode;
            //Console.WriteLine(timeForMovie);
            if(difference >= 0)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(difference)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(-difference)} more minutes.");
            }

        }
    }
}
