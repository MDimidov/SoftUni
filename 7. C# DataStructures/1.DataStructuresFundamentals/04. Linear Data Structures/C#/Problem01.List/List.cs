namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return items[index];
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set
            {
                if (index < Count)
                {
                   items[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (items.Length == Count)
            {
                T[] itemsCopy = new T[items.Length * 2];
                Array.Copy(items, itemsCopy, items.Length);
                items = itemsCopy;
            }

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}