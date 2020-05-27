using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._00
{
    public class Problem0040
    {
        public Problem0040()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var concatenated = concatenate(1_000_000);
            var n = 1;
            result = concatenated[n] - 48;
            for (var i = 0; i < 6; i++)
            {
                n = int.Parse(n + "0");
                result *= concatenated[n] - 48;
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(40, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private string concatenate(long n)
        {
            var result = ".";
            for (var i = 1; result.Length <= n + 1; i++) result += i;

            return result;
        }
    }
}
