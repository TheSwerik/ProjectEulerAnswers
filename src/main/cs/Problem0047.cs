using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

public class Problem0047
{
    private UInt64[] primes;

    public Problem0047()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        UInt64 result = 0;

        // Solution:
        primes = primeSieveButFast(1000);
        for (UInt64 i = 0;; i++)
        {
            // if (areConsecutive(new UInt64[] {i, i + 1, i + 2, i + 3}))
            // if (areConsecutive(new UInt64[] {i, i + 1}))
            if (areConsecutive(new UInt64[] {i, i + 1, i + 2}))
            {
                result = i;
                break;
            }
        }

        stopWatch.Stop();
        string test = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                          (double.Parse(test.Substring(test.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(test.Substring(test.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(test.Substring(test.IndexOf(".") + 1)) / 10_000 + " ms"));
    }

    private bool areConsecutive(UInt64[] numbers)
    {
        ArrayList foundPrimes = new ArrayList();
        foreach (UInt64 n in numbers)
        {
            UInt64 root = (UInt64) Math.Sqrt(n);
            for (UInt64 i = 0; primes[i] <= root; i++)
            {
                if (foundPrimes.Contains(primes[i])) continue;
                if (n % primes[i] == 0 && primes[i] != n / primes[i] && primes.Contains(n / primes[i]))
                {
                    foundPrimes.Add(primes[i]);
                    foundPrimes.Add(n / primes[i]);
                    goto end_of_loop;
                }
            }

            return false;
            end_of_loop:
            {
            }
        }

        return true;
    }

    private UInt64[] primeSieveButFast(UInt64 range)
    {
        bool[] bools = new bool[range + 1];
        Array.Fill(bools, true);
        double root = Math.Sqrt(range) + 0.5;
        for (UInt64 i = 3; i < root; i += 2)
        {
            if (bools[i])
            {
                for (UInt64 j = i * i; j < range; j += i * 2)
                {
                    bools[j] = false;
                }
            }
        }

        ArrayList primes = new ArrayList();
        primes.Add((UInt64) 2);
        for (UInt64 i = 3; i < range; i += 2)
        {
            if (bools[i])
            {
                primes.Add(i);
            }
        }

        return primes.OfType<UInt64>().ToArray();
    }
}