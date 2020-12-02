using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day02
    {
        public static void Solve()
        {
            var policies = from line in File.ReadAllLines("Day02.txt")
                           let parts = Regex.Match(line, @"([0-9]*)-([0-9]*) (.): (\w*)")
                           select new {
                               Min = int.Parse(parts.Groups[1].Value),
                               Max = int.Parse(parts.Groups[2].Value),
                               Chr = parts.Groups[3].Value[0],
                               Text = parts.Groups[4].Value
                               };

            var part1 = from policy in policies
                        let count = policy.Text.Count(c => c == policy.Chr)
                        where count >= policy.Min && count <= policy.Max
                        select policy;

            var part2 = from policy in policies
                        let first = policy.Text[policy.Min - 1] == policy.Chr
                        let second = policy.Text[policy.Max - 1] == policy.Chr
                        where first ^ second
                        select policy;

            Console.WriteLine($"Day  2 - Part1: {part1.Count()}\t\tPart 2: {part2.Count()}");
        }
    }
}
