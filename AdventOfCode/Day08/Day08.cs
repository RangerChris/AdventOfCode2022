using FluentAssertions;

namespace AdventOfCode.Day08;

public class Day08
{
    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day08\\Input.txt");

    [Fact]
    public void Day08Hint1Test()
    {
        const string input = @"30373
25512
65332
33549
35390";

        var forestMap = new ForestMap(input);
        forestMap.Rows.Should().Be(5);
        forestMap.Columns.Should().Be(5);

        forestMap.Map[1][1].Visible.Should().BeTrue();
        forestMap.Map[2][1].Visible.Should().BeTrue();
        forestMap.Map[1][2].Visible.Should().BeTrue();
        forestMap.Map[3][2].Visible.Should().BeTrue();
        
        var visibleTrees = forestMap.GetVisibleTrees();
        visibleTrees.Should().HaveCount(21);
    }
    
    [Fact]
    public async Task Day08Puzzle1Test()
    {
        var input = await File.ReadAllTextAsync(DataPath);
        var forestMap = new ForestMap(input);
        var visibleTrees = forestMap.Map.SelectMany(c => c).ToList().Where(t=>t.Visible);
        visibleTrees.Count().Should().Be(1827);
    }
    
    [Fact]
    public void Day08Hint2Test()
    {
        const string input = @"30373
25512
65332
33549
35390";

        var forestMap = new ForestMap(input);
        forestMap.Map[1][2].ScenicScore.Should().Be(4);
        forestMap.Map[3][2].ScenicScore.Should().Be(8);
    }
    
    [Fact]
    public async Task Day08Puzzle2Test()
    {
        var input = await File.ReadAllTextAsync(DataPath);
        var forestMap = new ForestMap(input);
        var scenicScores = forestMap.Map.SelectMany(c => c).ToList().Where(t=>t.Visible);
        scenicScores.Max(c=>c.ScenicScore).Should().Be(335580);
    }
}