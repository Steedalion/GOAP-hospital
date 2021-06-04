using System;
using System.Collections;
using System.Collections.Generic;
using Planning;
using UnityEngine;

public class TreatPatient : GAction
{
    private Cubicle cubicle;
    public override bool PrePerform()
    {
       
        if (inventory.Contains<Cubicle>())
        {
            cubicle = inventory.FindResource<Cubicle>();
            target = cubicle.gameObject;
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
        if (cubicle!=null)
        {
            inventory.RemoveItem(cubicle);
            GWorld.Instance().Cubicles.Add(cubicle);
        }
        return true;
    }
}
