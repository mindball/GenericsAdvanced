using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethodsAndDelegates.TypeConverterDemo
{
    public class BufferTypeConverter<T> : IBufferTypeConverter<T>, IBuffer<T>
    {
        protected Queue<T> _queue = new Queue<T>();

        public virtual bool IsEmpty => _queue.Count == 0;

        public virtual T Read() => _queue.Dequeue();


        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }
        //Refactoring to extension method
        //public IEnumerable<TOutput> AsEnumerableOf<TOutput>()
        //{
        //    var converter = TypeDescriptor.GetConverter(typeof(TOutput));
        //    foreach (var item in _queue)
        //    {
        //        var result = converter.ConvertTo(item, typeof(TOutput));
        //        yield return (TOutput)result;
        //    }
        //}

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
