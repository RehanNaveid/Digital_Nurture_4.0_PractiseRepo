using ECommercePlatformSearchFunction.Models;


namespace ECommercePlatformSearchFunction.Services
{
    public static class SearchService
    {
        public static Product? LinearSearch(Product[] products, string productName)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase))
                    return product;
            }
            return null;
        }

        public static Product? BinarySearch(Product[] products, string productName)
        {

             Array.Sort(products, (p1, p2) =>
                string.Compare(p1.ProductName, p2.ProductName, StringComparison.OrdinalIgnoreCase));

            int low = 0, high = products.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int comparison = string.Compare(products[mid].ProductName, productName, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0) return products[mid];
                else if (comparison < 0) low = mid + 1;
                else high = mid - 1;
            }
            return null;
        }
    }
}
