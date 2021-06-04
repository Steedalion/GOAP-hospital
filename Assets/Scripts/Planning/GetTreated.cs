using UnityEngine;

namespace Planning
{
    public class GetTreated : GAction
    {
        private Cubicle cubicle;
        public override bool PrePerform()
        {
            if (!inventory.Contains<Cubicle>())
            {
                Debug.Log( "No cubicle in inventory");
                return false;
            }
            
            cubicle = inventory.FindResource<Cubicle>();
            target = cubicle.gameObject;
            return true;
        }

        public override bool PostPerform()
        {
            GWorld.Instance().isTreated.Add(GetComponent<Patient>());
            if (cubicle != null)
            {
                inventory.RemoveItem(cubicle);
            }
            return true;
        }
    }
}