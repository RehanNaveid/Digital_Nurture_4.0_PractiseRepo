using ECommercePlatformSearchFunction.Models;
using ECommercePlatformSearchFunction.Services;

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Shoes", "Fashion"),
            new Product(3, "Book", "Education"),
            new Product(4, "Mobile", "Electronics")
        };

        Console.WriteLine("--- Linear Search ---");
        var result1 = SearchService.LinearSearch(products, "Book");
        Console.WriteLine(result1 != null ? $"Found: {result1.ProductName}" : "Not Found");

        Console.WriteLine("\n--- Binary Search ---");
        var result2 = SearchService.BinarySearch(products, "Mobile");
        Console.WriteLine(result2 != null ? $"Found: {result2.ProductName}" : "Not Found");
    }
}
