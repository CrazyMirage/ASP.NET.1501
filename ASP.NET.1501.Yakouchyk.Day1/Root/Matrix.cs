using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{

    static class Matrix
    {
        public delegate int LineWeight(int[] arr);

        static int LineSum(int[] arr) 
        {
            int sum = 0;
            foreach (int element in arr)
                sum += element;
            return sum;
        }

        static int LineMax(int[] arr) 
        {
            int max = arr[0];
            foreach (int element in arr)
                if (max < element)
                    max = element;
            return max;
        }

        static int LineMin(int[] arr) 
        {
            int min = arr[0];
            foreach (int element in arr)
                if (min > element)
                    min = element;
            return min;
        }

        static public void Sort(ref int[][] matrix, LineWeight func, bool direction)
        {
            int[] lineWeight = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                lineWeight[i] = func(matrix[i]);
            }

            for (int i = 0; i < matrix.Length; i++)
                for (int j = i; j < matrix.Length; j++)
                {
                    if ((lineWeight[i] > lineWeight[j]) == direction)
                    {
                        Swap(ref lineWeight[i], ref lineWeight[j]);
                        Swap(ref matrix[i], ref matrix[j]);
                    }

                }
        }

        static public void SortWithLineSum(ref int[][] matrix, bool direction = false) 
        {
            Sort(ref matrix, LineSum, direction);
        }

        static public void SortWithMinLineElement(ref int[][] matrix, bool direction = false)
        {
            Sort(ref matrix, LineMin, direction);
        }

        static public void SortWithMaxLineElement(ref int[][] matrix, bool direction = false)
        {
            Sort(ref matrix, LineMax, direction);
        }

        static void Swap<T>(ref T a, ref T b) 
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static public string ToString(int[][] matrix)
        {
            StringBuilder str = new StringBuilder();
            foreach (int[] arr in matrix) 
            {
                foreach(int elem in arr)
                    str.Append(elem + " ");
                str.Append('\n');
            }
            return str.ToString();
        }
    }
}
