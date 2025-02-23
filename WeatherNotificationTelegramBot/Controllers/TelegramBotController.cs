using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace WeatherNotificationTelegramBot.Controllers
{
    [ApiController]
    [Route("api/telegram")]
    public class TelegramBotController(IOptions) : ControllerBase
    {
        [HttpGet("set-webhook")]
        public async Task<string> SetWebHook([FromServices] ITelegramBotClient client, CancellationToken cancellationToken)
        {
            
        }
    }
}
