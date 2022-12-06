namespace Day04;
public class Range
{
    public int Start { get; }
    public int End { get; }

    public Range(string range)
    {
        var rangeArray = range.Split('-');
        Start = int.Parse(rangeArray[0]);
        End = int.Parse(rangeArray[1]);
    }
}
