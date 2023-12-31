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
            : this(DefaultCapacity)
        {
            this.items = new T[DefaultCapacity];
        }

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
                return this.items[this.Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);
                this.items[this.Count - 1 - index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) < 0)
            {
                return false;
            }

            return true;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }

            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            this.Grow();
            index = this.Count - 1 - index;
            for (int i = index; i < this.Count; i++)
            {
                this.items[i + 1] = this.items[i];
            }

            this.items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            index = this.Count - 1 - index;
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Grow()
        {
            if (this.items.Length <= this.Count)
            {
                T[] newArray = new T[this.items.Length * 2];
                for (int i = 0; i < this.Count; i++)
                {
                    newArray[i] = this.items[i];
                }

                this.items = newArray;
            }
        }
    }
}