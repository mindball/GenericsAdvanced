using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethodsAndDelegates.TypeConverterDemo
{
    public class BufferTypeConverter<T> : IBufferTypeConverter<T>
    {
        protected Queue<T> _queue = new Queue<T>();

        public virtual bool IsEmpty => _queue.Count == 0;

        public virtual T Read() => _queue.Dequeue();


        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }
        public IEnumerable<TOutput> AsEnumerable<TOutput>()
        {
            var converter = 
        }

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
