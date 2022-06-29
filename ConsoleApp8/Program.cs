public class Node<T>
{
    public T Value { get; set; }

    public Node<T> LeftChild { get; set; }

    public Node<T> RightChild { get; set; }

    public Node(T value, Node<T> leftChild, Node<T> rightChild)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }
}



public class BinarySearchTree<T> : IAbstractBinarySearchTree<T> where T : IComparable
{
    public BinarySearchTree()
    {
    }

    public BinarySearchTree(Node<T> root)
    {
        this.Root = root;
        this.LeftChild = root.LeftChild;
        this.RightChild = root.RightChild;
    }

    public Node<T> Root { get; private set; }

    public Node<T> LeftChild { get; private set; }

    public Node<T> RightChild { get; private set; }

    public T Value => this.Root.Value;

    public bool Contains(T element)
    {
        var current = this.Root;
        while (current != null)
        {
            if (element.CompareTo(current.Value) < 0)
            {
                current = current.LeftChild;
            }
            else if (element.CompareTo(current.Value) > 0)
            {
                current = current.RightChild;
            }
            else
            {
                break;
            }
        }

        return current != null;
    }

    public void Insert(T element)
    {
        var newElement = new Node<T>(element, null, null);

        if (this.Root == null)
        {
            this.Root = newElement;
        }
        else
        {
            var childElement = this.Root;
            Node<T> parentElement = null;

            while (childElement != null)
            {
                parentElement = childElement;

                if (newElement.Value.CompareTo(childElement.Value) < 0)
                {
                    childElement = childElement.LeftChild;
                }
                else if (newElement.Value.CompareTo(childElement.Value) > 0)
                {
                    childElement = childElement.RightChild;
                }
                else
                {
                    return;
                }
            }

            if (parentElement.Value.CompareTo(newElement.Value) < 0)
            {
                parentElement.RightChild = newElement;
            }
            else
            {
                parentElement.LeftChild = newElement;
            }
        }
    }

    public IAbstractBinarySearchTree<T> Search(T element)
    {
        var current = this.Root;

        while (current != null)
        {
            if (element.CompareTo(current.Value) < 0)
            {
                current = current.LeftChild;
            }
            else if (element.CompareTo(current.Value) > 0)
            {
                current = current.RightChild;
            }
            else
            {
                break;
            }
        }

        return new BinarySearchTree<T>(current);
    }

    public ICollection<T> OrderBfs()
    {
        var result = new List<T>();
        var queue = new Queue<Node<T>>();
        queue.Enqueue(this.Root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            result.Add(node.Value);
            if (node.LeftChild != null) queue.Enqueue(node.LeftChild);
            if (node.RightChild != null) queue.Enqueue(node.RightChild);
        }

        return result;
    }

    public ICollection<T> OrderDfs()
    {
        var order = new List<T>();
        Dfs(this.Root, order);
        return order;
    }

    private void Dfs(Node<T> node, ICollection<T> order)
    {
        if (node.LeftChild != null) Dfs(node.LeftChild, order);
        if (node.RightChild != null) Dfs(node.RightChild, order);
        order.Add(node.Value);
    }
}




public interface IAbstractBinarySearchTree<T> where T: IComparable
{
    //Вставка элемента
    void Insert(T element);
    //Содержит ли дерево данный элемент?
    bool Contains(T element);
    //Поиск
    IAbstractBinarySearchTree<T> Search(T element);
    //Корень дерева/поддерева
    Node<T> Root { get;  }
    //Дочерний элемент слева
    Node<T> LeftChild { get;  }
    //Дочерний элемент справа
    Node<T> RightChild { get; }
    //Значение
    T Value { get; }
    ICollection<T> OrderBfs();
    ICollection<T> OrderDfs();
}











public static class TreePrinter<T> where T: IComparable
{
    static readonly int COUNT = 10;  
    private static void Print(Node<T> root, int space)  
    {  
        if (root == null)  
            return;  
        space += COUNT;  

        Print(root.RightChild, space);  

        Console.Write("\n");  
        for (int i = COUNT; i < space; i++)  
            Console.Write(" ");  
        Console.Write(root.Value + "\n");  

        Print(root.LeftChild, space);  
    }
    
    public static void Print(IAbstractBinarySearchTree<T> tree)  
    {  
        Print(tree.Root, 0);  
    }
}





class Program
{
    static void Main(string[] args)
    {
        IAbstractBinarySearchTree<int> bst = new BinarySearchTree<int>();
        bst.Insert(13);
        bst.Insert(19);
        bst.Insert(6);
        bst.Insert(2);
        bst.Insert(8);
        bst.Insert(17);
        bst.Insert(23);
        var bfs = bst.OrderBfs();
        foreach (var i in bfs)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("******");
        var dfs = bst.OrderDfs();
        foreach (var i in dfs)
        {
            Console.WriteLine(i);
        }
        TreePrinter<int>.Print(bst);
    }
}

