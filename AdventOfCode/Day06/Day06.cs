using FluentAssertions;

namespace AdventOfCode.Day06;

public class Day06
{
    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day06\\Input.txt");

    [Fact]
    public void Day06Puzzle1HintTest()
    {
        var signal1 = new Signal("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
        var startPosition = signal1.FindStart();
        startPosition.Should().Be(7);
        
        var signal2 = new Signal("bvwbjplbgvbhsrlpgdmjqwftvncz");
        startPosition = signal2.FindStart();
        startPosition.Should().Be(5);
        
        var signal3 = new Signal("nppdvjthqldpwncqszvftbrmjlhg");
        startPosition = signal3.FindStart();
        startPosition.Should().Be(6);
        
        var signal4 = new Signal("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
        startPosition = signal4.FindStart();
        startPosition.Should().Be(10);
        
        var signal5 = new Signal("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
        startPosition = signal5.FindStart();
        startPosition.Should().Be(11);
    }

    [Fact]
    public async Task Day06Puzzle1Test()
    {
        var signal = await File.ReadAllTextAsync(DataPath);
        var signal1 = new Signal(signal);
        var startPosition = signal1.FindStart();
        startPosition.Should().Be(1109);
    }
}