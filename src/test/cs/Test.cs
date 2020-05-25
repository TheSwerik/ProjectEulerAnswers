using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace Euler.test.cs
{
    public static class ProblemTest
    {
        private const bool Release = false;
        public static bool DoBenchmark = false;

        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            if (DoBenchmark)
            {
                new Benchmark();
                return;
            }

            if (args.Length > 0) Start(args[0]);
            while (args.Length == 0)
            {
                Console.WriteLine("\nWhich do you want to try out?");
                var input = Console.ReadLine();
                if (input.Equals("0")) return;
                Start(input);
            }
        }

        private static void Start(string input)
        {
            var path = "Euler.main.cs._0" + (input.Length < 3 ? '0' : input[0]) + ".Problem" +
                       new string('0', 4 - input.Length) + input;
            var problem = Type.GetType(path);
            if (problem == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot find the Class: " + path);
                Console.ResetColor();
            }
            else
            {
                Activator.CreateInstance(problem);
            }
        }
    }
}