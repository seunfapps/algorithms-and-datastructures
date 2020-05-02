using System;
namespace AlgorithmsDataStructures.Algorithms
{
    public class PriorityQueue<T>
    {
        LinkedList<T> list = new LinkedList<T>();

        //assume items with higher values have higher priority in the queue
        public void Enqueue (T item)
        {
            if(list.Count == 0)
                list.AddLast(item);
            else
            {
                var current = list.Head;

                //while(current.Value.CompareTo(item) > 0)
                //{
                    //current is larger than what we want to insert, so continue to loop
                    current = current.Next;
                //}
                if(current == null)
                {
                    //we made it to the end of the list
                    list.AddLast(item);
                }
                else
                {
                    //item being inserted is larger than the current, so insert item before currnet.
                    list.AddBefore(item, current); 
                }
            }
        }

        public T Dequeue()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("The Queue is empty");

            T value = list.Head.Value;
            list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("The Queue is empty");

            return list.Head.Value;
        }
    }
}
