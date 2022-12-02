using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day02;

public class Day02
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day02(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day02\\input.txt");

    [Fact]
    public async Task Day02SolutionTest()
    {
        using var sr = File.OpenText(DataPath);
        string? lineData;
        var gameRounds = new List<GameRound>();

        while ((lineData = await sr.ReadLineAsync()) != null)
        {
            var tempStrategy = new GameRound(lineData);
            gameRounds.Add(tempStrategy);
            //_testOutputHelper.WriteLine(tempStrategy.ToString());
        }
        
        _testOutputHelper.WriteLine($"Total score: {gameRounds.Sum(c=>c.Score)}");
    }

    [Fact]
    public void Day02HintTest()
    {
        var round1 = new GameRound("A Y");
        var round2 = new GameRound("B X");
        var round3 = new GameRound("C Z");

        round1.Opponent.Should().Be(GameRound.WeaponSelection.Rock);
        round1.Player.Should().Be(GameRound.WeaponSelection.Paper);
        round1.GetWinner.Should().Be(GameRound.Winner.Player);
        round1.Score.Should().Be(8);
        
        round2.Opponent.Should().Be(GameRound.WeaponSelection.Paper);
        round2.Player.Should().Be(GameRound.WeaponSelection.Rock);
        round2.GetWinner.Should().Be(GameRound.Winner.Opponent);
        round2.Score.Should().Be(1);
        
        round3.Opponent.Should().Be(GameRound.WeaponSelection.Scissors);
        round3.Player.Should().Be(GameRound.WeaponSelection.Scissors);
        round3.GetWinner.Should().Be(GameRound.Winner.Draw);
        round3.Score.Should().Be(6);

        var totalScore = round1.Score + round2.Score + round3.Score;
        totalScore.Should().Be(15);
    }
}