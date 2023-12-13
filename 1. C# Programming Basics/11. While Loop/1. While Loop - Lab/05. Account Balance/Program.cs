using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Account_Balance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input;
            double money;
            double sum = 0;

            while ((input = Console.ReadLine()) != "NoMoreMoney")
            {
                money = double.Parse(input);
                if (money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Increase: {money:f2}");
                }
                sum += money;

            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
