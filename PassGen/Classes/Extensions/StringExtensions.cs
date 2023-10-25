using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen.Classes.Extensions
{
    public static class StringExtensions
    {
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
