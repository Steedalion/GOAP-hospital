using Planning.PlanningEditTests;

namespace Planning.Actions
{
    public class GetPatient : GAction
    {
        public override bool PrePerform()
        {
            target = PatientQueue.Instance().MyQueue.RemovePatient().gameObject;
            return true;
        }

        public override bool PostPerform()
        {
            return true;
        }
    }
}