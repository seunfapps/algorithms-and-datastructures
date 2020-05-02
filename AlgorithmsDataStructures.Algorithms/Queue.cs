using System;
namespace AlgorithmsDataStructures.Algorithms
{
    public class Queue<T>
    {
        LinkedList<T> list = new LinkedList<T>();

        public void Enqueue (T item)
        {
            list.AddLast(item);
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
