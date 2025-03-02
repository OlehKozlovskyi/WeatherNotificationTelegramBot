using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.Abstractions;

namespace WeatherNotificationTelegramBot.Application.Services
{
    public class WeatherUserService : IWeatherUserService
    {
        private readonly IWeatherUserRepository _weatherUserRepository;

        public WeatherUserService(IWeatherUserRepository weatherUserRepository)
        {
            _weatherUserRepository = weatherUserRepository;
        }

        public async Task AddUser(string id, string firstName, string lastName, string telegramUsername)
        {
            await _weatherUserRepository.AddUser(id, firstName, lastName, telegramUsername);
        }
    }
}
