using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
    private readonly Queue<T> _queue;
    private readonly int _capacity;

    public CircularBuffer(int capacity)
    {
        _queue = new Queue<T>(capacity);
        _capacity = capacity;
    }

    public T Read()
    {
        if (_queue.TryDequeue(out var result))
        {
            return result;
        }
        throw new InvalidOperationException();
    }

    public void Write(T value)
    {
        if (_queue.Count >= _capacity) throw new InvalidOperationException();
        _queue.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_queue.Count >= _capacity) _queue.Dequeue();
        _queue.Enqueue(value);
    }

    public void Clear() => _queue.Clear();
}
