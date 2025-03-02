using WeatherNotificationTelegramBot.Application.DTOs;
using WeatherNotificationTelegramBot.BusinessLogic.Entities;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IWeatherUserService
    {
        Task AddWeatherUserEntryAsync(UserWeatherRecordDto recordDto);
        Task<UserResponseHistoryDto> GetUserById(int id);
        Task<List<UsersInformationDto>> GetUsersAsync();
    }
}