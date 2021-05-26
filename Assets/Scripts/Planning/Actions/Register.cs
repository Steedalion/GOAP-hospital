using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : GAction
{
    public override bool PrePerform()
    {
        Debug.Log("Register Entered");
        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
