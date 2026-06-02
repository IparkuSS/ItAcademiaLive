using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Olga.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayController : ControllerBase
    {

        [HttpPost("analyze")]
        public ActionResult<string> Analyze(int[] requestIds)
        {
            int min = requestIds[0];

            foreach (int id in requestIds)
            {
                if (id < min)
                {
                    min = id;

                }
            }
            //Console.WriteLine("Min element: " + min);
            return "";
        }
    }
    }

