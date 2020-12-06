using System;
using System.Diagnostics;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            Day01.Solve();
            Day02.Solve();
            Day03.Solve();
            Day04.Solve();
            Day05.Solve();
            Day06.Solve();

            var elapsed = stopwatch.Elapsed;

            Console.WriteLine($"\nTime: {elapsed}");
        }
    }
}
