using System;
using System.Diagnostics;
using System.IO;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0099
    {
        public Problem0099()
        {
            string[] lines =
                File.ReadAllLines(
                    "C:\\Users\\seibel\\IdeaProjects\\Privat\\Euler\\src\\main\\resources\\p099_base_exp.txt");
            int[,] numbers = new int[lines.Length, 2];
            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i, 0] = int.Parse(lines[i].Substring(0, lines[i].IndexOf(',')));
                numbers[i, 1] = int.Parse(lines[i].Substring(lines[i].IndexOf(',') + 1));
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int maxIndex = 0;

            Solution:
            int number = numbers[0, 0];
            int exponent = numbers[0, 1];
            for (int i = 1; i < lines.Length; i++)
            {
                if (numbers[i, 1] > exponent)
                {
                    double div = ((double) numbers[i, 1]) / exponent;
                    if (Math.Pow(numbers[i, 0], div) > number)
                    {
                        maxIndex = i;
                        number = numbers[i, 0];
                        exponent = numbers[i, 1];
                    }
                }
                else
                {
                    double div = ((double) exponent) / numbers[i, 1];
                    if (Math.Pow(number, div) < numbers[i, 0])
                    {
                        maxIndex = i;
                        number = numbers[i, 0];
                        exponent = numbers[i, 1];
                    }
                }
            }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + ++maxIndex + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(99, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}