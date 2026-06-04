using Aleksandr.Live.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace Aleksandr.Live.Api.Controllers
{
    //public record OrderRequest(int Id, string Name, string Email);
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private string _email;
        public string Email
        {
            get => _email;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email не может быть пустым.");

                // Выражение для проверки базового формата email
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                // Проверка с использованием регулярного выражения
                if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException($"Некорректный формат email: {value}");
                }

                _email = value;

            }
        }
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
        public ActionResult<string> CreateOrder([FromBody] Order request)
        {
            // Принимаем Name и Email из JSON, остальные поля вручную
            var myOrder = new Order(
                id: request.Id,
                name: request.Name,
                email: request.Email,
                isClosed: false // Статус вручную
            );

            OrderService orderService = new OrderService();

            if (orderService.AddOrder(myOrder))
            {
                return Ok($"Odrer added: {myOrder.ToString()}");
            }
            else
            {
                return BadRequest($"Order with id {myOrder.Id} allready exist!");
            }
        }

        [HttpGet("process")]
        public ActionResult GetOrder()
        {
            OrderService orderService = new OrderService();

            return Ok(orderService.GetAll());
        }

        [HttpDelete("process")]
        public ActionResult RemoveOrder([FromBody] int id)
        {
            OrderService orderService = new OrderService();

            var isSuccess = orderService.Delete(id);

            return Ok("Remaoved!");
        }

        [HttpPut("process")]
        public ActionResult EditOrder([FromBody] Order request)
        {
            OrderService order = new OrderService();
            var myOrder = new Order(
                id: request.Id,
                name: request.Name,
                email: request.Email,
                isClosed: false // Статус вручную
            );

            if (order.Update(myOrder))
            {
                return Ok("Update successs!");
            }
            else
            {
                return BadRequest($"Order with id: {myOrder.Id} didn`t find.");
            }
            
        }
    }
}

//}
//"id": 111,
//"name": "Иван",                    JSON запрос
//"email": "ivan@example.com"
//}




