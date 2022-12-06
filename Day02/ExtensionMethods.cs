namespace Day02;

public static class ExtensionMethods
{
    public static readonly int WIN_POINTS = 6;
    public static readonly int DRAW_POINTS = 3;
    public static readonly int LOST_POINTS = 0;

    public enum Hand
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
    }

    public enum Outcome
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }

    public static Hand MapHand(this char handCode) => handCode switch
    {
        'A' or 'X' => Hand.Rock,
        'B' or 'Y' => Hand.Paper,
        'C' or 'Z' => Hand.Scissors
    };

    public static Outcome MapOutcome(this char handCode) => handCode switch
    {
        'X' => Outcome.Lose,
        'Y' => Outcome.Draw,
        'Z' => Outcome.Win
    };

    public static int ScoreRound(Hand oponentHand, Hand myHand)
    {
        switch (oponentHand)
        {
            case Hand.Rock:
                return ((int)myHand) + myHand switch
                {
                    Hand.Paper => WIN_POINTS,
                    Hand.Rock => DRAW_POINTS,
                    _ => LOST_POINTS
                };
            case Hand.Paper:
                return ((int)myHand) + myHand switch
                {
                    Hand.Scissors => WIN_POINTS,
                    Hand.Paper => DRAW_POINTS,
                    _ => LOST_POINTS
                };
            case Hand.Scissors:
                return ((int)myHand) + myHand switch
                {
                    Hand.Rock => WIN_POINTS,
                    Hand.Scissors => DRAW_POINTS,
                    _ => LOST_POINTS
                };
            default: return 0;
        }
    }

    public static Hand MapHandByOutcome(this Hand oponentHand, Outcome outcome)
    {
        switch (outcome)
        {
            case Outcome.Lose:
                return oponentHand switch
                {
                    Hand.Rock => Hand.Scissors,
                    Hand.Paper => Hand.Rock,
                    Hand.Scissors => Hand.Paper
                };
            case Outcome.Win:
                return oponentHand switch
                {
                    Hand.Rock => Hand.Paper,
                    Hand.Paper => Hand.Scissors,
                    Hand.Scissors => Hand.Rock
                };
            default: return oponentHand; //Draw
        }
    }

    public static int ScoreRoundByOutcome(Hand oponentHand, Outcome outcome)
    {
        return ((int)oponentHand.MapHandByOutcome(outcome)) + ((int)outcome);
    }
}

