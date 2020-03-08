using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0056
    {
        public Problem0056()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            BigInteger result = 0;

            // Solution:
            for (int a = 2; a < 100; a++)
            {
                for (int b = 2; b < 100; b++)
                {
                    BigInteger dSum = DigitSum(BigInteger.Pow(a, b));
                    if (dSum > result) result = dSum;
                }
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
                Benchmark.AddTime(56, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private BigInteger DigitSum(BigInteger n)
        {
            BigInteger result = 0;
            string s = n.ToString();
            foreach (char c in s)
            {
                result += c - 48;
            }

            return result;
        }
    }
}