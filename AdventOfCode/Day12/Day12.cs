using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day12;

public class Day12
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day12(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day12\\Input.txt");
    private static string DataPathHint => Path.Combine(Directory.GetCurrentDirectory(), "Day12\\Input-hint.txt");

    [Fact]
    public async Task Day12Hint1()
    {
        var input = await File.ReadAllTextAsync(DataPathHint);
        input = input.Replace(" ->", "");
        var rockData = input.Split(Environment.NewLine);
        var gameWorld = new World(rockData);
 
        gameWorld.WorldMinX.Should().Be(494);
        gameWorld.WorldMaxX.Should().Be(503);
        gameWorld.WorldMinY.Should().Be(4);
        gameWorld.WorldMaxY.Should().Be(9);
        
        gameWorld.DrawHorizontalLine(497, 2, 7);
        
        _testOutputHelper.WriteLine(gameWorld.DrawWorld());
    }
    
    [Fact]
    public async Task Day12Puzzle1()
    {
        var input = await File.ReadAllTextAsync(DataPath);
        input = input.Replace(" ->", "");
        var rockData = input.Split(Environment.NewLine);
        var gameWorld = new World(rockData);
 
        gameWorld.WorldMinX.Should().Be(432);
        gameWorld.WorldMaxX.Should().Be(518);
        gameWorld.WorldMinY.Should().Be(13);
        gameWorld.WorldMaxY.Should().Be(156);
        
        _testOutputHelper.WriteLine(gameWorld.DrawWorld());
    }
}