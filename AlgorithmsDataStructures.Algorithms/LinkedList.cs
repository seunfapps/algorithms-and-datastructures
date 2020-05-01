using System;
using System.Collections;
using AlgorithmsDataStructures.Models;

namespace AlgorithmsDataStructures.Algorithms
{
    public class LinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        //first node
        public LinkedListNode<T> Head { get; set; }
        //last node
        public LinkedListNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;

            if (Count == 1)
                Tail = Head;
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
                Head = node;
            else
                Tail.Next = node;

            Tail = node;

            Count++;
        }


        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            //start from beginning of the list
            LinkedListNode<T> current = Head;
            while(current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                //move to next item in List;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //copy list into array, starting from index
            LinkedListNode<T> current = Head;
            while(current.Next != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
