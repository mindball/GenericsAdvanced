using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesOfConverters.TypeDescriptorGetConverter
{
    public class GetConverterDemo
    {
        public void BadConverter()
        {
            //type = typeof(T);
            //if (type == typeof(Boolean))
            //{
            //    returnValue = (T)((object)Convert.ToBoolean(value));
            //}
            //else if (type == typeof(String))
            //{
            //    returnValue = (T)((object)value);
            //}
            //else if (type == typeof(Int16))
            //{
            //    returnValue = (T)((object)Convert.ToInt16(value));
            //}
            //else if (type == typeof(Int32))
            //{
            //    returnValue = (T)((object)Convert.ToInt32(value));
            //}
            //...and on and on for a dozen+ types
        }


        public T GetTFromString<T>(string mystring)
        {
            var foo = TypeDescriptor.GetConverter(typeof(T));
            return (T)(foo.ConvertFromInvariantString(mystring));
        }
    }

}
