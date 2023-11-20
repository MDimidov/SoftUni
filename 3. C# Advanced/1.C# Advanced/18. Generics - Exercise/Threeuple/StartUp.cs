using Threeuple;

string[] personTokens = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

string[] drinkTokens = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

string[] bankTokens = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


CustomThreeuple<string, string, string> personDetails = new($"{personTokens[0]} {personTokens[1]}", personTokens[2], String.Join(" ", personTokens[3..]));

CustomThreeuple<string, int, bool> drinkDetails = new(drinkTokens[0], int.Parse(drinkTokens[1]), drinkTokens[2] == "drunk");

CustomThreeuple<string, double, string> bankDetails = new(bankTokens[0], double.Parse(bankTokens[1]), bankTokens[2]);

Console.WriteLine(personDetails);
Console.WriteLine(drinkDetails);
Console.WriteLine(bankDetails);