using System.Text;
using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day10;

public class Day10
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day10(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day10\\Input.txt");
    
    [Fact]
    public void Day10Hint1()
    {
        var input = @"noop
addx 3
addx -5";

        var cpu = new Cpu();
        cpu.Cycles.Should().Be(1);
        cpu.RegisterX.Should().Be(1);
        cpu.LoadInstructions(input);
        cpu.Instructions.Should().HaveCount(3);
        cpu.Execute();

        cpu.Cycles.Should().Be(6);
        cpu.RegisterX.Should().Be(-1);
        
        var debug = new StringBuilder();
        foreach (var state in cpu.CpuStateHistory)
        {
            debug.AppendLine(state.ToString());
        }
        _testOutputHelper.WriteLine(debug.ToString());
    }
    
    [Fact]
    public void Day10Hint2()
    {
        var input = @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";

        var cpu = new Cpu();
        cpu.LoadInstructions(input);
        cpu.Instructions.Should().HaveCount(146);
        cpu.Execute();

        cpu.Cycles.Should().Be(241);
        cpu.RegisterX.Should().Be(17);
        
        var debug = new StringBuilder();
        foreach (var state in cpu.CpuStateHistory)
        {
            debug.AppendLine(state.ToString());
        }
        _testOutputHelper.WriteLine(debug.ToString());

        var signalAtCycle20 = cpu.GetSignalValue(20);
        signalAtCycle20?.Cycle.Should().Be(20);
        signalAtCycle20?.RegisterValue.Should().Be(21);
        signalAtCycle20?.SignalValue.Should().Be(420);
        
        var signalAtCycle60 = cpu.GetSignalValue(60);
        signalAtCycle60?.Cycle.Should().Be(60);
        signalAtCycle60?.RegisterValue.Should().Be(19);
        signalAtCycle60?.SignalValue.Should().Be(1140);
        
        var signalAtCycle100 = cpu.GetSignalValue(100);
        signalAtCycle100?.Cycle.Should().Be(100);
        signalAtCycle100?.RegisterValue.Should().Be(18);
        signalAtCycle100?.SignalValue.Should().Be(1800);
        
        var signalAtCycle140 = cpu.GetSignalValue(140);
        signalAtCycle140?.Cycle.Should().Be(140);
        signalAtCycle140?.RegisterValue.Should().Be(21);
        signalAtCycle140?.SignalValue.Should().Be(2940);
        
        var signalAtCycle180 = cpu.GetSignalValue(180);
        signalAtCycle180?.Cycle.Should().Be(180);
        signalAtCycle180?.RegisterValue.Should().Be(16);
        signalAtCycle180?.SignalValue.Should().Be(2880);
        
        var signalAtCycle220 = cpu.GetSignalValue(220);
        signalAtCycle220?.Cycle.Should().Be(220);
        signalAtCycle220?.RegisterValue.Should().Be(18);
        signalAtCycle220?.SignalValue.Should().Be(3960);
    }

    [Fact]
    public async Task Day10Puzzle1()
    {
        var input = await File.ReadAllTextAsync(DataPath);
        var cpu = new Cpu();
        cpu.LoadInstructions(input);
        cpu.Instructions.Should().HaveCount(140);
        cpu.Execute();
        
        cpu.Cycles.Should().Be(241);
        var signalStrength = cpu.GetSignalValue(20).SignalValue + cpu.GetSignalValue(60).SignalValue + cpu.GetSignalValue(100).SignalValue +
                             cpu.GetSignalValue(140).SignalValue + cpu.GetSignalValue(180).SignalValue + cpu.GetSignalValue(220).SignalValue;
        signalStrength.Should().Be(13680);
    }
}