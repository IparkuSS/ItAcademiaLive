namespace Matvey.Live.Api.Services
{
   
    public class OrderService
    {
        private static List<Order> _orders = new List<Order>();
       
        private static int _nextId = 1;

        public Order AddOrder(OrderRequest request)
        {
            var order = new Order
            {
                Id = _nextId++,
                SecondName = "DefaultSecondName",
                Status = OrderStatus.Open,
                Name = request.Name,
                Email = request.Email
            };

            _orders.Add(order);
            return order;
        }

        public bool DeleteOrder(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return false;
            }

            return _orders.Remove(order);
        }

        public bool UpdateOrder(int id, OrderRequest request)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return false;
            }

            order.Name = request.Name;
            order.Email = request.Email;
            order.Status = OrderStatus.InProgress; 

            return true;
        }

        public List<Order> GetAllOrders()
        {
            return _orders.ToList(); 
        }


        public Order GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

 
        public List<Order> GetOpenOrders()
        {
            return _orders.Where(o => o.Status != OrderStatus.Closed).ToList();
        }

        public bool CloseOrder(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return false;
            }

            order.Status = OrderStatus.Closed;
            return true;
        }
    }
}

