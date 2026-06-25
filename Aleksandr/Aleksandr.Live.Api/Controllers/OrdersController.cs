using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.DTO;
using Aleksandr.Live.Api.Services;
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
        new Order { Id = 2, Name = "Заказ 2", Status = "Process"},
        new Order { Id = 3, Name = "Заказ 3", Status = "Create" },
        new Order { Id = 4, Name = "Заказ 4", Status = "Process" },
        new Order { Id = 5, Name = "Заказ 5", Status = "Create" },

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

        [HttpPost("sorted-names-by-id")]
        public ActionResult<List<string>> GetSortedNamesById([FromBody] SortRequest request)
        {
            var query = _orders.Where(o => o.Status == "Create");

            if (request?.Direction?.ToLower() == "desc")
            {
                query = query.OrderByDescending(o => o.Id);
            }
            else
            {
                query = query.OrderBy(o => o.Id); //Дефолт (asc)
            }

            List<OrderResponseDto> result = query
             .Select(o => new OrderResponseDto
             {
                 Id = o.Id,
                 Name = o.Name
             })
             .ToList();

            return Ok(result);
        }
    }
}


