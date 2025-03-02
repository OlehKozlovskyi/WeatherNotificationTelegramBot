using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherNotificationTelegramBot.Application.Services;
using WeatherNotificationTelegramBot.Settings;

namespace WeatherNotificationTelegramBot.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route("api/telegram")]
    public class TelegramBotController(IOptions<TelegramBotSettings> options) : ControllerBase
    {
        [HttpGet("set-webhook")]
        public async Task<string> SetWebHook([FromServices] ITelegramBotClient client, CancellationToken cancellationToken)
        {
            var url = options.Value.Url.AbsoluteUri;
            await client.SetWebhook(url, allowedUpdates: [], secretToken: options.Value.SecretKey, cancellationToken: cancellationToken);
            return $"Webhook is connected to {url}";
        }

        [HttpPost("update")]
        public async Task<IActionResult> Post([FromBody] Update update, [FromServices] ITelegramBotClient bot, 
            [FromServices] UpdateHandleService handleUpdateService, CancellationToken ct)
        {
            if (Request.Headers["X-Telegram-Bot-Api-Secret-Token"] != options.Value.SecretKey)
                return Forbid();
            try
            {
                await handleUpdateService.HandleUpdateAsync(bot, update, ct);
            }
            catch (Exception exception)
            {
                await handleUpdateService.HandleErrorAsync(bot, exception, Telegram.Bot.Polling.HandleErrorSource.HandleUpdateError, ct);
            }
            return Ok();
        }
    }

}
