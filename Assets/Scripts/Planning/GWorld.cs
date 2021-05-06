using UnityToolbox.Tools;

namespace Planning
{
    public class GWorld:Singleton<GWorld>
    {
        public WorldStates WorldStates { get; }

        public GWorld()
        {
            WorldStates = new WorldStates();
        }
        
        
    }
}