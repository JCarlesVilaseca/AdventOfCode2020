using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day01
    {
        private static IEnumerable<int> ParsedInput()
        {
            return
                from line in File.ReadAllLines("Day01.txt")
                select int.Parse(line);
        }

        public static string Part1()
        {
            var numbers = ParsedInput();

            return (from number1 in numbers
                from number2 in numbers
                where number1 + number2 == 2020
                select (number1 * number2).ToString()).First();
        }

        public static string Part2()
        {
            var numbers = ParsedInput();

            return (from number1 in numbers
                    from number2 in numbers
                    from number3 in numbers
                    where number1 + number2 + number3 == 2020
                    select (number1 * number2 * number3).ToString()).First();
        }
    }
}
