using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;

namespace Euler.test.cs
{
    public class ProblemBenchmark
    {
        private const int Max = 1000;
        private const int Checks = 25;
        private static readonly ArrayList Skip = new ArrayList {148, 704};
        private static Dictionary<int, ArrayList> _times = null!;

        public ProblemBenchmark()
        {
            _times = new Dictionary<int, ArrayList>();
            // Test every Problem:
            Console.WriteLine("Starting Benchmark...");
            for (var i = 1; i <= Max; i++)
            for (var j = 0; j < Checks + 2; j++)
            {
                ProblemTest.DoBenchmark = j >= 2;
                Console.WriteLine("Checking Problem " + i + "\t Run: " + (j + 1));
                //start Problems:
                var input = i + "";
                var path = "Euler.main.cs.Problem" + new string('0', 4 - input.Length) + input;
                var problem = Type.GetType(path);
                if (problem == null || Skip.Contains(i))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    break;
                }

                Activator.CreateInstance(problem);

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.WriteLine("Benchmark Finished!");
            //Write to Excel:
            WriteToExcel();
        }

        private void WriteToExcel()
        {
            Console.WriteLine("Writing to Excel...");
            using var workbook =
                new XLWorkbook("..\\EulerBenchmark.xlsx");
            var worksheet = workbook.Worksheet(1);
            var index = 3;
            foreach (var cell in worksheet.Row(1).Cells())
                if (cell.GetString().Contains("C#"))
                    index = cell.WorksheetColumn().ColumnNumber();

            worksheet.Column(index).Cell(1).Value = "C#";

            //write Excel
            for (var i = 1; i <= Max; i++)
            {
                if (!_times.ContainsKey(i))
                {
                    worksheet.Column(index).Cell(i + 1).Value = "/";
                    continue;
                }

                var avg = _times[i].Cast<double>().Sum();
                avg /= _times[i].Count;
                worksheet.Column(index).Cell(i + 1).Value = avg;
            }

            workbook.SaveAs("..\\EulerBenchmark.xlsx");

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.WriteLine("Excel file written!");
        }

        public static void AddTime(int number, double timeInMs)
        {
            if (!_times.ContainsKey(number)) _times.Add(number, new ArrayList());

            _times[number].Add(timeInMs);
        }

        private static void ClearCurrentConsoleLine()
        {
            var currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}