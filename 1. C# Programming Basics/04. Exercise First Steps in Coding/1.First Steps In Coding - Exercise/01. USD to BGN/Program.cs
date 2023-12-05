// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Запазваме USD, които идват от конзовата в променлива от тип double
            double usd = double.Parse(Console.ReadLine());

            //2. Преобразуваме USD > BGN (1 USD = 1.79549 BGN)
            double bgn = usd * 1.79549;

            //3. Извеждаме резултата от конзолата (BGN)
            Console.WriteLine(bgn);
            
        }
    }
}