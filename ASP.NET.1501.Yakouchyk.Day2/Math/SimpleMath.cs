using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CustomMath
{
    public static class SimpleMath
    {
        public static double Root(double number, uint n, double eps = 0.001)
        {
            if (number == 0 || number == 1 || n == 1)
                return number;

            double x;
            double nextX = 1;
            do
            {
                x = nextX;
                nextX = ((n - 1) * x + number / Pow(x, n - 1)) / n;
            } while (Math.Abs(x - nextX) > eps);
            return nextX;
        }

        public static double Pow(double number, uint n)
        {
            double result = 1;
            for (int i = 0; i < n; i++)
                result *= number;
            return result;
        }

        public static int GCDTimeTest(out long time, params int[] elements)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int result = GCD(elements);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
        }

        public static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a < b)
                Swap(ref a, ref b);
            int temp;
            do
            {
                temp = b;
                b = a % b;
                a = temp;
            } while (b != 0);

            return a;
        }

        public static int GCD(params int[] elements)
        {
            if (elements.Length > 0)
            {
                if (elements.Length > 1)
                {
                    int temp = elements[0];
                    for (int i = 1; i < elements.Length; i++)
                    {
                        temp = GCD(temp, elements[i]);
                    }
                    return temp;
                }
                else
                    return Math.Abs(elements[0]);
            }
            else
                throw new Exception("Not enough parametrs");
        }

        public static int BinaryGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0)
                return b;
            if (b == 0 || a == b)
                return a;
            if (a == 1 || b == 1)
                return 1;
            if (a % 2 == 0)
            {
                if (b % 2 == 0)
                {
                    return BinaryGCD(a >> 1, b >> 1) << 1;
                }
                else
                {
                    return BinaryGCD(a >> 1, b);
                }
            }
            else
            {
                if (b % 2 == 0)
                {
                    return BinaryGCD(a, b >> 1);
                }
                else
                {
                    if (a > b)
                    {
                        return BinaryGCD((a - b) >> 1, b);
                    }
                    else
                    {
                        return BinaryGCD((b - a) >> 1, a);
                    }
                }
            }
        }

        public static int BinaryGCD(params int[] elements)
        {
            if (elements.Length > 0)
            {
                if (elements.Length > 1)
                {
                    int temp = elements[0];
                    for (int i = 1; i < elements.Length; i++)
                    {
                        temp = BinaryGCD(temp, elements[i]);
                    }
                    return temp;
                }
                else
                    return Math.Abs(elements[0]);
            }
            else
                throw new Exception("Not enough parametrs");
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
