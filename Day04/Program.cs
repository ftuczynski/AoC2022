namespace Day04;

class Program
{
    static void Main()
    {
        Console.WriteLine("------ Advent Of Code Day 4 ------");
        var input = File.ReadAllLines("input.txt").Select(x => x.Split(',').Select(x => new Range(x)).ToArray()).ToArray();

        //PART 1
        Console.WriteLine("Part 1: " + SolvePartOne(input));

        //PART 2
        Console.WriteLine("Part 2: " + SolvePartTwo(input));
    }
    public static int SolvePartOne(Range[][] input)
    {
        return input.Count(ranges => ranges.RangesFullyOverlap());
    }

    public static int SolvePartTwo(Range[][] input)
    {
        return input.Count(ranges => ranges.RangesOverlap());
    }
}

public static class ExtensionMethods
{
    public static bool RangesFullyOverlap(this Range[] ranges) =>
        ranges[0].Start >= ranges[1].Start && ranges[0].End <= ranges[1].End ||
        ranges[1].Start >= ranges[0].Start && ranges[1].End <= ranges[0].End;

    public static bool RangesOverlap(this Range[] ranges) =>
        !(ranges[0].End < ranges[1].Start || ranges[0].Start > ranges[1].End);
}