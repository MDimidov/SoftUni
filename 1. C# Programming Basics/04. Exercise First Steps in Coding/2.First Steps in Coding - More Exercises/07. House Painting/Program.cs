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
            double x = double.Parse(Console.ReadLine()); //височина на къщата
            double y = double.Parse(Console.ReadLine()); //дължина на страничната стена
            double h = double.Parse(Console.ReadLine()); //височина на триъгълната част на покрива

            double S1 = 2 * x * x + 2 * x * y - 1.2 * 2 - 2 * 1.5 * 1.5; //лицето на стените боядисани в зелено
            double S2 = 2 * x * y + x * h; // лицето на покрива боядисан в червено

            double g = S1 / 3.4; //литри изразходвани зелена боя
            double r = S2 / 4.3; //литри изразходвани червена боя

            //double total = g + r; //общао литри


            Console.WriteLine(String.Format("{0:0.00}", g));
            Console.WriteLine(String.Format("{0:0.00}", r));

        }
    }
}