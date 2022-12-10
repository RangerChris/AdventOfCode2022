using FluentAssertions;

namespace AdventOfCode.Day10;

public class Day10
{
    [Fact]
    public void Day10Hint1()
    {
        var input = @"noop
addx 3
addx -5";

        var cpu = new Cpu();
        cpu.Cycles.Should().Be(0);
        cpu.RegisterX.Should().Be(1);
        cpu.LoadInstructions(input);
        cpu.Instructions.Should().HaveCount(3);
        cpu.Execute();

        cpu.Cycles.Should().Be(5);
        cpu.RegisterX.Should().Be(-1);
    }
}