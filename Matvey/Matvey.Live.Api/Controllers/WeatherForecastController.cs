using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

public class OrderItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class OrderRequest
{
    public OrderItem Item { get; set; } = new();
}

[Route("api/[controller]")]
[ApiController]
public class ProgrammController : ControllerBase
{
    private static readonly ConcurrentBag<OrderItem> _orderList = new();


    [HttpPost("add")]
    public IActionResult Add([FromBody] OrderRequest request)
    {
        if (request?.Item == null)
            return BadRequest(new { error = "ƒанные не предоставлены" });

        if (request.Item.Id <= 0)
            return BadRequest(new { error = "Id должен быть больше 0" });

        if (string.IsNullOrWhiteSpace(request.Item.Name))
            return BadRequest(new { error = "Name не может быть пустым" });

        _orderList.Add(request.Item);
        return Ok(new { message = "ƒобавлено успешно", item = request.Item });
    }

    public IActionResult GetByIds()
    {
        var filteredItems = _orderList.Where(item => item.Id == 2 || item.Id == 3).OrderBy(item => item.Name).ToList();
        return Ok(filteredItems);
    }

}