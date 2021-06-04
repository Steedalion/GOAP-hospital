using Planning;
using UnityEngine;

public class GoToWaitingRoom : GAction
{
    public override bool PrePerform()
    {
        Debug.Log("Going to waiting room.");
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance().WorldStates.IncrementState(AgentStates.patientsWaiting,1);
        GWorld.Instance().Waiting.Add(GetComponent<Patient>());
        agentBeliefs.AddState(AgentStates.atHospital,1);
        return true;
    }
}
