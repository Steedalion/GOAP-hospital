using NUnit.Framework;

namespace Planning.PlanningEditTests
{
    public class WorldStatesTests
    {
        private WorldStates worldStates;
        private string basicState = "name";
        private int initialValue = 3;

        [SetUp]
        public void CreateWorldState()
        {
            worldStates = new WorldStates();
        }

        [Test]
        public void ShouldNotBeNull()
        {
            Assert.NotNull(worldStates);
        }

        [Test]
        public void InitialSizeShouldBeZero()
        {
            Assert.AreEqual(worldStates.Size(), 0);
        }

        [Test]
        public void AddShouldIncreaseSize()
        {
            worldStates.AddState(basicState, initialValue);
            Assert.AreEqual(worldStates.Size(), 1);
        }

        [Test]
        public void EmptyWorldShouldNotHaveState()
        {
            Assert.IsFalse(worldStates.HasState(basicState));
        }

        [Test]
        public void AddingWorldShouldHaveState()
        {
            worldStates.AddState(basicState, 5);
            Assert.IsTrue(worldStates.HasState(basicState));
        }

        [Test]
        public void ModifyingWorldShouldIncreaseValue()
        {
            worldStates.AddState(basicState, 5);
            worldStates.IncrementState(basicState, 1);
            Assert.AreEqual(6, worldStates.GetValue(basicState));
        }
        

        [Test]
        public void IncrementingANonExistingStateWork()
        {
            worldStates.IncrementState(basicState, 4);
            Assert.AreEqual(4, worldStates.GetValue(basicState));
        }

        [Test]
        public void NegativeIncrementZeroSumRemovesKey()
        {
            worldStates.AddState(basicState, 5);
                        Assert.IsTrue(worldStates.HasState(basicState));
            worldStates.IncrementState(basicState, -5);
            Assert.IsFalse(worldStates.HasState(basicState));
        }[Test]
        public void NegativeIncrementRemovesKey()
        {
            worldStates.AddState(basicState, 5);
                        Assert.IsTrue(worldStates.HasState(basicState));
            worldStates.IncrementState(basicState, -6);
            Assert.IsFalse(worldStates.HasState(basicState));
        }

        [Test]
        public void NonNegativeSumIncrementDoesNotRemove()
        {
            worldStates.AddState(basicState, 5);
            worldStates.IncrementState(basicState, -4);
            Assert.IsTrue(worldStates.HasState(basicState));
        }

        [Test]
        public void RemoveNonExistingKeyShouldNotThrowError()
        {
            worldStates.RemoveState(basicState);
        }
    }
}