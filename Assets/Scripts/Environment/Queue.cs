using System;
using System.Collections.Generic;

public class MyQueue<T> {
    private readonly List<T> items = new List<T>();

    public int Count => items.Count;

    public bool IsEmpty => items.Count == 0;

    public void Enqueue(T item) {
        items.Add(item);
    }

    public T Dequeue() {
        if(IsEmpty) {
            throw new InvalidOperationException();
        }

        T item = items[0];
        items.RemoveAt(0);
        return item;
    }

    public T Peek() {
        if(IsEmpty) {
            throw new InvalidOperationException("No mame no items");
        }

        return items[0];
    }

    public void Clear() {
        items.Clear();
    }
}
