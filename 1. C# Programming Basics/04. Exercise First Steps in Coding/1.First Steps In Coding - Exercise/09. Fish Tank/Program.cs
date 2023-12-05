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
            //      - 1.Дължина в см – int
            int a = int.Parse(Console.ReadLine());

            //      - 2.Широчина в см – int
            int b = int.Parse(Console.ReadLine());

            //      - 3.Височина в см – int
            int c = int.Parse(Console.ReadLine());

            //      - 4.Процент  – double
            double percent = double.Parse(Console.ReadLine());
            double percent1 = percent / 100;


            //2. Пресмятаме обема на паралелепипеда
            double V = (a * b * c) / 1000.0;

            //3. Изчисляваме достъпния обем в паралелепипеда
            double V1 = V - (V * percent1);


            //4. Отпечатваме крайния резултат
            Console.WriteLine(V1);
        }
    }
}