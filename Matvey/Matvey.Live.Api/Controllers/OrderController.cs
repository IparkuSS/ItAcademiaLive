using Microsoft.AspNetCore.Mvc;
using Matvey.Live;

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
    }
}