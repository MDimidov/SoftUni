using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stream_Of_Letters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата се чете поредица от редове с един символ на всеки до получаване на командата "End".
            string input;
            char letter;
            string word = "";
            string sentence = "";
            int c = 0;
            int o = 0;
            int n = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                letter = input[0];
                if (Char.IsLetter(letter))
                {
                    if (letter == 'c' && c == 0)
                    {
                        c++;
                        //continue;
                    }
                    else if (letter == 'o' && o == 0)
                    { 
                        o++;
                        //continue;
                    }
                    else if (letter == 'n' && n == 0)
                    {
                        n++;
                        //continue;
                    }
                    else
                        word += letter;



                    if (c == o && o == n && o == 1)
                    {
                        word += " ";
                        c = 0;
                        o = 0;
                        n = 0;
                        sentence += word;
                        word = "";
                    }
                    
                }
            }
            Console.WriteLine(sentence);
        }
    }
}
