using System.Text.RegularExpressions;

namespace PassGen.Classes
{
    /// <summary>
    /// Contains predetermined regex for validating each password component
    /// <br/>and ultimately determining whether a password meets its ruleset's criteria.
    /// </summary>
    public class PasswordValidator
    {
        /// <summary>
        /// Regex for lowercase character set.
        /// </summary>
        public readonly string RegexLowercase = @"[a-z]";

        /// <summary>
        /// Regex for uppercase character set.
        /// </summary>
        public readonly string RegexUppercase = @"[A-Z]";

        /// <summary>
        /// Regex for numeric character set.
        /// </summary>
        public readonly string RegexNumeric = @"[\d]";

        /// <summary>
        /// Regex for special character set.
        /// </summary>
        public readonly string RegexSpecial = @"[-~`!@#$%^&*_+=|:;',.?]";

        /// <summary>
        /// Runs validation of a <see cref="Generator.PasswordToBeValidated"/> against that generator's ruleset.
        /// </summary>
        /// <param name="generator"></param>
        /// <returns><c>true</c> if the password successfully passes validation; otherwise, <c>false</c>.</returns>
        public bool IsPasswordIsValidAgainstRuleset(Generator generator)
        {
            if (generator.PasswordToBeValidated == null)
            {
                return false;
            }

            bool isLowercaseValid = generator.Ruleset.IncludeLowercase
                ? Regex.IsMatch(generator.PasswordToBeValidated, RegexLowercase)
                : !Regex.IsMatch(generator.PasswordToBeValidated, RegexLowercase);

            bool isUppercaseValid = generator.Ruleset.IncludeUppercase
                ? Regex.IsMatch(generator.PasswordToBeValidated, RegexUppercase)
                : !Regex.IsMatch(generator.PasswordToBeValidated, RegexUppercase);

            bool isNumericValid = generator.Ruleset.IncludeNumeric
                ? Regex.IsMatch(generator.PasswordToBeValidated, RegexNumeric)
                : !Regex.IsMatch(generator.PasswordToBeValidated, RegexNumeric);

            bool isSpecialValid = generator.Ruleset.IncludeSpecial
                ? Regex.IsMatch(generator.PasswordToBeValidated, RegexSpecial)
                : !Regex.IsMatch(generator.PasswordToBeValidated, RegexSpecial);

            bool isSpaceValid = generator.Ruleset.IncludeSpaces
                ? Regex.IsMatch(generator.PasswordToBeValidated, @"[\s]")
                : !Regex.IsMatch(generator.PasswordToBeValidated, @"[\s]");

            return isLowercaseValid && isUppercaseValid && isNumericValid && isSpecialValid && isSpaceValid;
        }
    }
}
