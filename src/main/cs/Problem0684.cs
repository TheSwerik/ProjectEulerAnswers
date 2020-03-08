using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;
using Microsoft.VisualBasic;

namespace Euler.main.cs
{
    public class Problem0684
    {
        private ulong mod = 1_000_000_007;

        public Problem0684()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            ulong[] fibo = Fibo(90);
            for (int i = fibo.Length-1; i > 1; i--)
            {
                System.Console.WriteLine(i);
                result += DigitSum(fibo[i]);
                result %= mod;
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
                Benchmark.AddTime(684, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private ulong DigitSum(ulong n)
        {
            if (n < 10) return n;
            string nines = "";
            ulong max = n / 9;
            for (ulong i = 0; i < max; i++)
            {
                nines += '9';
            }

            return (ulong) (BigInteger.Parse((n % 9) + nines) % mod);
        }

        private ulong[] Fibo(ulong n)
        {
            n++;
            ulong[] result = new ulong[n];
            result[0] = 0;
            ulong a = result[1] = 1;
            ulong b = result[2] = 1;
            for (ulong i = 3; i < n; i++)
            {
                ulong help = b;
                b += a;
                a = help;
                result[i] = b % mod;
            }

            return result;
        }
    }
}