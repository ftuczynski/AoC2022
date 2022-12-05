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

    public static Hand MapHand(this char handCode) => handCode switch
    {
        'A' or 'X' => Hand.Rock,
        'B' or 'Y' => Hand.Paper,
        'C' or 'Z' => Hand.Scissors
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
}

