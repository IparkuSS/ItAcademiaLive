namespace Matvey.Live.Api.Task2
{
    public interface IOrderService
    {
        List<OrderDto> GetSortedOrders(OrderRequest request);
    }
}
