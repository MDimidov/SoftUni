using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Area_of_Figures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string shape = Console.ReadLine();
            double area = 0;

            if(shape == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
                //Console.WriteLine(area);
            }
            else if (shape == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = b * a;
                //Console.WriteLine(a * b);
            }
            else if (shape == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = r * r * Math.PI;
            }
            else if (shape == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b / 2;
            }



            Console.WriteLine($"{area:f3}");

        }
    }
}
