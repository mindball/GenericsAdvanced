using AutoMapper;
using System;


namespace TypesOfConverters.AutomapperTypeConverter
{
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            var result = System.Convert.ToDateTime(source);
            return result;
        }
    }
}
