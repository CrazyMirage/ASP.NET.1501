using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    public class Polynom
    {
        private double[] coefficients;

        private int degree;
        private bool degreeCalculated = false;


        public int Degree
        {
            get
            {
                if (!degreeCalculated)
                {
                    CalculateDegree();
                }
                return degree;
            }
            private set { degree = value; }
        }

        private Polynom(int size)
        {
            coefficients = new double[size];
        }

        public Polynom(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("coefficients");
            this.coefficients = (double[])coefficients.Clone();
        }

        public Polynom(Polynom polynom)
        {
            if (polynom == null)
                throw new ArgumentNullException("polynom");
            this.coefficients = (double[])polynom.coefficients.Clone();
        }



        public double Calculate(double x)
        {
            double result = 0;
            for (int i = 0; i <= Degree; i++)
                result += coefficients[i] * SimpleMath.Pow(x, i);
            return result;
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index > Degree)
                    throw new ArgumentOutOfRangeException("index");
                return coefficients[index];
            }
            private set { coefficients[index] = value; }
        }

        public static Polynom operator + (Polynom lhs, Polynom rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException("lhs");
            if (rhs == null)
                throw new ArgumentNullException("rhs");

            Polynom max, min;
            if (lhs.Degree > rhs.Degree)
            {
                max = lhs;
                min = rhs;
            }
            else
            {
                max = rhs;
                min = lhs;
            }

            Polynom result = new Polynom(max.Degree + 1);

            int i = 0;
            for (; i <= min.Degree; i++)
            {
                result[i] = min[i] + max[i];
            }
            for (; i <= max.Degree; i++)
            {
                result[i] = max[i];
            }


            return result;
        }

        public static Polynom operator - (Polynom pol)
        {
            if (pol == null)
                throw new ArgumentNullException("pol");
            Polynom result = new Polynom(pol.Degree + 1);
            for (int i = 0; i <= pol.Degree; i++)
            {
                result[i] = -pol[i];
            }
            return result;
        }

        public static Polynom operator - (Polynom lhs, Polynom rhs)
        {
            return lhs+(-rhs);
        }

        public static Polynom operator * (Polynom pol, double x)
        {
            if (pol == null)
                throw new ArgumentNullException("pol");
            Polynom result = new Polynom(pol);
            for (int i = 0; i <= result.Degree; i++)
                result.coefficients[i] *= x;

            return result;
        }

        public static Polynom operator * (double x, Polynom pol)
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
                if (this[i] != work[i])
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return (int)Calculate(1);
        }

        private void CalculateDegree()
        {
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                if (Math.Abs(coefficients[i]) > double.Epsilon)
                {
                    Degree = i;
                    degreeCalculated = true;
                    return;
                }
            }
        }
    }
}
