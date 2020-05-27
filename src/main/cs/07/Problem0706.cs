using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs._07
{
    public class Problem0706
    {
        public Problem0706()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            BigInteger result = 0;

            // Solution:
            result = BigF(100_001) % 1_000_000_007;

            Console.WriteLine(
                (3 * 1150500 / 2267
                 + BigInteger.Parse("9" + new string('0', 99999)))
                * 2267 / 6750 % 1_000_000_007
            );


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    706, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private BigInteger f(string n)
        {
            BigInteger counter = 0;
            for (var i = 0; i < n.Length; i++)
            for (var j = 1; j <= n.Length - i; j++)
            {
                var sub = n.Substring(i, j);
                BigInteger sum = 0;
                foreach (var c in sub) sum += c - 48;

                if (sum % 3 == 0) counter++;
            }

            return counter;
        }

        private BigInteger BigF(int digits)
        {
            if ((digits + 1) % 3 == 0) return BigInteger.Parse('3' + new string('0', digits - 1));
            BigInteger result = 0;

            // Solution:
            var min = BigInteger.Parse("1" + new string('0', digits - 1));
            var max = BigInteger.Parse("1" + new string('0', digits));
            Console.WriteLine("Generated min & max.");
            for (var i = min; i < max; i++)
                if (f(i + "") % 3 == 0)
                    result++;
            // System.Console.WriteLine(i);

            return result;
        }
    }
}