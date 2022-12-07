using System.Text;

namespace AdventOfCode.Day07;

public class DirectoryNode
{
    public DirectoryNode()
    {
        FileName = "";
        Size = 0;
        DirectoryName = "";
        NodeType = NodeType.File;
    }
    
    public string FileName { get; init; }
    public long Size { get; set; }
    public string DirectoryName { get; init; }
    public NodeType NodeType { get; init; }
    public int Depth { get; set; }
    public TreeNode<DirectoryNode>? NodeLink { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder("");
        var tabs = "";

        for (int i = 0; i < Depth; i++)
        {
            tabs += "\t";
        }
        
        if (string.IsNullOrEmpty(DirectoryName) && string.IsNullOrEmpty(FileName))
        {
            result.AppendLine("- / (dir)");
        }
        if (NodeType == NodeType.Directory)
        {
            result.AppendLine($"{tabs}- {DirectoryName} (dir, size={Size})");    
        }
        if (NodeType == NodeType.File)
        {
            result.AppendLine($"{tabs}- {FileName} (file, size={Size})");    
        }

        return result.ToString();
    }
}

public enum NodeType
{
    File,
    Directory
}