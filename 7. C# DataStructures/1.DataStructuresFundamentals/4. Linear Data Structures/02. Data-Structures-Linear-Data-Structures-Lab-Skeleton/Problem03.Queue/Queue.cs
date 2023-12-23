namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
            }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public T Element { get; set; }
            public Node Next { get; set; }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Node oldHead = this.head;
            this.head.Next = oldHead;
            this.head = new Node(item);
        }

        public T Dequeue()
        {
            this.IsEmptyQueue();

            Node oldHead = this.head;
            this.head = oldHead.Next;

            this.Count--;
            return oldHead.Element;
        }

        public T Peek()
        {
            this.IsEmptyQueue();
            return this.head.Element;
        }

        public bool Contains(T item)
        {
            Node node = this.head;
            while (node != null)
            {
                if(node.Element.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;
            while(node != null)
            {
                yield return node;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void IsEmptyQueue()
        {
            if(this.head == null)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
        }
    }
}