namespace Planning.Actions
{
    public class GetPatient : GAction
    {
        public override bool PrePerform()
        {
            target = GWorld.Instance().PatientQueue.Remove().gameObject;
            GWorld.Instance().WorldStates.IncrementState("Waiting",-1);
            return true;
        }

        public override bool PostPerform()
        {
            return true;
        }
    }
}