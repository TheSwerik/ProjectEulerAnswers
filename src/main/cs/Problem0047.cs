using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

public class Problem0047
{
    private ulong[] primes;

    public Problem0047()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        ulong result = 0;

        // Solution:
        primes = primeSieveButFast(150_000);
        for (ulong i = 20;; i++)
        {
            if (primes.Contains(i)) continue;
            if (numberOfPrimFactors(new ulong[] {i, i + 1, i + 2, i + 3}))
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

    private bool numberOfPrimFactors(ulong[] numbers)
    {
        for (int j = 0; j < numbers.Length; j++)
        {
            int count = 0;
            ulong n = numbers[j];
            for (ulong i = 0; primes[i] <= n; i++)
            {
                if (n % primes[i] == 0)
                {
                    count++;
                }

                while (n % primes[i] == 0)
                {
                    n /= primes[i];
                }
            }

            if (count != 4)
            {
                return false;
            }
        }

        return true;
    }

    private ulong[] primeSieveButFast(ulong range)
    {
        bool[] bools = new bool[range + 1];
        Array.Fill(bools, true);
        double root = Math.Sqrt(range) + 0.5;
        for (ulong i = 3; i < root; i += 2)
        {
            if (bools[i])
            {
                for (ulong j = i * i; j < range; j += i * 2)
                {
                    bools[j] = false;
                }
            }
        }

        ArrayList primes = new ArrayList();
        primes.Add((ulong) 2);
        for (ulong i = 3; i < range; i += 2)
        {
            if (bools[i])
            {
                primes.Add(i);
            }
        }

        return primes.OfType<ulong>().ToArray();
    }
}