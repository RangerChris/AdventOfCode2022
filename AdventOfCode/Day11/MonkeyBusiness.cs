namespace AdventOfCode.Day11;

public class MonkeyBusiness
{
    public MonkeyBusiness(List<Monkey> monkeys)
    {
        Monkeys = monkeys;
    }

    public static List<Monkey> Monkeys { get; set; }

    public void Inspect(bool worry)
    {
        foreach (var monkey in Monkeys)
        {
            while (monkey.ItemList.Any())
            {
                monkey.Inspect(monkey.ItemList.First(), worry);    
            }
        }
    }

    public int GetMonkeyBusiness()
    {
        var badMonkeyList = MonkeyBusiness.Monkeys.OrderByDescending(c=>c.InspectCount).ToList();
        var monkeyBusiness = badMonkeyList[0].InspectCount * badMonkeyList[1].InspectCount;
        return monkeyBusiness;
    }
}