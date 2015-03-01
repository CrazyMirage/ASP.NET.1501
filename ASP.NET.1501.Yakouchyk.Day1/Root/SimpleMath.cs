using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{
    static class SimpleMath
    {
        static public double Root(double number, int n, double eps = 0.001) 
        {
            double x;
            double nextX = 1;
            do
            {
                x = nextX;
                nextX =  ((n - 1) * x + number / Pow(x,n-1))/n;
            } while (Math.Abs(x - nextX) > eps);
            return nextX;
        }

        static public double Pow(double number, int n) 
        {
            double result = number;
            for (int i = 1; i < n; i++)
                result *= number;
            return result;
        }

    }
}
