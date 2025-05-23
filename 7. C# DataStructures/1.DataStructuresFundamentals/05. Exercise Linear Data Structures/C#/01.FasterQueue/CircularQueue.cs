namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private int startIndex, endIndex;

        private T[] elements;

        public CircularQueue(int capacity = 4)
        {
            elements = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            emptyQueueThrowError();

            T element = elements[startIndex];
            startIndex = ++startIndex % elements.Length;
            Count--;

            return element;
        }

        public void Enqueue(T item)
        {
            if (Count >= elements.Length)
            {
                Grow();
            }

            elements[endIndex++ % elements.Length] = item;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++) { 
                yield return elements[(startIndex + i) % elements.Length];
            }
        }

        public T Peek()
        {
            emptyQueueThrowError();

            return elements[startIndex];
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                array[i] = elements[(startIndex + i) % elements.Length];
            }

            return array;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void Grow()
        {
            T[] newElements = new T[elements.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                newElements[i] = elements[(startIndex + i) % elements.Length];
            }

            elements = newElements;
        }

        private void emptyQueueThrowError()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException(nameof(elements));
            }
        }
    }

}
