using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0051
    {
        public Problem0051()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:



            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(51, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}