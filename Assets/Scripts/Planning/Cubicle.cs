using System;
using UnityEngine;

namespace Planning.PlanningEditTests
{
    public class Cubicle: MonoBehaviour, GResource
    {
        private void Start()
        {
            GWorld.Instance().CubicleQueue.Add(this);
        }
    }
}