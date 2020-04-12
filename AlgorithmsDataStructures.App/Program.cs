using System;
using AlgorithmsDataStructures.Models;

namespace AlgorithmsDataStructures.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Node a = new Node{ Value = 10 };

            Node b = new Node { Value = 12 };

            Node c = new Node { Value =  15 };

            a.Next = b;
            b.Next = c;
        }
    }
}
