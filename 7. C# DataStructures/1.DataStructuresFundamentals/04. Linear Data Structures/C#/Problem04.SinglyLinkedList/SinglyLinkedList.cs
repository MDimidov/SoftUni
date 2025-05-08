namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            Node node = new Node(item, head);
            head = node;

            Count++;
        }

        public void AddLast(T item)
        {
            if (head == null)
            {
                AddFirst(item);
                return;
            }
            else
            {
                Node node = head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                Node newNode = new Node(item);
                node.Next = newNode;
            }

            Count++;
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

        public T GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException(nameof(head));
            }

            return head.Element;
        }

        public T GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException(nameof(head));
            }

            Node node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException(nameof(head));
            }

            T item = head.Element;

            head = head.Next;
            Count--;

            return item;
        }

        public T RemoveLast()
        {
            T element;
            if (head == null)
            {
                throw new InvalidOperationException(nameof(head));
            }
            else if (Count == 1)
            {
                element = head.Element;
                head = null;
            }
            else
            {


                Node node = head;

                while (node.Next?.Next != null)
                {
                    node = node.Next;
                }

                element = node.Next.Element;
                node.Next = null;
            }

            Count--;
            return element;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}