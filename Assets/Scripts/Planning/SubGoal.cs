using System.Collections.Generic;
using Planning;

public class SubGoal
{
    public Dictionary<AgentStates, int> sgoal;
    public bool remove;
    
    public SubGoal(AgentStates action, int importance, bool removeable)
    {
        sgoal = new Dictionary<AgentStates, int>();
        sgoal.Add(action,importance);
        remove = removeable;
    }
}