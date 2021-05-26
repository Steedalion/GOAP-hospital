﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(GAgentVisual))]
[CanEditMultipleObjects]
public class GAgentVisualEditor : Editor 
{


    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();
        GAgentVisual agent = (GAgentVisual) target;
        GUILayout.Label("Name: " + agent.name);
        GUILayout.Label("Current Action: " + agent.gameObject.GetComponent<GAgent>().currentAction);
        GUILayout.Label("Actions: ");
        
        for (int i = 0; i < agent.gameObject.GetComponent<GAgent>().actions.Count; i++)
        {
            GAction a = agent.gameObject.GetComponent<GAgent>().actions[i];
            string pre = "";
            string eff = "";

            foreach (KeyValuePair<string, int> p in a.preconditions)
                pre += p.Key + ", ";
            foreach (KeyValuePair<string, int> e in a.effects)
                eff += e.Key + ", ";

            GUILayout.Label(i+"===  " + a.actionName + "(" + pre + ")(" + eff + ")");
            
        }
    
        GUILayout.Label("Goals: ");
        foreach (KeyValuePair<SubGoal, int> g in agent.gameObject.GetComponent<GAgent>().goals)
        {
            GUILayout.Label("---: ");
            foreach (KeyValuePair<string, int> sg in g.Key.sgoal)
                GUILayout.Label("=====  " + sg.Key);
        }
        serializedObject.ApplyModifiedProperties();
    }
}