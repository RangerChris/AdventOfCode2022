namespace AdventOfCode.Day02;

public class GameRound
{
    public enum WeaponSelection
    {
        Rock,
        Paper,
        Scissors,
        Unknown
    }
    
    public enum Winner
    {
        Opponent,
        Player,
        Draw
    }

    public GameRound(string lineData)
    {
        Input = lineData;
        Opponent = ParseStrategy(lineData[0]);
        Player = ParseStrategy(lineData[2]);
    }

    private string Input { get; }
    internal WeaponSelection Opponent { get; }
    public WeaponSelection Player { get; }

    public int Score
    {
        get
        {
            var tempScore = 0;
            switch (Player)
            {
                case WeaponSelection.Rock : tempScore = 1;
                    break;
                case WeaponSelection.Paper : tempScore = 2;
                    break;
                case WeaponSelection.Scissors : tempScore = 3;
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

    private WeaponSelection ParseStrategy(char strategyCode)
    {
        return strategyCode switch
        {
            'A' => WeaponSelection.Rock,
            'B' => WeaponSelection.Paper,
            'C' => WeaponSelection.Scissors,
            'X' => WeaponSelection.Rock,
            'Y' => WeaponSelection.Paper,
            'Z' => WeaponSelection.Scissors,
            _ => WeaponSelection.Unknown
        };
    }

    public override string ToString()
    {
        return $"Input: {Input} Opponent: {Opponent} Player: {Player} Who won {GetWinner} Score: {Score}";
    }
}