using System;
using System.Collections.Generic;
using Matvey.Live.Api.Models;

namespace Matvey.Live.Api.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; }

        public static ProductDto FromProduct(Product product)
        {
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                StockQuantity = product.StockQuantity
            };
        }

        public Product ToProduct()
        {
            return new Product
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                Category = this.Category,
                StockQuantity = this.StockQuantity
            };
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}, Category: {Category}, Stock: {StockQuantity}";
        }
    }

    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Name = this.Name,
                Price = this.Price,
                Category = this.Category,
                StockQuantity = this.StockQuantity
            };
        }
    }

    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                Category = this.Category,
                StockQuantity = this.StockQuantity
            };
        }
    }
}