using System;
using System.Collections.Generic;
using System.Linq;

namespace Planning
{
    public class GInventory
    {
        private List<GResource> items = new List<GResource>();
        public int Size => items.Count;

        public bool Contains<T>()
        {
            return items.Any(resources => resources.GetType() == typeof(T));
        }
        
        public T FindResource<T>() where T:GResource
        {
            foreach (GResource item in items)
            {
                if (item.GetType() == typeof(T))
                {
                    return (T) item;
                }
            }

            throw new InventoryDoesNotContain();
        }

        public void RemoveItem(GResource resource)
        {
            int indexToRemove = -1;
            foreach (GResource it in items)
            {
                indexToRemove++;
                if (resource == it)
                    break;
            }
            if(indexToRemove >-1)
            {
                items.RemoveAt(indexToRemove);
                return;
            }
            throw new NotInInventory();
        }


        public void AddItem(GResource resource)
        {
            if (resource ==null)
            {
                throw new NullReferenceException();
            }
            items.Add(resource);
        }
    }

    public class NotInInventory : Exception
    {
    }

    public class InventoryDoesNotContain : Exception
    {
    }

    public interface GResource
    {
    }
}