namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {

        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
            }

            public T Element { get; private set; }

            public Node Previous { get; set; }

            public Node Next { get; set; }
        }

        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            ValidateList();
            return this.head.Element;
        }

        public T GetLast()
        {
            ValidateList();
            return this.tail.Element;
        }

        public T RemoveFirst()
        {
            ValidateList();
            T firstElement = this.head.Element;

            if (this.head.Next == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            ValidateList();
            T lastElement = this.tail.Element;
            if (this.tail.Previous == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }

            Count--;
            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Element;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void ValidateList()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Doubly Linked List should not be empty!");
            }
        }
    }
}