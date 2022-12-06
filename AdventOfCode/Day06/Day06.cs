using FluentAssertions;

namespace AdventOfCode.Day06;

public class Day06
{
    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day06\\Input.txt");

    [Fact]
    public void Day06Puzzle1HintTest()
    {
        var signal1 = new Signal("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4);
        var startPosition = signal1.FindStart();
        startPosition.Should().Be(7);
        
        var signal2 = new Signal("bvwbjplbgvbhsrlpgdmjqwftvncz", 4);
        startPosition = signal2.FindStart();
        startPosition.Should().Be(5);
        
        var signal3 = new Signal("nppdvjthqldpwncqszvftbrmjlhg", 4);
        startPosition = signal3.FindStart();
        startPosition.Should().Be(6);
        
        var signal4 = new Signal("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4);
        startPosition = signal4.FindStart();
        startPosition.Should().Be(10);
        
        var signal5 = new Signal("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4);
        startPosition = signal5.FindStart();
        startPosition.Should().Be(11);
    }

    [Fact]
    public async Task Day06Puzzle1Test()
    {
        var signal = await File.ReadAllTextAsync(DataPath);
        var signal1 = new Signal(signal, 4);
        var startPosition = signal1.FindStart();
        startPosition.Should().Be(1109);
    }

    [Fact]
    public void Day06Puzzle2HintTest()
    {
        var signal1 = new Signal("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14);
        var startPosition = signal1.FindStart();
        startPosition.Should().Be(19);
        
        var signal2 = new Signal("bvwbjplbgvbhsrlpgdmjqwftvncz", 14);
        startPosition = signal2.FindStart();
        startPosition.Should().Be(23);
    }
    
    [Fact]
    public async Task Day06Puzzle2Test()
    {
        var signal = await File.ReadAllTextAsync(DataPath);
        var signal1 = new Signal(signal, 14);
        var startPosition = signal1.FindStart();
        startPosition.Should().Be(3965);
    }
}