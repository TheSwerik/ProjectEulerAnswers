using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0039
    {
    public Problem0039()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        long result = 0;

        // Solution:
        var maxSolutions = 0;
        for (var i = 1000; i > 2; i--)
        {
            var solutions = numberOfSolutions(i);
            if (solutions > maxSolutions)
            {
                maxSolutions = solutions;
                result = i;
            }
        }


        stopWatch.Stop();
        var elapsedTime = stopWatch.Elapsed.ToString();
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
        var result = 0;

        for (var c = n / 2; c > 2; c--)
        for (var b = c; b > 1; b--)
        {
            var a = Math.Sqrt(c * c - b * b);
            if (a + b + c == n) result++;
        }

        return result;
    }
    }
}