namespace Planning.Actions
{
    public class GetPatient : GAction
    {
        private Patient patient;
        private Cubicle cubicle;
        public override bool PrePerform()
        {
            if (GWorld.Instance().Waiting.IsEmpty())
            {
                return false;
            }
            patient = GWorld.Instance().Waiting.Remove();
            if (patient == null)
            {
                return false;
            }
            target = patient.gameObject;
            
            cubicle = GWorld.Instance().Cubicles.Remove();
            if (cubicle == null)
            {
                GWorld.Instance().Waiting.Add(patient);
                return false;
            }
            inventory.AddItem(cubicle);
            
            GWorld.Instance().WorldStates.IncrementState(AgentStates.Waiting,-1);
            return true;
        }

        public override bool PostPerform()
        {
            GiveToPatient(cubicle);
            return true;
        }

        private void GiveToPatient(GResource resource)
        {
            patient.Inventory.AddItem(resource);
        }
    }
}