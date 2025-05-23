namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T item)
            {
                Value = item;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }
        public int Count { get; private set; }

        private Node Tail;
        private Node Head;

        public void AddFirst(T item)
        {
            if (Head == null)
            {
                Head = Tail = new Node(item);
            }
            else
            {
                Head.Previous = new Node(item);
                Head.Previous.Next = Head;
                Head = Head.Previous;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            if (Tail == null)
            {
                Tail = Head = new Node(item);
            }
            else
            {
                Tail.Next = new Node(item);
                Tail.Next.Previous = Tail;
                Tail = Tail.Next;
            }

            Count++;
        }

        public T GetFirst()
        {
            IfEmptyThrowException();

            return Head.Value;
        }

        public T GetLast()
        {
            IfEmptyThrowException();

            return Tail.Value;
        }

        public T RemoveFirst()
        {
            IfEmptyThrowException();

            T element = Head.Value;

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Head.Next.Previous = null;
                Head = Head.Next;
            }

            Count--;

            return element;
        }

        public T RemoveLast()
        {
            IfEmptyThrowException();
            T element = Tail.Value;
            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Tail.Previous.Next = null;
                Tail = Tail.Previous;
            }

            Count--;

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = Head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void IfEmptyThrowException()
        {
            if (Head == null)
            {
                throw new InvalidOperationException(nameof(Count));
            }
        }
    }
}