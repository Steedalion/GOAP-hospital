using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GAgent : MonoBehaviour
{
    public List<GAction> actions = new List<GAction>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();

    private Gplanner planner;
    private Queue<GAction> actionQ;
    public GAction currentAction;
    private SubGoal currentSubgoal;
    private bool invoked;

    public void Start()
    {
        GAction[] actionsOnMe = gameObject.GetComponents<GAction>();
        foreach (GAction action in actionsOnMe)
        {
            actions.Add(action);
        }
    }

    void CompleteAction()
    {
        currentAction.running = false;
        currentAction.PostPerform();
        invoked = false;
    }

    private void LateUpdate()
    {
        if (currentAction != null && currentAction.running)
        {
            if (currentAction.agent.hasPath && currentAction.agent.remainingDistance < 1f)
            {
                if (!invoked)
                {
                    Invoke(nameof(CompleteAction), currentAction.duration);
                    invoked = true;
                }
            }


            return;
        }

        if (planner == null || actionQ == null)
        {
            planner = new Gplanner();
            IOrderedEnumerable<KeyValuePair<SubGoal, int>> sorted =
                from goal in goals orderby goal.Value descending select goal;

            foreach (KeyValuePair<SubGoal, int> sg in sorted)
            {
                actionQ = planner.plan(actions, sg.Key.sgoal, null);
                if (actionQ != null)
                {
                    currentSubgoal = sg.Key;
                    break;
                }
            }
        }

        if (actionQ != null && actionQ.Count == 0)
        {
            if (currentSubgoal.remove)
            {
                goals.Remove(currentSubgoal);
            }

            planner = null;
        }

        if (actionQ != null && actionQ.Count > 0)
        {
            currentAction = actionQ.Dequeue();
            if (currentAction.PrePerform())
            {
                if (currentAction.target == null && currentAction.targetTag != "")
                {
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                }

                if (currentAction.target != null)
                {
                    currentAction.running = true;
                    currentAction.agent.SetDestination(currentAction.target.transform.position);
                    Debug.Log("Selected object" + currentAction.target);
                }
                else
                {
                    Debug.LogError("No object found");
                }
            }
            else
            {
                actionQ = null;
            }
        }
    }
}