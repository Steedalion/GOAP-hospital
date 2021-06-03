using System;
using System.Collections.Generic;

namespace Planning
{
    public class MyQueue<T>
    {
        private Queue<T> thisQueue = new Queue<T>();

        public delegate void OnEvent();

        public OnEvent onUpdate;


        public void Add(T element)
        {
            thisQueue.Enqueue(element);
            onUpdate?.Invoke();
        }

        public int Size()
        {
            return thisQueue.Count;
        }

        public void ClearQueueNotEvents()
        {
            thisQueue.Clear();
            thisQueue = new Queue<T>();
            onUpdate?.Invoke();
        }

        public T Remove()
        {
            if (Size() == 0)
            {
                throw new EmptyQueue();
            }
            onUpdate?.Invoke();
            return thisQueue.Dequeue();
        }

        public bool IsEmpty()
        {
            return Size() < 1;
        }
    }

    public class EmptyQueue : Exception
    {
    }
}