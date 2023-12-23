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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            if(this.top.Element == null)
            {
                this.top.Element = new Node(item);
            }
            else
            {
                var node = new Node(item, this.top);
                this.top = node;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            Node oldTop = this.top;
            this.top = oldTop.Next;
            this.Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            if(this.top == null)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.top.Element;
        }

        public bool Contains(T item)
        {
            Node node = this.top;
            while(node != null)
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
            Node node = this.top;
            while(node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}