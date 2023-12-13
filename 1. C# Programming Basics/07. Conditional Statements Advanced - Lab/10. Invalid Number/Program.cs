using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Invalid_Number
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (!(number >= 100 && number <= 200 || number == 0))
            Console.WriteLine("invalid");
        }
    }
}
