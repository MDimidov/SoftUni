using System;
using System.Runtime.Serialization;

namespace _06._Operations_Between_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. От конзолата се прочитат 3 реда, въведени от потребителя:
            //      •	N1 – цяло число в интервала[0...40 000]
            int num1 = int.Parse(Console.ReadLine());
            //      •	N2 – цяло число в интервала[0...40 000]
            int num2 = int.Parse(Console.ReadLine());
            //      •	Оператор – един символ измежду: „+“, „-“, „*“, „/“, „%“
            char symbol = char.Parse(Console.ReadLine());
            double num3 = 0;
            if (symbol == '+' || symbol == '-' || symbol == '*')
            {
                string num = "odd";
                if (symbol == '+')
                {
                    num3 = num1 + num2;
                }
                else if (symbol == '-')
                {
                    num3 = (num1 - num2);
                }
                else if (symbol == '*')
                {
                    num3 = num1 * num2;
                }
                if (num3 % 2 == 0)
                {
                    num = "even";
                }
                Console.WriteLine($"{num1} {symbol} {num2} = {num3} - {num}");
            }
            
            if (symbol == '%' || symbol == '/')
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else if (symbol == '/')
                {
                    num3 = (double) num1 / num2;
                    Console.WriteLine($"{num1} {symbol} {num2} = {num3:f2}");

                }
                else
                {
                    num3 = num1 % num2;
                    Console.WriteLine($"{num1} {symbol} {num2} = {num3}");

                }
                
            }
            

        }
    }
}
