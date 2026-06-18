using Anton.Live.Api.Interfaces;
using Anton.Live.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Anton.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repo;

        public OrdersController(IOrderRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var order = _repo.GetById(id);
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> Create(Order order)
        {
            var created = _repo.Add(order);
            return 
        }
    }
}
