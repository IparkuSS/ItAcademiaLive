using System.Text.RegularExpressions;
using Matvey.Live;
using Matvey.Live.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matvey.Live.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("createOrder")]
        public IActionResult CreateOrder(OrderRequest request)
        {
            
            if (!IsValidEmail(request.Email))
            {
                return BadRequest("Некорректный формат Email");
            }

            
            var order = _orderService.AddOrder(request);

            return Ok(order.ToString());
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            bool deleted = _orderService.DeleteOrder(id);

            if (!deleted)
            {
                return NotFound($"Заказ с ID {id} не найден");
            }

            return Ok($"Заказ с ID {id} успешно удалён");
        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateOrder(int id,OrderRequest request)
        {
            // Валидация Email
            if (!IsValidEmail(request.Email))
            {
                return BadRequest("Некорректный формат Email");
            }

            bool updated = _orderService.UpdateOrder(id, request);

            if (!updated)
            {
                return NotFound($"Заказ с ID {id} не найден");
            }

            var order = _orderService.GetOrderById(id);
            return Ok(order.ToString());
        }

        [HttpPost("all")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound($"Заказ с ID {id} не найден");
            }

            return Ok(order.ToString());
        }

        [HttpPost("open")]
        public IActionResult GetOpenOrders()
        {
            var orders = _orderService.GetOpenOrders();
            return Ok(orders);
        }

        [HttpPost("close/{id}")]
        public IActionResult CloseOrder(int id)
        {
            bool closed = _orderService.CloseOrder(id);

            if (!closed)
            {
                return NotFound($"Заказ с ID {id} не найден");
            }

            var order = _orderService.GetOrderById(id);
            return Ok(order.ToString());
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}