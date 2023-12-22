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
                throw new NotImplementedException(capacity);
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
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
            if (IndexOf(item) != -1)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.items.Take(this.Count))
            {
                yield return item;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item = this.items[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            Grow();

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;

        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < this.Count; i--)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count] = default;
            this.Count--;

        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds!");
            }
        }

        private void Grow()
        {
            if (this.items.length <= this.Count)
            {
                T[] coppyArray = new T[this.items.length * 2];
                for (int i = 0; i < items.length; i++)
                {
                    coppyArray[i] = this.items[i];
                }

                this.items = coppyArray;
            }
        }
    }
}