namespace AdventOfCode.Day02;

public class GameRoundStrategy1 : GameRound
{
    public GameRoundStrategy1(string lineData)
    {
        Input = lineData;
        Opponent = ParseStrategy(lineData[0]);
        Player = ParseStrategy(lineData[2]);
    }

    private static WeaponSelection ParseStrategy(char strategyCode)
    {
        return strategyCode switch
        {
            'A' => WeaponSelection.Rock,
            'B' => WeaponSelection.Paper,
            'C' => WeaponSelection.Scissors,
            'X' => WeaponSelection.Rock,
            'Y' => WeaponSelection.Paper,
            'Z' => WeaponSelection.Scissors,
            _ => throw new ArgumentException("Invalid input", nameof(strategyCode))
        };
    }
}