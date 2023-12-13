using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Character_Sequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
