using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen.Classes
{
    public class PasswordRuleset
    {
        public int MaximumIdenticalConsecutiveCharacters { get; set; } = 2;
        public int PasswordLengthMinimum { get; set; } = 8;
        public int PasswordLengthMaximum { get; set; } = 64;
        public bool IncludeLowercase { get; set; } = true;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeNumeric { get; set; } = true;
        public bool IncludeSpecial { get; set; } = true;
        public bool IncludeSpaces { get; set; } = false;
        public int DesiredLengthOfPassword { get; set; } = 12;

        /// <summary>
        /// Updates password ruleset based on parameters.
        /// </summary>
        /// <param name="maxIdenticalConsecChars">Allowed maximum of identical characters placed consecutively.</param>
        /// <param name="passwordLengthMin">Password length minimum.</param>
        /// <param name="passwordLengthMax">Password length maximum.</param>
        /// <param name="includeLowercase">Bool to say if lowercase are required</param>
        /// <param name="includeUppercase">Bool to say if uppercase are required</param>
        /// <param name="includeNumeric">Bool to say if numerics are required</param>
        /// <param name="includeSpecial">Bool to say if special characters are required</param>
        /// <param name="includeSpaces">Bool to say if spaces are required</param>
        /// <param name="lengthOfPassword">Length of password required. Must meet password length min/max constraints.</param>
        /// <returns>void.</returns>
        public void UpdatePasswordRuleset(int maxIdenticalConsecChars = 2,
            int passwordLengthMin = 8,
            int passwordLengthMax = 64,
            bool includeLowercase = true,
            bool includeUppercase = true,
            bool includeNumeric = true,
            bool includeSpecial = true,
            bool includeSpaces = false,
            int lengthOfPassword = 12)
        {
            MaximumIdenticalConsecutiveCharacters = maxIdenticalConsecChars;
            PasswordLengthMinimum = passwordLengthMin;
            PasswordLengthMaximum = passwordLengthMax;
            IncludeUppercase = includeUppercase;
            IncludeLowercase = includeLowercase;
            IncludeNumeric = includeNumeric;
            IncludeSpecial = includeSpecial;
            IncludeSpaces = includeSpaces;
            DesiredLengthOfPassword = lengthOfPassword;
        }
    }
}
