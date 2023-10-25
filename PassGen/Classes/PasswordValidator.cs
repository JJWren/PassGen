using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PassGen.Classes
{
    public class PasswordValidator
    {
        public readonly string RegexLowercase = @"[a-z]";
        public readonly string RegexUppercase = @"[A-Z]";
        public readonly string RegexNumeric = @"[\d]";
        public readonly string RegexSpecial = @"[-~`!@#$%^&*_+=|:;',.?]";

        public bool IsPasswordIsValidAgainstDefaultRuleset(Generator generator)
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
