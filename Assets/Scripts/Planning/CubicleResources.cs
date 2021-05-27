using System;
using System.Collections.Generic;
using UnityToolbox.Tools;

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

    public class PatientQueue : Singleton<PatientQueue>
    {
        private readonly MyQueue<Patient> myQueue = new MyQueue<Patient>();

        public MyQueue<Patient> MyQueue
        {
            get { return myQueue; }
        }
    }
    public class CubicleResources : Singleton<CubicleResources>
    {
        private readonly MyQueue<Cubicle> myQueue = new MyQueue<Cubicle>();

        public MyQueue<Cubicle> MyQueue
        {
            get { return myQueue; }
        }
    }

    public class EmptyQueue : Exception
    {
    }
}