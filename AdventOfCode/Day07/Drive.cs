using System.Text;

namespace AdventOfCode.Day07;

public class Drive
{
    public TreeNode<DirectoryNode> DriveRoot { get; } = new TreeNode<DirectoryNode>(new DirectoryNode {DirectoryName = "/", NodeType = NodeType.Directory});

    public void BuildDirectoryStructure(string input)
    {
        input = input.Replace("$ cd /", "");
        input = input.Replace("$ ls", "");
        var currentTreeNode = DriveRoot;
        foreach (var currentInput in input.Split(Environment.NewLine))
        {
            DirectoryNode newNode;
            var command = currentInput.Trim();
            if (string.IsNullOrEmpty(command))
            {
                continue;
            }

            if (command.StartsWith("dir"))
            {
                var addDirectory = command.Split(" ");
                newNode = new DirectoryNode { DirectoryName = addDirectory[1], NodeType = NodeType.Directory };
                newNode.NodeLink = currentTreeNode?.AddChild(newNode);
                continue;
            }
            if (command.Equals("$ cd .."))
            {
                if (currentTreeNode?.Parent == null)
                {
                    currentTreeNode = DriveRoot;
                    continue;
                }
                
                currentTreeNode = currentTreeNode.Parent;
                continue;
            }
            if (command.StartsWith("$ cd"))
            {
                DirectoryNode? node = null;
                var changeDirectory = command.Split(" ");
                node = currentTreeNode.Children.SingleOrDefault(c => c.Value.DirectoryName.Equals(changeDirectory[2])).Value;

                if (node != null)
                {
                    currentTreeNode = node.NodeLink;
                    if (currentTreeNode != null)
                    {
                        currentTreeNode.Value.Depth = currentTreeNode.GetDepth();
                    }
                }
                
                continue;
            }

            var file = command.Split(" ");
            newNode = new DirectoryNode { Size = Convert.ToInt64(file[0]), FileName = file[1], NodeType = NodeType.File};
            newNode.NodeLink = currentTreeNode?.AddChild(newNode);
            if (newNode.NodeLink != null)
            {
                newNode.Depth = newNode.NodeLink.GetDepth();
                newNode.NodeLink.Parent.Value.Size = GetSize(newNode.NodeLink.Parent);
            }
        }
    }

    private long GetSize(TreeNode<DirectoryNode> treeNode)
    {
        if (treeNode != null)
        {
            var totalSize = treeNode.Flatten().Where(c => c.NodeType == NodeType.File).Sum(d => d.Size);
            return totalSize;
        }

        return 0;
    }

    public string PrintDirectoryStructure()
    {
        var result = new StringBuilder("");
        
        var treeStructure = DriveRoot.Flatten();
        foreach (var node in treeStructure)
        {
            result.Append(node);
        }
        return result.ToString();
    }

    public void CalculateSize()
    {
        var treeStructure = DriveRoot.Flatten();
        foreach (var node in treeStructure)
        {
            node.Size = GetSize(node.NodeLink);
        }

        DriveRoot.Value.Size = GetSize(DriveRoot);
    }
}