using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen.Classes.Factories
{
    public class PasswordFactory
    {
        public static string GenerateValidPasswordFromDefaultRuleset()
        {
            Console.WriteLine("Generating new password...");
            Generator generator = new();
            PasswordValidator validator = new();

            while (generator.ValidPassword == null)
            {
                generator.GeneratePassword();

                if (validator.IsPasswordIsValidAgainstDefaultRuleset(generator))
                {
                    generator.ValidPassword = generator.PasswordToBeValidated;
                    generator.PasswordToBeValidated = null;
                }
            }
            return generator.ValidPassword;
        }

        public static List<string> GenerateMultipleValidPasswordsFromDefaultRuleset(int numberOfPasswords)
        {
            Console.WriteLine("Generating password list...");
            List<string> passwordList = new();

            while (numberOfPasswords > 0)
            {
                Console.WriteLine($"{numberOfPasswords} left to generate...");
                passwordList.Add(GenerateValidPasswordFromDefaultRuleset());
                numberOfPasswords--;
            }

            return passwordList;
        }
    }
}
