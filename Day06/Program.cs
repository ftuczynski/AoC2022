namespace Day06;

class Program
{
    static void Main()
    {
        Console.WriteLine("------ Advent Of Code Day 5 ------");
        var input = File.ReadAllText("input.txt");

        //PART 1
        Console.WriteLine("Part 1: " + FindMarker(input, 4));

        //PART 2
        Console.WriteLine("Part 2: " + FindMarker(input, 14));
    }

    public static int FindMarker(string input, int markerLenght)
    {
        Queue<char> marker = new();
        input.Take(markerLenght-1).ToList().ForEach(x => marker.Enqueue(x));
        for (int i = markerLenght-1; i < input.Count(); i++)
        {
            if (marker.Count == markerLenght) marker.Dequeue();
            marker.Enqueue(input[i]);
            if (marker.Distinct().Count() == markerLenght) return i + 1;
        }
        return 0;
    }
}