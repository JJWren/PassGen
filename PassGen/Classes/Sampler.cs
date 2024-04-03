using PassGen.Classes.Extensions;
using PassGen.Classes.Factories;

namespace PassGen.Classes
{
    /// <summary>
    /// The Sampler class gives methods to generate and run different example sets of the capabilities of PassGen.
    /// </summary>
    public class Sampler
    {
        /// <summary>
        /// The standard set of examples cases of password generation.
        /// <list type="bullet">
        ///     <listheader>
        ///         <term>Example Cases:</term>
        ///         <description>These will be run by the method.</description>
        ///     </listheader>
        ///     <item><see cref="PasswordFactory.GenerateValidPasswordFromDefaultRuleset"/></item>
        ///     <item><see cref="PasswordFactory.GenerateMultipleValidPasswordsFromDefaultRuleset"/></item>
        ///     <item><see cref="PasswordFactory.GenerateValidPasswordWithNewRuleset"/></item>
        /// </list>
        /// </summary>
        public static void RunBase()
        {
            Console.WriteLine("Welcome to PassGen's base sample set!".ToBannerString());

            Console.WriteLine("\n" +
                "Generating a Single Password Via Default Ruleset:".ToBannerString());
            Console.WriteLine(PasswordFactory.GenerateValidPasswordFromDefaultRuleset());

            Console.WriteLine("\n" +
                "Generating 5 Passwords Via Default Ruleset:".ToBannerString());
            List<string> passwordList = PasswordFactory.GenerateMultipleValidPasswordsFromDefaultRuleset(5);

            foreach (string password in passwordList)
            {
                Console.WriteLine($"\t{password}");
            }

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
        }
    }
}
