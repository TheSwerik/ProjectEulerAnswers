using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0034
    {
        private readonly int[] _factorials;

        public Problem0034()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            _factorials = new[]
            {
                1, 1, 2, 6,
                Factorial(4),
                Factorial(5),
                Factorial(6),
                Factorial(7),
                Factorial(8),
                Factorial(9)
            };
            List<long> list = new List<long>();
            for (long i = 3; i < 2540161; i++)
                if (GetDigitFactorial(i) == i)
                    list.Add(i);

            foreach (long n in list) result += n;

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(34, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private long GetDigitFactorial(long n)
        {
            string asString = n + "";
            int[] numbers = new int[asString.Length];
            for (int i = 0; i < asString.Length; i++) numbers[i] = asString[i] - 48;

            long result = 0;
            foreach (int number in numbers) result += _factorials[number];

            return result;
        }

        private int Factorial(int n)
        {
            int result = n;
            for (int i = n - 1; i > 1; i--) result *= i;

            return result;
        }
    }
}