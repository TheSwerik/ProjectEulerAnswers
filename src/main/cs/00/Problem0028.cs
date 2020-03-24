using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0028
    {
    public Problem0028()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        long result = 1;

        // Solution:
        var step = 2;
        var num = 1;
        for (var i = 0; i < 500; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                num += step;
                result += num;
            }

            step += 2;
        }


        stopWatch.Stop();
        var elapsedTime = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                          (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                " ms"));
        if (Test.DoBenchmark)
            Benchmark.AddTime(28, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
    }
    }
}