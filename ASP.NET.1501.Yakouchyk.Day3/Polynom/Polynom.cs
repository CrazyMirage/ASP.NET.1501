using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomMath;
using System.Threading.Tasks;

namespace Polynom
{
    public class Polynom
    {
        private double[] coefficients;

        public int Degree { get; private set; }

        public Polynom(int size, double defaultValue = 0)
        {
            coefficients = new double[size];

            if (defaultValue != 0)
            {
                for (int i = 0; i < size; i++)
                    coefficients[i] = defaultValue;
                Degree = size - 1;
            }

        }

        public Polynom(params double[] coefficients)
        {
            this.coefficients = (double[])coefficients.Clone();
            CalculateDegree();
        }

        public Polynom(Polynom pol)
        {
            this.coefficients = (double[])pol.coefficients.Clone();
            Degree = pol.Degree;
        }

        public Polynom()
        {
            coefficients = new double[0];
            Degree = 0;
        }



        public double Calculate(double x)
        {
            double result = 0;
            for (uint i = 0; i <= Degree; i++)
                result += coefficients[i] * SimpleMath.Pow(x, (i));
            return result;
        }

        public static Polynom operator +(Polynom first, Polynom second)
        {
            Polynom max, min;
            if (first.Degree > second.Degree)
            {
                max = first;
                min = second;
            }
            else
            {
                max = second;
                min = first;
            }

            Polynom result = new Polynom(max.Degree + 1);

            int i = 0;
            for (; i <= min.Degree; i++)
            {
                result.coefficients[i] = min.coefficients[i] + max.coefficients[i];
            }
            for (; i <= max.Degree; i++)
            {
                result.coefficients[i] = max.coefficients[i];
            }

            result.CalculateDegree();

            return result;
        }

        public static Polynom operator -(Polynom first, Polynom second)
        {
            Polynom result = new Polynom(Math.Max(first.Degree, second.Degree) + 1);
            for (int i = 0; i <= first.Degree; i++)
                result.coefficients[i] = first.coefficients[i];
            for (int i = 0; i <= first.Degree; i++)
                result.coefficients[i] -= second.coefficients[i];


            result.CalculateDegree();
            return result;
        }

        public static Polynom operator *(Polynom pol, double x)
        {
            Polynom result = new Polynom(pol);
            for (int i = 0; i <= result.Degree; i++)
                result.coefficients[i] *= x;

            result.CalculateDegree();
            return result;
        }

        public static Polynom operator *(double x, Polynom pol)
        {
            return pol * x;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Polynom work = (Polynom)obj;
            if (this.Degree != work.Degree)
                return false;

            for (int i = 0; i <= this.Degree; i++)
            {
                if (this.coefficients[i] != work.coefficients[i])
                    return false;
            }

            return true;
        }


        private void CalculateDegree()
        {
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                if (coefficients[i] != 0)
                {
                    Degree = i;
                    return;
                }
            }
        }
    }
}
