using System.Collections.Generic;
using Planning.PlanningEditTests;
using UnityToolbox.Tools;

namespace Planning
{
    public class GWorld:Singleton<GWorld>
    {
        public WorldStates WorldStates { get; }
                public MyQueue<Patient> PatientQueue = new MyQueue<Patient>();


        public GWorld()
        {
            WorldStates = new WorldStates();
        }
        
        
    }
}