using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0002
    {
    public Problem0002()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        ulong result = 0;

        // Solution:
        ulong fibo1 = 1;
        ulong fibo2 = 1;
        while (fibo2 < 4000000)
            if ((fibo1 = fibo2 + (fibo2 = fibo1)) % 2 == 0)
                result += fibo1;


        stopWatch.Stop();
        var elapsedTime = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                          (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                " ms"));
        if (Test.DoBenchmark)
            Benchmark.AddTime(2, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
    }
    }
}