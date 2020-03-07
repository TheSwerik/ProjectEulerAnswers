using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0021
    {
        public Problem0021()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            for (long i = 2; i <= 10000; i += 2)
            {
                long sum1 = 1;
                double root = Math.Sqrt(i);
                for (int j = 2; j <= root; j++)
                {
                    if (i % j == 0) sum1 += j + (i / j);
                }

                if (sum1 == i) continue;

                long sum2 = 1;
                root = Math.Sqrt(sum1);
                for (int j = 2; j <= root; j++)
                {
                    if (sum1 % j == 0) sum2 += j + (sum1 / j);
                }

                if (sum2 == i) result += i;
            }


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(21, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}