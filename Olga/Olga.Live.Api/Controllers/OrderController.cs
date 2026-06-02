using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Olga.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost("createOrder")]
        public IActionResult CreateOrder([FromBody] OrderRequest request)
        {
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
