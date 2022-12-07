using System.Collections;
using System.Text;

namespace Day05;

class Program
{
    static void Main()
    {
        Console.WriteLine("------ Advent Of Code Day 5 ------");
        var input = File.ReadAllText("input.txt").Split(Environment.NewLine + Environment.NewLine);
        var stacksInput = input[0].Split(Environment.NewLine);
        var instructionsInput = input[1].Split(Environment.NewLine);

        //PART 1
        Console.WriteLine("Part 1: " + SolvePartOne(stacksInput, instructionsInput));

        //PART 2
        Console.WriteLine("Part 2: " + SolvePartTwo(stacksInput, instructionsInput));
    }

    public static string SolvePartOne(string[] stacksInput, string[] instructionsInput)
    {
        var stacks = stacksInput.MapCrateStacks();
        var procedures = instructionsInput.MapProcedures();
        foreach (var procedure in procedures)
        {
            for (int q = 0; q < procedure.Quantity; q++)
            {
                var crate = stacks[procedure.From].Pop();
                stacks[procedure.To].Push(crate);
            }
        }
        StringBuilder topCrates = new();
        for (int i = 1; i <= stacks.Count; i++)
        {
            topCrates.Append(stacks[i].Peek());
        }
        return topCrates.ToString();
    }

    public static string SolvePartTwo(string[] stacksInput, string[] instructionsInput)
    {
        var stacks = stacksInput.MapCrateStacks();
        var procedures = instructionsInput.MapProcedures();
        foreach (var procedure in procedures)
        {
            stacks[procedure.From].ToArray()
                .Take(procedure.Quantity)
                .Reverse().ToList()
                .ForEach(crate =>
                {
                    stacks[procedure.From].Pop();
                    stacks[procedure.To].Push(crate);
                });
        }
        StringBuilder topCrates = new();
        for (int i = 1; i <= stacks.Count; i++)
        {
            topCrates.Append(stacks[i].Peek());
        }
        return topCrates.ToString();
    }
}

public static class ExtensionMethods
{
    public static Dictionary<int, Stack> MapCrateStacks(this string[] input)
    {
        var crateRowsIndexes = input.Last()
            .Select((x, i) => new { value = x, index = i })
            .Where(x => char.IsDigit(x.value))
            .Select(x => x.index).ToList();

        Dictionary<int, Stack> stacks = new();
        for (var i = 1; i <= crateRowsIndexes.Count; i++)
        {
            stacks.Add(i, new Stack());
            for (var j = crateRowsIndexes.Count - 2; j >= 0; j--)
            {
                var crateLabel = input[j][crateRowsIndexes[i - 1]];
                if (char.IsLetter(crateLabel)) stacks[i].Push(crateLabel);
            }
        }
        return stacks;
    }

    public static ProcedureStep[] MapProcedures(this string[] input)
    {
        return input.Select(x => new ProcedureStep(x)).ToArray();
    }
}