using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day05
    {
        public static void Solve()
        {
            var input = from line in File.ReadLines("Day05.txt")
                        let bin = Convert.ToInt32(line.Replace("B", "1").Replace("F", "0").Replace("R", "1").Replace("L", "0"), 2)
                        orderby bin
                        select bin;

            var min = input.Min();
            var max = input.Max();

            var part2 = ( (max + 1) * max - (min - 1) * min ) / 2 - input.Sum();

            Console.WriteLine($"Day  5 - Part1: {max}\t\tPart 2: {part2}");
        }
    }
}
