using System;
namespace AlgorithmsDataStructures.Algorithms
{
    public class Stack<T>
    {
        public Stack()
        {
        }

        //Implementing Stack using the LinkedList we created
        LinkedList<T> list = new LinkedList<T>();


        public void Push(T item)
        {
            list.AddFirst(item);
        }

        public T Pop()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            T value = list.Head.Value;
            list.RemoveFirst();
            return value;
        }
    }
}
