using System;
using System.Collections.Generic;
using Planning;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";

    public float cost = 1;

    public float duration;

    public GameObject target;

    public string targetTag;

    public WorldState[] preConditions, postConditions;
    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;

    public WorldStates agentBeliefs;
    public bool running = false;
    public NavMeshAgent agent;




    protected GAction()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    private void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        if (preConditions != null)
        {
            foreach (WorldState condition in preConditions)
            {
                preconditions.Add(condition.key, condition.value);
            }
        }

        if (postConditions != null)
        {
            foreach (WorldState condition in postConditions)
            {
                effects.Add(condition.key, condition.value);
            }
        }
    }

    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> currentCondition)
    {
        foreach (KeyValuePair<string, int> precondition in preconditions)
        {
            if (currentCondition.ContainsKey(precondition.Key))
            {
                return false;
            }
        }

        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();
}