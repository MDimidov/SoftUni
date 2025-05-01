namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public Node(T element)
            {
                Element = element;
                Next = null;
            }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public Node Next { get; set; }
            public T Element { get; set; }
        }

        private Node top;

        public int Count { get; private set; } = 0;

        public void Push(T item)
        {
            Node newNode = new Node(item, top);
            top = newNode;
            Count++;
        }

        public T Pop()
        {
            if(top == null)
            {
                throw new InvalidOperationException(nameof(top));
            }

            Node node = top;
            top = top.Next;
            Count--;

            return node.Element;
        }

        public T Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException(nameof(top));
            }
            return top.Element;
        }

        public bool Contains(T item)
        {
            Node node = top;
            for (int i = 0; i < Count; i++)
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
            Node node = top;

            while(node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}