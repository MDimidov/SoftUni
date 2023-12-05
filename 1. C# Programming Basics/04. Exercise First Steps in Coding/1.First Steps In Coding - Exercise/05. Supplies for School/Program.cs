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
            //1. Трябва да вкараме данните
                //•	Брой пакети химикали - int
            int pens = int.Parse(Console.ReadLine());

                //•	Брой пакети маркери - int
            int markers = int.Parse(Console.ReadLine());   

                //•	Литри препарат за почистване на дъска - int
            int preparation = int.Parse(Console.ReadLine());

                //•	Процент намаление - int
            int percent = int.Parse(Console.ReadLine());



            //2. Тук изчисляваме колко ще заплати за всеки продукт
            double pensPrice = pens * 5.8; 
            double markersPrice = markers * 7.20;
            double preparationPrice = preparation * 1.2;
            double discount = percent / 100.0;

            //3. Цена на материалите (общата сума + отстъпка)
            double totalPrice = pensPrice + markersPrice + preparationPrice;
            double totalPriceDis = totalPrice - totalPrice * discount;

            //4. Отпечатваме крайния резултат
            Console.WriteLine(totalPriceDis);

        }
    }
}