using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day08
    {
        public static void Solve()
        {
            var input = from line in File.ReadLines("Day08.txt")
                        let op = Regex.Match(line, "^(\\w+) ((\\+|\\-)\\d+)$")
                        select new Instruction
                        {
                            Operation = op.Groups[1].Value,
                            Argument = int.Parse(op.Groups[2].Value)
                        };

            var part1 = SolvePart1(input);
            var part2 = SolvePart2(input);

            Console.WriteLine($"Day  8 - Part1: {part1}\t\tPart 2: {part2}");
        }

        private static int SolvePart1(IEnumerable<Instruction> input)
        {
            var machine = new Machine { Program = input.ToArray() };

            try
            {
                machine.Run();
            }
            catch(InfiniteLoopException)
            {
                return machine.Accumulator;
            }
            throw new ArgumentException("Program doesn't loop infinitely");
        }

        private static int SolvePart2(IEnumerable<Instruction> input)
        {
            var machine = new Machine { Program = input.ToArray() };

            for(int i = 0; i < machine.Program.Count(); i++) {
                if (!machine.SwapInstruction(i)) continue;

                try
                {
                    machine.Run();
                    return machine.Accumulator;
                }
                catch(InfiniteLoopException)
                {
                    // continue
                }
                finally
                {
                    machine.SwapInstruction(i);
                }
            }
            throw new ArgumentException("Program never ends without infinite loop");
        }
    }

    class Instruction
    {
        public string Operation { get; set; }
        public int Argument { get; set; }
        public bool Visited { get; set; }
    }

    class InfiniteLoopException: Exception {}

    class Machine
    {
        public int Accumulator { get; private set;}
        public int IP { get; private set; }
        public Instruction[] Program { get; set; }

        public void Run()
        {
            IP = 0;
            Accumulator = 0;
            Program.ToList().ForEach(x => x.Visited = false);

            while(true) {
                if (IP>=Program.Count()) break;

                var currentInstruction = Program.ElementAt(IP);

                if (currentInstruction.Visited)
                    throw new InfiniteLoopException();
                else
                    currentInstruction.Visited = true;

                switch(currentInstruction.Operation)
                {
                    case "acc":
                        Accumulator += currentInstruction.Argument;
                        IP += 1;
                        break;
                    case "jmp":
                        IP += currentInstruction.Argument;
                        break;
                    case "nop":
                        IP += 1;
                        break;
                }
            }
        }

        public bool SwapInstruction(int position)
        {
            if (Program[position].Operation == "jmp")
                Program[position].Operation = "nop";
            else if (Program[position].Operation == "nop")
                Program[position].Operation = "jmp";
            else
                return false;

            return true;
        }
    }
}
