using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesOfConverters.CustomTypeConverter
{
    public class WeekConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            var canConvert = sourceType == typeof(string) 
                || base.CanConvertFrom(context, sourceType);
            return canConvert;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is string input)
            {
                return Week.TryParse(input);
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
