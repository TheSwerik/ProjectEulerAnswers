using System;
using System.Diagnostics;
using System.Numerics;

public class Problem0048
{
    public Problem0048()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        BigInteger result = 0;

        // Solution:
        for (int i = 1; i < 1000; i++)
        {
            result += BigInteger.Pow(i, i);
        }


        stopWatch.Stop();
        string test = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result.ToString().Substring(result.ToString().Length-10) + "\tTime:\t" +
                          (double.Parse(test.Substring(test.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(test.Substring(test.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(test.Substring(test.IndexOf(".") + 1)) / 10_000 + " ms"));
    }
}