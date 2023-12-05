using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Even_or_Odd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Input
            string password = Console.ReadLine();

            //act
            if (password == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
                Console.WriteLine("Wrong password!");

        }
    }
}
