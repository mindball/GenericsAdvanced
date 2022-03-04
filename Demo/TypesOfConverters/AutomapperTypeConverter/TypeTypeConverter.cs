using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypesOfConverters.AutomapperTypeConverter
{
    public class TypeTypeConverter : ITypeConverter<string, Type>
    {
        public Type Convert(string source, Type destination, ResolutionContext context)
        {
            var result = Assembly.GetExecutingAssembly().GetType(source);
            return result;
        }
    }
}
