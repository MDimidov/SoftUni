using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Max_Number
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int minNum = int.MaxValue;
            int num;
            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                num = int.Parse(input);
                if (minNum > num)
                    minNum = num;
            }
            Console.WriteLine(minNum);
        }
    }
}
