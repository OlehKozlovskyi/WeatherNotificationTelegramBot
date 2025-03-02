using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.Services;
using WeatherNotificationTelegramBot.Settings;

namespace WeatherNotificationTelegramBot.Controllers
{
    [ApiController]
    [Route("api/telegram")]
    public class TelegramBotController(IOptions<TelegramBotSettings> options, IOpenWeatherService openWeatherService) : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("set-webhook")]
        public async Task<string> SetWebHook([FromServices] ITelegramBotClient client, CancellationToken cancellationToken)
        {
            var url = options.Value.Url.AbsoluteUri;
            await client.SetWebhook(url, allowedUpdates: [], secretToken: options.Value.SecretKey, cancellationToken: cancellationToken);
            return $"Webhook is connected to {url}";
        }

        [ApiExplorerSettings(IgnoreApi = true)]
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

        [HttpPost("sendWeatherToAll")]
        public async Task<IActionResult> SendWeatherToAll([FromServices] ITelegramBotClient bot, [FromServices] IOpenWeatherService weatherService, 
            [FromServices] IWeatherUserService weatherUserService, [FromQuery] string cityName, CancellationToken ct)
        {
            var users = await weatherUserService.GetUsersAsync();
            foreach (var user in users)
            {
                var weatherInfo = await weatherService.GetWeatherAsync(cityName);
                var messageTemplate = $@"
                    На даний час у {weatherInfo.Name}❤ погодні умови змінюються
                    температура повітря становить близько {weatherInfo.Main.Temp}°C🌡️ i відчувається як {weatherInfo.Main.Feels_Like}°C. 
                    Вітер помірний, з поривами до {weatherInfo.Wind.Speed} км/год🌬️.
                    Атмосферний тиск зараз складає {weatherInfo.Main.Pressure} мм рт. ст.😧
                    ";
                await bot.SendMessage(user.Id, messageTemplate);
            }
            return Ok();
        }

        [HttpPost("sendWeatherToUser/{userId}")]
        public async Task<IActionResult> SendWeatherToUser([FromServices] ITelegramBotClient bot, [FromServices] IOpenWeatherService weatherService,
            [FromServices] IWeatherUserService weatherUserService, [FromQuery] string cityName, [FromRoute] string userId, CancellationToken ct)
        {
            var weatherInfo = await weatherService.GetWeatherAsync(cityName);
            var messageTemplate = $@"
                На даний час у {weatherInfo.Name}❤ погодні умови змінюються
                температура повітря становить близько {weatherInfo.Main.Temp}°C🌡️ i відчувається як {weatherInfo.Main.Feels_Like}°C. 
                Вітер помірний, з поривами до {weatherInfo.Wind.Speed} км/год🌬️.
                Атмосферний тиск зараз складає {weatherInfo.Main.Pressure} мм рт. ст.😧
                ";
            await bot.SendMessage(userId, messageTemplate);
            return Ok();
        }
    }

}
