namespace WeatherNotificationTelegramBot.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBotSettings(this IServiceCollection services,
            IConfiguration configuration, string sectionName)
        {
            services.Configure<TelegramBotSettings>(configuration.GetSection(sectionName));
            return services;
        }
    }
}
