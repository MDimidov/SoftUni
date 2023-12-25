namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;

        private int startIndex;

        private int endIndex;

        private const int InitialCapacity = 4;


        CircularQueue(int capacity = InitialCapacity)
        {
            elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get => this.elements.Length; }

        public T Dequeue()
        {
            ValidateQueue();
            T item = this.elements[this.startIndex];
            this.startIndex = (this.startIndex + 1) % this.Capacity;
            this.Count--;
            return item;
        }

        public void Enqueue(T item)
        {
            if(Count >= this.Capacity)
            {
                Grow();
            }

            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.Capacity;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[(this.startIndex + i) % this.Capacity];
            }
        }

        public T Peek()
        {
            this.ValidateQueue();
            this.elements[this.startIndex];
        }
        public T[] ToArray()
            => this.CoppyArray(this.Count);

        

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void Grow()
        {
            this.elements = this.CoppyArray(this.Capacity * 2);
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void ValidateQueue()
        {
            if(Count <= 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
        }

        private T[] CoppyArray(int capacity)
        {
            T[] newArray = new T[capacity];
            int sourceIndex = this.startIndex;

            for (int i = 0; i < capacity; i++)
            {
                newArray[i] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.Capacity;
            }

            return newArray;
        }
    }

}
