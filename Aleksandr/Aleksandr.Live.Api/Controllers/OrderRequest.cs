using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aleksandr.Live.Api.Controllers
{
    public record OrderRequest(string Name, string Email);
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private readonly string _email;

        public string Email
        {
            get;

            init => _email = IsValidEmail(value) ? value : throw new ArgumentException("Email должен содержать символ @");
        }
        private bool IsValidEmail(string email) => !string.IsNullOrWhiteSpace(email) && email.Contains("@");
        public bool IsClosed { get; set; }
        public Order(int id, string name, string email, bool isClosed)
        {
            Id = id;
            Name = name;
            Email = email;
            IsClosed = isClosed;
        }
        public override string ToString()
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





