using System;
using System.Collections;
using System.Collections.Generic;
using Planning;
using UnityEngine;

public class TreatPatient : GAction
{
    public override bool PrePerform()
    {
        if (inventory.Contains<Cubicle>())
        {
            target = inventory.FindResource<Cubicle>().gameObject;
            return true;
        }
        else
        {
            throw new Exception("Missing a cubicle here");
        }

        return false;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
