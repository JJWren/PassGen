using PassGen.Classes;
using PassGen.Classes.Extensions;
using PassGen.Classes.Factories;

Console.WriteLine("Welcome to PassGen!".ToBannerString() +
    "\nThis is really meant to be a package, but I have left it as a console app " +
    "to show a few example outputs until it is fully ready.");

Console.WriteLine("\n" +
    "Generating a Single Password Via Default Ruleset:".ToBannerString());
Console.WriteLine(PasswordFactory.GenerateValidPasswordFromDefaultRuleset());

Console.WriteLine("\n" +
    "Generating 5 Passwords Via Default Ruleset:".ToBannerString());
Console.WriteLine(PasswordFactory.GenerateMultipleValidPasswordsFromDefaultRuleset(5).ToListString());


Console.WriteLine("\n" +
    "Generating a Single Password Via Custom Ruleset:".ToBannerString());
PasswordRuleset customRuleset = new()
{
    MaximumIdenticalConsecutiveCharacters = 3,
    PasswordLengthMaximum = 128,
    IncludeSpaces = true,
    DesiredLengthOfPassword = 128
};
Console.WriteLine(PasswordFactory.GenerateValidPasswordWithNewRuleset(customRuleset));

Console.WriteLine("\nGoodbye!");
Environment.Exit(0);