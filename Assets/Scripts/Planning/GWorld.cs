using UnityToolbox.Tools;

namespace Planning
{
    public class GWorld : Singleton<GWorld>
    {
        public WorldStates WorldStates { get; }
        public MyQueue<Patient> PatientQueue;
        public MyQueue<Cubicle> CubicleQueue;

        private string patientsKey = "Patients";
        private string cubicleKey = "Cubicles";
        

        private void UpdateStates()
        {
            WorldStates.UpdateState(patientsKey,  PatientQueue.Size());
            WorldStates.UpdateState(cubicleKey, CubicleQueue.Size());
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