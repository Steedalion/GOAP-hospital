using Planning.PlanningEditTests;

namespace Planning.Actions
{
    public class GetPatient : GAction
    {
        public override bool PrePerform()
        {
            target = GWorld.Instance().PatientQueue.RemovePatient().gameObject;
            return true;
        }

        public override bool PostPerform()
        {
            return true;
        }
    }
}