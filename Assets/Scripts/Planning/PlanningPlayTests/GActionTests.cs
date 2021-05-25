using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Planning.PlanningEditTests
{
    public class GActionTests
    {
        Dictionary<string, int> clearCondition;
        Dictionary<string, int> beforeCondition = new Dictionary<string, int>(){{"Before",1}};
        Dictionary<string, int> before2Condition = new Dictionary<string, int>(){{"Before",2}};
        GameObject gameObject;
        GAction actionWithoutPrecondition;
        private GAction beforeAndAfterAction;
        private GAction before2;

        [UnitySetUp]
        public IEnumerator InitializeTest()
        {
            clearCondition = new Dictionary<string, int>();
            
            
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
        
        
    }
    public class EmptyAction:GAction
    {
        public override bool PrePerform()
        {
            preconditions = new Dictionary<string, int>();
            preconditions.Add("Before",1);
            effects.Add("After",1);
            return true;
        }

        public override bool PostPerform()
        {
            return true;
        }
    }

    public class BeforeAndAfterAction:GAction
    {
        public void Awake()
        {
            preconditions = new Dictionary<string, int>();
            preconditions.Add("Before",1);
            effects.Add("After", 1);
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
    public class Before2Action:GAction
    {
        public void Awake()
        {
            preconditions = new Dictionary<string, int>();
            preconditions.Add("Before",2);
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