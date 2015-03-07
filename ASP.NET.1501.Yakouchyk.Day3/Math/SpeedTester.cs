using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace CustomMath
{
    public static class SpeedTester
    {
        public static long Test<T, F>(int repeat, Func<T[], F> testFunction, params T[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < repeat; i++)
                testFunction(args);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
