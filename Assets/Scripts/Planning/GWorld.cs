using UnityToolbox.Tools;

namespace Planning
{
    public class GWorld : Singleton<GWorld>
    {
        public WorldStates WorldStates { get; }
        public MyQueue<Patient> PatientQueue;
        public MyQueue<Cubicle> CubicleQueue;

        public void UpdateStates()
        {
            WorldStates.States["Patients"] = PatientQueue.Size();
            WorldStates.States["Cubicle"] = CubicleQueue.Size();
            // WorldStates.States.
        }


        public GWorld()
        {
            WorldStates = new WorldStates();
            PatientQueue = new MyQueue<Patient>();
            CubicleQueue = new MyQueue<Cubicle>();
            PatientQueue.onUpdate += UpdateStates;
            CubicleQueue.onUpdate += UpdateStates;
        }
    }
}