﻿namespace Problem01.List
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
                if (IsIndexValid(index))
                {
                    return items[index];
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set
            {
                if (IsIndexValid(index))
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
            if (items.Length <= Count)
            {
                GrowArray();
            }

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                    return true;
            }

            return false;
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
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (items.Length <= Count)
            {
                GrowArray();
            }

            IsIndexValid(index);

            for (int i = Count++; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            Count--;
            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            return true;
        }

        public void RemoveAt(int index)
        {
            if (IsIndexValid(index))
            {
                Count--;
                for (int i = index; i < Count; i++)
                {
                    items[i] = items[i + 1];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void GrowArray()
        {
            T[] itemsCopy = new T[items.Length * 2];
            Array.Copy(items, itemsCopy, items.Length);
            items = itemsCopy;
        }

        private bool IsIndexValid(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            return true;
        }
    }
}