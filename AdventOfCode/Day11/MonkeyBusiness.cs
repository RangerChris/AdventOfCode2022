namespace AdventOfCode.Day11;

public class MonkeyBusiness
{
    public MonkeyBusiness(List<Monkey> monkeys)
    {
        Monkeys = monkeys;
    }

    public static List<Monkey> Monkeys { get; set; }

    public void Inspect()
    {
        foreach (var monkey in Monkeys)
        {
            while (monkey.ItemList.Any())
            {
                monkey.Inspect(monkey.ItemList.First());    
            }
        }
    }
}