using System;
using UnityEngine;

namespace Planning.PlanningEditTests
{
    public class Cubicle: MonoBehaviour, GResource
    {
        private void Start()
        {
            CubicleResources.Instance().MyQueue.Add(this);
        }
    }
}