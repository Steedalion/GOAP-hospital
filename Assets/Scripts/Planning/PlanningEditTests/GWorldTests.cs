using NUnit.Framework;

namespace Planning.PlanningEditTests
{
    public class GWorldTests
    {
        [Test]
        public void ShouldNotBeNull()
        {
            Assert.IsNotNull(GWorld.Instance());
        }

        [Test]
        public void CanAccessWorld()
        {
            Assert.IsNotNull(GWorld.Instance().WorldStates);
        }
    }
}