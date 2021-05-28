using UnityToolbox.Tools;

namespace Planning.PlanningEditTests
{
    public class PatientQueue
    {
        private readonly MyQueue<Patient> myQueue = new MyQueue<Patient>();

        public MyQueue<Patient> MyQueue
        {
            get { return myQueue; }
        }
    }
}