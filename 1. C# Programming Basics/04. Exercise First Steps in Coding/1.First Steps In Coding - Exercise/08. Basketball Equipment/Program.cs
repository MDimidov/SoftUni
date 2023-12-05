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
            double yearPrice = int.Parse(Console.ReadLine());

            //2. Пресмятаме цената за всяка екипировка
            //•	Баскетболни кецове – цената им е 40 % по - малка от таксата за една година
            double shoes = yearPrice * 0.6;
            //•	Баскетболен екип – цената му е 20 % по - евтина от тази на кецовете
            double equpment = shoes * 0.8;
            //•	Баскетболна топка – цената ѝ е 1 / 4 от цената на баскетболния екип
            double ball = equpment / 4;
            //•	Баскетболни аксесоари – цената им е 1 / 5 от цената на баскетболната топка
            double acc = ball / 5;

            double total = shoes + equpment + ball + acc;


            //3. Намираме общата сума (годишна такса + цяла екипировка)
            double fullPrice = total + yearPrice;

            //4. Отпечатваме крайния резултат
            Console.WriteLine(fullPrice);
        }
    }
}