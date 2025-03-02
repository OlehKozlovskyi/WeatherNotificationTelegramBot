namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IWeatherUserService
    {
        Task AddUser(string id, string firstName, string lastName, string telegramUsername);
    }
}