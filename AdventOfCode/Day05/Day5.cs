using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day05;

public class Day5
{

    public Day5(ITestOutputHelper testOutputHelper)
    {
    }

    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day05\\Input.txt");
    
    [Fact]
    public async Task Day05Puzzle1Test()
    {
        var supplies = new Supplies();
        supplies.AddCreatesToStack("VCDRZGBW");
        supplies.AddCreatesToStack("GWFCBSTV");
        supplies.AddCreatesToStack("CBSNW");
        supplies.AddCreatesToStack("QGMNJVCP");
        supplies.AddCreatesToStack("TSLFDHB");
        supplies.AddCreatesToStack("JVTWMN");
        supplies.AddCreatesToStack("PFLCSTG");
        supplies.AddCreatesToStack("BDZ");
        supplies.AddCreatesToStack("MNZW");
        
        var movementInstructions = await File.ReadAllLinesAsync(DataPath);
        var allInstructions = new List<MovementInstructions>();
        
        foreach (var instruction in movementInstructions)
        {
            allInstructions.Add(new MovementInstructions(instruction));
        }

        allInstructions.Should().HaveCount(502);

        supplies.AddInstructions(allInstructions);
        supplies.StartCrane();

        var answer = "";
        foreach (var currentStack in supplies.Stacks)
        {
            answer += currentStack.Last().ToString();
        }

        answer.Should().Be("TBVFVDZPN");
    }
    
    [Fact]
    public void Day05Puzzle1HintTest()
    {
        var allInstructions = new List<MovementInstructions>
        {
            new("move 1 from 2 to 1"),
            new("move 3 from 1 to 3"),
            new("move 2 from 2 to 1"),
            new("move 1 from 1 to 2")
        };

        var supplies = new Supplies();
        supplies.AddCreatesToStack("ZN");
        supplies.AddCreatesToStack("MCD");
        supplies.AddCreatesToStack("P");

        supplies.AddInstructions(allInstructions);
        supplies.StartCrane();

        supplies.Stacks[0][0].Should().Be('C');
        
        supplies.Stacks[1][0].Should().Be('M');
        
        supplies.Stacks[2][0].Should().Be('P');
        supplies.Stacks[2][1].Should().Be('D');
        supplies.Stacks[2][2].Should().Be('N');
        supplies.Stacks[2][3].Should().Be('Z');
    }
}