using NUnit.Framework;
using UnityEngine;

namespace Planning.PlanningEditTests
{
    public class MyQueueTests
    {
        private GameObject gameObject;
        private Patient patient1 = new Patient(), patient = new Patient();
        private MyQueue<Patient> queue = new MyQueue<Patient>();

        private bool executed = false;

        public void ExecuteCommand()
        {
            executed = true;
        }

        [SetUp]
        public void CreateNew()
        {
            queue = new MyQueue<Patient>();
            executed = false;
        }


        [Test]
        public void ExecuteShouldbeNullAtStart()
        {
            Assert.False(executed);
        }

        [Test]
        public void ShouldNotBeNull()
        {
            Assert.IsNotNull(queue);
        }

        [Test]
        public void NewQueueShouldBeEmpty()
        {
            queue.ClearQueueNotEvents();
            Assert.AreEqual(0, queue.Size());
        }

        [Test]
        public void AddingSinglePatientShouldHaveSize1()
        {
            queue.Add(patient);
            Assert.AreEqual(1, queue.Size());
        }

        [Test]
        public void AddingSinglePatientShouldHaveSize2()
        {
            queue.Add(patient);
            queue.Add(patient1);
            Assert.AreEqual(2, queue.Size());
        }


        [Test]
        public void RemovingPatientShouldReturnValue()
        {
            queue.Add(patient);
            Assert.AreEqual(patient, queue.Remove());
        }

        [Test]
        public void RemovingPatientShouldDecreaseSize()
        {
            queue.Add(patient);
            queue.Add(patient1);
            queue.Remove();
            Assert.AreEqual(1, queue.Size());
        }

        [Test]
        public void RemovingLastPatientShouldDecreaseSize()
        {
            queue.Add(patient);
            queue.Remove();
            Assert.AreEqual(0, queue.Size());
        }

        [Test]
        public void RemovingPatientFromEmptyListShouldThrowException()
        {
            Assert.Throws<EmptyQueue>(() => queue.Remove());
        }

        [Test]
        public void ImmediatelyUpdateShouldNotExecute()
        {
            queue.onUpdate += ExecuteCommand;
            Assert.IsFalse(executed);
        }
        
        [Test]
        public void UpdateAddedLaterShouldNotExecute()
        {
            queue.Add(patient);
            queue.onUpdate += ExecuteCommand;
            Assert.IsFalse(executed);
        }
        [Test]
        public void AddingShouldInvokeUpdate()
        {
            queue.onUpdate += ExecuteCommand;
            queue.Add(patient);
            Assert.IsTrue(executed);
        }

        [Test]
        public void Adding2ShouldInvokeUpdate()
        {
            queue.Add(patient);
            queue.onUpdate += ExecuteCommand;
            queue.Add(patient1);
            Assert.IsTrue(executed);
        }

        [Test]
        public void RemovingShouldInvokeUpdate()
        {
            queue.Add(patient);
            queue.onUpdate += ExecuteCommand;
            queue.Remove();
            Assert.IsTrue(executed);
        }

        [Test]
        public void ClearingShouldInvokeUpdate()
        {
            queue.onUpdate += ExecuteCommand;
            queue.ClearQueueNotEvents();
            Assert.IsTrue(executed);
        }
    }
}