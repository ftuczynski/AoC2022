namespace Day02;

class Program
{
    static void Main()
    {
        Console.WriteLine("------ Advent Of Code Day 2 ------");
        var input = File.ReadAllLines("input.txt").Select(x => x.Split(" ").Select(x => Convert.ToChar(x)).ToArray()).ToArray();

        //PART 1
        Console.WriteLine("Part 1: " + SolvePartOne(input));

        //PART 2
        Console.WriteLine("Part 2: ");
    }

    static int SolvePartOne(char[][] input)
    {
        int score = 0;
        foreach (var round in input)
        {
            score += ExtensionMethods.ScoreRound(round[0].MapHand(), round[1].MapHand());
        }
        return score;
    }
}

