using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day14;

public class Day14
{
    private readonly ITestOutputHelper testOutputHelper;

    public Day14(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day14\\Input.txt");
    private static string DataPathHint => Path.Combine(Directory.GetCurrentDirectory(), "Day14\\Input-hint.txt");

    [Fact]
    public async Task Day14Hint1()
    {
        var input = await File.ReadAllTextAsync(DataPathHint);
        input = input.Replace(" ->", "");
        var rockData = input.Split(Environment.NewLine);
        var gameWorld = new World(rockData);
 
        gameWorld.WorldMinX.Should().Be(494);
        gameWorld.WorldMaxX.Should().Be(503);
        gameWorld.WorldMinY.Should().Be(4);
        gameWorld.WorldMaxY.Should().Be(9);
        
        testOutputHelper.WriteLine(gameWorld.DrawWorld());

        gameWorld.Spawner.Start();
        var grains = gameWorld.CountSandGrains();
        grains.Should().Be(24);
        
        testOutputHelper.WriteLine(gameWorld.DrawWorld());
    }
    
    [Fact]
    public async Task Day14Puzzle1()
    {
        var input = await File.ReadAllTextAsync(DataPath);
        input = input.Replace(" ->", "");
        var rockData = input.Split(Environment.NewLine);
        var gameWorld = new World(rockData);
 
        gameWorld.WorldMinX.Should().Be(432);
        gameWorld.WorldMaxX.Should().Be(518);
        gameWorld.WorldMinY.Should().Be(13);
        gameWorld.WorldMaxY.Should().Be(156);
        
        gameWorld.Spawner.Start();
        var grains = gameWorld.CountSandGrains();
        grains.Should().Be(817);
        
        testOutputHelper.WriteLine(gameWorld.DrawWorld());
    }
}