using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EventHandlerDemo.Delegate
{
    public static class BufferExtension
    {
        public static void Dump<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }
    }
}
