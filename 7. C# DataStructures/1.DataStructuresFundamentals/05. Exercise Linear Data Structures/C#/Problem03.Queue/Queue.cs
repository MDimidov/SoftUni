namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Element = value;
            }

            public Node(T value, Node node)
            {
                Element = value;
                Next = node;
            }

            public T Element { get; set; }

            public Node Next { get; set; } = null;
        }

        private Node head;

        public int Count { get; private set; } = 0;

        public void Enqueue(T item)
        {
            if (head == null)
            {
                head = new Node(item);
            }
            else
            {
                Node node = head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = new Node(item);
            }

            Count++;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException(nameof(head));
            }

            Node node = head;
            head = head.Next;
            Count--;

            return node.Element;
        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException(nameof(head));
            }

            return head.Element;
        }

        public bool Contains(T item)
        {
            Node node = head;
            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}