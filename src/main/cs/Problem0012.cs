using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0012
    {
        public Problem0012()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var divisors = 500;
            long n = 1;
            for (long i = 2;; i++)
            {
                n = i * (i + 1) / 2;
                var root = Math.Sqrt(n);
                var count = (int) root == root ? 1 : 0;
                for (long j = 1; j < root; j++)
                    if (n % j == 0)
                        count += 2;

                if (count > divisors)
                {
                    result = n;
                    break;
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
                Benchmark.AddTime(12, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}