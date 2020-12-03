using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day03
    {
        public static void Solve()
        {
            var lines = from line in File.ReadLines("Day03.txt")
                        select line;

            var slope31 = Trees(lines, 3, 1);

            var slope11 = Trees(lines, 1, 1);
            var slope51 = Trees(lines, 5, 1);
            var slope71 = Trees(lines, 7, 1);
            var slope12 = Trees(lines, 1, 2);

            var part1 = slope31;
            var part2 = slope11 * slope31 * slope51 * slope71 * slope12;

            Console.WriteLine($"Day  2 - Part1: {part1}\t\tPart 2: {part2}");
        }

        private static int Trees(IEnumerable<string> lines, int right, int down)
        {
            var found = from line in lines
                            .Skip(down)
                            .Select((map, row) => new { map, row })
                        where line.row % down == 0
                        let pos = ((line.row/down + 1) * right) % line.map.Length
                        let map = line.map[pos]
                        where map == '#'
                        select line;
            
            return found.Count();
        }
    }
}
