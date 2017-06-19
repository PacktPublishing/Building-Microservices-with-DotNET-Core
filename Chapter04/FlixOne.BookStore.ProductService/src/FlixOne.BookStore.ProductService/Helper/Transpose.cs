using System.Collections.Generic;
using System.Linq;
using FlixOne.BookStore.ProductService.Models;

namespace FlixOne.BookStore.ProductService.Helper
{
    public static class Transpose
    {
        public static ProductViewModel ToViewModel(this Product model)
        {
            return new ProductViewModel
            {
                CategoryId = model.CategoryId,
                CategoryDescription = model.Category.Description,
                CategoryName = model.Category.Name,
                ProductDescription = model.Description,
                ProductId = model.Id,
                ProductImage = model.Image,
                ProductName = model.Name,
                ProductPrice = model.Price
            };
        }
        public static Product ToProductModel(this ProductViewModel productvm)
        {
            return new Product
            {
                CategoryId = productvm.CategoryId,
                Description = productvm.ProductDescription,
                Id = productvm.ProductId,
                Name = productvm.ProductName,
                Price = productvm.ProductPrice
            };
        }

       
    }

    namespace System.Collections.Generic
    {
        public static class Transpose
        {
            public static IEnumerable<ProductViewModel> ToViewModel(this IEnumerable<Product> modelList)
            {
                return modelList.Select(product => product.ToViewModel()).ToList();
            }
        }
    }
}