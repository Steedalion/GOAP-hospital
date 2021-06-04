using Planning;

public class Nurse : GAgent
{
    // Start is called before the first frame update
    public void Start()
    {

        base.Start();
        SubGoal s1 = new SubGoal(AgentStates.treatPatient, 1, false);
        goals.Add(s1,3);
        SubGoal lunchBreak = new SubGoal(AgentStates.takeBreak, 1, true);
        goals.Add(lunchBreak,1);
    }

}