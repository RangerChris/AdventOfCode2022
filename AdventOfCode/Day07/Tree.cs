using System.Collections.ObjectModel;

namespace AdventOfCode.Day07;

public class TreeNode<T>
{
    private readonly List<TreeNode<T>> _children = new();

    public TreeNode(T value)
    {
        Value = value;
    }

    public TreeNode<T> this[int i] => _children[i];

    public TreeNode<T> Parent { get; private set; }

    public T Value { get; }

    public ReadOnlyCollection<TreeNode<T>> Children => _children.AsReadOnly();

    public TreeNode<T> AddChild(T value)
    {
        var node = new TreeNode<T>(value) {Parent = this};
        _children.Add(node);
        return node;
    }

    public TreeNode<T>[] AddChildren(params T[] values)
    {
        return values.Select(AddChild).ToArray();
    }

    public bool RemoveChild(TreeNode<T> node)
    {
        return _children.Remove(node);
    }

    public void Traverse(Action<T> action)
    {
        action(Value);
        foreach (var child in _children)
            child.Traverse(action);
    }

    public IEnumerable<T> Flatten()
    {
        return new[] {Value}.Concat(_children.SelectMany(x => x.Flatten()));
    }

    public TreeNode<T> InsertChild(TreeNode<T> parent, T value)
    {
        var node = new TreeNode<T>(value) {Parent = parent};
        parent._children.Add(node);
        return node;
    }

    public int GetDepth()
    {
        var depth = 0;

        var currentNode = this;
        while (currentNode.Parent != null)
        {
            currentNode = currentNode.Parent;
            depth++;
        }
        
        return depth;
    }
}