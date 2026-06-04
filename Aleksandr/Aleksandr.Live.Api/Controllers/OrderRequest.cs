using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace Aleksandr.Live.Api.Controllers
{
    //public record OrderRequest(int Id, string Name, string Email);

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

            if (OrderService.AddOrder(myOrder))
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
            return Ok(OrderService.GetAll());
        }

        [HttpDelete("process")]
        public ActionResult RemoveOrder([FromBody] int id)
        {
            OrderService.Delete(id);

            return Ok("Remaoved!");
        }

        [HttpPut("process")]
        public ActionResult EditOrder([FromBody] Order request)
        {
            var myOrder = new Order(
                id: request.Id,
                name: request.Name,
                email: request.Email,
                isClosed: false // Статус вручную
            );

            if (OrderService.Update(myOrder))
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
//"id": 4,
//"name": "Иван",                    JSON запрос
//"email": "ivan@example.com"
//}




