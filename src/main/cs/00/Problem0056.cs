using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0056
    {
        public Problem0056()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            BigInteger result = 0;

            // Solution:
            for (var a = 2; a < 100; a++)
            for (var b = 2; b < 100; b++)
            {
                var dSum = DigitSum(BigInteger.Pow(a, b));
                if (dSum > result) result = dSum;
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(56, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private BigInteger DigitSum(BigInteger n)
        {
            BigInteger result = 0;
            var s = n.ToString();
            foreach (var c in s) result += c - 48;

            return result;
        }
    }
}