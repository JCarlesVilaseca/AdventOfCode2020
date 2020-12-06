using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day06
    {
        public static void Solve()
        {
            var input = from line in File.ReadAllText("Day06.txt").Split("\n\n")
                        select line;

            var part1 = from groups in input.Select(p => p.Replace("\n", ""))
                        let answers = groups.OrderBy(x => x).GroupBy(x => x)
                        select answers.Count();

            var part2 = from groups in input
                        let common = groups.Split('\n').Aggregate((prev, it) => string.Concat(it.Intersect(prev)))
                        select common.Length;

            part2.ToList().ForEach(Console.WriteLine);

            Console.WriteLine($"Day  6 - Part1: {part1.Sum()}\t\tPart 2: {part2.Sum()}");
        }
    }
}
