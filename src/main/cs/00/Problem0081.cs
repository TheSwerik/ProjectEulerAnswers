using System;
using System.Diagnostics;
using System.IO;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0081
    {
        public Problem0081()
        {
            var lines = File.ReadAllLines(@"resources\p081_matrix.txt");
            var matrix = new int[lines.Length, lines.Length];
            for (var i = 0; i < lines.Length; i++)
            {
                var numbers = lines[i].Split(',');
                for (var j = 0; j < numbers.Length; j++) matrix[i, j] = int.Parse(numbers[j]);
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var gridSize = matrix.GetLength(0);
            for (var i = gridSize - 2; i >= 0; i--)
            {
                matrix[gridSize - 1, i] += matrix[gridSize - 1, i + 1];
                matrix[i, gridSize - 1] += matrix[i + 1, gridSize - 1];
            }

            for (var i = gridSize - 2; i >= 0; i--)
            for (var j = gridSize - 2; j >= 0; j--)
                matrix[i, j] += Math.Min(matrix[i + 1, j], matrix[i, j + 1]);

            result = matrix[0, 0];


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(81, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}