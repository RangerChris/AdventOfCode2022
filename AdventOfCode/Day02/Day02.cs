using FluentAssertions;

namespace AdventOfCode.Day02;

public class Day02
{
    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day02\\input.txt");

    [Fact]
    public async Task Day02Puzzle1Test()
    {
        using var sr = File.OpenText(DataPath);
        string? lineData;
        var gameRounds = new List<GameRound>();

        while ((lineData = await sr.ReadLineAsync()) != null)
        {
            var tempStrategy = new GameRoundStrategy1(lineData);
            gameRounds.Add(tempStrategy);
        }

        var totalScore = gameRounds.Sum(c => c.Score);
        totalScore.Should().Be(13005);
    }

    [Fact]
    public void Day02Puzzle1HintTest()
    {
        var round1 = new GameRoundStrategy1("A Y");
        var round2 = new GameRoundStrategy1("B X");
        var round3 = new GameRoundStrategy1("C Z");

        round1.Opponent.Should().Be(WeaponSelection.Rock);
        round1.Player.Should().Be(WeaponSelection.Paper);
        round1.GetWinner.Should().Be(Winner.Player);
        round1.Score.Should().Be(8);
        
        round2.Opponent.Should().Be(WeaponSelection.Paper);
        round2.Player.Should().Be(WeaponSelection.Rock);
        round2.GetWinner.Should().Be(Winner.Opponent);
        round2.Score.Should().Be(1);
        
        round3.Opponent.Should().Be(WeaponSelection.Scissors);
        round3.Player.Should().Be(WeaponSelection.Scissors);
        round3.GetWinner.Should().Be(Winner.Draw);
        round3.Score.Should().Be(6);

        var totalScore = round1.Score + round2.Score + round3.Score;
        totalScore.Should().Be(15);
    }

    [Fact]
    public void Day02Puzzle2HintTest()
    {
        var round1 = new GameRoundStrategy2("A Y");
        var round2 = new GameRoundStrategy2("B X");
        var round3 = new GameRoundStrategy2("C Z");
        
        round1.Opponent.Should().Be(WeaponSelection.Rock);
        round1.Player.Should().Be(WeaponSelection.Rock);
        round1.GetWinner.Should().Be(Winner.Draw);
        round1.Score.Should().Be(4);
        
        round2.Opponent.Should().Be(WeaponSelection.Paper);
        round2.Player.Should().Be(WeaponSelection.Rock);
        round2.GetWinner.Should().Be(Winner.Opponent);
        round2.Score.Should().Be(1);
        
        round3.Opponent.Should().Be(WeaponSelection.Scissors);
        round3.Player.Should().Be(WeaponSelection.Rock);
        round3.GetWinner.Should().Be(Winner.Player);
        round3.Score.Should().Be(7);
    }
    
    [Fact]
    public async Task Day02Puzzle2Test()
    {
        using var sr = File.OpenText(DataPath);
        string? lineData;
        var gameRounds = new List<GameRound>();

        while ((lineData = await sr.ReadLineAsync()) != null)
        {
            var tempStrategy = new GameRoundStrategy2(lineData);
            gameRounds.Add(tempStrategy);
        }

        var totalScore = gameRounds.Sum(c => c.Score);
        totalScore.Should().Be(11373);
    }
}