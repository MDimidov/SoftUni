using System;
namespace _03._Animal_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();
            string clas = "";

            switch (animal)
            {
                case "dog":
                    clas = "mammal";
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    clas = "reptile";
                    break;
                default:
                    clas = "unknown";
                    break;
            }
            Console.WriteLine(clas);
        }
    }
}