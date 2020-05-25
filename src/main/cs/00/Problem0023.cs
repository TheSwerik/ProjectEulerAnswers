using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0023
    {
        public Problem0023()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 1;

            // Solution:
            var abundant = new List<int>();
            var sumOfTwo = new bool[28123 + 1];
            for (var i = 2; i <= 28123; i++)
            {
                long sum = 1;
                var root = Math.Sqrt(i);
                for (var j = 2; j <= root; j++)
                    if (i % j == 0)
                        sum += j + (root == j ? 0 : i / j);

                if (sum > i) abundant.Add(i);
            }

            for (var i = 0; i < abundant.Count; i++)
            for (var j = i; j < abundant.Count; j++)
                sumOfTwo[abundant[i] + abundant[j] < 28123 ? abundant[i] + abundant[j] : 24] = true;

            for (var i = 2; i < 28123; i++)
                if (!sumOfTwo[i])
                    result += i;

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(23, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}