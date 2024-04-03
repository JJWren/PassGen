namespace PassGen.Classes.Factories
{
    /// <summary>
    /// Generates passwords using pre-defined factory methods.
    /// </summary>
    public class PasswordFactory
    {
        /// <summary>
        /// Using the default <see cref="PasswordRuleset"/>, a password will be generated and validated.
        /// </summary>
        /// <returns>The validated password as a <see cref="string"/>.</returns>
        public static string GenerateValidPasswordFromDefaultRuleset()
        {
            Console.WriteLine("Generating new password...");
            Generator generator = new();
            PasswordValidator validator = new();

            while (generator.ValidPassword == null)
            {
                generator.GeneratePassword();

                if (validator.IsPasswordIsValidAgainstRuleset(generator))
                {
                    generator.ValidPassword = generator.PasswordToBeValidated;
                    generator.PasswordToBeValidated = null;
                }
            }
            return generator.ValidPassword;
        }

        /// <summary>
        /// Using the default <see cref="PasswordRuleset"/>, generates the desired number of passwords using:
        /// <br/><see cref="GenerateValidPasswordFromDefaultRuleset"/>.
        /// </summary>
        /// <param name="numberOfPasswords">Desired number of passwords to generate.</param>
        /// <returns><see cref="List{T}"/> of validated <see cref="string"/> passwords.</returns>
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

        /// <summary>
        /// Using a customized <see cref="PasswordRuleset"/>, a password will be generated and validated.
        /// </summary>
        /// <param name="ruleset"></param>
        /// <returns>The validated password as a <see cref="string"/>.</returns>
        public static string GenerateValidPasswordWithNewRuleset(PasswordRuleset ruleset)
        {
            Console.WriteLine("Generating new password...");
            Generator generator = new()
            {
                Ruleset = ruleset
            };
            PasswordValidator validator = new();

            while (generator.ValidPassword == null)
            {
                generator.GeneratePassword();

                if (validator.IsPasswordIsValidAgainstRuleset(generator))
                {
                    generator.ValidPassword = generator.PasswordToBeValidated;
                    generator.PasswordToBeValidated = null;
                }
            }
            return generator.ValidPassword;
        }

        /// <summary>
        /// Using a customized <see cref="PasswordRuleset"/>, generates the desired number of passwords using:
        /// <br/><see cref="GenerateValidPasswordWithNewRuleset"/>.
        /// </summary>
        /// <param name="numberOfPasswords">Desired number of passwords to generate.</param>
        /// <param name="ruleset">Customizable password ruleset.</param>
        /// <returns><see cref="List{T}"/> of validated <see cref="string"/> passwords.</returns>
        public static List<string> GenerateMultipleValidPasswordsFromNewRuleset(int numberOfPasswords, PasswordRuleset ruleset)
        {
            Console.WriteLine("Generating password list...");
            List<string> passwordList = new();

            while (numberOfPasswords > 0)
            {
                Console.WriteLine($"{numberOfPasswords} left to generate...");
                passwordList.Add(GenerateValidPasswordWithNewRuleset(ruleset));
                numberOfPasswords--;
            }

            return passwordList;
        }
    }
}
