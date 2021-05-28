using System.Collections.Generic;
using Planning.PlanningEditTests;
using UnityToolbox.Tools;

namespace Planning
{
    public class GWorld : Singleton<GWorld>
    {
        public WorldStates WorldStates { get; }
        public MyQueue<Patient> PatientQueue;
        public MyQueue<Cubicle> CubicleQueue;


        public GWorld()
        {
            WorldStates = new WorldStates();
            PatientQueue = new MyQueue<Patient>();
            CubicleQueue = new MyQueue<Cubicle>();
        }
    }
}