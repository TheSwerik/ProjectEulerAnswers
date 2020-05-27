using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0089
    {
        public Problem0089()
        {
            var lines = File.ReadAllLines(@"resources\p089_roman.txt");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var roman = CreateRomanDict();
            var values = CalcValues(lines, roman);
            var cleanRoman = ConvertToRoman(values, roman);

            //calcMax:
            long max = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                max += lines[i].Length;
                result += cleanRoman[i].Length;
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + (max - result) + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    89, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private string[] ConvertToRoman(long[] values, Dictionary<char, long> roman)
        {
            var result = new string[values.Length];

            for (var i = 0; i < values.Length; i++)
            for (var j = 0; j < roman.Count; j++)
            {
                while (values[i] >= roman.ElementAt(j).Value)
                {
                    values[i] -= roman.ElementAt(j).Value;
                    result[i] += roman.ElementAt(j).Key;
                }

                var subtractChar = '#';
                if (j < 6) subtractChar = roman.Keys.ElementAt(j % 2 == 1 ? j + 1 : j + 2);
                if (subtractChar != '#' && values[i] >= roman.ElementAt(j).Value - roman[subtractChar])
                {
                    values[i] -= roman.ElementAt(j).Value - roman[subtractChar];
                    result[i] += subtractChar + "" + roman.Keys.ElementAt(j);
                }
            }

            return result;
        }

        private Dictionary<char, long> CreateRomanDict()
        {
            var roman = new Dictionary<char, long>();
            roman.Add('M', 1000);
            roman.Add('D', 500);
            roman.Add('C', 100);
            roman.Add('L', 50);
            roman.Add('X', 10);
            roman.Add('V', 5);
            roman.Add('I', 1);
            return roman;
        }

        private long[] CalcValues(string[] lines, Dictionary<char, long> roman)
        {
            var values = new long[lines.Length];
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < roman.Count; j++)
                {
                    var currentChar = roman.Keys.ElementAt(j);
                    if (line.Contains(currentChar))
                    {
                        var subtractChar = '#';
                        if (j < 6) subtractChar = roman.Keys.ElementAt(j % 2 == 1 ? j + 1 : j + 2);
                        var part = line.Substring(0, line.LastIndexOf(currentChar) + 1);
                        if (part.Contains(subtractChar))
                        {
                            values[i] -= roman[subtractChar];
                            part = part.Substring(0, part.IndexOf(subtractChar)) +
                                   part.Substring(part.IndexOf(subtractChar) + 1);
                            line = line.Substring(0, line.IndexOf(subtractChar)) +
                                   line.Substring(line.IndexOf(subtractChar) + 1);
                        }

                        values[i] += part.Length * roman[currentChar];
                        line = line.Substring(part.Length);
                    }
                }
            }

            return values;
        }
    }
}