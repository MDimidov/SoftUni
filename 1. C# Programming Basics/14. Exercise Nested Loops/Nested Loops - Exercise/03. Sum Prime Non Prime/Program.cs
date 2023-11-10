using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Sum_Prime_Non_Prime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input;
            int num;
            int sipleNum = 0;
            int difficultNum = 0;
            while((input = Console.ReadLine()) != "stop")
            {
                num = int.Parse(input);
                int sum = 0;
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (num == 0) { }

                else
                {
                    for (int i = 2; i <= num; i++)
                    {
                        if (num % i == 0)
                        {
                            sum++;
                        }
                    }
                    if (sum == 1)
                        sipleNum += num;
                    else
                        difficultNum += num;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {sipleNum}\n" +
                $"Sum of all non prime numbers is: {difficultNum}");
        }
    }
}
