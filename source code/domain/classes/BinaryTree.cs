using Domain.Intefaces;
using System;
using System.Collections.ObjectModel;

namespace domain.classes
{
    public class Node
    {
        public IRectangle Tag { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }

    public class BinaryTree
    {
        public Node Root { get; set; }

        public BinaryTree(Collection<IRectangle> values)
        {
            foreach (IRectangle i in values)
            {
                Add(i);
            }
        }

        // https://www.geeksforgeeks.org/find-the-closest-element-in-binary-search-tree-space-efficient-method/
        // Function to find the Node closest to the  
        // given key in BST using Morris Traversal 
        private Node Closest(Node root, int key)
        {
            int diff = int.MaxValue;
            Node current = root;
            Node closest = null;

            while (current != null)
            {
                if (current.LeftNode == null)
                {
                    // updating diff if the current diff is 
                    // smaller than prev difference 
                    if (diff > Math.Abs(current.Data - key))
                    {
                        diff = Math.Abs(current.Data - key);
                        closest = current;
                    }

                    current = current.RightNode;
                }
                else
                {
                    // finding the inorder predecessor 
                    Node pre = current.LeftNode;
                    while (pre.RightNode != null && pre.RightNode != current)
                    {
                        pre = pre.RightNode;
                    }

                    if (pre.RightNode == null)
                    {
                        pre.RightNode = current;
                        current = current.LeftNode;
                    }

                    // threaded link between curr and 
                    // its predecessor already exists 
                    else
                    {
                        pre.RightNode = null;

                        // if a closer Node found, then update  
                        // the diff and set closest to current 
                        if (diff > Math.Abs(current.Data - key))
                        {
                            diff = Math.Abs(current.Data - key);
                            closest = current;
                        }

                        // moving to the right child 
                        current = current.RightNode;
                    }
                }
            }

            return closest;
        }

        public Node Closest(int value)
        {
            return this.Closest(this.Root, value);
        }


        public bool Add(IRectangle rectangle)
        {
            Node before = null, after = this.Root;
            int top = rectangle.getTop();

            while (after != null)
            {
                before = after;
                if (top < after.Data) //Is new node in left tree? 
                {
                    after = after.LeftNode;
                }
                else if (top > after.Data) //Is new node in right tree?
                {
                    after = after.RightNode;
                }
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = top;
            newNode.Tag = rectangle;

            if (this.Root == null) // Is tree is empty
            {
                this.Root = newNode;
            }
            else
            {
                if (top < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data)
                {
                    return parent;
                }
                if (value < parent.Data)
                {
                    return Find(value, parent.LeftNode);
                }
                else
                {
                    return Find(value, parent.RightNode);
                }
            }

            return null;
        }

        public Node Find(int value)
        {
            return this.Find(value, this.Root);
        }
    }
}
