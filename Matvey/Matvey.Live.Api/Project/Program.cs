//using Matvey.Live.Api.Project.Repositories;
//using Matvey.Live.Api.Project.Models;

//namespace Matvey.Live.Api.Project
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("=== GENERIC REPOSITORY DEMO ===\n");

//            var productRepo = new ProductRepository();
//            var orderRepo = new OrderRepository();

//            Console.WriteLine("--- PRODUCTS ---");

//            productRepo.Add(new Product { Name = "Laptop", Price = 1200.99m, Stock = 10 });
//            productRepo.Add(new Product { Name = "Mouse", Price = 29.99m, Stock = 50 });
//            productRepo.Add(new Product { Name = "Keyboard", Price = 89.99m, Stock = 0 });

//            Console.WriteLine("\nAll products:");
//            foreach (var p in productRepo.GetAll())
//                Console.WriteLine($"  {p}");

//            Console.WriteLine("\nProducts in stock:");
//            foreach (var p in productRepo.GetInStock())
//                Console.WriteLine($"  {p}");

//            var laptop = productRepo.GetById(1);
//            if (laptop != null)
//            {
//                laptop.Price = 999.99m;
//                productRepo.Update(laptop);
//            }

//            Console.WriteLine($"\nAfter update: {productRepo.GetById(1)}");
//            productRepo.ReduceStock(1, 2);

//            Console.WriteLine("\n--- ORDERS ---");

//            orderRepo.Add(new Order
//            {
//                OrderNumber = "ORD-001",
//                OrderDate = DateTime.Now.AddDays(-5),
//                TotalAmount = 1500.50m,
//                SecondName = "Doe",              
//                Email = "john.doe@mail.com"      
//            });

//            orderRepo.Add(new Order
//            {
//                OrderNumber = "ORD-002",
//                OrderDate = DateTime.Now.AddDays(-2),
//                TotalAmount = 49.99m,
//                SecondName = "Smith",            
//                Email = "jane.smith@mail.com"    
//            });

//            Console.WriteLine("\nAll orders:");
//            foreach (var o in orderRepo.GetAll())
//                Console.WriteLine($"  {o}");

//            Console.WriteLine("\nOrders by customer 'Doe':");
//            foreach (var o in orderRepo.GetByCustomer("Doe"))
//                Console.WriteLine($"  {o}");

//            Console.WriteLine($"\nTotal revenue: {orderRepo.GetTotalRevenue():C}");

//            Console.WriteLine("\nOrders above $100:");
//            foreach (var o in orderRepo.GetOrdersAbove(100))
//                Console.WriteLine($"  {o}");

//            Console.WriteLine("\n--- GENERIC METHODS ---");
//            Console.WriteLine($"Total products: {productRepo.Count()}");
//            Console.WriteLine($"Total orders: {orderRepo.Count()}");

//            int productId = 1;
//            Console.WriteLine($"Product exists (Id={productId}): {productRepo.Exists(productId)}");

//            int missingId = 999;
//            Console.WriteLine($"Product exists (Id={missingId}): {productRepo.Exists(missingId)}");

//            Console.WriteLine("\nDeleting product with Id=3...");
//            productRepo.Delete(3);
//            Console.WriteLine($"Total products after delete: {productRepo.Count()}");

//            Console.WriteLine("\n=== DEMO COMPLETED ===");
//        }
//    }
//}
