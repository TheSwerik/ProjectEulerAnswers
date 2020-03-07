using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0039
    {
        public Problem0039()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            int maxSolutions = 0;
            for (int i = 1000; i > 2; i--)
            {
                int solutions = numberOfSolutions(i);
                if (solutions > maxSolutions)
                {
                    maxSolutions = solutions;
                    result = i;
                }
            }


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(39, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private int numberOfSolutions(int n)
        {
            int result = 0;

            for (int c = n / 2; c > 2; c--)
            for (int b = c; b > 1; b--)
            {
                double a = Math.Sqrt(c * c - b * b);
                if (a + b + c == n) result++;
            }

            return result;
        }
    }
}