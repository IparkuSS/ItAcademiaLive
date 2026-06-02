using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Aleksandr.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ItemsController : ControllerBase
    {

        public List<Item> items = new();

             //{
             //new Item { Id = 1, Name = "Первый", Email = "2" },
             //new Item { Id = 2, Name = "Второй", Email = "2" },
             //new Item { Id = 3, Name = "Третий", Email = "2" },
             //new Item { Id = 2, Name = "Четвертый", Email = "2" }
             //};
                    

        [HttpPost("filteritems")]
        public ActionResult AddItem([FromBody] Item item)
        {
                      
            items.Add(item);

            return Ok(item);

        }

        [HttpGet("filteritems")]
        public ActionResult<IEnumerable<Item>> GetItems()
        {

            var filteredItems = items
               .Where(x => x.Id == 2 || x.Id == 3)
               .ToList();

            return Ok(filteredItems);

        }
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
