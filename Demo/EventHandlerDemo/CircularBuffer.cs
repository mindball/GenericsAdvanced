using System;
using System.Collections;
using System.Collections.Generic;

namespace EventHandlerDemo
{ 
    public class CircularBuffer<T> : Buffer<T>
    {
        //Problem with EvenArgs is that makes a very difficult to a pass along any addition informations
        public event EventHandler<EventArgs> ItemDiscard;

        public event EventHandler<ItemDiscardedEventArgs<T>> CustomItemDiscard;

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
                var discard = _queue.Dequeue();
                OnItemDiscarded(discard, value);
            }
        }

        private void OnItemDiscarded(T discard, T value)
        {
            if(CustomItemDiscard != null)
            {
                var args = new ItemDiscardedEventArgs<T>(discard, value);
                CustomItemDiscard(this, args);
            }
        }
    }

    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T discardItem, T newItem)
        {
            ItemDiscarded = discardItem;
            NewItem = newItem;
        }

        public T ItemDiscarded { get; set; }

        public T NewItem { get; set; }
    }
}
