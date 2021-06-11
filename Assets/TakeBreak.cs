using System.Collections;
using System.Collections.Generic;
using Planning;
using UnityEngine;

public class TakeBreak : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        agentBeliefs.RemoveState(AgentStates.IAmTired);
        return true;
    }
}
