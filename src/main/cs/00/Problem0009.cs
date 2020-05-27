using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0009
    {
        public Problem0009()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            for (var i = 1; i < 500; i++)
            for (var j = i; j < 500; j++)
            for (var k = j; k < 500; k++)
                if (i * i + j * j == k * k && i + j + k == 1000)
                {
                    result = i * j * k;
                    goto end;
                }

            /*
            // Maurice Solution:
            for (int i = 1; i < 500; i++)
            {
                for (int j = i; j < 500; j++)
                {
                    int k = 1000 - i - j;
                    if (i * i + j * j == k * k)
                    {
                        result = i * j * k;
                        goto end;
                    }
                }
            }
            */

            end:
            {
            }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(9, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}