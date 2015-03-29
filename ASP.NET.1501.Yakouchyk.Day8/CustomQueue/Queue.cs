using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        private class Node<T>
        {
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }
            public T Value { get; set; }
        }

        private Node<T> top;
        private Node<T> bottom;


        public Queue() { }

        public Queue(IEnumerable<T> values)
        {
            foreach (T elem in values)
            {
                Enqueue(elem);
            }
        }

        public void Enqueue(T value)
        {
            if (top == null)
            {
                top = new Node<T> { Value = value };
                bottom = top;
            }
            else
            {
                Node<T> temp = new Node<T> { Value = value, Next = bottom };
                bottom.Previous = temp;
                bottom = temp;
            }
        }

        public T Dequeue()
        {
            if (top == null)
                throw new InvalidOperationException("It's empty");
            T value = top.Value;
            if (top == bottom)
            {
                top = null;
                bottom = null;
            }
            else
            {
                top = top.Previous;
                top.Next = null;
            }
            return value;
        }

        public T Peek()
        {
            if (top == null)
                throw new InvalidOperationException("It's empty");
            return top.Value;
        }

        public bool Empty()
        {
            if (top == null)
                return true;
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = top;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
