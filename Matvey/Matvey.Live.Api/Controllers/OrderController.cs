using Microsoft.AspNetCore.Mvc;

namespace Matvey.Live.Api.Serializ
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private static List<OrderDto> _orders = new List<OrderDto>();

        [HttpGet("orders")]
        public IActionResult GetAllOrders()
        {
            return Ok(_orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            var order = _orders.Find(o => o.OrderId == id);
            if (order == null)
                return NotFound($"Заказ с ID {id} не найден");

            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderDto newOrder)
        {

            if (string.IsNullOrEmpty(newOrder.CustomerName))
                return BadRequest("Имя клиента обязательно");

            if (newOrder.OrderId == Guid.Empty)
                newOrder.OrderId = Guid.NewGuid();

            if (newOrder.OrderDate == default)
                newOrder.OrderDate = DateTime.Now;

            _orders.Add(newOrder);

            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.OrderId }, newOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(Guid id, OrderDto updatedOrder)
        {
            var existingOrder = _orders.Find(o => o.OrderId == id);
            if (existingOrder == null)
                return NotFound($"Заказ с ID {id} не найден");

            // Обновляем поля
            existingOrder.CustomerName = updatedOrder.CustomerName;
            existingOrder.TotalAmount = updatedOrder.TotalAmount;
            existingOrder.OrderDate = updatedOrder.OrderDate;
            existingOrder.IsPaid = updatedOrder.IsPaid;

            return Ok(existingOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            var order = _orders.Find(o => o.OrderId == id);
            if (order == null)
                return NotFound($"Заказ с ID {id} не найден");

            _orders.Remove(order);
            return NoContent();
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var results = _orders.FindAll(o =>
                o.CustomerName.Contains(name, StringComparison.OrdinalIgnoreCase)
            );

            return Ok(results);
        }
    }
}

