using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodStrings
{
    internal class Box<T> where T : IComparable<T>
    {
        private List<T> items;
        public Box() 
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public int Count(T element)
        {
            int count = 0;
            foreach (T item in items)
            {
                if(item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public void SwapIndexes(int firstIndex, int secondIndex)
        {
            (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (T item in items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
