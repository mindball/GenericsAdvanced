using System.Collections;
using System.Collections.Generic;

namespace Demo.IEnumerableDemo
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }

        void Write(T value);

        T Read();
    }

    public class Buffer<T> : IBuffer<T>
    {
        protected Queue<T> _queue = new Queue<T> ();

        public virtual bool IsEmpty => _queue.Count == 0;

        public virtual T Read() =>  _queue.Dequeue();


        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
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

    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity;
        public CircularBuffer(int capacity)
        {
            this._capacity = capacity;
        }

        public bool IsFull => _queue.Count == _capacity;

        public override void Write(T value)
        {
            base.Write(value);
            if(_queue.Count > _capacity)
            {
                _queue.Dequeue();
            }
        }
    }
}
