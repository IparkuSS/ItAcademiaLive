using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aleksandr.Live.Api.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[ArrayController]")] //same as upper expression
    [ApiController]
    public class ArrayController : ControllerBase
    {
        [HttpPost("analyze")]
        public ActionResult<string> Analyze(int[] requestIds)
        {
            if (requestIds.Length == 0)
            {
                return BadRequest("empty");

            }

            int min = requestIds.Min();

            return Ok($"Min item - {min}");
        }

    }
}
