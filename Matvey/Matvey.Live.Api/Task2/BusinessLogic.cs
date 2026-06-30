namespace Matvey.Live.Api.Task2
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>
            {
                new Order { Id = 1, Name = "Телефон", Status = "Create" },
                new Order { Id = 2, Name = "Ноутбук", Status = "Processing" },
                new Order { Id = 3, Name = "Планшет", Status = "Create" },
                new Order { Id = 4, Name = "Наушники", Status = "Completed" },
                new Order { Id = 5, Name = "Клавиатура", Status = "Create" },
                new Order { Id = 6, Name = "Монитор", Status = "Create" }
            };
        }

        public List<OrderDto> GetSortedOrders(OrderRequest request)  
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Запрос не может быть пустым");
            }

            if (request.Id != 1 && request.Id != -1)
            {
                throw new ArgumentException("Направление сортировки должно быть 1 (по возрастанию) или -1 (по убыванию)");
            }

            var query = _orders.Where(o => o.Status == "Create");

            query = request.Id == 1
                ? query.OrderBy(o => o.Id)
                : query.OrderByDescending(o => o.Id);

            return query.Select(o => new OrderDto  
            {
                Id = o.Id,
                Name = o.Name,
                Status = o.Status  
            }).ToList();
        }
    }
}