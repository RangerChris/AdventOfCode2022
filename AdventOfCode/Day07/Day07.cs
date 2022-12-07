using FluentAssertions;
using Xunit.Abstractions;

namespace AdventOfCode.Day07;

public class Day07
{
    private readonly ITestOutputHelper _testOutputHelper;
    private static string DataPath => Path.Combine(Directory.GetCurrentDirectory(), "Day07\\Input.txt");

    public Day07(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Day07Hint1Test()
    {
        const string input = @"
                            $ cd /
                            $ ls
                            dir a
                            14848514 b.txt
                            8504156 c.dat
                            dir d
                            $ cd a
                            $ ls
                            dir e
                            29116 f
                            2557 g
                            62596 h.lst
                            $ cd e
                            $ ls
                            584 i
                            $ cd ..
                            $ cd ..
                            $ cd d
                            $ ls
                            4060174 j
                            8033020 d.log
                            5626152 d.ext
                            7214296 k";

        var drive = new Drive();
        drive.BuildDirectoryStructure(input);
        drive.CalculateSize();
        _testOutputHelper.WriteLine(drive.PrintDirectoryStructure());

        var dirE = drive.DriveRoot.Flatten().Single(c => c.DirectoryName.Equals("e"));
        dirE.Size.Should().Be(584);
        
        var dirA = drive.DriveRoot.Flatten().Single(c => c.DirectoryName.Equals("a"));
        dirA.Size.Should().Be(94853);
        
        var dirD = drive.DriveRoot.Flatten().Single(c => c.DirectoryName.Equals("d"));
        dirD.Size.Should().Be(24933642);
        
        var dirRoot = drive.DriveRoot.Flatten().Single(c => c.DirectoryName.Equals("/"));
        dirRoot.Size.Should().Be(48381165);
    }

    [Fact]
    public async Task Day07Puzzle1Test()
    {
        var input = await File.ReadAllTextAsync(DataPath);
        var drive = new Drive();
        drive.BuildDirectoryStructure(input);
        drive.CalculateSize();
        
        _testOutputHelper.WriteLine(drive.PrintDirectoryStructure());
        
        var dirRoot = drive.DriveRoot.Flatten().Single(c => c.DirectoryName.Equals("/"));
        dirRoot.Size.Should().Be(47052440);

        var puzzle1Answer = drive.DriveRoot.Flatten().Where(c => c.Size <= 100000 && c.NodeType == NodeType.Directory).Sum(c=>c.Size);
        puzzle1Answer.Should().Be(1232307);
    }
}