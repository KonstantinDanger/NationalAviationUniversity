using System.Collections;

public class ArrayOperations
{
    public static void StartOperations()
    {
        List<Product> list = new List<Product>();
        ArrayList arrayList = new ArrayList();
        Product[] array = new Product[] {};

        Product iron = new Product("Iron", 1, DateTime.Now, DateTime.Today);
        Product wheat = new Product("Wheat", 2, DateTime.Now, DateTime.Today);
        Product silk = new Product("Silk", 3, DateTime.Now, DateTime.Today);

        list.Add(iron);
        arrayList.Add(wheat);
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = silk;

        list.Remove(iron);
        arrayList.Remove(wheat);
        array[0] = null;
        Array.Resize(ref array, array.Length - 1);

        list.Add(iron);
        list.Add(iron);

        arrayList.Add(wheat);
        arrayList.Add(wheat);

        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = iron;
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = silk;

        Console.WriteLine(list[0]);
        Console.WriteLine(arrayList[0]);
        Console.WriteLine(array[1] + "\n");

        foreach (Product product in list)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine('\n');

        foreach (Product product in arrayList)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine('\n');

        foreach (Product product in array)
        {
            Console.WriteLine(product);
        }
    }
}

