﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0029
    {
        public Problem0029()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            HashSet<BigInteger> set = new HashSet<BigInteger>();
            for (int i = 2; i <= 100; i++)
            for (int j = 2; j <= 100; j++)
                set.Add(BigInteger.Pow(j, i));

            result = set.Count;


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(29, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}