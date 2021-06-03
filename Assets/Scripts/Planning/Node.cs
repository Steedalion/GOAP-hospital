using System.Collections.Generic;

public class Node
{
    public Node parent;
    public float cost;

    public Dictionary<string, int> WorldState;
    public GAction action;

    public Node(Node parent, float cost, Dictionary<string, int> worldState, GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.WorldState = worldState;
        this.action = action;
    }

    public Node(Node parent, float cost, Dictionary<string, int> worldState, Dictionary<string, int> beliefStates,
        GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.WorldState = worldState;
        this.action = action;

        //add belief states to world states.
        foreach (KeyValuePair<string, int> keyValuePair in beliefStates)
        {
            if (this.WorldState.ContainsKey(keyValuePair.Key))
                return;
            this.WorldState.Add(keyValuePair.Key, keyValuePair.Value);
        }
    }
}