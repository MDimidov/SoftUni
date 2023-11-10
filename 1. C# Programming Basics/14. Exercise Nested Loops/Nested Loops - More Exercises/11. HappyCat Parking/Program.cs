using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.HappyCat_Parking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //От конзолата се четат два реда:
            //      •	Брой дни – цяло число в интервала[1 … 5]
            int days = int.Parse(Console.ReadLine());
            //      •	Брой часове за всеки един от дните - цяло число в интервала[1 … 24]
            int hours = int.Parse(Console.ReadLine());

            double totalSum = 0;

            for (int i = 1; i <= days; i++)
            {
                double sum = 0;
                
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                        sum += 2.5;
                    else if (i % 2 != 0 && j % 2 == 0)
                        sum += 1.25;
                    else
                        sum += 1;
                }
                Console.WriteLine($"Day: {i} - {sum:f2} leva");
                totalSum += sum;
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");

        }
    }
}
