using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Safe_Passwords_Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int cnt = 0;
            int A = 35;
            int B = 64;
            
            for (int x = 1; x<= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {                    
                    if(cnt == max)
                    {
                        return;
                    }
                    
                    Console.Write($"{(char)A}{(char)B}{x}{y}{(char)B}{(char)A}|");
                    
                    cnt++;
                    A++;
                    B++;

                    if (A > 55)
                        A = 35;
                    if (B > 96)
                        B = 64;                    
                }       
            }
            
        }
    }
}
