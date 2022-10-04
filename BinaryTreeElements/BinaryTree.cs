using System.Collections;

public class BinaryTree<T> : IEnumerable<T> where T : IComparable
{
    private Node<T> root;
    public int Length { get; private set; }

    public void Add(T data)
    {
        Node<T> prev = null; 
        Node<T> next = root; 

        while(next != null)
        {
            prev = next;

            if(root.Data.CompareTo(data) > 0)
            {
                next = next.RightNode;
            }
            else if(root.Data.CompareTo(data) < 0)
            {
                next = next.LeftNode;
            }
            else
            {
                return;
            }
        }

        Node<T> newNode = new Node<T>(data);
        
        if(root == null)
        {
            root = newNode;
        }
        else
        {
            if(root.Data.CompareTo(data) > 0)
            {
                prev.RightNode = newNode;
            }
            else if(root.Data.CompareTo(data) < 0)
            {
                prev.LeftNode = newNode;
            }
            else
            {
                return;
            }
        }

        Length++;
    }

    public void Add(params T[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            Add(data[i]);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return PreOrder(root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<T> PreOrder(Node<T> node)
    {
        if (node != null)
        {
            yield return node.Data;
        }
        else
        {
            yield break;
        }

        foreach (var leftNode in PreOrder(node.LeftNode))
        {
            yield return leftNode;
        }

        foreach (var rightNode in PreOrder(node.RightNode))
        {
            yield return rightNode;
        }
    }
}
