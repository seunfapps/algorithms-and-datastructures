using System;
using System.Collections;
using System.Collections.Generic;
using AlgorithmsDataStructures.Models;

namespace AlgorithmsDataStructures.Algorithms
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> Head { get; set; }
        private int Count { get; set; }

        public void Add(T item)
        {
            //Tree is empty, Allocate the head
            if (Head == null)
                Head = new BinaryTreeNode<T>(item);
            else
            //Tree is not empty, so find the right place to insert
            //Searching always start from the root node (Head)
                AddTo(Head, item);

            Count++;
        }

        //recursive add
        public void AddTo(BinaryTreeNode<T> node, T item)
        {
            if (item.CompareTo(node.Value) < 0)
            {
                //value you want to insert is less than the node, go left.
                if (node.Left == null)
                {
                    //if left node is empty, insert node here
                    node.Left = new BinaryTreeNode<T>(item);
                }
                else
                {
                    //if left node is not empty, do same for node
                    AddTo(node.Left, item);
                }
            }
            else
            {
                //value you want to insert is greater than the node, go right.
                if(node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(item);
                }
                else
                {
                    AddTo(node.Right, item);
                }
                
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
