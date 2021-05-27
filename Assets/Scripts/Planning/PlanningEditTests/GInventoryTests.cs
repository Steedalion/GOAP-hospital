using System;
using NUnit.Framework;

namespace Planning.PlanningEditTests
{
    public class GInventoryTests
    {
        private GInventory inventory;
        private MyResource resource = new MyResource();

        [SetUp]
        public void SetupTests()
        {
            inventory = new GInventory();
        }

        [Test]
        public void CreateNotNullInventor()
        {
            inventory = new GInventory();
            Assert.IsNotNull(inventory);
        }

        [Test]
        public void AddResourceToInventory()
        {
            inventory.AddItem(resource);
        }

        [Test]
        public void AddResourceShouldIncreaseSize()
        {
            inventory.AddItem(resource);
            Assert.AreEqual(1, inventory.Size);
        }

        [Test]
        public void GetItemShouldReturnSameItem()
        {
            inventory.AddItem(resource);
            Assert.AreEqual(resource, inventory.FindResource<MyResource>());
        }

        [Test]
        public void AddingNullResourceShouldThrowException()
        {
            MyResource nullResource = null;
            Assert.Throws<NullReferenceException>(() => inventory.AddItem(nullResource));
        }

        [Test]
        public void EmptyListShouldNotContain()
        {
            Assert.IsFalse(inventory.Contains<MyResource>());
        }
        
        [Test]
        public void AddedShouldBeContained()
        {
            inventory.AddItem(resource);
            Assert.NotNull(inventory.Contains<MyResource>());
        }

        [Test]
        public void RemovingNotContainedShouldThrowException()
        {
            Assert.Throws<NotInInventory>(() => inventory.RemoveItem(resource));
        }
        [Test]
        public void RemovingItemShouldDecreseSize()
        {
            inventory.AddItem(resource);
            inventory.RemoveItem(resource);
            Assert.AreEqual(0, inventory.Size);
        }
        

    }

    internal class MyResource : GResource
    {
    }
}