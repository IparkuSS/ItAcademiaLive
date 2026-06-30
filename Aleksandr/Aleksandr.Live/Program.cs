namespace Aleksandr.Live
{
    class Program
    {
        static void Main()
        {

            Guid sampleGuid = Guid.NewGuid();

            List<Order> orders = new List<Order>
            {
                new Order { Id = sampleGuid, Status = "Paid", TotalAmount = 150.50m },
                new Order { Id = Guid.NewGuid(), Status = "Pending", TotalAmount = 99.00m },
                new Order { Id = Guid.NewGuid(), Status = "Paid", TotalAmount = 450.00m },
                new Order { Id = Guid.NewGuid(), Status = "Cancelled", TotalAmount = 20.00m }
            };

            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Ноутбук", Price = 1200m, CategoryId = 1, IsActive = true },
                new Product { Id = 2, Name = "Мышь", Price = 25m, CategoryId = 2, IsActive = true },
                new Product { Id = 3, Name = "Клавиатура", Price = 45m, CategoryId = 2, IsActive = false },
                new Product { Id = 4, Name = "Монитор", Price = 300m, CategoryId = 1, IsActive = true }
            };

            Console.WriteLine("--- ЗАКАЗЫ ---");

            // Задача 1: Есть ли заказы в статусе Pending
            bool hasPendingOrders = orders.Any(o => o.Status == "Pending");
            Console.WriteLine($"Заказы Pending: {hasPendingOrders}");

            // Задача 2: Найти заказ по Guid или вернуть null
            Order foundOrder = orders.FirstOrDefault(o => o.Id == sampleGuid);
            Console.WriteLine($"Заказ по GUID найден: {foundOrder != null}");

            // Задача 3: Сколько оплаченных заказов
            int paidOrdersCount = orders.Count(o => o.Status == "Paid");
            Console.WriteLine($"Количество оплаченных заказов: {paidOrdersCount}");

            // Задача 4: Общая сумма всех заказов
            decimal totalSum = orders.Sum(o => o.TotalAmount);
            Console.WriteLine($"Общая сумма всех заказов: {totalSum:C}");

            Console.WriteLine("\n--- ТОВАРЫ ---");

            // Задача 5: Список уникальных CategoryId товаров
            var uniqueCategoryIds = products.Select(p => p.CategoryId).Distinct().ToList();
            Console.WriteLine($"Уникальные CategoryId: {string.Join(", ", uniqueCategoryIds)}");

            // Задача 6: Отсортировать товары по возрастанию цены
            var sortedProducts = products.OrderBy(p => p.Price).ToList();
            Console.WriteLine("Товары по возрастанию цены:");
            foreach (var p in sortedProducts)
            {
                Console.WriteLine($" - {p.Name}: {p.Price:C}");
            }

            // Задача 7: Получить список ProductListItemDto с полями Id, Name, Price
            List<ProductListItemDto> productDtos = products.Select(p => new ProductListItemDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
            Console.WriteLine($"Создано DTO объектов: {productDtos.Count}");

            // Задача 8: Вернуть все активные товары из каталога
            var activeProducts = products.Where(p => p.IsActive).ToList();
            Console.WriteLine($"Количество активных товаров: {activeProducts.Count}");
        }

    }

}