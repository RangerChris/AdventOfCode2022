namespace AdventOfCode.Day02;

public class GameRound
{
    protected string? Input { get; set; }
    internal WeaponSelection Opponent { get; init; }
    public WeaponSelection Player { get; init; }

    public int Score
    {
        get
        {
            var tempScore = 0;
            switch (Player)
            {
                case WeaponSelection.Rock:
                    tempScore = 1;
                    break;
                case WeaponSelection.Paper:
                    tempScore = 2;
                    break;
                case WeaponSelection.Scissors:
                    tempScore = 3;
                    break;
            }

            if (GetWinner == Winner.Player)
            {
                tempScore += 6;
            }

            if (GetWinner == Winner.Draw)
            {
                tempScore += 3;
            }

            return tempScore;
        }
    }

    public Winner GetWinner
    {
        get
        {
            if (Player == WeaponSelection.Rock && Opponent == WeaponSelection.Scissors)
            {
                return Winner.Player;
            }

            if (Player == WeaponSelection.Scissors && Opponent == WeaponSelection.Paper)
            {
                return Winner.Player;
            }

            if (Player == WeaponSelection.Paper && Opponent == WeaponSelection.Rock)
            {
                return Winner.Player;
            }

            if (Player == Opponent)
            {
                return Winner.Draw;
            }

            return Winner.Opponent;
        }
    }
}