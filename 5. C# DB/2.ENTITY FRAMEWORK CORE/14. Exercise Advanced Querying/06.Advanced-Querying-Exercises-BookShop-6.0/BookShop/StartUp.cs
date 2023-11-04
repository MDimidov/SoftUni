namespace BookShop;

using BookShop.Models;
using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        //Stopwatch sp = Stopwatch.StartNew();
        //2.	Age Restriction
        //string input = Console.ReadLine()!.ToLower();
        //string result = GetBooksByAgeRestriction(db, input);
        //Console.WriteLine(result);

        //3.	Golden Books
        //Console.WriteLine(GetGoldenBooks(db));

        //4.	Books by Price
        //Console.WriteLine(GetBooksByPrice(db));

        //5.	Not Released In
        //int year = int.Parse(Console.ReadLine()!);
        //Console.WriteLine(GetBooksNotReleasedIn(db, year));

        //6.	Book Titles by Category
        //string input = Console.ReadLine()!;
        //Console.WriteLine(GetBooksByCategory(db, input));

        //7.	Released Before Date
        //string input = Console.ReadLine()!;
        //Console.WriteLine(GetBooksReleasedBefore(db, input));

        //8.	Author Search
        //string input = Console.ReadLine()!;
        //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

        //9.	Book Search
        //string input = Console.ReadLine()!;
        //Console.WriteLine(GetBookTitlesContaining(db, input));

        //10.	Book Search by Author
        //string input = Console.ReadLine()!;
        //sp.Restart();
        //Console.WriteLine(GetBooksByAuthor(db, input));

        //11.	Count Books
        //int lengthCheck = int.Parse(Console.ReadLine()!);
        //Console.WriteLine(CountBooks(db, lengthCheck));

        //12.	Total Book Copies
        //Console.WriteLine(CountCopiesByAuthor(db));

        //13.	Profit by Category
        //Console.WriteLine(GetTotalProfitByCategory(db));

        //14.	Most Recent Books
        //sp.Restart();
        //Console.WriteLine(GetMostRecentBooks(db));

        //15.	Increase Prices
        //IncreasePrices(db);

        //16.	Remove Books
        Console.WriteLine(RemoveBooks(db));



        //sp.Stop();
        //Console.WriteLine(sp.ElapsedMilliseconds);
    }

    //2.	Age Restriction
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        AgeRestriction translation = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

        var books = context.Books
            .AsNoTracking()
            .Where(b => b.AgeRestriction == translation)
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray();

        return String.Join(Environment.NewLine, books);
    }

    //3.	Golden Books
    public static string GetGoldenBooks(BookShopContext context)
    {
        EditionType goldEdition = EditionType.Gold;

        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Copies < 5000 &&
                        b.EditionType == goldEdition)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, books);
    }

    //4.	Books by Price
    public static string GetBooksByPrice(BookShopContext context)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => $"{b.Title} - ${b.Price:f2}")
            .ToArray();

        return string.Join(Environment.NewLine, books);
    }

    //5.	Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate!.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, books);
    }

    //6.	Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToArray();

        var books = context.Books
            .AsNoTracking()
            .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray();

        return String.Join(Environment.NewLine, books);
    }

    //7.	Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        var books = context.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate < dateTime)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
            .ToArray();

        return String.Join(Environment.NewLine, books);
    }

    //8.	Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        //input = "%" + input;
        var authors = context.Authors
            //.FromSqlInterpolated(@$"SELECT [a].[AuthorId], [a].[FirstName], [a].[LastName]
            //                        FROM [Authors] AS [a]
            //                        Where [a].[FirstName] LIKE {input}")
            .AsNoTracking()
            //.ToArray()
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => $"{a.FirstName} {a.LastName}")
            .ToArray()
            .OrderBy(a => a);

        return string.Join(Environment.NewLine, authors);
    }

    //9.	Book Search
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray();

        return string.Join(Environment.NewLine, books);
    }

    //10.	Book Search by Author
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
            .ToArray();

        return string.Join(Environment.NewLine, books);
    }

    //11.	Count Books
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        return context.Books
            .AsNoTracking()
            .Count(b => b.Title.Length > lengthCheck);
    }

    //12.	Total Book Copies
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var authors = context.Authors
            .AsNoTracking()
            .OrderByDescending(a => a.Books.Sum(b => b.Copies))
            .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
            .ToArray();

        return string.Join(Environment.NewLine, authors);
    }

    //13.	Profit by Category
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var categories = context.Categories
            .AsNoTracking()
            .OrderByDescending(c => c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies))
            .ThenBy(c => c.Name)
            .Select(c => $"{c.Name} ${c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies):f2}")
            .ToArray();

        return string.Join(Environment.NewLine, categories);
    }

    //14.	Most Recent Books
    public static string GetMostRecentBooks(BookShopContext context)
    {
        StringBuilder sb = new();

        var booksByCategories = context.Categories
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                c.Name,
                Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Select(cb => $"{cb.Book.Title} ({cb.Book.ReleaseDate!.Value.Year})")
                        .Take(3)
                        .ToArray()
            })
            .ToArray();

        foreach (var category in booksByCategories)
        {
            sb.AppendLine($"--{category.Name}");
            foreach (var book in category.Books)
            {
                sb.AppendLine(book);
            }
        }

        return sb.ToString().TrimEnd();
    }

    //15.	Increase Prices
    public static void IncreasePrices(BookShopContext context)
    {
        const decimal PriceToIncrease = 5;

        context.Books
            .Where(b => b.ReleaseDate.HasValue &&
                        b.ReleaseDate.Value.Year < 2010)
            .UpdateFromQuery(b => new Book()  { Price = b.Price + PriceToIncrease});

        //foreach (var book in books)
        //{
        //    book.Price += PriceToIncrease;
        //}

        

        //context.SaveChanges();
    }

    //16.	Remove Books
    public static int RemoveBooks(BookShopContext context)
    {
        const int MinRequiredCopies = 4200;

        var booksToDelete = context.Books
            .Where(b => b.Copies < MinRequiredCopies);

        int deletedBooks = booksToDelete.Count();

        //context.RemoveRange(booksToDelete);
        //context.SaveChanges();

        booksToDelete.DeleteFromQuery();

        return deletedBooks;
    }
}



