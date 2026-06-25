using Aleksandr.Live.Api.Domains;
using Microsoft.AspNetCore.Mvc;

namespace Aleksandr.Live.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly List<Order> _orders = new List<Order>
    {
        new Order { Id = 1, Name = "Заказ 1", Status = "Create" },
        new Order { Id = 2, Name = "Заказ 2", Status = "Process" },
        new Order { Id = 3, Name = "Заказ 3", Status = "Create" }
    };

        [HttpGet("created-names")]
        public ActionResult<List<string>> GetCreatedOrderNames()
        {
            List<string> createdNames = _orders
.Where(o => o.Status == "Create")
.Select(o => o.Name)
.ToList();

            return Ok(createdNames);
        }
    }
}


