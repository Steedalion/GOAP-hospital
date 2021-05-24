using System.Collections.Generic;

public class Node
{
    public Node parent;
    public float cost;

    public Dictionary<string, int> state;
    public GAction action;

    public Node(Node parent, float cost, Dictionary<string, int> state, GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = state;
        this.action = action;
    }
}