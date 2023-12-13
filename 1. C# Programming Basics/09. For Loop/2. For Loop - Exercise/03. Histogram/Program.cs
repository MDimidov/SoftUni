using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Histogram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. На първия ред от входа стои цялото число n (1 ≤ n ≤ 1000) – брой числа.
            int n = int.Parse(Console.ReadLine());
            int num;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            //На следващите n реда стои по едно цяло число в интервала [1…1000] – числата върху които да бъде изчислена хистограмата.
            for (int i = 0; i < n; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (num < 200)
                    p1++;
                else if (num >= 200 && num <= 399)
                    p2++;
                else if (num >= 400 && num <= 599)
                    p3++;
                else if (num >= 600 && num < 800)
                    p4++;
                else
                    p5++;
            }

            //Отпечатваме
            Console.WriteLine($"{p1 / n * 100:f2}%");
            Console.WriteLine($"{p2 / n * 100:f2}%");
            Console.WriteLine($"{p3 / n * 100:f2}%");
            Console.WriteLine($"{p4 / n * 100:f2}%");
            Console.WriteLine($"{p5 / n * 100:f2}%");


        }
    }
}
