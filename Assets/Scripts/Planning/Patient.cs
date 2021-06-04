namespace Planning
{
    public class Patient : GAgent
    {
        // Start is called before the first frame update
        public void Start()
        {

            base.Start();
            SubGoal waiting = new SubGoal(AgentStates.isWaiting, 1, true);
            goals.Add(waiting,3);
            //TODO: This breaks patient behavior.

            SubGoal goHome = new SubGoal(AgentStates.atHome, 3, true);
            goals.Add(goHome,5);
        }

    }
}