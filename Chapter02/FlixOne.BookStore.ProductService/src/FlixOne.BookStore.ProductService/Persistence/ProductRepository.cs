using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.BookStore.ProductService.Contexts;
using FlixOne.BookStore.ProductService.Models;

namespace FlixOne.BookStore.ProductService.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetBy(Guid id)
        {
           return  _context.Find<Product>(id);
        }

        public void Remove(Guid id)
        {
            var product = GetBy(id);
            _context.Remove(product);
        }

        public void Update(Product product)
        {
           _context.Update(product);
        }
    }
}