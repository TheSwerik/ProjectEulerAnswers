using System;
using System.Net.Mime;
using System.Threading;
using Microsoft.VisualBasic;

namespace Euler.test.cs
{
    public class Test
    {
        public const bool DoBenchmark = true;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            if (DoBenchmark)
            {
                Benchmark benchmark = new Benchmark();
                return;
            }
            if (args.Length > 0)
            {
                //start Problem:
                string path = "Problem" + args[0];
                Type problem = Type.GetType(path);
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
            else
            {
                while (true)
                {
                    Console.WriteLine("\nWhich do you want to try out?");
                    string input = Console.ReadLine();
                    if (input.Equals("0"))
                    {
                        return;
                    }

                    //start Problems:
                    string path = "Problem" + new string('0', 4 - input.Length) + input;
                    Type problem = Type.GetType(path);
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
    }
}