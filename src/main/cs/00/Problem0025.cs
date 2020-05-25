using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0025
    {
        public Problem0025()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 2;

            // Solution:
            BigInteger number1 = 1;
            BigInteger number2 = 1;
            BigInteger help;
            do
            {
                help = number2;
                number2 += number1;
                number1 = help;
                result++;
            } while (number2.ToString().Length < 1000);


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(25, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}