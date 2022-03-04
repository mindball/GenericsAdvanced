using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypesOfConverters.AutomapperTypeConverter;
using TypesOfConverters.CustomTypeConverter;
using TypesOfConverters.IConvertibleDemo;
using TypesOfConverters.OverridingExplicitAndImplicitConversion;
using TypesOfConverters.TypeDescriptorGetConverter;

namespace TypesOfConverters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TypeDescriptor.GetConverter
            GetConverterDemo obj = new GetConverterDemo();
            var result = obj.GetTFromString<bool>("true");

            Color redColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString("Red");
            string redString = TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(Color.Red);
            ;
            #endregion

            #region Custom Type (attribute)
            var w = TypeDescriptor.GetConverter(typeof(Week));
            var a = w.ConvertFrom("2020-W03");
            #endregion

            #region IConvertible
            House newHouse = new House()
            {
                Address = "han Asparuh 4, Stara Zagora",
                ForSale = true,
                DateBuilt = new DateTime(1960),
                Area = 120.22,
                NumberOfRooms = 4
            };

            double d = Convert.ToDouble(newHouse);
            DateTime dt = Convert.ToDateTime(newHouse);
            int z = Convert.ToInt32(newHouse);
            String s = Convert.ToString(newHouse);
            bool b = Convert.ToBoolean(newHouse);
            ;

            #endregion

            #region Overriding Explicit And Implicit Conversion

            int firstValue = 20;
            Measurement implicitConv = firstValue;

            Measurement explicitConv = new Measurement() { Value = 10 };
            int secondValue = (int)explicitConv;

            #endregion

            #region Automapper type converters

            
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<string, int>().ConvertUsing(q => Convert.ToInt32(q));
                cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<string, Type>().ConvertUsing<TypeTypeConverter>();
                cfg.CreateMap<Source, Destination>();
            });
            configuration.AssertConfigurationIsValid();

            var mapper = new Mapper(configuration);

            var source = new Source
            {
                Value1 = "5",
                Value2 = "01.01.2021",
                Value3 = "TypesOfConverters.AutomapperTypeConverter.Destination"
            };

            var destination = mapper.Map<Source, Destination>(source);
            Console.WriteLine($"Type: {destination.Value1.GetType().Name}, value: {destination.Value1}");
            Console.WriteLine($"Type: {destination.Value2.GetType().Name}, value: {destination.Value2}");
            Console.WriteLine($"Type: {destination.Value3.GetType().Name}, value: {destination.Value3.Name}");
            ;

            #endregion
        }
    }
}
