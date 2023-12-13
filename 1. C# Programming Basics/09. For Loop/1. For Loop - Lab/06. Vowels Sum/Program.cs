using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Vowels_Sum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a')
                    sum++;
                else if (text[i] == 'e')
                    sum += 2;
                else if (text[i] == 'i')
                    sum += 3;
                else if (text[i] == 'o')
                    sum += 4;
                else if (text[i] == 'u')
                    sum += 5;
            }
            Console.WriteLine(sum);
        }
    }
}
