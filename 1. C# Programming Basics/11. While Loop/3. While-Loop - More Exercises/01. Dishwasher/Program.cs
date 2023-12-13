using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Dishwasher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата се четат:
            //      •	Брой бутилки от препарат, който ще бъде използван за миенето на чинии - цяло число в интервала[1…10]
            int preparationLeft = 750 * int.Parse(Console.ReadLine());
            int potsCounter = 0;
            string input;
            int dishes = 0;
            int sumCleanDishes = 0;
            int sumCleanPots = 0;
            //      На всеки следващ ред, до получаване на командата "End" или докато количеството
            //      препарат не се изчерпи, брой съдове, които трябва да бъдат измити -цяло число в интервала[1…100]
            while ((input = Console.ReadLine()) != "End")
            {
                potsCounter++;


                if (potsCounter % 3 == 0)
                {
                    dishes = 15 * int.Parse(input);
                    sumCleanPots += int.Parse(input);
                }
                else
                {
                    dishes = 5 * int.Parse(input);
                    sumCleanDishes += int.Parse(input);
                }
                preparationLeft -= dishes;
                if (preparationLeft < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(preparationLeft)} ml. more necessary!");
                    return;
                }

            }
            Console.WriteLine($"Detergent was enough!\n" +
                $"{sumCleanDishes} dishes and {sumCleanPots} pots were washed.\n" +
                $"Leftover detergent {preparationLeft} ml.");

        }
    }
}
