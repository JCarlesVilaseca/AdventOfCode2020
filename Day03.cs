using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day03
    {
        public static void Solve()
        {
            var input = from line in File.ReadAllLines("Day03.txt")
                           select line;

            var length = input.ElementAt(0).Length;

            Console.WriteLine("Lentgh=" + length);

            var full = string.Join("", input);

            var part1 = from line in full.Select((chr, pos) => new {  chr, pos })
                        
                        where ((line.pos +1 ) % (length + 3)) == 0 && line.chr == '#'
                        select line;
            /*
            var part2 = from policy in policies
                        let first = policy.Text[policy.Min - 1] == policy.Chr
                        let second = policy.Text[policy.Max - 1] == policy.Chr
                        where first ^ second
                        select policy;
            */

            part1.ToList().ForEach(x =>
            {

                Console.WriteLine(x);
            });

            Console.WriteLine($"Day  2 - Part1: {part1.Count()}\t\tPart 2: {0}");
        }
    }
}
