using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Coins
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            int counter = 0;

            while (sum > 0)
            {
                counter++;
                if (sum - 2 >= 0)
                    sum -= 2;
                else if (sum - 1 >= 0)
                    sum--;
                else if (sum - 0.5 >= 0)
                    sum -= 0.5;
                else if (sum - 0.2 >= 0)
                    sum -= 0.2;
                else if (sum - 0.1 >= 0)
                    sum -= 0.1;
                else if (sum - 0.05 >= 0)
                    sum -= 0.05;
                else if (sum - 0.02 >= 0)
                    sum -= 0.02;
                else
                    sum -= 0.01;
                sum = Math.Round(sum, 2);
            }
            Console.WriteLine(counter);
        }
    }
}
