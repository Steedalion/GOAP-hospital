using System;
using System.Collections.Generic;
using UnityToolbox.Tools;

namespace Planning.PlanningEditTests
{
    public class PatientQueue : Singleton<PatientQueue>
    {
        private static Queue<Patient> queue = new Queue<Patient>();

        public void Add(Patient patient)
        {
            queue.Enqueue(patient);
        }

        public int getSize()
        {
            return queue.Count;
        }

        public void Reset()
        {
            queue.Clear();
        }

        public Patient RemovePatient()
        {
            if (getSize() == 0)
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