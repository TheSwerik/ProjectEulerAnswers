using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0003
    {
        public Problem0003()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long largestFact = 0;

            // Solution:
            var n = 600_851_475_143;
            long counter = 2;
            while (counter * counter <= n)
                if (n % counter == 0) n /= largestFact = counter;
                else counter = counter == 2 ? 3 : counter + 2;

            if (n > largestFact) largestFact = n;

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + largestFact + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(3, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}