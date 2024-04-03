namespace PassGen.Classes.Extensions
{
    /// <summary>
    /// Provides additional extentions to the <see cref="String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Creates a banner of '#' around the given string.
        /// <br/>Example:
        /// <example>
        /// <br/><br/>Given string:
        /// <br/><c>WELCOME</c>
        /// <br/><br/>Output:
        /// <code>#############
        /// #  WELCOME  #
        /// #############
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="str">The given <see cref="string"/>.</param>
        /// <returns>The given string with a banner of '#' around it.</returns>
        public static string ToBannerString(this string str)
        {
            if (str == null)
            {
                return string.Empty;
            }

            string bannerTopAndBottom = new('#', str.Length + 6);
            string bannerMiddle = $"#  {str}  #";
            return string.Join("\n", bannerTopAndBottom, bannerMiddle, bannerTopAndBottom);
        }
    }
}
