using System.Collections.Immutable;
using Xunit.Abstractions;

namespace AdventOfCode.Day01;

public class Day01
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day01(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day01\\input.txt");

    [Fact]
    public async Task Day01Test()
    {
        var calorieCounter = 0;
        var maxCalories = 0;
        var elvesList = new List<Elf>();
        var currentElf = new Elf();
        using var sr = File.OpenText(DataPath);
        string? lineData;
        
        while ((lineData = await sr.ReadLineAsync()) != null)
        {
            if (string.IsNullOrEmpty(lineData))
            {
                currentElf.TotalCalories = calorieCounter;
                calorieCounter = 0;
                elvesList.Add(currentElf);
                currentElf = new Elf();
            }
            else
            {
                calorieCounter += Convert.ToInt32(lineData);
                if (maxCalories < calorieCounter)
                {
                    maxCalories = calorieCounter;
                }    
            }
        }

        _testOutputHelper.WriteLine($"Max calories: {maxCalories}");

        _testOutputHelper.WriteLine("Top 3 elves:");
        var top3Elves = elvesList.OrderByDescending(c => c.TotalCalories).Take(3).ToImmutableList();
        foreach (var elf in top3Elves)
        {
            _testOutputHelper.WriteLine(elf.ToString());
        }
        _testOutputHelper.WriteLine($"Top 3 elves total calories: {top3Elves.Sum(c=>c.TotalCalories)}");
    }
}