using System;
using System.Diagnostics;
using System.Collections;
using System.Linq;

public class Problem0046
{
    private int[] primes;

    public Problem0046()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        UInt64 result = 0;

        // Solution:
        primes = primeSieveButFast(10_000);
        // System.Console.WriteLine(primes.Length + " Primes generated.");

        for (UInt64 i = 9;; i += 2)
        {
            // if (isComposite(i))
            // {
            //     if (isGoldbach(i))
            //     {
            //         System.Console.WriteLine(i);
            //     }
            //     else
            //     {
            //         result = i;
            //         break;
            //     }
            //
            //     if (!isGoldbach(i))
            //     {
            //     }
            // }

            if (isComposite(i) && !isGoldbach(i))
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

    private bool isGoldbach(UInt64 n)
    {
        for (int i = 0; i < primes.Length; i++)
        {
            int p = primes[i];
            if (p > (int) n - 2)
            {
                break;
            }

            for (int j = 1;; j++)
            {
                UInt64 func = (UInt64) (p + 2 * (j * j));
                if (n == func)
                {
                    return true;
                }
                else if (n < func)
                {
                    break;
                }
            }
        }

        return false;
    }

    private bool isComposite(UInt64 n)
    {
        UInt64 max = (UInt64) Math.Sqrt(n);
        for (UInt64 divisor = 2; divisor <= max; divisor++)
        {
            if (n % divisor == 0)
            {
                return true;
            }
        }

        return false;
    }

    public static int[] primeSieveButFast(int range)
    {
        bool[] bools = new bool[range + 1];
        Array.Fill(bools, true);
        double root = Math.Sqrt(range) + 0.5;
        for (int i = 3; i < root; i += 2)
        {
            if (bools[i])
            {
                for (int j = i * i; j < range; j += i * 2)
                {
                    bools[j] = false;
                }
            }
        }

        ArrayList primes = new ArrayList();
        primes.Add(2);
        for (int i = 3; i < range; i += 2)
        {
            if (bools[i])
            {
                primes.Add(i);
            }
        }

        return primes.OfType<int>().ToArray();
    }
}