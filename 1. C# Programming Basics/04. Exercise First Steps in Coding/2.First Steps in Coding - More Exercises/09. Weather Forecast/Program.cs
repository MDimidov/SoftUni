// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String w = Console.ReadLine(); //въвеждане на времето в козолата

            if (w == "sunny") //с иф функцията проверяваме дали времето е слънчево ако ->
            {
                Console.WriteLine("It's warm outside!"); //твърдението е вярно отпечатва тази, част
            }
            else
            {
                Console.WriteLine("It's cold outside!"); //твърдението е грешно отпечатва тази, част
            }
          
        }
    }
}