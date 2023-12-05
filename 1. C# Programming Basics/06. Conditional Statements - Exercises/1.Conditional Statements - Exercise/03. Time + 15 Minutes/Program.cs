using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Time___15_Minutes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме час и минути
            int hh = int.Parse(Console.ReadLine());
            int mm = int.Parse(Console.ReadLine());

            //2. Съобразяваме се със следните условия
            int total = hh * 60 + mm + 15;
            int h = total / 60;
            double m = total % 60;

            //3. Проверяваме дали часовете са повече от 24
            if (h>=24)
                h -= 24;

            //4. Отпечатваме крайния резултат
            Console.WriteLine($"{h}:{m:00}");

            Console.WriteLine($"{h}:{String.Format("{0:00}", m)}");
          //  Console.WriteLine($"{0:00}", 3.456);
        }
    }
}
