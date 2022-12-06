namespace Day03;

class Program
{
    static void Main()
    {
        Console.WriteLine("------ Advent Of Code Day 3 ------");
        var input = File.ReadAllLines("input.txt");

        //PART 1
        Console.WriteLine("Part 1: " + SolvePartOne(input));

        //PART 2
        Console.WriteLine("Part 2: " + SolvePartTwo(input));
    }

    public static int SolvePartOne(string[] input)
    {
        var prioritySum = 0;
        foreach(var rucksack in input)
        {
            var compartments = new string[] { rucksack.Substring(0, rucksack.Length / 2), rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2) };
            prioritySum += compartments[0].Intersect(compartments[1]).First().MapPriority();
        }
        return prioritySum;
    }

    public static int SolvePartTwo(string[] input)
    {
        var groups = input.Chunk(3);
        var prioritySum = 0;
        foreach(var group in groups)
        {
            prioritySum += group[0].Intersect(group[1]).Intersect(group[2]).First().MapPriority();
        }
        return prioritySum;
    }
}

