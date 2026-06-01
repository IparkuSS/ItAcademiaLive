using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Matvey.Live.Api.Controllers
{

    namespace Matvey.Live.Api.Controllers
    {
        public class OrderItem
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        public class CreateOrderRequest
        {
            public OrderItem OrderItem { get; set; } = new();
            public string Email { get; set; } = string.Empty;
        }

        [Route("api/[controller]")]
        [ApiController]
        public class ProgrammController : ControllerBase
        {
            private static readonly Dictionary<string, OrderItem> _orderDictionary = new();

            [HttpPost("add")]
            public IActionResult Add(CreateOrderRequest request)
            {
                if (request == null)
                    return BadRequest(new { error = "Данные не предоставлены" });

                if (string.IsNullOrWhiteSpace(request.Email))
                    return BadRequest(new { error = "Email не может быть пустым" });

                if (request.OrderItem == null)
                    return BadRequest(new { error = "OrderItem не предоставлен" });

                if (request.OrderItem.Id <= 0)
                    return BadRequest(new { error = "Id должен быть больше 0" });

                if (string.IsNullOrWhiteSpace(request.OrderItem.Name))
                    return BadRequest(new { error = "Name не может быть пустым" });

                if (_orderDictionary.ContainsKey(request.Email))
                    return BadRequest(new { error = $"Email '{request.Email}' уже существует в словаре" });
     
                _orderDictionary.Add(request.Email, request.OrderItem);

                return Ok(new
                {
                    message = "Добавлено успешно",
                    email = request.Email,
                    orderItem = request.OrderItem
                });
            }
        }
    }
}


