namespace Olga.Live.Api.Servises
{
    public class OrderService
    {
        private static readonly List<NewOrder> _orders = new();
        public List<NewOrder> GetAll()
        {
            return _orders;
        }
        public NewOrder Add(NewOrder order)
        {
            _orders.Add(order);
            return order;
        }
        public bool DeleteById(int id)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
                return false;

            _orders.Remove(order);
            return true;
        }
        public bool UpdateById(int id, OrderRequest request)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
                return false;

            order.Name = request.Name;
            order.Email = request.Email;

            return true;
        }
    }
}
