using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Field { public string Name { get; set; } public Func<string, bool> Valid { get; set; }}

    public class Day04
    {

        public static void Solve()
        {
            var validations = new[] {
                new Field {Name = "byr", Valid = x => int.Parse(x) >= 1920 && int.Parse(x) <= 2002  },
                new Field {Name = "iyr", Valid = x => int.Parse(x) >= 2010 && int.Parse(x) <= 2020  },
                new Field {Name = "eyr", Valid = x => int.Parse(x) >= 2020 && int.Parse(x) <= 2030  },
                new Field {Name = "hgt", Valid = x => {
                    var parsed = Regex.Match(x,"^(\\d*)(cm|in)$");
                    if (!parsed.Success) return false;
                    var value = int.Parse(parsed.Groups[1].Value);

                    switch (parsed.Groups[2].Value)
                    {
                        case "cm": return value >= 150 && value <= 193;
                        case "in": return value >= 59 && value <= 76;
                    }
                    return false;
                }   },
                new Field {Name = "hcl", Valid = x => Regex.IsMatch(x,"^#[0-9a-f]{6}$") },
                new Field {Name = "ecl", Valid = x => Regex.IsMatch(x,"^(amb|blu|brn|gry|grn|hzl|oth){1}$")   },
                new Field {Name = "pid", Valid = x => Regex.IsMatch(x,"^\\d{9}$")   } };


            var parsed = from line in File.ReadAllText("Day04.txt").Split("\n\n").Select(p => p.Replace("\n", " "))
                         let groups = line.Split(' ').Select(part => Regex.Match(part, "(\\w*):(.*)"))
                         select groups.Select(g => new { field = g.Groups[1].Value, value = g.Groups[2].Value });

            var part1 = from p in parsed
                       where validations.All(validation => p.Any(x => x.field == validation.Name))
                       select p;

            var part2 = from p in part1
                        where p.All(x =>
                        {
                            var validation = validations.FirstOrDefault(v => v.Name == x.field);

                            return validation != null ? validation.Valid(x.value) : true;
                        })
                        select p;

            Console.WriteLine($"Day  4 - Part1: {part1.Count()}\t\tPart 2: {part2.Count()}");
        }
    }
}
