using System.Text.RegularExpressions;
using Matvey.Live;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matvey.Live.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult CreateOrder(OrderRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || !IsValidEmail(request.Email))
            {
                return BadRequest("Некорректный формат Email. Пример правильного email: user@example.com");
            }

            var order = new Order
            {
                Id = new Random().Next(1, 10000), 
                SecondName = "DefaultSecondName", 
                Status = OrderStatus.Open, 
                Name = request.Name,
                Email = request.Email
            };

            return Ok(order.ToString());
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Регулярное выражение для проверки Email
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}