using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine.Serialization;

namespace Planning
{

    [System.Serializable]
    public class WorldState
    {
        [FormerlySerializedAs("name")] public string key;
        public int value;
    }
    public class WorldStates
    {
        public Dictionary<string,int> States { get; }

        public WorldStates()
        {
            States = new Dictionary<string, int>();
        }

        public int Size()
        {
            return States.Count;
        }

        public void AddState(string stateName, int value)
        {
            States.Add(stateName,value);
        }

        public bool HasState(string stateName)
        {
            return States.ContainsKey(stateName);
        }

        public void IncrementState(string stateName, int increaseBy)
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

        public void RemoveState(string stateName)
        {
            States.Remove(stateName);
        }

        public double GetValue(string stateName)
        {
            return States[stateName];
        }
        
         public Dictionary<string, int> GetStates()
        {
            return States;
        }

         public void UpdateState(string basicState, int i)
         {
                 States[basicState] = i;
         }
    }
}