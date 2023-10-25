using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen.Classes.Extensions
{
    public static class IEnumerableExtensions
    {
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
