using Anton.Live.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anton.Live.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgController : ControllerBase
    {
        private readonly DataService _data;

        public MsgController(DataService data) => _data = data;

        [HttpGet]
        public async Task<string> Get()
        {
            var userTask = _data.LoadUserAsync();
            var settingsTask = _data.LoadSettingsAsync();
            await Task.WhenAll(userTask, settingsTask);
            var user = await userTask;
            var settings = await settingsTask;
            return $"{user.Msg}\n {settings.Msg}";
        }
    }
}