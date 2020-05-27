using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0055
    {
        public Problem0055()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            for (ulong i = 1; i < 10_000; i++)
            {
                BigInteger n = i;
                for (var j = 0; j < 50; j++)
                    if (IsPalindrome(n += Rev(n)))
                        goto end;

                result++;

                end:
                {
                }
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    55, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private BigInteger Rev(BigInteger n)
        {
            var arr = (n + "").ToCharArray();
            Array.Reverse(arr);
            return BigInteger.Parse(new string(arr));
        }

        private bool IsPalindrome(BigInteger n)
        {
            var s = n.ToString();
            for (var i = 0; i < s.Length / 2; i++)
                if (s[i] != s[s.Length - i - 1])
                    return false;

            return true;
        }
    }
}