using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olga.Live.Api.Servises;
using System.Text.RegularExpressions;


namespace Olga.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrderService _orderService { get; set; }
        public OrdersController()
        {
            _orderService = new OrderService();
        }

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

            _orderService.Add(order);
            return Ok(order.ToString());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _orderService.DeleteById(id);
            if (!result)

            return NotFound("Order not found.");
            return Ok("Deleted successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderRequest request)
        {
            var result = _orderService.UpdateById(id, request);

            if (!result)

            return NotFound("Order not found.");
            return Ok("Updated successfully.");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetAll());
        }
    }
}
