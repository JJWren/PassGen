using PassGen.Classes.Extensions;
using PassGen.Classes.Factories;

Console.WriteLine("Welcome to PassGen!\n\n" +
    "This is really meant to be a package, but I have left it as a console app " +
    "to show a few example outputs until it is fully ready.");

Console.WriteLine("\nGenerating a Single Password Via Default Ruleset:");
Console.WriteLine(PasswordFactory.GenerateValidPasswordFromDefaultRuleset());

Console.WriteLine("\nGenerating 5 Passwords Via Default Ruleset:");
string test = PasswordFactory.GenerateMultipleValidPasswordsFromDefaultRuleset(5).ToListString();
Console.WriteLine(test);