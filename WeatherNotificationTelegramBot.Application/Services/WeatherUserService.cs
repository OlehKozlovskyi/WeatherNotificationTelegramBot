using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.DTOs;

namespace WeatherNotificationTelegramBot.Application.Services
{
    public class WeatherUserService : IWeatherUserService
    {
        private readonly IWeatherUserRepository _weatherUserRepository;

        public WeatherUserService(IWeatherUserRepository weatherUserRepository)
        {
            _weatherUserRepository = weatherUserRepository;
        }

        public async Task AddWeatherUserEntryAsync(UserWeatherRecordDto recordDto)
        {
            await _weatherUserRepository.AddRecord(recordDto);
        }
    }
}
