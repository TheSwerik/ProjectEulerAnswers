using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0045
    {
        public Problem0045()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            for (var i = 144;; i++)
            {
                long h = i * (2 * i - 2);

                long p = 0;
                for (long j = 165; p != h; j++)
                {
                    p = j / 2 * (3 * j + 1);
                    if (p > h) goto end;
                }

                long t = 0;
                for (long j = 285; t != h; j++)
                {
                    t = j / 2 * (j + 1);
                    if (t > h) goto end;
                }

                result = t;
                break;

                end:
                {
                }
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    45, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}