using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0015
    {
        public Problem0015()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            // Solution:
            BigInteger n = 1;
            BigInteger k = 1;
            for (var i = 21; i < 40; i++)
            {
                n = n * i;
                k = k * (i - 20);
            }

            n = n / k * 2;


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + n + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    15, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}