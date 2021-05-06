using System.Collections.Generic;

namespace Planning
{

    [System.Serializable]
    public class WorldState
    {
        public string name;
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
    }
}