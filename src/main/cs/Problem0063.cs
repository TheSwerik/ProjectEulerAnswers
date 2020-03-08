using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0063
    {
        public Problem0063()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            int min = 0;
            for (int exp = 1;; exp++)
            {
                for (int j = min; j < 10; j++)
                {
                    ulong solution = (ulong) Math.Pow(j, exp);

                    if ((solution + "").Length == exp) result++;
                    else min++;
                }

                if (min > 9) break;
            }

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(63, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        string s =
            "The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=8^9, is a ninth power."
            +
            "How many n-digit positive integers exist which are also an nth power?";
    }
}