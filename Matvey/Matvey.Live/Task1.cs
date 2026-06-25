using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
}

class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>
        {
            new Order { Id = 1, Name = "Телефон", Status = "Create" },
            new Order { Id = 2, Name = "Ноутбук", Status = "Processing" },
            new Order { Id = 3, Name = "Планшет", Status = "Create" },
            new Order { Id = 4, Name = "Наушники", Status = "Completed" },
            new Order { Id = 5, Name = "Клавиатура", Status = "Create" }
        };

        List<string> names = orders
            .Where(o => o.Status == "Create")
            .OrderBy(o => o.Name)      
            .Select(o => o.Name)
            .ToList();

        Console.WriteLine($"Всего заказов: {orders.Count}");
        Console.WriteLine($"Заказов со статусом 'Create': {names.Count}");
        Console.WriteLine("\nИмена заказов со статусом 'Create':");

        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {names[i]}");
        }
    }
}