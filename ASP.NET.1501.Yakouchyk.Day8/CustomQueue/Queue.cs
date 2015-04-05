using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        //private class Node<T>
        //{
        //    public Node<T> Next { get; set; }
        //    public Node<T> Previous { get; set; }
        //    public T Value { get; set; }
        //}

        //private Node<T> top;
        //private Node<T> bottom;

        private int begin;
        public int Size { get; private set; }

        private T[] array;


        public Queue() { }

        public Queue(IEnumerable<T> values)
        {
            //foreach (T elem in values)
            //{
            //    Enqueue(elem);
            //}

            array = values.ToArray();
            Size = array.Length;
        }

        public void Enqueue(T value)
        {
            //if (top == null)
            //{
            //    top = new Node<T> { Value = value };
            //    bottom = top;
            //}
            //else
            //{
            //    Node<T> temp = new Node<T> { Value = value, Next = bottom };
            //    bottom.Previous = temp;
            //    bottom = temp;
            //}
            if (array == null)
                array = new [] { value };
            else if (Size >= array.Length)
            {
                var temp = array.Length;
                Array.Resize(ref array, array.Length * 2);
                for (int i = 0; i < begin; i++)
                {
                    array[temp + i] = array[i];
                    array[i] = default(T);
                }
                array[begin + Size] = value;
            }
            else {
                array[(begin + Size) % array.Length] = value;
            }
            Size++;
        }

        public T Dequeue()
        {
            //if (top == null)
            //    throw new InvalidOperationException("It's empty");
            //T value = top.Value;
            //if (top == bottom)
            //{
            //    top = null;
            //    bottom = null;
            //}
            //else
            //{
            //    top = top.Previous;
            //    top.Next = null;
            //}
            //return value;

            if(Size <= 0)
                throw new InvalidOperationException("It's empty");
            var temp = array[begin];
            begin = (begin + 1) % array.Length;
            Size--;
            return temp;

        }

        public T Peek()
        {
            //if (top == null)
            //    throw new InvalidOperationException("It's empty");
            //return top.Value;
            if (Size <= 0)
                throw new InvalidOperationException("It's empty");
            return array[begin];
        }

        public bool Empty()
        {
            //if (top == null)
            //    return true;
            //return false;
            return Size <= 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Node<T> current = top;
            //while (current != null)
            //{
            //    yield return current.Value;
            //    current = current.Previous;
            //}

            for (int i = begin; i < Size; i++)
                yield return array[i % array.Length];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
