using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0027
    {
        public Problem0027()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var nMax = 0;

            for (var a = -1000; a <= 1000; a++)
            for (var b = -1000; b <= 1000; b++)
            {
                var n = 0;
                while (isPrim(formula(a, b, n))) n++;

                if (n > nMax)
                {
                    result = a * b;
                    nMax = n;
                }
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(27, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private long formula(long a, long b, long n)
        {
            return n * n + a * n + b;
        }

        private bool isPrim(long n)
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;

            if (n % 2 == 0 || n % 3 == 0) return false;

            var root = (long) Math.Sqrt(n) + 1;
            for (var i = 6L; i <= root; i += 6)
                if (n % (i - 1) == 0 || n % (i + 1) == 0)
                    return false;

            return true;
        }
    }
}