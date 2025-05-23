namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return items[Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);

                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (items.Length <= Count)
            {
                Grow();
            }

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) >= 0) return true;

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (items[i].Equals(item)) return Count - 1 - i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            if (items.Length <= Count)
            {
                Grow();
            }


            for (int i = Count - 1; i > Count - 1 - index; i--)
            {
                items[i + 1] = items[i];
            }

            Count++;
            items[Count - 1 - index] = item;

        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = Count - 1 - index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void Grow()
        {
            T[] array = new T[items.Length * 2];
            Array.Copy(items, array, Count);
            items = array;
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index > Count - 1) throw new IndexOutOfRangeException(nameof(index));
        }
    }
}