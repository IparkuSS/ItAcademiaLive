using DTO = Matvey.Live.Api.DTO;
using Matvey.Live.Api.Extensions;


public class LINQ8
{
    public void ExecuteAllLinqQueries()
    {
        var orders = new List<DTO.Order>
    {
        new DTO.Order { Id = Guid.NewGuid(), Status = DTO.OrderStatus.Pending, TotalAmount = 150.50m },
        new DTO.Order { Id = Guid.NewGuid(), Status = DTO.OrderStatus.Paid, TotalAmount = 200.00m },
        new DTO.Order { Id = Guid.NewGuid(), Status = DTO.OrderStatus.Paid, TotalAmount = 300.75m },
        new DTO.Order { Id = Guid.NewGuid(), Status = DTO.OrderStatus.Shipped, TotalAmount = 100.25m },
        new DTO.Order { Id = Guid.NewGuid(), Status = DTO.OrderStatus.Pending, TotalAmount = 50.00m }
    };

        var products = new List<DTO.Product>
    {
         new DTO.Product { Id = Guid.NewGuid(), Name = "Ноутбук", Sku = "SKU001", UpdatedAt = new DateTime(2024, 01, 15), Price = 1500.00m, CategoryId = 1, IsActive = true },
    new DTO.Product { Id = Guid.NewGuid(), Name = "Ноутбук Pro", Sku = "SKU001", UpdatedAt = new DateTime(2024, 02, 20), Price = 1600.00m, CategoryId = 1, IsActive = true },
    new DTO.Product { Id = Guid.NewGuid(), Name = "Мышь", Sku = "SKU002", UpdatedAt = new DateTime(2024, 01, 10), Price = 25.50m, CategoryId = 2, IsActive = true },
    new DTO.Product { Id = Guid.NewGuid(), Name = "Мышь Pro", Sku = "SKU002", UpdatedAt = new DateTime(2024, 03, 01), Price = 35.00m, CategoryId = 2, IsActive = true },
    new DTO.Product { Id = Guid.NewGuid(), Name = "Клавиатура", Sku = "SKU003", UpdatedAt = new DateTime(2024, 01, 05), Price = 45.00m, CategoryId = 2, IsActive = false },
    new DTO.Product { Id = Guid.NewGuid(), Name = "Монитор", Sku = "SKU004", UpdatedAt = new DateTime(2024, 02, 15), Price = 300.00m, CategoryId = 1, IsActive = true },
    new DTO.Product { Id = Guid.NewGuid(), Name = "Наушники", Sku = "SKU005", UpdatedAt = new DateTime(2024, 03, 10), Price = 80.00m, CategoryId = 3, IsActive = true },
    new DTO.Product { Id = Guid.NewGuid(), Name = "Колонки", Sku = "SKU006", UpdatedAt = new DateTime(2024, 01, 20), Price = 120.00m, CategoryId = 3, IsActive = false }
    };

        var targetGuid = orders.First().Id;

        bool hasPendingOrders = orders.Any(o => o.Status == DTO.OrderStatus.Pending);
        Console.WriteLine($"1. Есть ли заказы в статусе Pending: {hasPendingOrders}");

        DTO.Order foundOrder = orders.FirstOrDefault(o => o.Id == targetGuid);
        Console.WriteLine($"2. Найти заказ по Guid: {(foundOrder != null ? $"Найден (ID: {foundOrder.Id})" : "Не найден")}");

        int paidOrdersCount = orders.Count(o => o.Status == DTO.OrderStatus.Paid);
        Console.WriteLine($"3. Количество оплаченных заказов: {paidOrdersCount}");

        decimal totalSum = orders.Sum(o => o.TotalAmount);
        Console.WriteLine($"4. Общая сумма всех заказов: {totalSum:C}");

        List<int> uniqueCategoryIds = products
            .Select(p => p.CategoryId)
            .Distinct()
            .ToList();
        Console.WriteLine($"5. Уникальные CategoryId товаров: {string.Join(", ", uniqueCategoryIds)}");

        List<DTO.Product> sortedProducts = products
            .OrderBy(p => p.Price)
            .ToList();
        Console.WriteLine("6. Товары, отсортированные по возрастанию цены:");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"   - {product.Name}: {product.Price:C}");
        }

        List<DTO.ProductListItemDto> productDtos = products
            .Select(p => new DTO.ProductListItemDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            })
            .ToList();
        Console.WriteLine("7. ProductListItemDto:");
        foreach (var dto in productDtos)
        {
            Console.WriteLine($"   - ID: {dto.Id}, Name: {dto.Name}, Price: {dto.Price:C}");
        }

        List<DTO.Product> activeProducts = products
            .Where(p => p.IsActive)
            .ToList();
        Console.WriteLine("8. Активные товары:");
        foreach (var product in activeProducts)
        {
            Console.WriteLine($"   - {product.Name} (CategoryId: {product.CategoryId})");
        }

        var ordersByStatus = orders
    .GroupBy(o => o.Status)
    .Select(g => new
    {
        Status = g.Key,
        Count = g.Count(),
        TotalSum = g.Sum(o => o.TotalAmount)
    })
    .ToList();

        Console.WriteLine("9. Статистика по статусам заказов:");
        foreach (var item in ordersByStatus)
        {
            Console.WriteLine($"   - {item.Status}: {item.Count} шт., сумма: {item.TotalSum:C}");
        }

        var latestProductsBySku = products
       .OrderByDescending(p => p.UpdatedAt)  
       .DistinctBy(p => p.Sku)               
       .ToList();

        Console.WriteLine("10. Последние товары по каждому SKU:");
        foreach (var product in latestProductsBySku)
        {
            Console.WriteLine($"   - SKU: {product.Sku}, Name: {product.Name}, Updated: {product.UpdatedAt:yyyy-MM-dd}, Price: {product.Price:C}");
        }

        //11 Extension

        var paidOrders = orders.GetPaidOrdersList();
        Console.WriteLine($"   - Количество оплаченных заказов: {orders.GetPaidOrdersCount()}");
        Console.WriteLine($"   - Сумма оплаченных заказов: {orders.GetPaidOrdersTotalSum():C}");

        Console.WriteLine("   - Список оплаченных заказов:");
        foreach (var order in paidOrders)
        {
            Console.WriteLine($"     ID: {order.Id}, Сумма: {order.TotalAmount:C}");
        }
    }
}