using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.DTOs;
using WeatherNotificationTelegramBot.BusinessLogic.Entities;

namespace WeatherNotificationTelegramBot.Application.Services
{
    public class WeatherUserService : IWeatherUserService
    {
        private readonly IWeatherUserRepository _weatherUserRepository;
        private readonly IMapper _mapper;

        public WeatherUserService(IWeatherUserRepository weatherUserRepository, IMapper mapper)
        {
            _weatherUserRepository = weatherUserRepository;
            _mapper = mapper;
        }

        public async Task AddWeatherUserEntryAsync(UserWeatherRecordDto recordDto)
        {
            var user = _mapper.Map<User>(recordDto);
            var weatherRequest = _mapper.Map<WeatherRequest>(recordDto);
            await _weatherUserRepository.AddRecord(user, weatherRequest);
        }

        public async Task<UserResponseHistoryDto> GetUserById(int id)
        {
            var user = await _weatherUserRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserResponseHistoryDto>(user);
        }

        public async Task<List<UsersInformationDto>> GetUsersAsync()
        {
            var users = _mapper.Map<List<UsersInformationDto>>(await _weatherUserRepository.GetUsersAsync());
            return users;
        }
    }
}
