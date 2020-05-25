using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0007
    {
        public Problem0007()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            ulong counter = 4;
            for (ulong i = 11;; i += 2)
            {
                //check if i is prime:
                for (ulong j = 3; j <= (ulong) Math.Sqrt(i); j++)
                    if (i % j == 0)
                        goto end;

                //check if it's the 10001st:
                if (++counter == 10001)
                {
                    result = i;
                    break;
                }

                end:
                {
                }
            }
            //shaved off from 1,5sec to /3ms

            /*
            // Faster:
            ArrayList primes = new ArrayList();
            primes.Add(2);
            outer:
            for (ulong i = 3; primes.Count < 10001; i += 2)
            {
                ulong sqrt = (ulong) Math.Sqrt(i);
                for (int j = 0; j < primes.Count && (ulong) primes[j] <= sqrt; j++)
                {
                    if (i % (ulong) primes[j] == 0)
                    {
                        goto end;
                    }
                }
    
                primes.Add(i);
            }
    
            result = (ulong) primes[primes.Count - 1];
            */

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(7, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}