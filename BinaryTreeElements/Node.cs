using System.Collections;

public class Node<T> : IEnumerable where T : IComparable
{
    public T Data { get; private set; }

    public Node<T> ?RightNode { get; set; }
    public Node<T> ?LeftNode { get; set; }

    public Node()
    {
        Data = default;
        RightNode = null;
        LeftNode = null;
    }

    public Node(T data)
    {
        Data = data;
    }

    public Node(T data, Node<T> rightNode, Node<T> leftNode)
    {
        Data = data;
        RightNode = rightNode;
        LeftNode = leftNode;
    }

    public int CompareTo(T other)
    {
        return Data.CompareTo(other);
    }

    public override string ToString()
    {
        return String.Format($"Node data: {(dynamic)Data}");
    }

    public IEnumerator GetEnumerator()
    {
        yield return Data;
    }
}
