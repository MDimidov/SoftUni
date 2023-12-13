using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Old_Books
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. We read from the Console favorite book
            string favoriteBook = Console.ReadLine();
            //2. We create counter for the books, which we checked
            int counter = 0;
            //3. We read from the console, title for this book
            string currentBook;
            //4. We turn on loop to run while we check every book in the library
            // => until we recieve command "No More books"
            while ((currentBook = Console.ReadLine()) != "No More Books")
            {
            //  4.1 We compare the title of this book to the title of Mimi's favorite book
            //  => if the titles is the same: we found the book and the loop end
                if (currentBook == favoriteBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    return;
                }
            //  => if the titles is different: we increase the counter by 1, and read new title
                counter++;
            }

            
            //5. We write that the book is missing
            Console.WriteLine($"The book you search is not here!\n" +
                $"You checked {counter} books.");
        }
    }
}
