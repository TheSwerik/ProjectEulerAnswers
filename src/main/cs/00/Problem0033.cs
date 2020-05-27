using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0033
    {
        public Problem0033()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var counter = 0;
            var numerators = new int[4];
            var denominators = new int[4];
            for (var denominator = 12; denominator < 100; denominator++)
            {
                if (denominator % 10 == 0) continue;
                for (var numerator = 11; numerator < denominator; numerator++)
                {
                    if (numerator % 10 == 0) continue;
                    var numeratorChars = (numerator + "").ToCharArray();
                    var denominatorChars = (denominator + "").ToCharArray();
                    char numeratorC;
                    char denominatorC;
                    if (denominatorChars[0] == numeratorChars[0])
                    {
                        denominatorC = denominatorChars[1];
                        numeratorC = numeratorChars[1];
                    }
                    else if (denominatorChars[1] == numeratorChars[0])
                    {
                        denominatorC = denominatorChars[0];
                        numeratorC = numeratorChars[1];
                    }
                    else if (denominatorChars[0] == numeratorChars[1])
                    {
                        denominatorC = denominatorChars[1];
                        numeratorC = numeratorChars[0];
                    }
                    else if (denominatorChars[1] == numeratorChars[1])
                    {
                        denominatorC = denominatorChars[0];
                        numeratorC = numeratorChars[0];
                    }
                    else
                    {
                        continue;
                    }

                    var fractal = (double) numerator / denominator;
                    if (fractal == (double) (numeratorC - 48) / (denominatorC - 48))
                    {
                        numerators[counter] = numeratorC - 48;
                        denominators[counter++] = denominatorC - 48;
                    }
                }
            }

            result = getLowestDenominatorProduct(numerators, denominators);

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    33, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private long getLowestDenominatorProduct(int[] numerators, int[] denominators)
        {
            var num = 0;
            var denom = 0;
            for (var i = 0; i < numerators.Length; i++)
            {
                for (var j = 2; j < denominators[i]; j++)
                    if (numerators[i] % j == 0 && denominators[i] % j == 0)
                    {
                        numerators[i] /= j;
                        denominators[i] /= j;
                        j = 1;
                    }

                if (i == 0)
                {
                    denom = denominators[i];
                    num = numerators[i];
                }
                else
                {
                    denom *= denominators[i];
                    num *= numerators[i];
                }
            }

            return getLowestDenominatorProduct(num, denom);
        }

        private long getLowestDenominatorProduct(int numerator, int denominator)
        {
            for (var j = 2; j < denominator; j++)
                if (numerator % j == 0 && denominator % j == 0)
                {
                    numerator /= j;
                    denominator /= j;
                    j = 1;
                }

            return denominator;
        }
    }
}