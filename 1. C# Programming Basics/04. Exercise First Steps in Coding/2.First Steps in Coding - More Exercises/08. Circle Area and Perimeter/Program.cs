// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine()); //радиус на кръга
            double pi = Math.PI; //наследяваме числото ПИ

            double S = pi * r * r; //лицето на окръжността
            double P = 2 * pi * r; //обиколката на окръжността



            Console.WriteLine(String.Format("{0:0.00}", S)); //отпечатва лицето на окръжността на нов ред
            Console.WriteLine(String.Format("{0:0.00}", P)); //отпечатва обиколката на окръжността на нов ред

        }
    }
}