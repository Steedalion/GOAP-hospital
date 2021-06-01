using System.Collections;
using System.Collections.Generic;
using Planning;
using UnityEngine;

public class GoToWaitingRoom : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance().WorldStates.IncrementState("Waiting",1);
        GWorld.Instance().PatientQueue.Add(GetComponent<Patient>());
        return true;
    }
}
