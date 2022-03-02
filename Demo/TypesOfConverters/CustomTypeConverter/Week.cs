using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesOfConverters.CustomTypeConverter
{
    [TypeConverter(typeof(WeekConverter))]
    public class Week
    {
        public int Year { get; set; }

        public int WeekNumber { get; set; }

        public static Week TryParse(string input)
        {
            string[] pattern = { "-W" };
            var result = input.Split(pattern, StringSplitOptions.None);
            if (result.Length != 2)
            {
                return null;
            }
            if (int.TryParse(result[0], out int year) && int.TryParse(result[1], out int week))
            {
                return new Week { Year = year, WeekNumber = week };
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Year}-W{WeekNumber:D2}"; 
        }
    }
}
