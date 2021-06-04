using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine.Serialization;

namespace Planning
{

    [System.Serializable]
    public class WorldState
    {
        [FormerlySerializedAs("name")] public AgentStates key;
        public int value;
    }
    public class WorldStates
    {
        public Dictionary<AgentStates,int> States { get; }

        public WorldStates()
        {
            States = new Dictionary<AgentStates, int>();
        }

        public int Size()
        {
            return States.Count;
        }

        public void AddState(AgentStates stateName, int value)
        {
            States.Add(stateName,value);
        }

        public bool HasState(AgentStates stateName)
        {
            return States.ContainsKey(stateName);
        }

        public void IncrementState(AgentStates stateName, int increaseBy)
        {
            if (States.ContainsKey(stateName))
            {
                States[stateName] += increaseBy;
                if (States[stateName] <= 0)
                {
                    RemoveState(stateName);
                }
            }
            else
            {
                States.Add(stateName, increaseBy);
            }
        }

        public void RemoveState(AgentStates stateName)
        {
            States.Remove(stateName);
        }

        public double GetValue(AgentStates stateName)
        {
            return States[stateName];
        }
        
         public Dictionary<AgentStates, int> GetStates()
        {
            return States;
        }

         public void UpdateState(AgentStates basicState, int i)
         {
                 States[basicState] = i;
         }
    }
}