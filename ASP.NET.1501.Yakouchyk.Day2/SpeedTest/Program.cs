using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMath;

namespace SpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 175081;
            int b = 175993;
            int c = 173189;
            long time = SpeedTester.Test(10000, SimpleMath.GCD, a, b, c);
            Console.WriteLine(time);

            time = SpeedTester.Test(10000, SimpleMath.BinaryGCD, a, b, c);
            Console.WriteLine(time);
            Console.ReadLine();
        }
    }
}
