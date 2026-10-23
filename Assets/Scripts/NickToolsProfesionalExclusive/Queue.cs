using UnityEngine;
using System;

namespace Environment {
    public sealed class Queue<T> {
        private T[] items = new T[0];


        //Change to list

        public int Count { get; private set; }

        public void Enqueue(T item) {
            T[] newItems = new T[Count + 1];
            for(int i = 0; i < Count; i++)
                newItems[i] = items[i];

            newItems[Count] = item;
            items = newItems;
            Count++;
        }

        public T Dequeue() {
            if(Count == 0)
                throw new InvalidOperationException("I cant dequeue nothing");

            T item = items[0];
            T[] newItems = new T[Count - 1];
            for(int i = 1; i < Count; i++)
            {
                newItems[i - 1] = items[i];
            }

            items = newItems;
            Count--;
            return item;
        }

        public T Peek() {
            if(Count == 0)
                throw new InvalidOperationException("Bro, queue is empty");

            return items[0];
        }

        public void Clear() {
            items = new T[0];
            Count = 0;
        }
    }
}
