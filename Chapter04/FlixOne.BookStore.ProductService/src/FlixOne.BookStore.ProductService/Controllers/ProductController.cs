using System;
using System.Linq;
using FlixOne.BookStore.ProductService.Helper;
using FlixOne.BookStore.ProductService.Models;
using FlixOne.BookStore.ProductService.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.BookStore.ProductService.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult Get()
        {
            var productvm = _productRepository.GetAll().ToList();
            return new OkObjectResult(productvm);
        }

        [HttpGet]
        [Route("product/{productid}")]
        public IActionResult Get(string productId)
        {
            var productModel = _productRepository.GetBy(new Guid(productId));

            return new OkObjectResult(productModel);
        }

        [HttpPost]
        [Route("addproduct")]
        public IActionResult Post([FromBody] ProductViewModel productvm)
        {
            if (productvm == null)
                return BadRequest();
            var productModel = productvm.ToProductModel();
            _productRepository.Add(productModel);

            return StatusCode(201, Json(true));
        }

        [HttpPut]
        [Route("updateproduct/{productid}")]
        public IActionResult Update(string productid, [FromBody] ProductViewModel productvm)
        {
            var productId = new Guid(productid);
            if (productvm == null || productvm.ProductId != productId)
                return BadRequest();

            var product = _productRepository.GetBy(productId);
            if (product == null)
                return NotFound();

            product.Name = productvm.ProductName;
            product.Description = productvm.ProductDescription;
            _productRepository.Update(product);
            return new NoContentResult();
        }

        [HttpDelete]
        [Route("deleteproduct/{productid}")]
        public IActionResult Delete(string productid)
        {
            var productId = new Guid(productid);
            var product = _productRepository.GetBy(productId);
            if (product == null)
                return NotFound();

            _productRepository.Remove(productId);
            return new NoContentResult();
        }
    }
}