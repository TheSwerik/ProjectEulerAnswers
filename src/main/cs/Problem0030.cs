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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            HashSet<long> numbers = new HashSet<long>();
            for (int i = 0; i < 10; i++)
            {
                long a = (long) Math.Pow(i, 5);
                for (int j = 0; j < 10; j++)
                {
                    long b = (long) Math.Pow(j, 5);
                    for (int k = 0; k < 10; k++)
                    {
                        long c = (long) Math.Pow(k, 5);
                        for (int l = 0; l < 10; l++)
                        {
                            long d = (long) Math.Pow(l, 5);
                            String testString = i + "" + j + "" + k + "" + l;
                            long testNumber = a + b + c + d;

                            if ((testNumber + "").Equals(testString))
                            {
                                numbers.Add(testNumber);
                            }

                            for (int m = 0; m < 10; m++)
                            {
                                long e = (long) Math.Pow(m, 5);
                                testString = i + "" + j + "" + k + "" + l + "" + m;
                                testNumber = a + b + c + d + e;

                                if ((testNumber + "").Equals(testString)) numbers.Add(testNumber);

                                for (int n = 0; n < 10; n++)
                                {
                                    long f = (long) Math.Pow(n, 5);
                                    testString = i + "" + j + "" + k + "" + l + "" + m + "" + n;
                                    testNumber = a + b + c + d + e + f;

                                    if ((testNumber + "").Equals(testString)) numbers.Add(testNumber);
                                }
                            }
                        }
                    }
                }
            }

            foreach (long l in numbers)
            {
                result += l;
            }


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(30, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}