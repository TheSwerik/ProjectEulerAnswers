using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

public class Problem0050
{
    public Problem0050()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        int result = 0;

        // Solution:
        int[] primes = PrimeSieveButFast(1_000_000);
        int maxNumber = 0;
        for (int i = 0; i < primes.Length-1; i++)
        {
            int count = 1;
            int sum = primes[i];
            while (sum < 1_000_000) sum += primes[i + count++];
            sum -= primes[i + count - 1];

            if (primes.Contains(sum) && maxNumber < count)
            {
                maxNumber = count;
                result = sum;
            }
        }


        stopWatch.Stop();
        string test = stopWatch.Elapsed.ToString();
        Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                          (double.Parse(test.Substring(test.LastIndexOf(":") + 1, 2)) >= 1
                              ? double.Parse(test.Substring(test.LastIndexOf(":") + 1)) + " s"
                              : double.Parse(test.Substring(test.IndexOf(".") + 1)) / 10_000 + " ms"));
    }

    private int[] PrimeSieveButFast(int range)
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
        primes.Add( 2);
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