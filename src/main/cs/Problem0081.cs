using System;
using System.Diagnostics;
using System.IO;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0081
    {
        public Problem0081()
        {
            string[] lines =
                File.ReadAllLines(
                    "G:\\Programme\\IntelliJ Projects\\ProjectEulerAnswers\\src\\main\\resources\\p081_matrix.txt");
            int[,] matrix = new int[lines.Length, lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split(',');
                for (int j = 0; j < numbers.Length; j++)
                {
                    matrix[i, j] = int.Parse(numbers[j]);
                }
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            int gridSize = matrix.GetLength(0);
            for (int i = gridSize - 2; i >= 0; i--)
            {
                matrix[gridSize - 1, i] += matrix[gridSize - 1, i + 1];
                matrix[i, gridSize - 1] += matrix[i + 1, gridSize - 1];
            }

            for (int i = gridSize - 2; i >= 0; i--)
            {
                for (int j = gridSize - 2; j >= 0; j--)
                {
                    matrix[i, j] += Math.Min(matrix[i + 1, j], matrix[i, j + 1]);
                }
            }

            result = matrix[0, 0];


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(81, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}