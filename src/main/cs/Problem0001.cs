using System;
using System.Diagnostics;

public class Problem0001
{
    public Problem0001()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        Int64 result = 0;

        // Solution:
        for (int i = 3; i < 1000; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                result += i;
            }
        }

        stopWatch.Stop();
        string test = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                          (double.Parse(test.Substring(test.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(test.Substring(test.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(test.Substring(test.IndexOf(".") + 1)) / 10_000 + " ms"));
    }
}