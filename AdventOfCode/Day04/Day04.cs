using FluentAssertions;

namespace AdventOfCode.Day04;

public class Day04
{
    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day04\\Input.txt");

    [Fact]
    public async Task Day04Puzzle1Test()
    {
        using var sr = File.OpenText(DataPath);
        string? lineData;
        var assignments = new List<SectionAssignment>();

        while ((lineData = await sr.ReadLineAsync()) != null)
        {
            assignments.Add(new SectionAssignment(lineData));
        }

        assignments.Should().HaveCount(1000);
        var fullyContainsList = assignments.Where(c => c.ContainsFully()).ToList();
        fullyContainsList.Should().HaveCount(466);
    }

    [Fact]
    public void Day04Puzzle1HintTest()
    {
        var assignment1 = new SectionAssignment("2-4,6-8");

        assignment1.PairList[0].Min.Should().Be(2);
        assignment1.PairList[0].Max.Should().Be(4);
        assignment1.PairList[1].Min.Should().Be(6);
        assignment1.PairList[1].Max.Should().Be(8);

        var assignment2 = new SectionAssignment("2-8,3-7");
        var assignment3 = new SectionAssignment("6-6,4-6");

        assignment1.ContainsFully().Should().BeFalse();
        assignment2.ContainsFully().Should().BeTrue();
        assignment3.ContainsFully().Should().BeTrue();

        var assignment4 = new SectionAssignment("2-4,2-5");
        assignment4.ContainsFully().Should().BeTrue();
        var assignment5 = new SectionAssignment("2-5,2-4");
        assignment5.ContainsFully().Should().BeTrue();

        var assignment6 = new SectionAssignment("2-4,6-8");
        assignment6.Overlaps().Should().BeFalse();
        var assignment7 = new SectionAssignment("5-7,7-9");
        assignment7.Overlaps().Should().BeTrue();
        var assignment8 = new SectionAssignment("2-8,3-7");
        assignment8.Overlaps().Should().BeTrue();
    }

    [Fact]
    public async Task Day04Puzzle2Test()
    {
        using var sr = File.OpenText(DataPath);
        string? lineData;
        var assignments = new List<SectionAssignment>();

        while ((lineData = await sr.ReadLineAsync()) != null)
        {
            assignments.Add(new SectionAssignment(lineData));
        }

        assignments.Should().HaveCount(1000);
        var overlapList = assignments.Where(c => c.Overlaps()).ToList();
        overlapList.Should().HaveCount(865);
    }
}