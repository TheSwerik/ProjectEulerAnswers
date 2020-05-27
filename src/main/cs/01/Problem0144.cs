using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._01
{
    public class Problem0144
    {
        public Problem0144()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    144, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}