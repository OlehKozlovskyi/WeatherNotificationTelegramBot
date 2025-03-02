using Microsoft.Extensions.Options;
using Telegram.Bot;
using WeatherNotificationTelegramBot.DataAccess;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.Helpers;
using WeatherNotificationTelegramBot.Application.Services;
using WeatherNotificationTelegramBot.Settings;
using WeatherNotificationTelegramBot.DataAccess.Repositories;
using Microsoft.OpenApi.Models;

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
            services.AddSingleton<IWeatherParser, WeatherJsonParser>();
            services.AddSingleton<IWeatherUserRepository, WeatherUserRepository>();
            services.AddSingleton<IWeatherUserService, WeatherUserService>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "WeatherNotificationTelegramBot", 
                    Version = "v1" 
                });
            });
            return services;
        }

    }
}
