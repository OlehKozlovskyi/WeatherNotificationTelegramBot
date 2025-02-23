using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace WeatherNotificationTelegramBot.Controllers
{
    [ApiController]
    [Route("api/telegram")]
    public class TelegramBotController(IOptions<TelegramBotSettings> options) : ControllerBase
    {
        [HttpGet("set-webhook")]
        public async Task<string> SetWebHook([FromServices] ITelegramBotClient client, CancellationToken cancellationToken)
        {
            var url = options.Value.Url.AbsoluteUri;
            await client.SetWebhook(url, allowedUpdates: [], secretToken: options.Value.SecureToken, cancellationToken: cancellationToken);
            return $"Webhook is connected to {url}";
        }
    }
}
