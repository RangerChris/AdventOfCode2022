using System.Net;
using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day09;

public class Day09
{
    private readonly ITestOutputHelper _testOutputHelper;
    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day09\\Input.txt");
    private static string DataPathHint => Path.Combine(Directory.GetCurrentDirectory(), "Day09\\InputHint.txt");

    public Day09(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Day09Hint1()
    {
        var input = await File.ReadAllTextAsync(DataPathHint);
        var moves = input.Split(Environment.NewLine);
        var rope = new Rope(6, 5, true);

        foreach (var move in moves)
        {
            _testOutputHelper.WriteLine($"Move: {move}");
            _testOutputHelper.WriteLine(rope.DoMovement(move));
        }

        rope.RopeHead.Position.X.Should().Be(2);
        rope.RopeHead.Position.Y.Should().Be(2);
        rope.RopeTail.Position.X.Should().Be(1);
        rope.RopeTail.Position.Y.Should().Be(2);

        rope.VisitList.Should().HaveCount(13);
    }
    
    [Fact]
    public async Task Day09Puzzle1()
    {
        var input = await File.ReadAllTextAsync(DataPath);
        var moves = input.Split(Environment.NewLine);
        var rope = new Rope(600, 500, false);

        foreach (var move in moves)
        {
            _testOutputHelper.WriteLine($"Move: {move}");
            _testOutputHelper.WriteLine(rope.DoMovement(move));
        }
        
        rope.VisitList.Should().HaveCount(6470);
    }
}