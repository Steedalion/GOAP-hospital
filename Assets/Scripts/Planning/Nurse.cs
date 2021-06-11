using Planning;
using UnityEngine;

public class Nurse : GAgent
{
    // Start is called before the first frame update
    public void Start()
    {

        base.Start();
        SubGoal s1 = new SubGoal(AgentStates.treatPatient, 2, false);
        goals.Add(s1,3);
        SubGoal lunchBreak = new SubGoal(AgentStates.rested, 1, false);
        goals.Add(lunchBreak,5);
        
        Invoke(nameof(GetTired), Random.Range(10,20));
    }

    void GetTired()
    {
        beliefs.IncrementState(AgentStates.IAmTired,1);
        Invoke(nameof(GetTired), Random.Range(10,20));
    }

}