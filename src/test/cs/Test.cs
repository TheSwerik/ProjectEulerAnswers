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
                new ProblemBenchmark();
                return;
            }

            if (args.Length == 1) Start(args[0]);
            if (args.Length > 1)
            {
                if (args[0][0] == 'c') StartCpp(args[1]);
                else if (args[0][0] == 'p') StartPython(args[1]);
                else Console.WriteLine("Wrong Argument. Valid Arguments are \"\", \"Cpp\", \"python\"");
            }

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

        private static void StartPython(string input)
        {
            var start = new ProcessStartInfo
                        {
                            FileName = "python",
                            Arguments = Environment.CurrentDirectory +
                                        $@"\python\Problem{new string('0', 4 - input.Length) + input}.py",
                            UseShellExecute = false,
                            RedirectStandardOutput = true
                        };
            var watch = new Stopwatch();
            watch.Start();
            using var process = Process.Start(start);
            using var reader = process.StandardOutput;
            var solution = reader.ReadToEnd();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }

        private static void StartCpp(string input)
        {
            var start = new ProcessStartInfo
                        {
                            FileName = Environment.CurrentDirectory +
                                       $@"\cpp\Problem{new string('0', 4 - input.Length) + input}.exe",
                            UseShellExecute = false,
                            RedirectStandardOutput = true
                        };
            using var process = Process.Start(start);
            using var reader = process.StandardOutput;
            var solution = reader.ReadToEnd();
            Console.WriteLine(solution);
        }
    }
}