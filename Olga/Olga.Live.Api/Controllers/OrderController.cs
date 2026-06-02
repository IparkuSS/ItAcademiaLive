using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;


namespace Olga.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost("createOrder")]
        public IActionResult CreateOrder([FromBody] OrderRequest request)
        {
            string emailRegex = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            if (!Regex.IsMatch(request.Email, emailRegex))
            {
                return BadRequest("Invalid email format.");
            }

            var order = new NewOrder
            {
                OrderId = Random.Shared.Next(1, 10000),
                Name = request.Name,
                Email = request.Email,
                SecondName = "Smith",
                Status = OrderStatus.Closed
            };

            return Ok(order.ToString());
        }
    }
}
