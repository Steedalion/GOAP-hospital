using System;
using NUnit.Framework;
using UnityEngine;

namespace Planning.PlanningEditTests
{
    public class PatientQueueTests
    {
        private GameObject gameObject;
        private Patient patient1 = new Patient(), patient = new Patient();
        private MyQueue<Patient> patientQueue = new MyQueue<Patient>();

        [SetUp]
        public void CreateNew()
        {
            patientQueue.Reset();
        }


        [Test]
        public void ShouldNotBeNull()
        {
            Assert.IsNotNull(patientQueue);
        }

        [Test]
        public void NewQueueShouldBeEmpty()
        {
            patientQueue.Reset();
            Assert.AreEqual(0, patientQueue.Size());
        }

        [Test]
        public void AddingSinglePatientShouldHaveSize1()
        {
            patientQueue.Add(patient);
            Assert.AreEqual(1, patientQueue.Size());
        }

        [Test]
        public void AddingSinglePatientShouldHaveSize2()
        {
            patientQueue.Add(patient);
            patientQueue.Add(patient1);
            Assert.AreEqual(2, patientQueue.Size());
        }


        [Test]
        public void RemovingPatientShouldReturnValue()
        {
            patientQueue.Add(patient);
            Assert.AreEqual(patient, patientQueue.RemovePatient());
        }

        [Test]
        public void RemovingPatientShouldDecreaseSize()
        {
            patientQueue.Add(patient);
            patientQueue.Add(patient1);
            patientQueue.RemovePatient();
            Assert.AreEqual(1, patientQueue.Size());
        }
        [Test]
        public void RemovingLastPatientShouldDecreaseSize()
        {
            patientQueue.Add(patient);
            patientQueue.RemovePatient();
            Assert.AreEqual(0, patientQueue.Size());
        }

        [Test]
        public void RemovingPatientFromEmptyListShouldThrowException()
        {
            Assert.Throws<EmptyQueue>(() =>patientQueue.RemovePatient());
        }
    }

  
}