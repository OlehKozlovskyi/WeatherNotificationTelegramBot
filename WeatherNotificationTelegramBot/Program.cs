using WeatherNotificationTelegramBot.Extensions;
using WeatherNotificationTelegramBot.Settings;

namespace WeatherNotificationTelegramBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var _services = builder.Services;
            var _configuration = builder.Configuration;
            var telegramBotSettings = new TelegramBotSettings();
            _configuration.GetSection("TelegramBotSettings").Bind(telegramBotSettings);
            _services.AddTelegramClientSettings("TelegramBotSettings", _configuration);
            _services.AddTelegramClient(telegramBotSettings);
            _services.AddCustomServices();
            _services.ConfigureTelegramBotMvc();
            _services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
