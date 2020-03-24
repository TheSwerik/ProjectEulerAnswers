using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0030
    {
    public Problem0030()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        long result = 0;

        // Solution:
        var numbers = new HashSet<long>();
        for (var i = 0; i < 10; i++)
        {
            var a = (long) Math.Pow(i, 5);
            for (var j = 0; j < 10; j++)
            {
                var b = (long) Math.Pow(j, 5);
                for (var k = 0; k < 10; k++)
                {
                    var c = (long) Math.Pow(k, 5);
                    for (var l = 0; l < 10; l++)
                    {
                        var d = (long) Math.Pow(l, 5);
                        var testString = i + "" + j + "" + k + "" + l;
                        var testNumber = a + b + c + d;

                        if ((testNumber + "").Equals(testString)) numbers.Add(testNumber);

                        for (var m = 0; m < 10; m++)
                        {
                            var e = (long) Math.Pow(m, 5);
                            testString = i + "" + j + "" + k + "" + l + "" + m;
                            testNumber = a + b + c + d + e;

                            if ((testNumber + "").Equals(testString)) numbers.Add(testNumber);

                            for (var n = 0; n < 10; n++)
                            {
                                var f = (long) Math.Pow(n, 5);
                                testString = i + "" + j + "" + k + "" + l + "" + m + "" + n;
                                testNumber = a + b + c + d + e + f;

                                if ((testNumber + "").Equals(testString)) numbers.Add(testNumber);
                            }
                        }
                    }
                }
            }
        }

        foreach (var l in numbers) result += l;


        stopWatch.Stop();
        var elapsedTime = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                          (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                " ms"));
        if (Test.DoBenchmark)
            Benchmark.AddTime(30, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
    }
    }
}