using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{

    public class BinaryTree<T> : IEnumerable<T>
    {

        private class Node<T>
        {
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public Node<T> Parent { get; set; }
            public T Value { get; set; }
        }

        private Func<T, T, int> compare;
        private Node<T> root;

        public BinaryTree()
            : this((Func<T, T, int>)null)
        {
        }

        public BinaryTree(Comparer<T> comparer)
            : this(comparer.Compare)
        {
        }

        public BinaryTree(Func<T, T, int> compare)
        {
            if (compare == null)
            {
                if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                    compare = Comparer<T>.Default.Compare;
                else
                    throw new ArgumentException();
            }
            this.compare = compare;
        }

        public void Add(T value)
        {
            Node<T> temp = new Node<T>() { Value = value };
            if (root == null)
                root = temp;
            else
            {
                Node<T> current = root;
                while (current != null)
                {
                    int cmp = compare(value, current.Value);
                    if (cmp < 0)
                    {
                        if (current.Left == null)
                        {
                            temp.Parent = current;
                            current.Left = temp;
                            current = null;
                        }
                        else
                            current = current.Left;
                    }
                    else if (cmp > 0)
                    {
                        if (current.Right == null)
                        {
                            temp.Parent = current;
                            current.Right = temp;
                            current = null;
                        }
                        else
                            current = current.Right;
                    }
                    //else
                    //{
                    //    temp.Left = current.Left;
                    //    temp.Right = current.Right;
                    //    current = temp;
                    //}
                }
            }
        }

        public void Delete(T value)
        {
            var node = Find(value);
            Node<T> removed;
            Node<T> temp;
            if (node != null)
            {
                if (node.Left == null || node.Right == null)
                    removed = node;
                else
                    removed = Minimum(node.Right);

                if (removed.Left != null)
                    temp = removed.Left;
                else
                    temp = removed.Right;


                if (temp != null)
                    temp.Parent = removed.Parent;


                if (removed.Parent == null)
                    root = temp;
                else
                {
                    if (removed.Parent.Left == removed)
                        removed.Parent.Left = temp;
                    else
                        removed.Parent.Right = temp;

                }
                if (removed != node)
                    node.Value = removed.Value;

            }


        }

        public bool Exist(T value)
        {
            return Find(value) != null;
        }

        public IEnumerable<T> PostOrder()
        {
            var stack = new Stack<Node<T>>();
            var temp = root;
            Node<T> prev = null;
            stack.Push(root);
            while (stack.Count != 0)
            {
                temp = stack.Peek();
                if (prev == null || prev.Left == temp || prev.Right == temp)
                {
                    if (temp.Left != null)
                        stack.Push(temp.Left);
                    else if (temp.Right != null)
                        stack.Push(temp.Right);
                }
                else if (temp.Left == prev)
                {
                    if (temp.Right != null)
                        stack.Push(temp.Right);
                }
                else
                {
                    yield return temp.Value;
                    stack.Pop();
                }
                prev = temp;
            }
        }

        public IEnumerable<T> PreOrder()
        {
            var stack = new Stack<Node<T>>();
            var temp = root;
            while (temp != null || stack.Count != 0)
            {
                if (stack.Count != 0)
                {
                    temp = stack.Pop();
                }
                while (temp != null)
                {
                    yield return temp.Value;
                    if (temp.Right != null)
                        stack.Push(temp.Right);
                    temp = temp.Left;
                }
            }
        }

        public IEnumerable<T> InOrder()
        {
            var stack = new Stack<Node<T>>();
            var temp = root;
            while (temp != null || stack.Count != 0)
            {
                if (stack.Count != 0)
                {
                    temp = stack.Pop();
                    yield return temp.Value;
                    temp = temp.Right;
                }
                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.Left;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private Node<T> Minimum(Node<T> node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        private Node<T> Find(T value)
        {
            Node<T> current = root;
            while (current != null)
            {
                int cmp = compare(value, current.Value);
                if (cmp < 0)
                {
                    current = current.Left;
                }
                else if (cmp > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return current;
                }
            }
            return null;
        }


    }
}
