using System;
using System.Diagnostics;
using System.IO;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._00
{
    public class Problem0099
    {
        public Problem0099()
        {
            var lines = File.ReadAllLines(@"resources\p099_base_exp.txt");
            var numbers = new int[lines.Length, 2];
            for (var i = 0; i < lines.Length; i++)
            {
                numbers[i, 0] = int.Parse(lines[i].Substring(0, lines[i].IndexOf(',')));
                numbers[i, 1] = int.Parse(lines[i].Substring(lines[i].IndexOf(',') + 1));
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var maxIndex = 0;

            var number = numbers[0, 0];
            var exponent = numbers[0, 1];
            for (var i = 1; i < lines.Length; i++)
                if (numbers[i, 1] > exponent)
                {
                    var div = (double) numbers[i, 1] / exponent;
                    if (Math.Pow(numbers[i, 0], div) > number)
                    {
                        maxIndex = i;
                        number = numbers[i, 0];
                        exponent = numbers[i, 1];
                    }
                }
                else
                {
                    var div = (double) exponent / numbers[i, 1];
                    if (Math.Pow(number, div) < numbers[i, 0])
                    {
                        maxIndex = i;
                        number = numbers[i, 0];
                        exponent = numbers[i, 1];
                    }
                }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + ++maxIndex + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(99, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}
