//using Aleksandr.Live.Api.Domains;

//namespace Aleksandr.Live.Api.Services
//{
//    public class OrderService
//    {

//        private static readonly List<Order> _orders = new()
//        {
//            new Order (id: 2, name: "Иван", email:"ivan@gmail.com",isClosed: false),
//            new Order (3, "Петр", "petr@gmail.com", true),
//            new Order (1, "Евгений", "jack@gmail.com", true),
//        };

//        // Получить все заказы
//        public static List<Order> GetAll() => _orders.OrderBy(o => o.Id).ToList();

//        // Добавление
//        public bool AddOrder(Order order)
//        {
//            //var isOrder = _orders.FirstOrDefault(o => o.Id == order.Id);

//            if (CheckOrderExistById(order))
//            {
//                return false;
//            }

//            _orders.Add(order);

//            return true;

//        }

//        // Удаление
//        public bool Delete(int id)
//        {
//            var order = _orders.FirstOrDefault(o => o.Id == id);

//            if (order == null) return false;

//            _orders.Remove(order);

//            return true;
//        }

//        // Изменение
//        public bool Update(Order updatedOrder)
//        {
//            var order = _orders.FirstOrDefault(o => o.Id == updatedOrder.Id);

//            if (order == null) return false;

//            order.Id = updatedOrder.Id;
//            order.Name = updatedOrder.Name;
//            order.Email = updatedOrder.Email;

//            return true;
//        }
//        public bool CheckOrderExistById(Order order)
//        {
//            var isOrder = _orders.FirstOrDefault(o => o.Id == order.Id);

//            if (isOrder == null) return false;

//            return true;

//        }

//    }
//}
