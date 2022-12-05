namespace Day01;

class Program
{
    static void Main()
    {
        Console.WriteLine("------ Advent Of Code Day 1 ------");
        var input = File.ReadAllText("input.txt");
        //PART 1
        Console.WriteLine("Part 1: " + Solve(input, 1));

        //PART 2
        Console.WriteLine("Part 2: " + Solve(input, 3));
    }

    static int Solve(string input, int numberOfElves)
    {
        return input.Trim()
           .Split(Environment.NewLine + Environment.NewLine)
           .Select(elf => elf.Split(Environment.NewLine).Sum(int.Parse))
           .OrderByDescending(sum => sum)
           .Take(numberOfElves)
           .Sum();
    }
}
