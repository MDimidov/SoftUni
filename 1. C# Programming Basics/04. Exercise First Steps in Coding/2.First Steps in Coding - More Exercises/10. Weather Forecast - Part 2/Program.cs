// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine()); //въвеждаме градусите по целзии в конзолата

            if (w >= 5 & w <= 11.9) //с иф функцията подаваме първото условие ако ->
            {
                Console.WriteLine("Cold"); //твърдението е вярно отпечатва тази част, ако не е продължава напред да търси съвпадение
            }
            else if (w >= 12 & w <= 14.9) //с else if функцията проверяваме следното твърдение
            {
                Console.WriteLine("Cool"); //ако е вярно отпеятва тази част, ако не преминава напред
            }

            else if (w >= 15 & w <= 20) //с else if функцията проверяваме следното твърдение
            {
                Console.WriteLine("Mild"); //ако е вярно отпеятва тази част, ако не преминава напред
            }

            else if (w >= 20.1 & w <= 25.9) //с else if функцията проверяваме следното твърдение
            {
                Console.WriteLine("Warm"); //ако е вярно отпеятва тази част, ако не преминава напред
            }

            else if (w >= 26 & w <= 35) //с else if функцията проверяваме следното твърдение
            {
                Console.WriteLine("Hot"); //ако е вярно отпеятва тази част, ако не преминава напред
            }

            else //с else функцията му задаваме какво да отпечата, ако няма съвпадения с горните условия
            {
                Console.WriteLine("unknown"); 
            }

        }
    }
}