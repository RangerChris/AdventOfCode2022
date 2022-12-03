using FluentAssertions;

namespace AdventOfCode.Day03;

public class Day03
{
    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day03\\input.txt");

    [Fact]
    public async Task Day03Puzzle1Test()
    {
        using var sr = File.OpenText(DataPath);
        string? lineData;
        var allRucksacks = new List<Rucksack>();

        while ((lineData = await sr.ReadLineAsync()) != null)
        {
            allRucksacks.Add(new Rucksack(lineData));
        }

        var totalPriority = allRucksacks.Sum(c => c.Priority);
        totalPriority.Should().Be(8515);
    }
    
    [Fact]
    public void Day03Puzzle1HintTest()
    {
        var rucksack1 = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");
        var rucksack2 = new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL");
        var rucksack3 = new Rucksack("PmmdzqPrVvPwwTWBwg");
        var rucksack4 = new Rucksack("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn");
        var rucksack5 = new Rucksack("ttgJtRGJQctTZtZT");
        var rucksack6 = new Rucksack("CrZsJsPPZsGzwwsLwLmpwMDw");

        rucksack1.Compartment1.Should().Be("vJrwpWtwJgWr");
        rucksack1.Compartment2.Should().Be("hcsFMMfFFhFp");
        rucksack1.PriorityItem.Should().Be('p');
        rucksack1.Priority.Should().Be(16);
        
        rucksack2.Compartment1.Should().Be("jqHRNqRjqzjGDLGL");
        rucksack2.Compartment2.Should().Be("rsFMfFZSrLrFZsSL");
        rucksack2.PriorityItem.Should().Be('L');
        rucksack2.Priority.Should().Be(38);
        
        rucksack3.Compartment1.Should().Be("PmmdzqPrV");
        rucksack3.Compartment2.Should().Be("vPwwTWBwg");
        rucksack3.PriorityItem.Should().Be('P');
        rucksack3.Priority.Should().Be(42);
        
        rucksack4.Compartment1.Should().Be("wMqvLMZHhHMvwLH");
        rucksack4.Compartment2.Should().Be("jbvcjnnSBnvTQFn");
        rucksack4.PriorityItem.Should().Be('v');
        rucksack4.Priority.Should().Be(22);
        
        rucksack5.Compartment1.Should().Be("ttgJtRGJ");
        rucksack5.Compartment2.Should().Be("QctTZtZT");
        rucksack5.PriorityItem.Should().Be('t');
        rucksack5.Priority.Should().Be(20);
        
        rucksack6.Compartment1.Should().Be("CrZsJsPPZsGz");
        rucksack6.Compartment2.Should().Be("wwsLwLmpwMDw");
        rucksack6.PriorityItem.Should().Be('s');
        rucksack6.Priority.Should().Be(19);

        var totalPriority = rucksack1.Priority +
                            rucksack2.Priority +
                            rucksack3.Priority +
                            rucksack4.Priority +
                            rucksack5.Priority +
                            rucksack6.Priority;

        totalPriority.Should().Be(157);
    }
}