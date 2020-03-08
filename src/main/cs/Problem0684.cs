using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Emit;
using DocumentFormat.OpenXml.Spreadsheet;
using Euler.test.cs;
using Microsoft.VisualBasic;

namespace Euler.main.cs
{
    public class Problem0684
    {
        private long mod = 1_000_000_007;

        public Problem0684()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            ulong[] fibo = Fibo(90);
            for (int k = 2; k <= 90; k++)
            {
                result += ModS(fibo[k]);
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

        private long ModS(ulong k)
        {
            int n = (int) (k / 9);
            BigInteger sum = Mod(2 * (BigInteger.ModPow(2, n, mod) * BigInteger.ModPow(5, n + 2, mod) - 7) - 9 * n);

            for (ulong r = k % 9 + 2; r <= 9; r++)
            {
                sum -= Mod(r * BigInteger.ModPow(10, n, mod) - 1);
            }

            return (long) Mod(sum);
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
                result[i] = b % (ulong) mod;
            }

            return result;
        }

        private BigInteger Mod(BigInteger n)
        {
            BigInteger nMod = n % mod;
            return nMod >= 0 ? nMod : nMod + mod;
        }
    }
}