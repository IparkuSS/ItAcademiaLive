using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Aleksandr.Live.Api.DTO;

namespace Aleksandr.Live.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpGet("test-serialization")]
        public ActionResult<object> TestSerialization()
        {
            
            OrderDto myOrder = new OrderDto
            {
                OrderId = 105,
                CustomerName = "Иван Иванов",
                TotalAmount = 4999.50m,
                OrderDate = DateTime.Now,
                Items = new List<string> { "Клавиатура", "Мышь" }
            };

            string jsonString = JsonSerializer.Serialize(myOrder);
                        
            OrderDto deserializedOrder = JsonSerializer.Deserialize<OrderDto>(jsonString);
                        
            return new
            {
                OriginalJson = jsonString,
                RestoredOrderId = deserializedOrder?.OrderId
            };
        }
    }
}
