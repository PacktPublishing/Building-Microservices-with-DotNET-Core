using System;

namespace ProductServiceClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new ProductServiceClient {BaseUri = new Uri("http://localhost:22651/")};
            var products = client.Product.Get();
            Console.WriteLine($"Total count {products.Count}");
            foreach (var product in products)
            {
                Console.WriteLine($"ProductId:{product.Id},Name:{product.Name}");
            }
            Console.Write("Press any key to continue ....");
            Console.ReadLine();
        }
    }
}