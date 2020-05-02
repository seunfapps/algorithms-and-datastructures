using System;
using System.Collections;
using AlgorithmsDataStructures.Models;

namespace AlgorithmsDataStructures.Algorithms
{
    public class DoublyLinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        //first node
        public DoublyLinkedListNode<T> Head { get; set; }
        //last node
        public DoublyLinkedListNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedListNode<T>(value));
        }

        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            DoublyLinkedListNode<T> temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;

            if (Count == 1)
                Tail = Head;
            else
                temp.Previous = Head;

            
        }

        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedListNode<T>(value));
        }

        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (Count == 0)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;

            Count++;
        }

        public void RemoveFirst()
        {
            Head = Head.Next;
            Count--;

            if (Count == 0)
                 Tail = null;

            Head.Previous = null;
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
                Tail.Previous.Next = null;
                Tail = Tail.Previous;
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
            DoublyLinkedListNode<T> current = Head;
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
            DoublyLinkedListNode<T> current = Head;
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
            DoublyLinkedListNode<T> current = Head;
            //DoublyLinkedListNode<T> previous = null;

            while(current.Next != null)
            {
                if (current.Value.Equals(item))
                {
                    if(current.Previous != null)
                    {
                        if (current.Value.Equals(item))
                        {
                            current.Previous.Next = current.Next;
                        }
                        else
                        {
                            current = current.Next;
                        }
                    }
                    else
                    {
                        RemoveFirst();
                    }

                    Count--;
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
