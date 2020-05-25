using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0004
    {
    public Problem0004()
    {
        ulong biggestFactor = 9999;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        ulong result = 0;

        // Solution:
        for (var i = biggestFactor * biggestFactor; i > 0; i--)
        {
            var test = (i + "").ToCharArray();
            for (ulong j = 0; j < (ulong) (test.Length / 2); j++)
                if (test[j] != test[(ulong) test.Length - j - 1])
                    goto outer;

            result = i;
            //check if multiple of 3-digit numbers:
            for (var j = biggestFactor; j > Math.Sqrt(result); j--)
                if (result % j == 0)
                    goto end;
            outer:
            {
            }
        }

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
            Benchmark.AddTime(4, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
    }
    }
}