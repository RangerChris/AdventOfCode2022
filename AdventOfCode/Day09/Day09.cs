using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day09;

public class Day09
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day09(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Day09Hint1()
    {
        const string input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";

        var moves = input.Split(Environment.NewLine);
        var rope = new Rope(6, 5);

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
}