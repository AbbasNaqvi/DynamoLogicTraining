using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegexPractice
{
    class ItemLog :ICollection<Item>
    {
        public List<Item> itemList { get; set; }

       public ItemLog()
        {
            itemList = new List<Item>();
        
        }
        public void Add(Item item)
        {
            itemList.Add(item);
        }

        public void Clear()
        {
            itemList.Clear();
        }

        public bool Contains(Item item)
        {
            return itemList.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            itemList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get {
                return itemList.Count;
            }
           
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Item item)
        {
            return itemList.Remove(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return itemList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
