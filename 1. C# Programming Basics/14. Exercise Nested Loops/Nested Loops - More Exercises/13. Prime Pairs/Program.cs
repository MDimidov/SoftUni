using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Prime_Pairs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //От конзолата се четат четири реда:
            //      •	На първия ред – началната стойност на първите първата двойка числа – цяло положително число в диапазона[10… 90]
            int firstStart = int.Parse(Console.ReadLine());
            //      •	На втория ред – началната стойност на втората двойка числа – цяло положително число в диапазона[10… 90]
            int secondStart = int.Parse(Console.ReadLine());
            //      •	На третия ред – разликата между началната и крайната стойност на първата двойка числа – цяло положително число в диапазона[1… 9]
            int firstFinish = int.Parse(Console.ReadLine()) + firstStart;
            //      •	На четвъртия ред – разликата между началната и крайната стойност на втората двойка числа – цяло положително число в диапазона[1… 9]
            int secondFinish = int.Parse(Console.ReadLine()) + secondStart;

            for (int i = firstStart; i <= firstFinish; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    for (int j = secondStart; j <= secondFinish; j++)
                    {
                        for (int k = 2; k < j; k++)
                        {
                            isPrime = true;
                            if (j % k == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        if (isPrime)
                        {
                            Console.WriteLine($"{i}{j}");
                        }
                    }

                }
            }

        }
    }
}
