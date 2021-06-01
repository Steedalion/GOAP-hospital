using UnityEngine;

namespace Planning
{
    public class Cubicle: MonoBehaviour, GResource
    {
        private void Start()
        {
            GWorld.Instance().CubicleQueue.Add(this);
        }
    }
}