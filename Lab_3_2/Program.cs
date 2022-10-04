public class Program
{
    public static void Main()
    {
        //ArrayOperations.StartOperations();

        BinaryTree<int> tree = new BinaryTree<int>();

        tree.Add(10);
        tree.Add(8);
        tree.Add(2);
        tree.Add(3);
        tree.Add(5);
        tree.Add(2);

        foreach (var item in tree)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine('\n');

        BinaryTree<Product> tree1 = new BinaryTree<Product>();

        //tree1.Add(new Product("Veal", 10, DateTime.Now, DateTime.Today));
        //tree1.Add(new Product("Copper wire", 15, DateTime.Now, DateTime.Today));
        //tree1.Add(new Product("PC", 6, DateTime.Now, DateTime.Today));

        foreach (var item in tree1)
        {
            Console.Write(item + "\n");
        }

        //Console.WriteLine("\n" + tree1.Length);
    }
}