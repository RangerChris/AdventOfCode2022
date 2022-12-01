using Xunit.Abstractions;

namespace AdventOfCode;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

    [Fact]
    public async Task Day01Test()
    {
        var calorieCounter = 0;
        var maxCalories = 0;
        using var sr = File.OpenText(DataPath);
        string? lineData;
        while ((lineData = await sr.ReadLineAsync()) != null)
            if (!string.IsNullOrEmpty(lineData))
            {
                calorieCounter += Convert.ToInt32(lineData);
                if (maxCalories < calorieCounter) maxCalories = calorieCounter;
            }
            else
            {
                calorieCounter = 0;
            }

        _testOutputHelper.WriteLine($"Max calories: {maxCalories}");
    }
}