public class Nurse : GAgent
{
    // Start is called before the first frame update
    public void Start()
    {

        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, true);
        goals.Add(s1,3);
    }

}