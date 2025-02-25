using Microsoft.Extensions.Options;
using Telegram.Bot;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.Services;
using WeatherNotificationTelegramBot.Settings;

namespace WeatherNotificationTelegramBot.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramClient(this IServiceCollection services, TelegramBotSettings options)
        {
            services.AddHttpClient("tgwebhook").RemoveAllLoggers().AddTypedClient<ITelegramBotClient>(
                httpClient => new TelegramBotClient(options.SecureToken, httpClient));
            return services;
        }

        public static IServiceCollection AddTelegramClientSettings(this IServiceCollection services, string sectionName, 
            IConfiguration configuration)
        {
            services.Configure<TelegramBotSettings>(configuration.GetSection(sectionName));
            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<UpdateHandleService>();
            services.AddSingleton<IOpenWeatherService, OpenWeatherService>();
            services.AddSingleton<IGeoCoordinatsService, GeoCoordinatsService>();
            return services;
        }
    }
}
