﻿using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day11;

public class Day11
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day11(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day11\\Input.txt");
    private static string DataPathHint => Path.Combine(Directory.GetCurrentDirectory(), "Day11\\Input-hint.txt");

    [Fact]
    public void Day11Hint1()
    {
        var input = File.ReadAllText(DataPathHint);
        var monkeyList = InitializeMonkeys(input);
        monkeyList.Should().HaveCount(4);
        var business = new MonkeyBusiness(monkeyList);
        business.Inspect(false);

        MonkeyBusiness.Monkeys[0].ItemList.Should().HaveCount(4);
        MonkeyBusiness.Monkeys[1].ItemList.Should().HaveCount(6);

        for (var i = 1; i < 20; i++)
        {
            business.Inspect(false);
        }
        
        MonkeyBusiness.Monkeys[0].ItemList.Should().HaveCount(5);
        MonkeyBusiness.Monkeys[1].ItemList.Should().HaveCount(5);

        var monkeyBusiness = business.GetMonkeyBusiness();
        monkeyBusiness.Should().Be(10605);
    }
    
    [Fact]
    public void Day11Puzzle1()
    {
        var input = File.ReadAllText(DataPath);
        var monkeyList = InitializeMonkeys(input);
        monkeyList.Should().HaveCount(8);
        var business = new MonkeyBusiness(monkeyList);
        
        for (var i = 0; i < 20; i++)
        {
            business.Inspect(false);
        }

        var monkeyBusiness = business.GetMonkeyBusiness();
        monkeyBusiness.Should().Be(54253);
    }

    [Fact]
    public void Day11Puzzle2()
    {
        var input = File.ReadAllText(DataPath);
        var monkeyList = InitializeMonkeys(input);
        monkeyList.Should().HaveCount(8);
        var business = new MonkeyBusiness(monkeyList);
        
        for (var i = 0; i < 10000; i++)
        {
            business.Inspect(true);
        }

        var monkeyBusiness = business.GetMonkeyBusiness();
        monkeyBusiness.Should().Be(870868608);
    }

    private static List<Monkey> InitializeMonkeys(string input)
    {
        var result = new List<Monkey>();
        input = input.Replace("Monkey ", "");
        input = input.Replace("Starting items: ", "");
        input = input.Replace("Operation: new = old ", "");
        input = input.Replace("Test: divisible by ", "");
        input = input.Replace("If true: throw to monkey ", "");
        input = input.Replace("If false: throw to monkey ", "");

        var newInput = input.Split(Environment.NewLine).ToList();

        var monkeyIndex = 0;
        while (monkeyIndex < newInput.Count)
        {
            var newMonkey = new Monkey(
                Convert.ToInt32(newInput[monkeyIndex].Replace(":", "").Trim()), 
                newInput[monkeyIndex+1].Split(","), 
                newInput[monkeyIndex+2].Trim(),
                Convert.ToInt32(newInput[monkeyIndex+3].Trim()),
                Convert.ToInt32(newInput[monkeyIndex+4].Trim()),
                Convert.ToInt32(newInput[monkeyIndex+5].Trim()));
            
            result.Add(newMonkey);
            monkeyIndex += 7;
        }
        
        return result;
    }
}