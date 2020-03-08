using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0057
    {
        public Problem0057()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 1;

            // Solution:
            BigInteger n = 1393;
            BigInteger d = 985;
            for (int i = 8; i <= 1000; i++)
            {
                BigInteger temp = d;
                d += n;
                n = d + temp;

                if (n.ToString().Length > d.ToString().Length) result++;
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
                Benchmark.AddTime(57, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private decimal FractionLoop(int iteration)
        {
            if (iteration == 1) return 2.5m;
            return 2 + 1 / FractionLoop(iteration - 1);
        }
    }
}