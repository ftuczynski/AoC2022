using System.Text.RegularExpressions;

namespace Day05;

public class ProcedureStep
{
    public int Quantity { get; }
    public int From { get; }
    public int To { get; }

    public ProcedureStep(string procedure)
    {
        var procedureValues = Regex.Matches(procedure, @"\d+")
            .Select(p=>p.Value).ToArray();
        Quantity = int.Parse(procedureValues[0]);
        From = int.Parse(procedureValues[1]);
        To = int.Parse(procedureValues[2]);
    }
}
