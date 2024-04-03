namespace PassGen.Classes
{
    /// <summary>
    /// Determines the password criteria that must be met (min/max length, allowable character types, etc).
    /// </summary>
    public class PasswordRuleset
    {
        /// <summary>
        /// The max allowable identical characters used consecutively (ex: "11", "aa", "www").
        /// </summary>
        public int MaximumIdenticalConsecutiveCharacters { get; set; } = 2;

        /// <summary>
        /// Minimum character length of the password.
        /// </summary>
        public int PasswordLengthMinimum { get; set; } = 8;

        /// <summary>
        /// Maximum character length of the password.
        /// </summary>
        public int PasswordLengthMaximum { get; set; } = 64;

        /// <summary>
        /// Dictates if the password will include lowercase characters.
        /// </summary>
        public bool IncludeLowercase { get; set; } = true;

        /// <summary>
        /// Dictates if the password will include uppercase characters.
        /// </summary>
        public bool IncludeUppercase { get; set; } = true;

        /// <summary>
        /// Dictates if the password will include numeric characters.
        /// </summary>
        public bool IncludeNumeric { get; set; } = true;

        /// <summary>
        /// Dictates if the password will include special characters.
        /// </summary>
        public bool IncludeSpecial { get; set; } = true;

        /// <summary>
        /// Dictates if the password will include spaces.
        /// </summary>
        public bool IncludeSpaces { get; set; } = false;

        /// <summary>
        /// Dictates the length of the password.
        /// </summary>
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
