using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FlixOne.BookStore.ProductService.Contexts;
using FlixOne.BookStore.ProductService.Models;
using FlixOne.BookStore.ProductService.Persistence;

namespace FlixOne.BookStore.ProductService.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository(new ProductContext());
        }
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var observable = _productRepository.GetAll();
            var arrayResult = observable.SelectMany(p => p).ToArray();
            return await arrayResult;
        }
    }
}