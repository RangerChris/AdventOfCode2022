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

    [Fact]
    public void Day03Puzzle2HintTest()
    {
        var rucksack1 = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");
        var rucksack2 = new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL");
        var rucksack3 = new Rucksack("PmmdzqPrVvPwwTWBwg");
        var rucksack4 = new Rucksack("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn");
        var rucksack5 = new Rucksack("ttgJtRGJQctTZtZT");
        var rucksack6 = new Rucksack("CrZsJsPPZsGzwwsLwLmpwMDw");

        var elfGroup1 = new List<Rucksack>
        {
            rucksack1,
            rucksack2,
            rucksack3
        };

        var elfGroup2 = new List<Rucksack>
        {
            rucksack4,
            rucksack5,
            rucksack6
        };

        elfGroup1[0].Content.Should().Be("vJrwpWtwJgWrhcsFMMfFFhFp");
        elfGroup1[1].Content.Should().Be("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL");
        elfGroup1[2].Content.Should().Be("PmmdzqPrVvPwwTWBwg");

        elfGroup2[0].Content.Should().Be("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn");
        elfGroup2[1].Content.Should().Be("ttgJtRGJQctTZtZT");
        elfGroup2[2].Content.Should().Be("CrZsJsPPZsGzwwsLwLmpwMDw");

        var group1PriorityItem = Helper.GetGroupPriorityItem(elfGroup1);
        group1PriorityItem.Should().Be('r');

        var group2PriorityItem = Helper.GetGroupPriorityItem(elfGroup2);
        group2PriorityItem.Should().Be('Z');

        Helper.GetPriority(group1PriorityItem).Should().Be(18);
        Helper.GetPriority(group2PriorityItem).Should().Be(52);
    }

    [Fact]
    public async Task Day03Puzzle2Test()
    {
        using var sr = File.OpenText(DataPath);
        string? lineData;
        var allElfGroups = new List<ElfGroup>();
        var currentElfGroup = new ElfGroup();

        // Get all elves and create groups of 3
        while ((lineData = await sr.ReadLineAsync()) != null)
        {
            var rucksack = new Rucksack(lineData);
            currentElfGroup.Group.Add(rucksack);
            
            if (currentElfGroup.Group.Count >= 3)
            {
                allElfGroups.Add(currentElfGroup);
                currentElfGroup = new ElfGroup();
            }
        }
        
        allElfGroups.Count.Should().Be(100);
        
        // Find group priority
        foreach (var currentGroup in allElfGroups)
        {
            currentGroup.PriorityItem = Helper.GetGroupPriorityItem(currentGroup.Group);
            currentGroup.Priority = Helper.GetPriority(currentGroup.PriorityItem);
        }
        
        var groupScore = allElfGroups.Sum(c => c.Priority);
        groupScore.Should().Be(2434);
    }
}