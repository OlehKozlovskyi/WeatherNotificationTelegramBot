
namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IWeatherUserRepository
    {
        Task AddUser(string id, string firstName, string lastName, string telegramUsername);
    }
}