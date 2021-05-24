using System.Collections.Generic;

public class SubGoal
{
    public Dictionary<string, int> sgoal;
    public bool remove;
    
    public SubGoal(string action, int importance, bool removeable)
    {
        sgoal = new Dictionary<string, int>();
        sgoal.Add(action,importance);
        remove = removeable;
    }
}