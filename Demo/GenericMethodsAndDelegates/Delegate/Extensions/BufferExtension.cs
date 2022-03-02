using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GenericMethodsAndDelegates.Delegate.Extensions
{
    //boxing version
    //custom delegate type
    public delegate void Print(object print);

    //generic version
    //custom delegate type
    public delegate void Print<T>(T print);

    public static class BufferExtension
    {
        //This cannot convert DateTime
        //Refactor to Map
        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TOutput));
            foreach (var item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }

        public static IEnumerable<TOutput> Map<T, TOutput>(this IBuffer<T> buffer, Converter<T, TOutput> converter)
        {
            //But this is projection, and there be a short way
            //foreach (var item in buffer)
            //{
            //    TOutput result = converter(item);
            //    yield return result;
            //}

            //Shortway
            return buffer.Select(b => converter(b));
        }

        //boxing version
        public static void Dump<T>(this IBuffer<T> buffer, Print print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }

        //generic version
        public static void Dump<T>(this IBuffer<T> buffer, Print<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }

        public static void DumpWithActionPredicate<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }
    }
}
