using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            
            bool closed = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Day1");
                Console.WriteLine("1) Root of n-th degree");
                Console.WriteLine("2) Matrix sort");

                Console.Write("\nEnter the number(1,2) of task or q for exit: ");
                answer = Console.ReadLine().Trim();
                switch (answer)
                {
                    case "1":
                        TestRoot();
                        break;
                    case "2":
                        TestMatrix();
                        break;
                    case "q":
                        closed = true;
                        break;
                    default:
                        break;
                }
            }while(!closed);

        }
        static void TestMatrix()
        {
            int[][] matrix = new[]{

                    new []{1,3,5,2,54,2,65},
                    new [] {45,67,-23,56},
                    new [] {34,788,966}
                };
            Console.WriteLine("Our matrix:");
            Console.WriteLine(Matrix.ToString(matrix));


            Console.WriteLine("Our matrix after sorting (line sum):");
            Matrix.SortWithLineSum(ref matrix, false);
            Console.WriteLine(Matrix.ToString(matrix));

            Console.WriteLine("Our matrix after sorting (line max element):");
            Matrix.SortWithMaxLineElement(ref matrix);
            Console.WriteLine(Matrix.ToString(matrix));

            Console.WriteLine("Our matrix after sorting (line min element):");
            Matrix.SortWithMinLineElement(ref matrix, true);
            Console.WriteLine(Matrix.ToString(matrix));

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        static void TestRoot()
        {
            double number;
            int degree;
            double eps;
            bool closed = false;
            String answer;

            Console.WriteLine("Root of n-th degree");
            while (!closed)
            {
                Console.WriteLine("Type number:");
                number = double.Parse(Console.ReadLine());
                Console.WriteLine("Type degree(integer):");
                degree = int.Parse(Console.ReadLine());
                Console.WriteLine("Type eps:");
                eps = double.Parse(Console.ReadLine());

                Console.WriteLine("custom function: {0}\nstandart function: {1}\n", SimpleMath.Root(number, degree, eps), Math.Pow(number, 1 / (double)degree));

                Console.Write("You want repeat(y/N)? ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                    case "Y":
                        break;

                    case "n":
                    case "N":
                        closed = true;
                        break;
                    default:
                        closed = true;
                        break;
                }

            }
        }
    }
}
