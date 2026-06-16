using System;
using System.Collections.Generic;
using System.Linq;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public int StockQuantity { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Price: {Price:C}, Category: {Category}, Stock: {StockQuantity}";
    }
}

public interface IProductReader
{
    Product GetProductById(int id);
    IEnumerable<Product> GetAllProducts();
    bool ProductExists(int id);
}

public class ProductRepository : IProductReader
{
    private readonly List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Ноутбук", Price = 999.99m, Category = "Электроника", StockQuantity = 10 },
            new Product { Id = 2, Name = "Смартфон", Price = 599.50m, Category = "Электроника", StockQuantity = 25 },
            new Product { Id = 3, Name = "Наушники", Price = 149.99m, Category = "Аудио", StockQuantity = 50 },
            new Product { Id = 4, Name = "Клавиатура", Price = 89.99m, Category = "Периферия", StockQuantity = 30 },
            new Product { Id = 5, Name = "Мышь", Price = 39.99m, Category = "Периферия", StockQuantity = 45 }
        };
    }

    public ProductRepository(List<Product> products)
    {
        _products = products ?? new List<Product>();
    }

    public Product GetProductById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            throw new ArgumentException($"Товар с ID {id} не найден");
        }

        return product;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _products.AsReadOnly();
    }

    public bool ProductExists(int id)
    {
        return _products.Any(p => p.Id == id);
    }
}