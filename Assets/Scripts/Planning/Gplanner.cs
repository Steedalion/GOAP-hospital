﻿using System;
using System.Collections.Generic;
using System.Linq;
using Planning;
using UnityEditor;
using UnityEngine;

public class Gplanner : MonoBehaviour
{
    public Queue<GAction> plan(List<GAction> actions, Dictionary<string, int> goal, WorldStates states)
    {
        List<GAction> usableActions = actions.Where(gAction => gAction.isAchievable()).ToList();

        List<Node> leaves = new List<Node>();
        Node start = new Node(parent: null, cost: 0, GWorld.Instance().WorldStates.States, action: null);

        bool success = BuildGraph(start, leaves, usableActions, goal);
        //TODO: Leaves is an output;


        if (!success)
        {
            Debug.Log("NO PLAN FOUND");
            return null;
        }

        //find best leaf
        Node cheapest = FindCheapestLeaf(leaves);

        //GetParentList
        List<GAction> result = new List<GAction>();
        Node n = cheapest;
        while (n.action != null)
        {
            if (n.action != null)
            {
                result.Insert(0, n.action);
            }

            n = n.parent;
        }

        Queue<GAction> queue = new Queue<GAction>();
        foreach (GAction gAction in result)
        {
            queue.Enqueue(gAction);
        }

        Debug.Log("the plan is : ");
        foreach (GAction gAction in queue)
        {
            Debug.Log("Q: " + gAction.actionName);
        }

        return queue;
    }

    private bool BuildGraph(Node parent, List<Node> leaves, List<GAction> usableActions, Dictionary<string, int> goal)
    {
        bool foundPath = false;

        foreach (GAction action in usableActions)
        {
            if (action.isAchievableGiven(parent.state))
            {
                Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                foreach (KeyValuePair<string, int> effect in action.effects)
                {
                    if (!currentState.ContainsKey(effect.Key))
                        currentState.Add(effect.Key, effect.Value);
                }

                Node node = new Node(parent, parent.cost + action.cost, currentState, action);

                if (GoalAchieved(goal, currentState))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    List<GAction> subset = ActionSubset(usableActions, action);
                    bool found = BuildGraph(node, leaves, subset, goal);
                    if (found)
                        foundPath = true;
                }
            }
        }

        return foundPath;
    }

    private List<GAction> ActionSubset(List<GAction> usableActions, GAction removeMe)
    {
        List<GAction> subset = new List<GAction>();
        foreach (GAction a in usableActions)
        {
            if (!a.Equals(removeMe))
            {
                subset.Add(a);
            }
        }

        return subset;
    }

    private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> currentState)
    {
        foreach (KeyValuePair<string, int> pair in goal)
        {
            if (!currentState.ContainsKey(pair.Key))
            {
                return false;
            }
        }

        return true;
    }


    private static Node FindCheapestLeaf(List<Node> leaves)
    {
        Node cheapest = null;
        foreach (Node leaf in leaves)
        {
            if (cheapest == null)
                cheapest = leaf;
            else
            {
                if (leaf.cost < cheapest.cost)
                {
                    cheapest = leaf;
                }
            }
        }

        return cheapest;
    }
}