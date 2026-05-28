using Microsoft.AspNetCore.Mvc;

namespace Aleksandr.Live.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ItemsController : ControllerBase
    {
                
        private List<Item> items = new()

    {
        new Item { Id = 1, Name = "Первый" },
        new Item { Id = 2, Name = "Второй" },
        new Item { Id = 3, Name = "Третий" },
        new Item { Id = 4, Name = "Четвертый" }
    };

        [HttpGet("filteritems")]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var filteredItems = items.Where(x => x.Id == 2 || x.Id == 3).ToList();

            return Ok(filteredItems);
        }
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
}
