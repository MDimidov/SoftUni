namespace GenericScale;

class StartUp
{
    static void Main(string[] args)
    {

        EqualityScale<string> isEquals = new("pesho", "pes2ho");
        Console.WriteLine(isEquals.AreEqual());
    }
}