using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._00
{
    public class Problem0097
    {
        public Problem0097()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            // Solution:
            var oof = (28433 * BigInteger.ModPow(2, 7830457, 10_000_000_000) + 1) % 10_000_000_000;

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + oof + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(97, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}
