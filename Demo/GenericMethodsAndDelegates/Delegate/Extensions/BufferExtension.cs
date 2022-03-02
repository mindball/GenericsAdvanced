using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GenericMethodsAndDelegates.Delegate.Extensions
{
    //boxing version
    public delegate void Print(object print);

    //generic version
    public delegate void Print<T>(T print);

    public static class BufferExtension
    {

        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TOutput));
            foreach (var item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
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
    }
}
