using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Cinema_Tickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name;
            string ticket;
            int totalTickets = 0;
            int ttlStudent = 0;
            int ttlStandart = 0;
            int ttlKid = 0;
            //              Входът е поредица от цели числа и текст:
            //  •	На първия ред до получаване на командата "Finish" - име на филма – текст
            while ((name = Console.ReadLine()) != "Finish")
            {
            int studentTickets = 0;
            int standartTickets = 0;
            int kidTickets = 0;
                int allTickets = 0;
            //  •	На втори ред – свободните места в салона за всяка прожекция – цяло число[1 … 100]
                int freePlaces = int.Parse(Console.ReadLine());
            //  •	За всеки филм, се чете по един ред до изчерпване на свободните места в залата или до получаване на командата "End":
                while (allTickets < freePlaces && (ticket = Console.ReadLine()) != "End")
                {
                    //  o Типа на закупения билет - текст("student", "standard", "kid")
                    allTickets++;
                    switch (ticket)
                    {
                        case "student":
                            studentTickets++;
                            ttlStudent++;
                            break;
                        case "standard":
                            ttlStandart++;
                            standartTickets++;
                            break;
                            default:
                            ttlKid++;
                            kidTickets++;
                            break;
                    }
                }
                Console.WriteLine($"{name} - {((double)standartTickets + studentTickets + kidTickets) / freePlaces * 100:f2}% full.");
                totalTickets += studentTickets + standartTickets + kidTickets;
            }
            Console.WriteLine($"Total tickets: {totalTickets}\n" +
                $"{(double)ttlStudent / totalTickets * 100:f2}% student tickets.\n" +
                $"{(double)ttlStandart / totalTickets * 100:f2}% standard tickets.\n" +
                $"{(double)ttlKid / totalTickets * 100:f2}% kids tickets.");

        }
    }
}
