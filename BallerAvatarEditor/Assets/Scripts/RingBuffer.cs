using UnityEngine;
using System.Collections.Generic;

public class RingBuffer<T> {
    Queue<T> _list;
    int maxcnt;

    public RingBuffer(int count)
    {
        _list = new Queue<T>(count);
        maxcnt = count;
        
    }

    public void Add(T item)
    {
        if (_list.Count >= maxcnt) {
            _list.Dequeue();
        }
        _list.Enqueue(item);
    }

    public T[] GetList()
    {
        return _list.ToArray();
    }
}
