using System.Security.Cryptography;

namespace PassGen.Classes
{
    /// <summary>
    /// Used for generating a randomized, unverified password. Should be run through the PasswordValidator class before use.
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Whitelist of numeric characters to be used.
        /// </summary>
        public string NumericCharacters { get; } = "0123456789";

        /// <summary>
        /// Whitelist of uppercase characters to be used.
        /// </summary>
        public string UppercaseCharacters { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Whitelist of lowercase characters to be used.
        /// </summary>
        public string LowercaseCharacters { get; } = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Whitelist of special characters to be used.
        /// </summary>
        public string SpecialCharacters { get; } = @"-~`!@#$%^&*_+=|:;',.?";

        /// <summary>
        /// A <see cref="PasswordRuleset"/> that defines how the passwords will be generated.
        /// </summary>
        public PasswordRuleset Ruleset { get; set; } = new PasswordRuleset();

        /// <summary>
        /// The generated password before it is validated.
        /// <br/>Created by the <see cref="GeneratePassword"/> method.
        /// </summary>
        public string? PasswordToBeValidated { get; set; } = null;

        /// <summary>
        /// The validated password. It is derived from the <see cref="PasswordToBeValidated"/>
        /// <br/>after is has gone through validation via the <see cref="PasswordValidator"/> class.
        /// </summary>
        public string? ValidPassword { get; set; } = null;

        /// <summary>
        /// Generates a random, unvalidated password based on the password ruleset -- <see cref="Ruleset"/>.
        /// <br/>If the ruleset is not defined, the default ruleset will be used.
        /// </summary>
        /// <returns>A randomly generated password that requires validation.</returns>
        public void GeneratePassword()
        {
            if (Ruleset.DesiredLengthOfPassword < Ruleset.PasswordLengthMinimum
                || Ruleset.DesiredLengthOfPassword > Ruleset.PasswordLengthMaximum)
            {
                throw new ArgumentOutOfRangeException(nameof(Ruleset.DesiredLengthOfPassword),
                    $"Password length must be equal to or inbetween the following:" +
                    $"\n\tMinimum length: {Ruleset.PasswordLengthMinimum}" +
                    $"\n\tMaximum length: {Ruleset.PasswordLengthMaximum}");
            }

            if (Ruleset.MaximumIdenticalConsecutiveCharacters < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Ruleset.MaximumIdenticalConsecutiveCharacters),
                    $"MaximumIdenticalConsecutiveCharacters must be greater than or equal to 1.");
            }

            string characterSet = GenerateAllowedCharacterSet();

            char[] passwordArr = new char[Ruleset.DesiredLengthOfPassword];
            int characterSetLength = characterSet.Length;

            for (int characterPosition = 0; characterPosition < Ruleset.DesiredLengthOfPassword; characterPosition++)
            {
                passwordArr[characterPosition] = characterSet[RandomNumberGenerator.GetInt32(characterSetLength)];

                bool maxConsecutiveCharactersSurpassed = false;
                int positionsToCheck = Ruleset.MaximumIdenticalConsecutiveCharacters - 1;
                int consecutiveCharCount = 0;

                if (positionsToCheck != 0 && characterPosition > positionsToCheck)
                {
                    while (positionsToCheck > 0)
                    {
                        if (passwordArr[characterPosition] != passwordArr[characterPosition - positionsToCheck])
                        {
                            break;
                        }

                        consecutiveCharCount++;
                        positionsToCheck--;
                    }

                    maxConsecutiveCharactersSurpassed = consecutiveCharCount > Ruleset.MaximumIdenticalConsecutiveCharacters;
                }

                // if true, repeat char generation on this position
                if (maxConsecutiveCharactersSurpassed) characterPosition--;
            }

            string password = string.Join(null, passwordArr);
            PasswordToBeValidated = password;
        }

        /// <summary>
        /// Generates a character set determined by the <seealso cref="Ruleset"/> that a password can be generated from.
        /// </summary>
        /// <returns>Allowed character set as a <seealso cref="string"/>.</returns>
        private string GenerateAllowedCharacterSet()
        {
            string characterSet = "";
            if (Ruleset.IncludeLowercase) characterSet += LowercaseCharacters;
            if (Ruleset.IncludeUppercase) characterSet += UppercaseCharacters;
            if (Ruleset.IncludeSpaces) characterSet += " ";
            if (Ruleset.IncludeNumeric) characterSet += NumericCharacters;
            if (Ruleset.IncludeSpecial) characterSet += SpecialCharacters;

            return characterSet;
        }
    }
}
