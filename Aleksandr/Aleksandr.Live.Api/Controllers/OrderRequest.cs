using Microsoft.AspNetCore.Mvc;

namespace Aleksandr.Live.Api.Controllers
{
    public record OrderRequest(string Name, string Email);
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsClosed { get; set; }
        public Order(int id, string name, string email, bool isClosed)
        {
            Id = id;
            Name = name;
            Email = email;
            IsClosed = isClosed;
        }
        public string ToString()
        {
            return IsClosed
                ? $"Order ID: {Id}"
                : $"Order Details - Name: {Name}, Email: {Email}";
        }

    }

    [Route("api/[controller]")]

    [ApiController]
    public class OrderController : ControllerBase
    {
        
        [HttpPost("process")]
        public ActionResult<string> CreateOrder([FromBody] OrderRequest request)
        {
            // Принимаем Name и Email из JSON, остальные поля вручную
            var myOrder = new Order(
                id: 101,
                name: request.Name,
                email: request.Email,
                isClosed: false // Статус вручную
            );

            return Ok(myOrder.ToString());

        }
    }
}





