namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node()
        {
            public Node(T elemennt)
            {
                this.Element = elemennt;
            }

            public Node(T elemennt, Node next)
            {
                this.Element = elemennt;
                this.Next = next;
            }

            public T Element { get; set; }
            public Node Next { get; set; }
        }

        private Node head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node node = new Node(item, this.head);
            head = node;
            Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);
            Node node = this.head;

            while(node.Next != null)
            {
                node = node.Next;
            }

            node.Next = newNode;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            IsListEmpty();
            Node node = this.head;
            while(node != null)
            {
                yield return node;
                node = node.Next;
            }
        }

        public T GetFirst()
        {
            IsListEmpty();
            return this.head.Element;
        }

        public T GetLast()
        {
            IsListEmpty();
            Node node = this.head;
            while(node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            IsListEmpty();
            Node oldHead = this.head;
            this.head = oldHead.Next;
            Count--;

            return oldHead.Element;
        }

        public T RemoveLast()
        {
            Node node = this.head;

            while(node.Next.Next != null)
            {
                node = node.Next;
            }

            T element = node.Next.Element;
            node.Next = null;
            Count--;
            return element;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void IsListEmpty()
        {
            if(this.Count <= 0)
            {
                throw new InvalidOperationException("The linked list is empty");
            }
        }
    }
}