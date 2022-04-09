using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsConstraint
{
    public static class EnumExtensions
    {
        public static HashSet<T> ToSet<T>(this List<string> statusCodes)
            where T : Enum
        {
            //only accept enum values (not names)
            //The problem with Enum.Parse() is it returns an enum object even if there’s no matching enum value
            return new HashSet<T>(statusCodes.Where(s => !string.IsNullOrEmpty(s)
                                                         && Int32.TryParse(s, out int intValue)
                                                         && Enum.IsDefined(typeof(T), intValue))
                .Select(s => (T) Enum.Parse(typeof(T), s)));
        }

        public static T Parse<T>(this string enumStr)
            where T : Enum
            => (T) Enum.Parse(typeof(T), enumStr);
    }
}
