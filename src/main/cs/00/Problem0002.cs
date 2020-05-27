using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._00
{
    public class Problem0002
    {
        public Problem0002()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;
            long n = 10000;

            // Solution:
            long fibo1 = 1;
            long fibo2 = 1;
            while (fibo1 < n)
                if ((fibo1 = fibo2 + (fibo2 = fibo1)) % 2 == 0 && fibo1 < n)
                {
                    result += fibo1;
                    Console.WriteLine(fibo1);
                }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(2, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}
