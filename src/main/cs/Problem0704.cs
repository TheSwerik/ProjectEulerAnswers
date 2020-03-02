using System;
using System.Diagnostics;

public class Problem0704
{
    public Problem0704()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        UInt64 result = 0;

        // Solution:
        UInt64 max = 10000000;
        int lastPercent = 0;
        for (UInt64 n = 1; n <= max; n++)
        {
            double percent = (double) n / max * 100;
            if (percent * 100 > lastPercent)
            {
                System.Console.Write("\r" + (percent).ToString("0.##") + "%");
                lastPercent = (int) (percent * 100);
            }

            result += f(n);
        }

        stopWatch.Stop();
        string test = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                          (double.Parse(test.Substring(test.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(test.Substring(test.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(test.Substring(test.IndexOf(".") + 1)) / 10_000 + " ms"));
    }

    private UInt64 f(UInt64 n)
    {
        UInt64 result = 0;
        for (UInt64 m = 0; m <= n; m++)
        {
            UInt64 g = this.g(n, m);
            if (g > result)
            {
                result = g;
            }
        }

        return result;
    }

    private UInt64 g(UInt64 n, UInt64 m)
    {
        // n over m
        n = fac(n, n - m) / fac(m);

        // find biggest potenz of 2
        UInt64 max = 0;
        UInt64 j = 1;
        for (UInt64 i = 0; j < n; i++, j = j * 2)
        {
            if (n % j != 0)
            {
                return max;
            }

            max = i;
        }

        return max;
    }

    private UInt64 fac(UInt64 n)
    {
        if (n == 0) return 1;
        for (UInt64 i = n - 1; i > 1; i--)
        {
            n = n * i;
        }

        return n > 0 ? n : 1;
    }

    private UInt64 fac(UInt64 n, UInt64 m)
    {
        if (n == 0) return 1;
        for (UInt64 i = n - 1; i > m; i--)
        {
            n = n * i;
        }

        return n > 0 ? n : 1;
    }
}