namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IOpenWeatherService
    {
        Task GetWeatherAsync(string location);
    }
}