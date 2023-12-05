// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Четем данните от конзолата
            //  - Необходимо количество найлон (в кв.м.) - int 
            int nylon = int.Parse(Console.ReadLine());

            //  - Необходимо количество боя(в литри) - int 
            int paint = int.Parse(Console.ReadLine());

            //  - Количество разредител(в литри) - int
            int tinnerLiters = int.Parse(Console.ReadLine());

            //  - Часовете, за които майсторите ще свършат работата - int
            int workingTime = int.Parse(Console.ReadLine());



            //2. Пресмятаме цената за всеки от материалите
            //  •	Предпазен найлон - 1.50 лв. за кв. метър (+ 2кв.м)
            double nylonPrice = (nylon + 2) * 1.5;

            //  •	Боя - 14.50 лв.за литър (+ 10%)
            double paintPrice = (paint + 0.1 * paint) * 14.5;

            //  •	Разредител за боя - 5.00 лв.за литър
            double tinnerPrice = tinnerLiters * 5;



            //3. Обща сума за материали (+0,40лв. за торбичка)
            double materialSum = nylonPrice + paintPrice + tinnerPrice + 0.4;

            //4. Изчисляваме колко пари ще са необходими за майсторите (1 час = 30% от материалите)
            double workerSum = (0.3 * materialSum) * workingTime;

            //5. Изчисляваме общата сума (материали + работа на майсторите)
            double totalSum = materialSum + workerSum;

            //6. Отпечатваме резултата на конзолата (обшата сума ремонт)
            Console.WriteLine(totalSum);
        }
    }
}