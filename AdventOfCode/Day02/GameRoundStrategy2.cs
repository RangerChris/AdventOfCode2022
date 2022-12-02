namespace AdventOfCode.Day02;

public class GameRoundStrategy2 : GameRound
{
    public GameRoundStrategy2(string lineData)
    {
        Input = lineData;
        Opponent = ParseStrategy(lineData[0]);
        Player = ParseStrategy(lineData[2]);
    }
    
    private WeaponSelection ParseStrategy(char code)
    {
        switch (code)
        {
            case 'A': return WeaponSelection.Rock;
            case 'B': return WeaponSelection.Paper;
            case 'C': return WeaponSelection.Scissors;
            case 'X': return DoNotBeat(Opponent); // Player lose
            case 'Y': return Opponent; // Player draw
            case 'Z': return Beats(Opponent); // Player win
            default:
                throw new ArgumentException("Invalid input", nameof(code));
        }
    }

    private WeaponSelection Beats(WeaponSelection weapon)
    {
        switch (weapon)
        {
            case WeaponSelection.Rock: return WeaponSelection.Paper;
            case WeaponSelection.Paper: return WeaponSelection.Scissors;
            case WeaponSelection.Scissors: return WeaponSelection.Rock;
            default:
                throw new ArgumentException("Invalid input", nameof(weapon));
        }
    }
    
    private WeaponSelection DoNotBeat(WeaponSelection weapon)
    {
        switch (weapon)
        {
            case WeaponSelection.Rock: return WeaponSelection.Scissors;
            case WeaponSelection.Paper: return WeaponSelection.Rock;
            case WeaponSelection.Scissors: return WeaponSelection.Paper;
            default:
                throw new ArgumentException("Invalid input", nameof(weapon));
        }
    }
}