using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Password
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            while (password != Console.ReadLine()) { }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}
