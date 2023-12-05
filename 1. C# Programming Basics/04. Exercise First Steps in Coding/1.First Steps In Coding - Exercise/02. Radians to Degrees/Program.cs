// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Четем радиани от конзоата и ги записваме в променлива от тип double
            double radians = double.Parse(Console.ReadLine());

            //2. Преобразуваме радианите в градуси (формула: градус = радиани * 180 / Math.PI)
            double degrees = radians * 180 / Math.PI;

            //3. Отпечатваме резултата на конзолата
            Console.WriteLine(degrees);
        }
    }
}