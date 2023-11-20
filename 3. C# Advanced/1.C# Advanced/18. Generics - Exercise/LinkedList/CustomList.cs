using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    internal class CustomList<T>
    {
        private const int InitialCapacity = 2;

        private T[] items;

        public CustomList()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if(index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                    return items[index];
            }

            set
            {
                if(index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }

        private void Resize()
        {
            T[] resizedArray = new T[this.items.Length * 2];

            for(int i = 0; i < Count; i++)
            {
                resizedArray[i] = this.items[i];
            }
            this.items = resizedArray;
        }

        private void Shrink()
        {
            T[] shrinkedArray = new T[this.items.Length / 2];
            for(int i = 0; i < this.Count; i++)
            {
                shrinkedArray[i] = this.items[i];
            }
            this.items = shrinkedArray;
        }

        public void Add(T item)
        {
            if(this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[this.Count++] = item;
        }

        public T RemoveAt(int index)
        {
            if(index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            T removedItem = this.items[index];
            //this.items[index] = default;
            ShiftLeft(index);

            this.Count--;
            if(this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return removedItem;
        }

        private void ShiftLeft(int index)
        {
            for(int i = index; i < Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for(int i = Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Insert(int index, T item)
        {
            if(index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            
            if(this.Count == items.Length)
            {
                this.Resize();
            }

            this.ShiftRight(index);
            Count++;
            this.items[index] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }    

        public void Swap(int firstIndex, int secondIndex)
        {
            if(firstIndex < 0 || firstIndex > Count
                || secondIndex < 0 || secondIndex > Count)
            {
                throw new IndexOutOfRangeException();
            }
            T temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }
    }
}
