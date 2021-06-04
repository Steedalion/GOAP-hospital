using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Planning.PlanningEditTests
{
    public class GActionTests
    {
        Dictionary<AgentStates, int> clearCondition;
        Dictionary<AgentStates, int> beforeCondition = new Dictionary<AgentStates, int>() {{AgentStates.atHospital, 1}};

        Dictionary<AgentStates, int> before2Condition = new Dictionary<AgentStates, int>()
            {{AgentStates.atHospital, 2}};

        GameObject gameObject;
        GAction actionWithoutPrecondition;
        private GAction beforeAndAfterAction;
        private GAction before2;

        private static AgentStates before = AgentStates.hasArrived;
        private static AgentStates after = AgentStates.hasRegistered;


        [UnitySetUp]
        public IEnumerator InitializeTest()
        {
            clearCondition = new Dictionary<AgentStates, int>();


            gameObject = GameObject.Instantiate(new GameObject());
            actionWithoutPrecondition = gameObject.AddComponent<EmptyAction>();
            beforeAndAfterAction = gameObject.AddComponent<BeforeAndAfterAction>();
            before2 = gameObject.AddComponent<Before2Action>();
            yield return null;
        }

        [UnityTearDown]
        public IEnumerator DestroyLeftovers()
        {
            GameObject.Destroy(gameObject);
            yield return null;
        }

        [UnityTest]
        public IEnumerator ActionWithoutPreconditionShouldBeTrue()
        {
            Assert.IsTrue(actionWithoutPrecondition.IsAchievable());

            yield return null;
        }

        [UnityTest]
        public IEnumerator ActionWithEmptyPreconditionShouldBeTrue()
        {
            Assert.IsTrue(actionWithoutPrecondition.IsAchievableGiven(clearCondition));

            yield return null;
        }

        [UnityTest]
        public IEnumerator ActionWithUnmetPreconditionShouldFail()
        {
            Assert.IsFalse(beforeAndAfterAction.IsAchievableGiven(clearCondition));

            yield return null;
        }

        [UnityTest]
        public IEnumerator ActionWithMetPreconditionShouldFail()
        {
            Assert.IsTrue(beforeAndAfterAction.IsAchievableGiven(beforeCondition));

            yield return null;
        }

        [UnityTest]
        public IEnumerator ActionLowerThanRequiredPreconditionShouldFail()
        {
            Assert.IsFalse(before2.IsAchievableGiven(beforeCondition));

            yield return null;
        }

        [UnityTest]
        public IEnumerator ActionNumerousPreconditionShouldPass()
        {
            Assert.IsTrue(before2.IsAchievableGiven(before2Condition));

            yield return null;
        }


        internal class EmptyAction : GAction
        {
            public override bool PrePerform()
            {
                preconditions = new Dictionary<AgentStates, int>();
                preconditions.Add(before, 1);
                effects.Add(after, 1);
                return true;
            }

            public override bool PostPerform()
            {
                return true;
            }
        }

        internal class BeforeAndAfterAction : GAction
        {
            public void Awake()
            {
                preconditions = new Dictionary<AgentStates, int>();
                preconditions.Add(before, 1);
                effects.Add(after, 1);
            }

            public override bool PrePerform()
            {
                return true;
            }

            public override bool PostPerform()
            {
                return true;
            }
        }

        internal class Before2Action : GAction
        {
            public void Awake()
            {
                preconditions = new Dictionary<AgentStates, int>();
                preconditions.Add(before, 2);
            }

            public override bool PrePerform()
            {
                return true;
            }

            public override bool PostPerform()
            {
                return true;
            }
        }
    }
}