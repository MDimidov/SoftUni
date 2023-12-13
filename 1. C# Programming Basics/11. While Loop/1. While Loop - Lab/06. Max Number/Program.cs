using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Max_Number
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int maxNum = int.MinValue;
            int num;
            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                num = int.Parse(input);
                if (maxNum < num)
                    maxNum = num;
            }
            Console.WriteLine(maxNum);
        }
    }
}
