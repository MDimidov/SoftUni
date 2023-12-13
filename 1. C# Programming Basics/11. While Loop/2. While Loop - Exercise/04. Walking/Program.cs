using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Walking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input;
            int currentSteps;
            int totalSteps = 0;
            while (totalSteps < 10000)
            {
                input = Console.ReadLine();
                if (input == "Going home")
                {
                    currentSteps = int.Parse(Console.ReadLine());
                    totalSteps += currentSteps;
                    break;
                }
                else
                {
                    currentSteps = int.Parse(input);
                }
                totalSteps += currentSteps;
            }
            if (totalSteps >= 10000)
            {
                Console.WriteLine($"Goal reached! Good job!\n" +
                    $"{totalSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - totalSteps} more steps to reach goal.");
            }
        }
    }
}
