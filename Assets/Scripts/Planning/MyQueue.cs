using System;
using System.Collections.Generic;

namespace Planning.PlanningEditTests
{
    public class MyQueue<T>
    {
        private static Queue<T> queue = new Queue<T>();

        public void Add(T element)
        {
            queue.Enqueue(element);
        }

        public int Size()
        {
            return queue.Count;
        }

        public void Reset()
        {
            queue.Clear();
        }

        public T RemovePatient()
        {
            if (Size() == 0)
            {
                throw new EmptyQueue();
            }
            return queue.Dequeue();
        }
    }
        public class EmptyQueue : Exception
    {
    }
}