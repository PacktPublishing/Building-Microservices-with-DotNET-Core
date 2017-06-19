using System.Data.Entity;
using FlixOne.BookStore.ProductService.Models;

namespace FlixOne.BookStore.ProductService.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=ProductDBConnectionString")
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}