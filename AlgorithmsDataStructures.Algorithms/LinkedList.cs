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

        public void AddBefore(LinkedListNode<T> newNode, LinkedListNode<T> beforeNode)
        {
            LinkedListNode<T> current = Head;

            while(current != beforeNode)
            {
                if(current.Next == beforeNode)
                {
                    newNode.Next = beforeNode;
                    current.Next = newNode;
                    Count++;
                    break;
                }
                current = current.Next;
            }
        }
        public void RemoveFirst()
        {
            Head = Head.Next;
            Count--;

            if (Count == 0)
                 Tail = null;
        }

        public void RemoveLast()
        {
            if(Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                LinkedListNode<T> current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                Tail = current;
            }
            
            Count--;
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
            /*
             Cases:
             1. Empty List, do nothing
             2. Single node in list (previous is null)
             3. Node to remove is first node
             4. Node to remove is middle or last node
             */
            LinkedListNode<T> current = Head;
            LinkedListNode<T> previous = null;

            while(current.Next != null)
            {
                if (current.Value.Equals(item))
                {
                    if(previous != null)
                    {
                        //Case 4
                        previous.Next = current.Next;
                        if(current.Next == null)
                        {
                            //last node
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        //either only one node in list or item is first in list
                        //Case 2 or 3
                        RemoveFirst();
                    }
                    return true;

                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
