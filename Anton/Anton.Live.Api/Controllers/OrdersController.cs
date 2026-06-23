using Anton.Live.Api.DTOs;
using Anton.Live.Api.Interfaces;
using Anton.Live.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Anton.Live.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto order) => Ok(order);

        [HttpGet]
        public ActionResult<OrderDto> Get() => new OrderDto
        {
            Id = 1,
            Product = "Laptop",
            Qty = 2,
            Price = 999.99m,
            IsPaid = true
        };
    }
}