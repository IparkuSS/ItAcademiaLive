using Microsoft.AspNetCore.Mvc;

namespace Aleksandr.Live.Api.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class OrderList : ControllerBase
    {
        [HttpPost("addorder")]
        public ActionResult<string> Addorder(int[] requestIds)
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



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
