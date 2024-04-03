using System.Collections;

namespace PassGen.Classes.Extensions
{
    /// <summary>
    /// Provides additional extentions to the <see cref="IEnumerable"/> class.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Creates a readable <see cref="string"/> version of the given <see cref="IEnumerable"/>.
        /// <br/>Example:
        /// <code>
        /// [ 55, 67, 42 ] => "[ 55, 67, 42 ]"
        /// </code>
        /// </summary>
        /// <param name="ienum">The given <see cref="IEnumerable"/>.</param>
        /// <returns>The <see cref="IEnumerable"/> as a readable <see cref="string"/>.</returns>
        public static string ToListString(this IEnumerable ienum)
        {
            if (ienum == null)
            {
                return string.Empty;
            }

            return $"[ {string.Join(", ", ienum.Cast<object>().ToList())} ]";
        }
    }
}
