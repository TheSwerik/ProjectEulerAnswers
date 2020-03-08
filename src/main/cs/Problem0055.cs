using System;
using System.Collections;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0055
    {
        public Problem0055()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            for (ulong i = 1; i < 10_000; i++)
            {
                BigInteger n = i;
                for (int j = 0; j < 50; j++)
                {
                    if (IsPalindrome(n += Rev(n))) goto end;
                }

                result++;

                end:
                {
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
                Benchmark.AddTime(55, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private BigInteger Rev(BigInteger n)
        {
            char[] arr = (n + "").ToCharArray();
            Array.Reverse(arr);
            return BigInteger.Parse(new string(arr));
        }

        private bool IsPalindrome(BigInteger n)
        {
            string s = n.ToString();
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1]) return false;
            }

            return true;
        }
    }
}