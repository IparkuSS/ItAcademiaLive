using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aleksandr.Live.Api.Controllers


{
    [Route("api/[controller]")]
    //[Route("api/[ArrayController]")] //same as upper expression
    //http://localhost:5023/api/Array/analyze
    [ApiController]
    public class ArrayController : ControllerBase
    {
        [HttpPost("analyze")]
        public ActionResult<string> Analyze(int[] requestIds)
        {
            try
            {
                if (requestIds.Length == 0)
                {

                    return BadRequest("empty");

                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error - {ex.Message}");
            }

            int min = requestIds.Min();

            return Ok($"Min item - {min}");
        }

    }
}
