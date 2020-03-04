using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

public class Problem0049
{
    private int[] _primes;

    public Problem0049()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        string result = "";

        // Solution:
        GenPrimes();
        foreach (int j in _primes)
        {
            for (int i = 45;; i++)
            {
                if (i == 3330 && j == 1487) continue;
                int b = j + i;
                int c = b + i;
                if (c > 9999) break;
                if (ArePermutes(j, b, c) && ArePrimes(j, b, c))
                {
                    result = "" + j + b + c;
                    goto end;
                }
            }
        }

        end:
        stopWatch.Stop();
        string test = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                          (double.Parse(test.Substring(test.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(test.Substring(test.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(test.Substring(test.IndexOf(".") + 1)) / 10_000 + " ms"));
    }

    private bool ArePrimes(int a, int b, int c)
    {
        return _primes.Contains(a) && _primes.Contains(b) && _primes.Contains(c);
    }

    private bool ArePermutes(int a, int b, int c)
    {
        string aS = a + "";
        char[] bS = (b + "").ToCharArray();
        char[] cS = (c + "").ToCharArray();
        char[] digits = aS.ToCharArray();

        bool[] bIndices = new bool[4];
        bool[] cIndices = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bIndices[j]) continue;
                if (digits[i] == bS[j])
                {
                    bIndices[j] = true;
                    break;
                }
            }

            for (int j = 0; j < 4; j++)
            {
                if (cIndices[j]) continue;
                if (digits[i] == cS[j])
                {
                    cIndices[j] = true;
                    break;
                }
            }
        }

        return !(bIndices.Contains(false) || cIndices.Contains(false));
    }

    private void GenPrimes()
    {
        ulong[] allPrimes = PrimeSieveButFast(10_000);
        _primes = new int[0];
        int i = 0;
        for (; i < allPrimes.Length; i++)
        {
            if (allPrimes[i] >= 1000)
            {
                _primes = new int[allPrimes.Length - i];
                break;
            }
        }

        for (int j = 0; j < _primes.Length; j++, i++)
        {
            _primes[j] = (int) allPrimes[i];
        }
    }

    private ulong[] PrimeSieveButFast(ulong range)
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