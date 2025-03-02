using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.DTOs;
using WeatherNotificationTelegramBot.BusinessLogic.Entities;

namespace WeatherNotificationTelegramBot.Application.Mapping
{
    public class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<UserWeatherRecordDto, User>().ReverseMap();
        }
    }
}
