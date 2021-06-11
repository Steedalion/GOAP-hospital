using UnityEngine;
using UnityToolbox.Tools;

namespace Planning
{
    public class GWorld : Singleton<GWorld>
    {
        public WorldStates WorldStates { get; }
        public MyQueue<Patient> Waiting;
        public MyQueue<Patient> isTreated;
        public MyQueue<Cubicle> Cubicles;

        

        private void UpdateStates()
        {
            WorldStates.UpdateState(AgentStates.patientsWaiting,  Waiting.Size());
            WorldStates.UpdateState(AgentStates.cubiclesAvailabe, Cubicles.Size());
            WorldStates.UpdateState(AgentStates.patientsTreated, isTreated.Size());
        }


        public GWorld()
        {
            WorldStates = new WorldStates();
            Waiting = new MyQueue<Patient>();
            Cubicles = new MyQueue<Cubicle>();
            isTreated = new MyQueue<Patient>();
            Waiting.onUpdate += UpdateStates;
            Cubicles.onUpdate += UpdateStates;
            isTreated.onUpdate += UpdateStates;
        }
    }
}