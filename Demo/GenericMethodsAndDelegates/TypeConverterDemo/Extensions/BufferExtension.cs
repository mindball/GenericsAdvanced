using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethodsAndDelegates.TypeConverterDemo.Extensions
{
    public static class BufferExtension
    {
        //Parameter T come outside because BufferExtension is static and non-generic
        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBufferTypeConverter<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TOutput));
            foreach (var item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }

        public static void Dump<T>(this IBufferTypeConverter<T> buffer)
        {
            foreach (var item in buffer)
            {
                Console.WriteLine(item);
            }
        }
    }
}
