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

        public bool Contains (T value)
        {
            BinaryTreeNode<T> parent;

            return FindWithParent(value, out parent) != null;
        }

        private BinaryTreeNode<T> FindWithParent(T item, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = Head;
            parent = null;

            while (current != null)
            {
                if(item.CompareTo(current.Value) < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if(item.CompareTo(current.Value) > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    //we found a match
                    break;
                }
            }

            return current;
            
        }


        public bool Remove (T item)
        {
            BinaryTreeNode<T> parent;

            BinaryTreeNode<T> current = FindWithParent(item, out parent);

            if (current == null) //item to remove wasn't found
                return false;


            /*Removing from Binary Tree is a bit more complex, there are 3 scenarios
            Case 1: If the node to remove has no right child, then node's left child replaces node
            Case 2: If the node's right child has no left child, then node's right child replaces node
            Case 3: If the node's right child has a left child, then replace node with node's right child's left-most child.
             */

            //Case 1
            if(current.Right == null)
            {
                if(parent == null)
                {
                    //if item is the root node.
                    Head = current.Left;
                }
                else
                {
                    //to determine where to put current node on parent, left side or right side
                    if(current.Value.CompareTo(parent.Value) < 0)
                    {
                        //if current value is less than parent value
                        //make current's left child the left child of parent
                        parent.Left = current.Left;
                    }
                    else
                    {
                        //if current value is more than or equal parent value
                        //make current's left child the right child of parent
                        parent.Right = current.Left;
                    }
                }
            }

            //Case 2
            else if(current.Right.Left == null)
            {
                if (parent == null)
                    Head = current.Right;
                else
                {
                    if(current.Value.CompareTo(parent.Value) < 0)
                    {
                        parent.Left = current.Right;
                    }
                    else
                    {
                        parent.Right = current.Right;
                    }
                }
            }

            //Case 3
            else
            {
                BinaryTreeNode<T> leftMost = current.Right.Left; //starting point
                BinaryTreeNode<T> leftMostParent = current.Right; //parent of the leftmost child

                while(leftMost.Left != null)//while there is still a child to the left, keep going left
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                //replace node with node's right child's left-most child. ?? -- not sure this bit.
                //the parent's left subtree becomes the leftmost's right subtree
                leftMostParent.Left = leftMost.Right;

                //assign leftmost's left and right to current's left and right children.
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                    Head = leftMost;
                else
                {
                    if (current.Value.CompareTo(parent.Value) < 0)
                    {
                        parent.Left = leftMost;
                    }
                    else
                    {
                        parent.Right = leftMost;
                    }
                }

            }
            return true;
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
