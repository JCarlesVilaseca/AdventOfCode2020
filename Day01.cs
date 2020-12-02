using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day01
    {
        public static void Solve()
        {
            var numbers = from line in File.ReadAllLines("Day01.txt")
                          select int.Parse(line);

            var part1 = (from number1 in numbers
                from number2 in numbers
                where number1 + number2 == 2020
                select (number1 * number2).ToString()).First();

            var part2 = (from number1 in numbers
                    from number2 in numbers
                    from number3 in numbers
                    where number1 + number2 + number3 == 2020
                    select (number1 * number2 * number3).ToString()).First();

            Console.WriteLine($"Day  1 - Part1: {part1}\t\tPart 2: {part2}");
        }
    }
}