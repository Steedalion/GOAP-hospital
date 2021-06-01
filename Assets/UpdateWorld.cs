using System.Collections;
using System.Collections.Generic;
using Planning;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    public Text states;

    private Dictionary<string, int> worldstates;

    // Start is called before the first frame update
    void Start()
    {
        worldstates = GWorld.Instance().WorldStates.States;

    }
    

    // Update is called once per frame
    void Update()
    {
        worldstates = GWorld.Instance().WorldStates.States;
        states.text = "";
        foreach (KeyValuePair<string,int> keyValuePair in worldstates)
        {
            states.text += keyValuePair.Key + " , " + keyValuePair.Value;
            states.text += "\n";
        }
        
    }
}
