using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementing_Linked_List
{
    internal class SoftUniLinkedList
    {
        public Node Head { get;set; }

        public Node Tail { get;set; }
        public int Count { get; set; }

        //methods
        public void AddFirst(int value)
        {
            Count++;
            Node node = new(value);
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
                return;
            }

            node.Next = Head;
            this.Head.Previous = node;
            this.Head = node;
        }

        public void AddLast(int value)
        {
            Count++;
            Node node = new(value);
            if(this.Tail == null)
            {
                this.Tail = node;
                this.Head = node;
                return;
            }

            node.Previous = this.Tail;
            this.Tail.Next = node;
            this.Tail = node;
        }

        public void RemoveFirst()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("The LinledList is empty");
            }
            if(Head.Next == null)
            {
                Head = null;
                Tail = null;
                //Count--;
            }
            else
            {
                Node oldHead = this.Head;
                Head = Head.Next;

                Head.Previous = null;
                oldHead.Next = null;
            }
            Count--;   
        }

        public void RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The LinledList is empty");
            }
            if (Tail.Previous == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Node oldTail = this.Tail;
                this.Tail = Tail.Previous;

                Tail.Next = null;
                oldTail.Previous = null;
            }
            Count--;
        }

        public void ForEach(Action<int> callBack)
        {
            Node current = Head;
            while(current != null)
            {
                callBack(current.Value);
                current = current.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int i = 0;
            ForEach(e => array[i++] = e);

            return array;
        }
    }
}
