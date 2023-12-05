using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            double grade = double.Parse(Console.ReadLine());

            //Act
            if (grade >= 5.5)
            {
                Console.WriteLine("Excellent!");
            }



        }
    }
}