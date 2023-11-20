using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    internal class Box <T>
    {
        private List<T> list;
        //private int count;

        public Box()
        {
            list = new List<T>();
            this.Count = 0;
        }
        public int Count { get; private set; }

        public void Add(T item)
        {
            this.list.Add(item);
            this.Count++;
        }
        public T Remove()
        {
            T item = list[Count - 1];
            this.list.Remove(item);
            this.Count--;
            return item;
        }
    }
}
