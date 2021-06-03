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
            WorldStates.UpdateState(nameof(Waiting),  Waiting.Size());
            WorldStates.UpdateState(nameof(Cubicles), Cubicles.Size());
            WorldStates.UpdateState(nameof(isTreated), isTreated.Size());
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