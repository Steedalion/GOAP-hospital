using System;
using NUnit.Framework;
using UnityEngine;

namespace Planning.PlanningEditTests
{
    public class PatientQueueTests
    {
        private GameObject gameObject;
        private Patient patient1 = new Patient(), patient = new Patient();
        private PatientQueue patientQueue = PatientQueue.Instance();

        [SetUp]
        public void CreateNew()
        {
            patientQueue.MyQueue.Reset();
        }


        [Test]
        public void ShouldNotBeNull()
        {
            Assert.IsNotNull(PatientQueue.Instance());
        }

        [Test]
        public void NewQueueShouldBeEmpty()
        {
            patientQueue.MyQueue.Reset();
            Assert.AreEqual(0, patientQueue.MyQueue.Size());
        }

        [Test]
        public void AddingSinglePatientShouldHaveSize1()
        {
            patientQueue.MyQueue.Add(patient);
            Assert.AreEqual(1, patientQueue.MyQueue.Size());
        }

        [Test]
        public void AddingSinglePatientShouldHaveSize2()
        {
            patientQueue.MyQueue.Add(patient);
            patientQueue.MyQueue.Add(patient1);
            Assert.AreEqual(2, patientQueue.MyQueue.Size());
        }


        [Test]
        public void RemovingPatientShouldReturnValue()
        {
            patientQueue.MyQueue.Add(patient);
            Assert.AreEqual(patient, patientQueue.MyQueue.RemovePatient());
        }

        [Test]
        public void RemovingPatientShouldDecreaseSize()
        {
            patientQueue.MyQueue.Add(patient);
            patientQueue.MyQueue.Add(patient1);
            patientQueue.MyQueue.RemovePatient();
            Assert.AreEqual(1, patientQueue.MyQueue.Size());
        }
        [Test]
        public void RemovingLastPatientShouldDecreaseSize()
        {
            patientQueue.MyQueue.Add(patient);
            patientQueue.MyQueue.RemovePatient();
            Assert.AreEqual(0, patientQueue.MyQueue.Size());
        }

        [Test]
        public void RemovingPatientFromEmptyListShouldThrowException()
        {
            Assert.Throws<EmptyQueue>(() =>patientQueue.MyQueue.RemovePatient());
        }
    }

  
}