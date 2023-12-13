using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Game_Of_Intervals
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. We enter from Console quantity of numbers
            int n = int.Parse(Console.ReadLine());

            double sum = 0;
            int from0to9 = 0;
            int from10to19 = 0;
            int from20to29 = 0;
            int from30to39 = 0;
            int from40to50 = 0;
            int invalid = 0;

            //2. We create loops to insert n numbers
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num >= 0 && num <= 9)
                {
                    sum += 0.2 * num;
                    from0to9++;
                }
                else if (num >= 10 && num <= 19)
                {
                    sum += 0.3 * num;
                    from10to19++;
                }
                else if (num >= 20 && num <= 29)
                {
                    sum += 0.4 * num;
                    from20to29++;
                }
                else if (num >= 30 && num <= 39)
                {
                    sum += 50;
                    from30to39++;
                }
                else if (num >= 40 && num <= 50)
                {
                    sum += 100;
                    from40to50++;
                }
                else
                {
                    sum /= 2;
                    invalid++;
                }
            }
            Console.WriteLine($"{sum:f2}");
            Console.WriteLine($"From 0 to 9: {(double)from0to9 / n * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {(double)from10to19 / n * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {(double)from20to29 / n * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {(double)from30to39 / n * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {(double)from40to50 / n * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {(double)invalid / n * 100:f2}%");

        }
    }
}
