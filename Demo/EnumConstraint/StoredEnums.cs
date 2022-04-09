using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumConstraint
{
    public class StoredEnums
    {
        public static Dictionary<int, string> EnumNamedValues<T>()
            where T : Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(T), item)!);

            return result;
        }
    }
}
