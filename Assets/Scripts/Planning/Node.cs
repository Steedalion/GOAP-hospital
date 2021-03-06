using System.Collections.Generic;
using Planning;

public class Node
{
    public Node parent;
    public float cost;

    public Dictionary<AgentStates, int> worldNow;
    public GAction action;

    public Node(Node parent, float cost, Dictionary<AgentStates, int> worldState, GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        worldNow = new Dictionary<AgentStates, int>(worldState);
        this.action = action;
    }

    public Node(Node parent, float cost, Dictionary<AgentStates, int> worldState, Dictionary<AgentStates, int> beliefStates,
        GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        worldNow = new Dictionary<AgentStates, int>(worldState);
        this.action = action;

        //add belief states to world states.
        foreach (KeyValuePair<AgentStates, int> keyValuePair in beliefStates)
        {
            if (worldNow.ContainsKey(keyValuePair.Key))
                return;
            worldNow.Add(keyValuePair.Key, keyValuePair.Value);
        }
    }
}